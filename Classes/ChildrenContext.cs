using PR_8_Konevskii.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class ChildrenContext : Models.Children, IContext
    {
        public ChildrenContext() { }
        public ChildrenContext(int Id, string Name, int Price, int Age, int IdShop) : base(Name, Price, Age, IdShop)
        {
            id = Id;
        }
        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allChildren = new List<object>();

            OleDbConnection connection = Common.DBCConnection.Connection();
            OleDbDataReader childrenData = Common.DBCConnection.Query("SELECT * FROM [Детские вещи]", connection);

            while (childrenData.Read())
            {
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).id == childrenData.GetInt32(2)) as ShopContext;
                if (shopElement == null)
                {
                    continue;
                }
                ChildrenContext newChildren = new ChildrenContext(
                    shopElement.id,
                    shopElement.Name,
                    shopElement.Price,
                    childrenData.GetInt32(1),
                    childrenData.GetInt32(2)
                    );
                allChildren.Add(newChildren);
            }
            Common.DBCConnection.CloseConnection(connection);
            return allChildren;
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
