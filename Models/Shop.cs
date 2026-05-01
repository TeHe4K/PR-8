using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Models
{
    public class Shop
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public Shop() { }
        public Shop(string Name, int Price)
        {
            this.Name = Name;
            this.Price = Price;
        }
    }
}
