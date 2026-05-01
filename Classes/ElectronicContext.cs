using PR_8_Konevskii.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_8_Konevskii.Classes
{
    public class ElectronicContext: Electronics, IContext
    {
        public ElectronicContext() { }
        public ElectronicContext(int Id, string Name, int Price, int BatteryCapacity, int DrivingSpeed) : base(Name, Price, BatteryCapacity, DrivingSpeed, Id) { }
        public List<object> All()
        {
            List<object> allShop = new ShopContext().All();
            List<object> allElectronics = new List<object>();
            OleDbConnection connection = Common.DBCConnection.Connection();
            OleDbDataReader electronicsData = Common.DBCConnection.Select("SELECT * FROM [Электроника]", connection);

            while (electronicsData.Read())
            {
                ShopContext shopElement = allShop.Find(
                    x => (x as ShopContext).id == electronicsData.GetInt32(2)) as ShopContext;
                ElectronicContext newElectronic = new ElectronicContext(
                    shopElement.Id,
                    shopElement.Name,
                    shopElement.Price,
                    electronicsData.GetInt32(1),
                    electronicsData.GetInt32(2)
                    );
                newElectronic.Add(newElectronic);
            }
            Common.DBCConnection.CloseConnection(connection);
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
