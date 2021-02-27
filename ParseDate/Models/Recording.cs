using System.Collections.Generic;
using System.Linq;

namespace ParseDate.Models
{
    public class Recording
    {
        public int Id { get; set; }
        public List<Product> Products { get; set; }

        public int GetProductCount()
        {
            return Products.Count;
        }

        public double GetProductPrice()
        {
            return Products.Select(c => c.Price).Sum();
        }
    }
}