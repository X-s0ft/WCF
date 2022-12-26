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
using WCF.Resourses.Classes;

namespace WCF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConnectHelper.wcfEntity = new DataBase_WCF_Entities();
            Order_table.ItemsSource = ConnectHelper.wcfEntity.Customer.ToList();

            cmbChose.Items.Add("Все заказчики");
            foreach (var item in ConnectHelper.wcfEntity.Customer.Select(x => x.SecondName).Distinct().ToList())
                cmbChose.Items.Add(item);
        }

        private void CmbFiltr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbChose.SelectedValue.ToString()== "Все заказчики")
            {
                Order_table.ItemsSource = ConnectHelper.wcfEntity.Customer.ToList();
            }
            else
            {
                Order_table.ItemsSource = ConnectHelper.wcfEntity.Customer.Where(x => x.SecondName == cmbChose.SelectedValue.ToString()).ToList();
            }
        }
    }
}
