using PR_8_Konevskii.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class ElectronicContext : Models.Electronics, IContext
    {
        public ElectronicContext() { }
        public ElectronicContext(int Id, string Name, int Price, int BatteryCapacity, int DrivingSpeed, int IdShop) : base(Name, Price, BatteryCapacity, DrivingSpeed, IdShop)
        {
            id = Id;
        }
        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allElectronics = new List<object>();
            OleDbConnection connection = Common.DBCConnection.Connection();
            try
            {
                OleDbDataReader electronicsData = Common.DBCConnection.Query("SELECT * FROM [Электроника]", connection);

                while (electronicsData.Read())
                {
                    ShopContext shopElement = allShop.Find(
                        x => (x as ShopContext).id == electronicsData.GetInt32(3)) as ShopContext;
                    if (shopElement == null)
                    {
                        continue;
                    }
                    ElectronicContext newElectronic = new ElectronicContext(
                        shopElement.id,
                        shopElement.Name,
                        shopElement.Price,
                        electronicsData.GetInt32(1),
                        electronicsData.GetInt32(2),
                        electronicsData.GetInt32(3)
                        );
                    allElectronics.Add(newElectronic);
                }
            }
            catch (OleDbException)
            {
                return allElectronics;
            }
            finally
            {
                Common.DBCConnection.CloseConnection(connection);
            }
            return allElectronics;
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
