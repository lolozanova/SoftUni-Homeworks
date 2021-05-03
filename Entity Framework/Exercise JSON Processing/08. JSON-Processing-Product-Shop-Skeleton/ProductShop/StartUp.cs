using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.DataTransferObjects;
using ProductShop.Models;

namespace ProductShop
{

    public class StartUp
    {
        static IMapper mapper; // za da mogat da go polzvat metodite

        public static object JsonDeserialized { get; private set; }

        public static void Main(string[] args)
        {
            var productShopContext = new ProductShopContext();

            productShopContext.Database.EnsureDeleted();

            productShopContext.Database.EnsureCreated();

           // Query 2 Import Users

            string inputJsonUsers = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\09.Json\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\users.json");

            string importUsersResult = ImportUsers(productShopContext, inputJsonUsers);

             Console.WriteLine(importUsersResult);

            //Query 3 Import Products

            string inputJsonProduct = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\09.Json\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\products.json");

            string importProductsResult = ImportProducts(productShopContext, inputJsonProduct);
            Console.WriteLine(importProductsResult);

            //Query 4 Import Categories

            string inputJsonCategory = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\09.Json\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\categories.json");

            string importCategoriesResult = ImportCategories(productShopContext, inputJsonCategory);

            Console.WriteLine(importCategoriesResult);

            //Query 5 Import Categories and Products

            string inputJsonCategoriesProducts = File.ReadAllText(@"C:\Users\Lori\Desktop\Softuni\07.Entity Framework\09.Json\08. JSON-Processing-Product-Shop-Skeleton\ProductShop\Datasets\categories-products.json");

         string importCategoryProductResult = ImportCategoryProducts(productShopContext, inputJsonCategoriesProducts);

            Console.WriteLine(importCategoryProductResult);

            //Export Products in Range
            Console.WriteLine(GetProductsInRange(productShopContext));

            //Export Successfully Sold Products
            Console.WriteLine(GetSoldProducts(productShopContext));

            //Export Categories by Products Count
            Console.WriteLine(GetCategoriesByProductsCount(productShopContext));


            //Export Users and Products
            Console.WriteLine(GetUsersWithProducts(productShopContext));
        }

        private static void InitializeAutoMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductShopProfile>();
            });

            mapper = config.CreateMapper();
        }

        public static string ImportUsers(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoUsers = JsonConvert.DeserializeObject<IEnumerable<UserInputModel>>(inputJson);

            var users = mapper.Map<IEnumerable<User>>(dtoUsers);
            context.Users.AddRange(users);
            context.SaveChanges();
            return $"Successfully imported {users.Count()}";
        }

        public static string ImportProducts(ProductShopContext context, string inputJson)
        {

            InitializeAutoMapper();

            var dtoProducts = JsonConvert.DeserializeObject<IEnumerable<ProductInputModel>>(inputJson);

            var products = mapper.Map<IEnumerable<Product>>(dtoProducts);

            context.Products.AddRange(products);
            context.SaveChanges();
            return $"Successfully imported {products.Count()}";
        }

        public static string ImportCategories(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();
          
            var dtoCategories = JsonConvert.DeserializeObject<IEnumerable<CategoryInputModel>>(inputJson);

            var sortedDtoCategories = dtoCategories.Where(x => x.Name != null);

            var categories = mapper.Map<IEnumerable<Category>>(sortedDtoCategories);

            context.Categories.AddRange(categories);

            context.SaveChanges();

            return $"Successfully imported {categories.Count()}";
        }

        public static string ImportCategoryProducts(ProductShopContext context, string inputJson)
        {
            InitializeAutoMapper();

            var dtoCategoriesProducts = JsonConvert.DeserializeObject<IEnumerable<CategoriesProductsInputModel>>(inputJson);

            var categoriesProducts = mapper.Map<IEnumerable<CategoryProduct>>(dtoCategoriesProducts);

            context.CategoryProducts.AddRange(categoriesProducts);

            context.SaveChanges();

            return $"Successfully imported {categoriesProducts.Count()}";
        }

        public static string GetProductsInRange(ProductShopContext context)
        {

            var products = context.Products
                .Where(p => p.Price >= 500 && p.Price <= 1000)
                .Select(p=> new 
                {
                    name = p.Name,
                    price = p.Price,
                    seller = p.Seller.FirstName + ' ' + p.Seller.LastName
                })
                .OrderBy(p=>p.price).ToList();

          var result =  JsonConvert.SerializeObject(products, Formatting.Indented);

            return result;
        }

        public static string GetSoldProducts(ProductShopContext context)
        {

            var users = context.Users
                .Where(u => u.ProductsSold.Any(p=>p.BuyerId != null))
                .Select(u => new
                {
                    firstName = u.FirstName,
                    lastName = u.LastName,
                    soldProducts = u.ProductsSold
                    .Where(x=>x.BuyerId !=null)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyerFirstName = p.Buyer.FirstName,
                        buyerLastName = p.Buyer.LastName
                    }).ToArray()
                })
                .OrderBy(u => u.lastName)
                .ThenBy(u => u.firstName)
                .ToArray();

            var result =JsonConvert.SerializeObject(users, Formatting.Indented);

            return result;
        }

        public static string GetCategoriesByProductsCount(ProductShopContext context)
        {
           

            var categories = context.Categories
                .Select(c => new
                {
                    category = c.Name,
                    productsCount = c.CategoryProducts.Count,
                    averagePrice = 
                    c.CategoryProducts.Average(x => x.Product.Price).ToString("F2"),
                    totalRevenue = c.CategoryProducts.Sum(x=>x.Product.Price).ToString("F2")
                })
                .OrderByDescending(c=>c.productsCount)
                .ToList();

            var result = JsonConvert.SerializeObject(categories, Formatting.Indented);

            return result;
        }

        public static string GetUsersWithProducts(ProductShopContext context)
        {

            var users = context.Users
                .Include(x=>x.ProductsSold)
                .ToList()
                    .Where(u => u.ProductsSold.Any(p => p.BuyerId != null))
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.ProductsSold.Where(p => p.BuyerId != null).Count(),
                            products = u.ProductsSold.Where(p=>p.BuyerId != null).Select(p => new
                            {
                              name =  p.Name,
                              price = p.Price
                            })
                        }
                    })
                    .OrderByDescending(x => x.soldProducts.products.Count() )
                    .ToList();
            var resultObject = new
            {
                usersCount = users.Count(),
                users = users
            };

            var jsonSerializedSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
               Formatting = Formatting.Indented
            };
            var resultJson = JsonConvert.SerializeObject(resultObject,  jsonSerializedSettings);

          return  resultJson;
            
        }
    }
}