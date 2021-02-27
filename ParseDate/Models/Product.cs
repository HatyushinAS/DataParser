namespace ParseDate.Models
{
    public class Product
    {
        public string Name { get; set; }
        private double _price;

        public double Price
        {
            get { return _price; }
            set
            {
                _price = value;
            }
        }
    }
}