using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductShop.Data;
using ProductShop.DataTransferedObject.Input;
using ProductShop.DataTransferedObject.Output;
using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace ProductShop
{
    public class StartUp
    {
        public static IMapper mapper;

        public static void Main(string[] args)
        {
            var context = CreateDatabase();

            InitializeAutoMapper();

            // Import Entities
            var xmlUsers = File.ReadAllText("./Datasets/users.xml");

            ImportUsers(context, xmlUsers);

            var xmlProducts = File.ReadAllText("./Datasets/products.xml");

            ImportProducts(context, xmlProducts);

            var xmlCategories = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\10XML\09. XML-Processing-Product-Shop-Skeleton\ProductShop\Datasets\categories.xml");

            ImportCategories(context, xmlCategories);

            var xmlCategoriesProducts = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\10XML\09. XML-Processing-Product-Shop-Skeleton\ProductShop\Datasets\categories-products.xml");

            ImportCategoryProducts(context, xmlCategoriesProducts);

            //Queries
            Console.WriteLine(GetProductsInRange(context));
            Console.WriteLine(GetSoldProducts(context));
            Console.WriteLine(GetCategoriesByProductsCount(context));
            Console.WriteLine(GetUsersWithProducts(context));

        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
           cfg.AddProfile<ProductShopProfile>());

            mapper = config.CreateMapper();
        }

        private static ProductShopContext CreateDatabase()
        {
            ProductShopContext context = new ProductShopContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            return context;
        }

        public static string ImportUsers(ProductShopContext context, string inputXml)
        {

            XmlSerializer serializer = new XmlSerializer(typeof(UserInputModel[]), new XmlRootAttribute("Users"));

            var textRead = new StringReader(inputXml);

            var usersDTO = serializer.Deserialize(textRead) as UserInputModel[];

            var users = mapper.Map<User[]>(usersDTO);

            context.Users.AddRange(users);

            context.SaveChanges();

            return $"Successfully imported {users.Length}";

        }

        public static string ImportProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            XmlSerializer serializer = new XmlSerializer(typeof(ProductInputModel[]), new XmlRootAttribute("Products"));

            var textRead = new StringReader(inputXml);

            var productDTO = serializer.Deserialize(textRead) as ProductInputModel[];

            var products = mapper.Map<Product[]>(productDTO);

            context.Products.AddRange(products);

            context.SaveChanges();

            return $"Successfully imported {products.Length}";
        }

        public static string ImportCategories(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(CategoryInputModel[]), new XmlRootAttribute("Categories"));

            var textRead = new StringReader(inputXml);
            var categoryDTO = serializer.Deserialize(textRead) as CategoryInputModel[];

            var categories = mapper.Map<Category[]>(categoryDTO);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Length}";

        }
        public static string GetProductsInRange(ProductShopContext context)
        {
            // Get all products in a specified price range between 500 and 1000(inclusive).
            //Order them by price(from lowest to highest).
            //Select only the product name, price and the full name of the buyer.
            //Take top 10 records.
            var productDTOs = context.Products
                       .Where(p => p.Price >= 500 && p.Price <= 1000)
                       .Select(p => new ProductOutputModel
                       {
                           Name = p.Name,
                           Price = p.Price,
                           BuyersName = p.Buyer.FirstName + ' ' + p.Buyer.LastName
                       })
                       .OrderBy(p => p.Price)
                       .Take(10)
                       .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(ProductOutputModel[]), new XmlRootAttribute("Products"));

            var textWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);
            serializer.Serialize(textWriter, productDTOs, ns);

            return textWriter.ToString();
        }

        public static string GetSoldProducts(ProductShopContext context)
        {
            //Get all users who have at least 1 sold item.
            //Select the person's first and last name. For each of the sold products, select the product's name and price. Take top 5 records. 
            //Order them by last name, then by first name.

            var usersDTO = context.Users
                .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                .Select(u => new UserOutputModel
                {
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Products = u.ProductsSold.Where(x => x.BuyerId != null)
                    .Select(p => new ProductOutputModel
                    {
                        Name = p.Name,
                        Price = p.Price
                    })
                    .Take(5)
                    .ToArray()
                })
                .OrderBy(u => u.LastName)
                .ThenBy(u => u.FirstName)
               .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(UserOutputModel[]), new XmlRootAttribute("Users"));

            var textWriter = new StringWriter();
            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);

            serializer.Serialize(textWriter, usersDTO, ns);


            return textWriter.ToString();

        }
        public static string ImportCategoryProducts(ProductShopContext context, string inputXml)
        {
            InitializeAutoMapper();

            var serializer = new XmlSerializer(typeof(CategoryProductInputModel[]), new XmlRootAttribute("CategoryProducts"));

            var textRead = new StringReader(inputXml);

            var categoryProductDTO = serializer.Deserialize(textRead) as CategoryProductInputModel[];

            var validCategoriesIds = context.Categories.Select(c => c.Id).ToArray();
            var validProductIds = context.Products.Select(c => c.Id).ToArray();

            var categoriesProducts = mapper.Map<CategoryProduct[]>(categoryProductDTO).Where(x => validCategoriesIds.Contains(x.CategoryId) && validProductIds.Contains(x.ProductId)).ToArray();

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Length}";
        }


        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
            // Get all categories.For each category select its name, the number of products, the average price of those products and the total revenue(total price sum) of those products(regardless if they have a buyer or not).
            //Order them by the number of products(descending) then by total revenue.
            var categoriesDTO = context.Categories
                      .Select(c => new CategoryOutputModel
                      {
                          Name = c.Name,
                          Count = c.CategoryProducts.Count,
                          AveragePrice = c.CategoryProducts.Average(p => p.Product.Price).ToString("f2"),
                          TotalRevenue = c.CategoryProducts.Sum(p => p.Product.Price).ToString("f2")
                      })
                      .OrderByDescending(c => c.Count)
                      .ThenBy(c => c.TotalRevenue)
                      .ToArray();

            XmlSerializer serializer = new XmlSerializer(typeof(CategoryOutputModel[]), new XmlRootAttribute("Categories"));

            StringBuilder sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);

            serializer.Serialize(new StringWriter(sb), categoriesDTO, ns);


            return sb.ToString().Trim();
        }
        public static string GetUsersWithProducts(ProductShopContext context)
        {
            // Select users who have at least 1 sold product.
            //Select only their first and last name, age, count of sold products and for each product - name and price sorted by price(descending). Take top 10 records.
            //Order them by the number of sold products (from highest to lowest). 

            var usersDTO = context.Users
                  .Where(u => u.ProductsSold.Any(p => p.Buyer != null))
                  .Select(u => new UserWithSoldProductsOutputModel
                  {
                      FirstName = u.FirstName,
                      LastName = u.LastName,
                      Age = u.Age,
                      SoldProducts = new SoldPoductOutputModel
                      {
                          Count = u.ProductsSold.Count(),
                          Products = u.ProductsSold.Where(p => p.BuyerId != null).Select(p => new ProductOutputModel
                          {
                              Name = p.Name,
                              Price = p.Price
                          })
                      .OrderByDescending(p => p.Price)
                      .ToArray()
                      }
                  })
                   .OrderByDescending(x => x.SoldProducts.Count)
                   .Take(10)
                    .ToArray();



            XmlSerializer serializer = new XmlSerializer(typeof(UserWithSoldProductsOutputModel[]), new XmlRootAttribute("Users"));

            StringBuilder sb = new StringBuilder();

            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);

            serializer.Serialize(new StringWriter(sb), usersDTO, ns);


            return sb.ToString().Trim();
        }
    }
}