using System;
using System.Collections.Generic;
using System.Drawing;
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

namespace PR_21._106_Molotkov_3
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

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!(int.TryParse(TbN.Text, out int nResult)))
                {
                    throw new Exception("Неккоректный ввод N");
                }

                if (!(int.TryParse(TbStart.Text, out int sResult)))
                {
                    throw new Exception("Неккоректный ввод начального значения диапазона");
                }
                if (!(int.TryParse(TbEnd.Text, out int eResult)))
                {
                    throw new Exception("Неккоректный ввод конечного значения диапазона");
                }

                if (sResult > eResult)
                {
                    throw new Exception("Начальное значение диапазона не может быть больше конечного");
                }
                Random random = new Random();
                int[] array = new int[nResult];
                for (int i = 0; i < nResult; i++)
                {
                    array[i] = random.Next(sResult, eResult);
                }

                List<int> even = new List<int>();
                List<int> uneven = new List<int>();
                for (int i = 0; i < nResult; i++)
                {
                    if (array[i] % 2 == 0) even.Add(array[i]);
                    if (array[i] % 2 == 1) uneven.Add(array[i]);
                }
                TbResult.Text = String.Empty;
                foreach (var item in even)
                {
                    TbResult.Text += $"{item} ";
                }
                foreach (var item in uneven)
                {
                    TbResult.Text += $"{item} ";
                }

            }
            catch (Exception exception)
            {
                TbResult.Text = exception.Message;
            }
        }
    }
}
