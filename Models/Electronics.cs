using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Models
{
    public class Electronics :Shop
    {
        public int BatteryCapacity { get; set; }
        public int DrivingSpeed { get; set; }
        public int IdShop { get; set; }
        public Electronics() { }
        public Electronics(string Name, int Price, int BatteryCapacity, int DrivingSpeed, int IdShop) : base(Name, Price)
        {
            this.BatteryCapacity = BatteryCapacity;
            this.DrivingSpeed = DrivingSpeed;
            this.IdShop = IdShop;
        }
    }
}
