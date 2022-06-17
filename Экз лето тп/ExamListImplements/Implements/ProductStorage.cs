using ExamContracts.BindingModels;
using ExamContracts.StoragesContracts;
using ExamContracts.ViewModels;
using ExamListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamListImplements.Implements
{
    public class ProductStorage: IProductStorage
    {
        private readonly DataListSingleton source;
        public ProductStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ProductViewModel> GetFullList()
        {
            var result = new List<ProductViewModel>();
            foreach (var component in source.Products)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<ProductViewModel>();
            foreach (var product in source.Products)
            {
                if (product.ProductName.Contains(model.product))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id || product.ProductName ==
                model.product)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(ProductBindingModel model)
        {
            var tempProduct = new Product
            {
                Id = 1,
                ProductComponents = new Dictionary<int, int>()
            };
            foreach (var product in source.Products)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.Products.Add(CreateModel(model, tempProduct));
        }
        public void Update(ProductBindingModel model)
        {
            Product tempProduct = null;
            foreach (var product in source.Products)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(ProductBindingModel model)
        {
            for (int i = 0; i < source.Products.Count; ++i)
            {
                if (source.Products[i].Id == model.Id)
                {
                    source.Products.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static Product CreateModel(ProductBindingModel model, Product
        product)
        {
            product.ProductName = model.product;
            product.Type = model.Type;

            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.ProductComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }

            foreach (var component in model.ProductComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] =
                    model.ProductComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.ProductComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private ProductViewModel CreateModel(Product product)
        {

            var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.ProductComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Type = product.Type,
                ProductComponents = productComponents
            };
        }
    }
}
