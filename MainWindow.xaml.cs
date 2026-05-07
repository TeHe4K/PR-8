using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PR_8_Konevskii
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Object> AllItem = new List<object>();
        public MainWindow()
        {
            InitializeComponent();
            LoadItems();
            CreateUI();
        }
        public void LoadItems()
        {
            AllItem.AddRange(new Classes.ChildrenContext().All());
            AllItem.AddRange(new Classes.SportContext().All());
            AllItem.AddRange(new Classes.ElectronicContext().All());
        }
        public void CreateUI()
        {
            foreach (object item in AllItem)
            {
                parent.Children.Add(new Elements.Item(item));
            }
        }
    }
}
