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
using System.Globalization;

namespace WpfApp4
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                Abiturient[] A = new Abiturient[3];
            
                for (int i = 0; i < A.Length; i++)
                {
                    A[i] = new Abiturient();
                    A[i].InputInfo(i + 1);
                    Console.WriteLine();
                }
                // 1. Список абитуриентов, имеющих неудовлетворительные оценки;
                Console.WriteLine("Неудовлетворительные оценки у: ");

                int BadPoint = 2;

                var BadPoints = A.Where(x => x.ratings.Split().Select(n => int.Parse(n, CultureInfo.InvariantCulture)).Contains(BadPoint)).Select(s => s);

                foreach (var Bad in BadPoints)
                {
                    Console.WriteLine(Bad.ToString());
                }
                Console.WriteLine();

                // 2. Список абитуриентов, у которых сумма баллов выше заданной;
                Console.Write("Введите общий балл: ");
                int S = Convert.ToInt16(Console.ReadLine());

                Console.Write($"Сумма всех баллов выше, чем {S} у: ");

                var PointsScoreMore = A.Where(x => x.ratings.Split().Select(n => int.Parse(n, CultureInfo.InvariantCulture)).Aggregate((a, b) => a + b) > S).Select(s => s);

                foreach (var Row in PointsScoreMore)
                {
                    Console.WriteLine(Row.ToString());
                }
                Console.WriteLine();

                // 3) Заданное число n абитуриентов, имеющих самую высокую сумму баллов; 
                Console.Write($"Самая большая сумма баллов: ");

                int PointsScoreMax = A.Max(x => x.ratings.Split().Select(n => int.Parse(n, CultureInfo.InvariantCulture)).Aggregate((a, b) => a + b));

                Console.Write(PointsScoreMax);

                var ScoreMaxAbiturient = A.Where(x => x.ratings.Split().Select(n => int.Parse(n, CultureInfo.InvariantCulture)).Aggregate((a, b) => a + b) == PointsScoreMax).Select(s => s);

                Console.Write($" у: ");

                foreach (var Row in ScoreMaxAbiturient)
                {
                    Console.WriteLine(Row.ToString());
                }

                Console.WriteLine();
            }

        }
        class Abiturient
        {
            public int id { get; set; }
            public string name { get; set; }
            public string family { get; set; }
            public string patroname { get; set; }
            public string address { get; set; }
            public string phone { get; set; }
            public string ratings { get; set; }

            public override string ToString()
            {
                return $"Имя: {name}, Фамилия: {family}, Отчество: {patroname}, Адрес: {address}, Телефон: {phone}, Оценки: {ratings} \t";
            }

            public void InputInfo(int id)
            {
                this.id = id;
                Console.WriteLine("Заполните данные - ");
                Console.Write("Имя: "); name = Console.ReadLine();
                Console.Write("Фамилия: "); family = Console.ReadLine();
                Console.Write("Отчество: "); patroname = Console.ReadLine();
                Console.Write("Адрес: "); address = Console.ReadLine();
                Console.Write("Телефон: "); phone = Console.ReadLine();
                Console.Write("Оценки: "); ratings = Console.ReadLine();
            }
        }
    }
    

