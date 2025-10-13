using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class RepoItems
    {
        public static List<object> AllItems()
        {
            List<object> allItems = new List<object>();
            allItems.Add(new Children("Игрушка интерактивная", 2200, 3));
            allItems.Add(new Children("Кактус танцующий", 894, 6));
            allItems.Add(new Children("Мягкая игрушка кошка подушка", 1724, 6));
            allItems.Add(new Sport("Спортивный костюм", 4913, "S"));
            allItems.Add(new Sport("Мяч для водного поло", 812, "61-63 СМ"));
            allItems.Add(new Sport("набор для гольфа Partida", 3950, "600*800 ММ"));
            return allItems;
        }
    }
}
