using ExamFileImplement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ExamFileImplement
{
    public class FileDataListSingleton
    {
		private static FileDataListSingleton instance;

		private readonly string ComponentFileName = "Component.xml";

		private readonly string ProductFileName = "Product.xml";
		public List<Component> Components { get; set; }
		public List<Product> Products { get; set; }
		private FileDataListSingleton()
		{
			Components = LoadComponents();
			Products = LoadProducts();
		}
		public static FileDataListSingleton GetInstance()
		{
			if (instance == null)
			{
				instance = new FileDataListSingleton();
			}
			return instance;
		}
		public static void FileDataListSingletonSave()
		{
			instance.SaveComponents();
			instance.SaveCanneds();

		}
		private List<Component> LoadComponents()
		{
			var list = new List<Component>();
			if (File.Exists(ComponentFileName))
			{
				var xDocument = XDocument.Load(ComponentFileName);
				var xElements = xDocument.Root.Elements("Component").ToList();
				foreach (var elem in xElements)
				{
					list.Add(new Component
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ComponentName = elem.Element("ComponentName").Value,
						Price = Convert.ToInt32(elem.Element("Price").Value),
						Type = elem.Element("Type").Value,
						TimeComp = Convert.ToDateTime(elem.Element("TimeComp").Value)
					});
				}
			}
			return list;
		}
		private List<Product> LoadProducts()
		{
			var list = new List<Product>();
			if (File.Exists(ProductFileName))
			{
				var xDocument = XDocument.Load(ProductFileName);
				var xElements = xDocument.Root.Elements("Product").ToList();
				foreach (var elem in xElements)
				{
					var cannComp = new Dictionary<int, int>();
					foreach (var component in elem.Element("ProductComponents").Elements("ProductComponent").ToList())
					{
						cannComp.Add(Convert.ToInt32(component.Element("Key").Value),
					   Convert.ToInt32(component.Element("Value").Value));
					}
					list.Add(new Product
					{
						Id = Convert.ToInt32(elem.Attribute("Id").Value),
						ProductName = elem.Element("ProductName").Value,
						Type =elem.Element("Type").Value,
						ProductComponents = cannComp
					});
				}
			}
			return list;
		}
		private void SaveComponents()
		{
			if (Components != null)
			{
				var xElement = new XElement("Components");
				foreach (var component in Components)
				{
					xElement.Add(new XElement("Component", new XAttribute("Id", component.Id),
					new XElement("ComponentName", component.ComponentName)));
				}
				var xDocument = new XDocument(xElement);
				xDocument.Save(ComponentFileName);
			}
		}
		private void SaveCanneds()
		{
			if (Products != null)
			{
				var xElement = new XElement("Products");
				foreach (var prod in Products)
				{
					var compElement = new XElement("ProductComponents");
					foreach (var component in prod.ProductComponents)
					{
						compElement.Add(new XElement("ProductComponent", new XElement("Key", component.Key),
						new XElement("Value", component.Value)));
					}
					xElement.Add(new XElement("Canned",
					 new XAttribute("Id", prod.Id),
					 new XElement("CannedName", prod.ProductName),
					 new XElement("Type", prod.Type),
					 compElement));
				}
				var xDocument = new XDocument(xElement);
				xDocument.Save(ProductFileName);
			}
		}
	}
}
