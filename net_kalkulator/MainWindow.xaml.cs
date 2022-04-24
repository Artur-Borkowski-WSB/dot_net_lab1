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

namespace net_kalkulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        string num1 = "";
        string num2 = "";
        string op = "";


        private void numClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                string val = button.Content.ToString();
                if (op == "")
                {
                    num1 += val;
                }
                else
                {
                    if (op == "/")
                    {
                        btn0.IsEnabled = true;
                    }
                    btnEq.IsEnabled = true;
                    num2 += val;
                }
                screen.Text += val;
            }
        }

        private void opClick(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (button != null)
            {
                string val = button.Content.ToString();
                op = val;
                btnPlus.IsEnabled = false;
                btnMinus.IsEnabled = false;
                btnDiv.IsEnabled = false;
                btnMul.IsEnabled = false;
                screen.Text = "";
                if (op == "/")
                {
                    btn0.IsEnabled = false;
                }
            }
        }

        private void resultClick(object sender, RoutedEventArgs e)
        {
            double num1x = 0, num2x = 0, res = 0;
            double.TryParse(num1, out num1x);
            double.TryParse(num2, out num2x);

            if (op == "+")
            {
                res = num1x + num2x;
            }
            else if (op == "-")
            {
                res = num1x - num2x;
            }
            else if (op == "*")
            {
                res = num1x * num2x;
            }
            else if (op == "/" && num2x != 0)
            {
                res = num1x / num2x;
            }
            res = Math.Round(res, 2);
            clearInput();
            screen.Text = res.ToString();
            num1 = res.ToString();
        }

        private void clearClick(object sender, RoutedEventArgs e)
        {
            clearInput();
        }

        private void clearInput()
        {
            num1 = "";
            num2 = "";
            op = "";
            screen.Text = "";
            btnPlus.IsEnabled = true;
            btnMinus.IsEnabled = true;
            btnDiv.IsEnabled = true;
            btnMul.IsEnabled = true;
            btnEq.IsEnabled = false;
            btn0.IsEnabled = true;
        }
    }
}
