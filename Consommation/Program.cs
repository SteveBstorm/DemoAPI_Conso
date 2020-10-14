using Consommation.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Consommation
{
    class Program
    {
        public static IEnumerable<Product> GetAll()
        {
            HttpClient _client = new HttpClient();

            using (HttpResponseMessage message = _client.GetAsync("http://localhost:63907/api/product").Result)
            {
                if(message.StatusCode == HttpStatusCode.OK)
                {
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                }
                else
                {
                    Console.WriteLine("Erreur de get");
                    return null;
                }
            }
        }

        public static Product GetOne(int Id)
        {
            HttpClient _client = new HttpClient();

            using (HttpResponseMessage message = _client.GetAsync("http://localhost:63907/api/product"+"/"+Id).Result)
            {
                if (message.StatusCode == HttpStatusCode.OK)
                {
                    string json = message.Content.ReadAsStringAsync().Result;
                    return JsonConvert.DeserializeObject<Product>(json);
                }
                else
                {
                    Console.WriteLine("Erreur de get");
                    return null;
                }
            }
        }

        public static void Post(Product body)
        {
            HttpClient _client = new HttpClient();

            string jsonBody = JsonConvert.SerializeObject(body);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage response = _client.PostAsync("http://localhost:63907/api/product", content).Result;

            if (response.IsSuccessStatusCode) { Console.WriteLine("enregistrement OK"); }
        }

        public static void Delete(int Id)
        {
            HttpClient _client = new HttpClient();
            _client.BaseAddress = new Uri("http://localhost:63907/api/product/");
            HttpResponseMessage response = _client.DeleteAsync(Id.ToString()).Result;

            response.EnsureSuccessStatusCode();
        }

        public static void Update(Product product)
        {
            HttpClient _client = new HttpClient();

            string jsonBody = JsonConvert.SerializeObject(product);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage message = _client.PutAsync("http://localhost:63907/api/product", content).Result;

            if (message.IsSuccessStatusCode) Console.WriteLine("Modification OK");
        }


        
        

        static void Main(string[] args)
        {
            #region Post
            //Product product = new Product
            //{
            //    Name = "produit 42",
            //    Price = 18.15M,
            //    BrandId = 1,
            //    CodeEAN13 = "1236547896541"
            //};

            //Post(product); 
            #endregion
            #region GetOne

            Product getOne = GetOne(1);
            Console.WriteLine("{0} - {1}", getOne.Name, getOne.Price);

            #endregion

            #region Delete 
            //Delete(5);
            #endregion

            #region Update
            Product product = new Product
            {
                Id = 3,
                Name = "produit 42",
                Price = 18.15M,
                BrandId = 1,
                CodeEAN13 = "1236547896541"
            };

            Update(product);
            #endregion

            #region GetAll

            //foreach (Product p in GetAll())
            //{
            //    Console.WriteLine("{0} - {1}", p.Name, p.Price);
            //}

            #endregion
            Console.WriteLine("Hello World!");
        }
    }
}
