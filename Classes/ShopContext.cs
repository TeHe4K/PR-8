using PR_8_Konevskii.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class ShopContext: Shop, IContext
    {
        public ShopContext() { }
        public ShopContext(int Id, string Name, int Price): base(Id,Name,Price { }
        public List<object> All() 
        {
            List<Object> allShop = new List<object>();

            OleDbConnection connection = Common.DBCConnection.Connection();
            OleDbDataReader shopData = Common.DBCConnection.Query("SELECT * FROM [Товар]", connection);
            while (shopData.Read())
            {
                ShopContext newShop = new ShopContext();
                shopData.GetInt32(0);
                shopData.GetString(1);
                shopData.GetInt32(2);
            };
            Common.DBCConnection.CloseConnection(connection);
            return allShop;
        }
        public void Delete()
        {
            throw new NotImplementedException();
        }
        public void Save(bool Update = false)
        {
            throw new NotImplementedException();
        }
    }
}
