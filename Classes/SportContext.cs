using PR_8_Konevskii.Interfaces;
using PR_8_Konevskii.Models;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class SportContext: Models.Sport, IContext
    {
        public SportContext() { }
        public SportContext(int Id, string Name, int Price, string Size, int IdShop) : base(Name, Price, Size, IdShop)
        {
            id = Id;
        }
        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allSports = new List<object>();
            OleDbConnection connection = Common.DBCConnection.Connection();
            OleDbDataReader sportsData = Common.DBCConnection.Query("SELECT * FROM [Спорт]", connection);

            while (sportsData.Read())
            {
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).id == sportsData.GetInt32(2)) as ShopContext;
                if (shopElement == null)
                {
                    continue;
                }
                SportContext newSport = new SportContext(
                    shopElement.id,
                    shopElement.Name,
                    shopElement.Price,
                    sportsData.GetValue(1).ToString(),
                    sportsData.GetInt32(2)
                    );
                allSports.Add(newSport);
            }
            Common.DBCConnection.CloseConnection(connection);
            return allSports;
        }
        public void Save(bool Update = false)
        {
            throw new NotImplementedException();
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
    }
}
