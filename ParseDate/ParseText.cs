using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using ParseDate.Models;

namespace ParseDate
{
    public class ParseText
    {
        public static IEnumerable<Recording> ParseInputText(string inputText)
        {
            if (inputText == null)
                throw new ArgumentNullException(nameof(inputText));
            var recordings = new List<Recording>();
            var splitText = inputText.Split(new[] {"Id="}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in splitText)
            {
                var productItems = item.Split(new[] {"\t"}, StringSplitOptions.RemoveEmptyEntries);
                var id = 0;
                id = int.Parse(productItems[0]);
                var products = ParseProduct(productItems);
                recordings.Add(new Recording(){Id = id, Products = products.ToList()});
            }

            return recordings;
        }

        private static IEnumerable<Product> ParseProduct(IEnumerable<string> item)
        {
            var products = new List<Product>();
            foreach (var i in item.Skip(1))
            {
                var product = i.Replace("[product=", "")
                    .Replace("]", "")
                    .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries);
                var productName = product[0];
                var price = new double();
                ;
                try
                {
                    price = double.Parse(product[1]
                        .Replace(" price=", ""));
                }
                catch(Exception){ }

                products.Add(new Product() {Name = productName, Price = price});
            }
            return products;
        }
    }
}