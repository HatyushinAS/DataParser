using System;
using System.Collections.Generic;
using System.Linq;

namespace ParseDate.Models
{
    public class OneFile
    {
        public DateTime Date { get; set; }
        public List<Recording> Recordings { get; set; }

        public int GetProductsCount()
        {
            return Recordings.Select(c => c.GetProductCount()).Sum();
        }

        public double GetProdictsPrice()
        {
            return Recordings.Select(c => c.GetProductPrice()).Sum();
        }
    }
}