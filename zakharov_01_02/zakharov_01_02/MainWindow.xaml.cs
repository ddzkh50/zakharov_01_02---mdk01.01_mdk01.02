using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace zakharov_01_02
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на пустые строки
            if (string.IsNullOrWhiteSpace(TB_name.Text) || 
                string.IsNullOrWhiteSpace(TB_clock1.Text) ||
                string.IsNullOrWhiteSpace(TB_ram.Text))
            {
                MessageBox.Show("Пустые строки недопустимы");
                return;
            }

            try
            {
                //Парсинг данных в переменные
                string name = TB_name.Text;
                double clock = double.Parse(TB_clock1.Text);
                double ram = double.Parse(TB_ram.Text);

                //Создание экземпляра класса и вывод информации о нем
                Computer c = new Computer(name, clock, ram);
                output_c1.Text = c.GetInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            //Работа метода анологична Button1_Click за исключением
            //работы с классом наследником (добавление еще 1 переменной)


            if (string.IsNullOrWhiteSpace(TB_name2.Text) ||
                string.IsNullOrWhiteSpace(TB_clock2.Text) ||
                string.IsNullOrWhiteSpace(TB_ram2.Text) ||
                string.IsNullOrWhiteSpace(TB_p.Text))
            {
                MessageBox.Show("Пустые строки недопустимы");
                return;
            }

            try
            {
                string name = TB_name2.Text;
                double clock = double.Parse(TB_clock2.Text);
                double ram = double.Parse(TB_ram2.Text);
                double p = double.Parse(TB_p.Text);

                ComputerP c = new ComputerP(p ,name, clock, ram);
                output_c2.Text = c.GetInfo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex}");
            }
        }
    }
}