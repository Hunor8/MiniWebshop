using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniWeb
{
    internal class Termekek
    {
        public Termekek(int id, string name, double price, string category, int inStock)
        {
            this.id = id;
            this.name = name;
            this.price = price;
            this.category = category;
            this.inStock = inStock;
        }

        public int id { get; set; }
        public string name { get; set; }
        public double price { get; set; }
        public string category { get; set; }
        public int inStock { get; set; }
    }
}
