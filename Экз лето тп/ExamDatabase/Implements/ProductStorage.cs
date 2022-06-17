using ExamContracts.BindingModels;
using ExamContracts.StoragesContracts;
using ExamContracts.ViewModels;
using ExamDatabase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamDatabase.Implements
{
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using var context = new ExDatabase();
            return context.Products
            .Include(rec => rec.ProductComponents)
            .ThenInclude(rec => rec.Component)
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public List<ProductViewModel> GetFilteredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ExDatabase();
            return context.Products
            .Include(rec => rec.ProductComponents)
            .ThenInclude(rec => rec.Component)
            .Where(rec => rec.ProductName.Contains(model.product))
            .ToList()
            .Select(CreateModel)
            .ToList();
        }
        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using var context = new ExDatabase();
            var product = context.Products
            .Include(rec => rec.ProductComponents)
            .ThenInclude(rec => rec.Component)
            .FirstOrDefault(rec => rec.ProductName == model.product ||
            rec.Id == model.Id);
            return product != null ? CreateModel(product) : null;
        }
        public void Insert(ProductBindingModel model)
        {
            using var context = new ExDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                Product product = new Product()
                {
                    ProductName = model.product,
                    Type = model.Type
                };
                context.Products.Add(product);
                context.SaveChanges();
                CreateModel(model, product, context);
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Update(ProductBindingModel model)
        {
            using var context = new ExDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                var element = context.Products.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element, context);
                context.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
        public void Delete(ProductBindingModel model)
        {
            using var context = new ExDatabase();
            Product element = context.Products.FirstOrDefault(rec => rec.Id ==
            model.Id);
            if (element != null)
            {
                context.Products.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static Product CreateModel(ProductBindingModel model, Product product,
      ExDatabase context)
        {
            product.ProductName = model.product;
            product.Type = model.Type;
            if (product.Id == 0)
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
            if (model.Id.HasValue)
            {
                var productComponents = context.ProductComponents.Where(rec =>
               rec.ProductId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.ProductComponents.RemoveRange(productComponents.Where(rec =>
               !model.ProductComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in productComponents)
                {
                    updateComponent.Count =
                   model.ProductComponents[updateComponent.ComponentId].Item2;
                    model.ProductComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.ProductComponents)
            {
                context.ProductComponents.Add(new ProductComponent
                {
                    ProductId = product.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return product;
        }
        private static ProductViewModel CreateModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                ProductName = product.ProductName,
                Type = product.Type,
                ProductComponents = product.ProductComponents
            .ToDictionary(recPC => recPC.ComponentId,
            recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}
