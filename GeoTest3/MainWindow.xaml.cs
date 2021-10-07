using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace GeoTest3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Dictionary<string, string> seller = new Dictionary<string, string>()
        {
             {"Чупашева А.И", "01.10.2015"},
             {"Иванов А.В", "10.01.2017"},
             {"Кривцов О.П", "05.02.2019"},
             {"Янаева Э.С", "15.12.2014"},
        };
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (CheckAll())
            {
                int dayMoney = Convert.ToInt32(Money.Text);
                double commision = default;
                var dateHire = Convert.ToDateTime(DateHire.Text).Year;
                if (dayMoney < 50000)
                {
                    commision=Math.Round(dayMoney*0.03,3);
                    
                }
                if (dayMoney > 50000)
                {
                    commision = Math.Round(dayMoney * 0.06, 3);

                }
                if (DateTime.Now.Year-dateHire>3)
                {
                    commision += Math.Round(dayMoney * 0.05, 3);

                }
                UserName.Text = Saller.Text;
                Result.Text = commision.ToString();
            }
            else
            {
                return;
            }

        }

        private void Money_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private bool CheckAll()
        {
            if (Money.Text == "")
            {
                MessageBox.Show("Неведенна средняя выручка");
                return false;
            }
            if (DateHire.Text == "")
            {
                MessageBox.Show("Неведенна дата ");
                return false;

            }
            if (Saller.Text == "")
            {
                MessageBox.Show("Неведенн продавец ");
                return false;
            }
            if (CheckSaller())
            {
                return true;
            }
            else
            {
                MessageBox.Show("Неправильно введенные данные о продовце");
                return false;
            }
        }

        private bool CheckSaller()
        {
            if (seller.ContainsKey(Saller.Text))
            {
                if (seller[Saller.Text]==DateHire.Text)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
