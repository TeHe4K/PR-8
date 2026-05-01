using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Models
{
    public class Sport:Shop
    {
        public string Size {  get; set; }
        public int Id { get; set; }
        public Sport() { }
        public Sport(string Name, int Price, string Size, int Id) : base(Name,Price) 
        {
            this.Size = Size;
            this.Id = Id;
        }
    }
}
