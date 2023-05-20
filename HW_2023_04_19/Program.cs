using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace HW_2023_04_19
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FruitsAndVegetables;Integrated Security=True;Connect Timeout=30;");
            MyClassMemu myClassMemu = new MyClassMemu();
            Display display = new Display();
            Console.WriteLine("Нажмите \"Y\" если хотите подключиться или отключиться от БД" );
            string result = Console.ReadLine();
            switch (result.ToUpper())
            {
                case "Y":
                    myClassMemu.MyMenu(conn);                    
                    Console.WriteLine("Нажмите 1. для отображения всей информации из таблицы");
                    Console.WriteLine("Нажмите 2. для отображения всех названий овощей и фруктов");
                    Console.WriteLine("Нажмите 3. для отображения всех цветов");
                    Console.WriteLine("Нажмите 4. для показа максимальной калорийности");
                    Console.WriteLine("Нажмите 5. для показа минимальной калорийности");
                    Console.WriteLine("Нажмите 6. для показа средней калорийности");
                    Console.WriteLine();
                    //Задание 4
                    Console.WriteLine("Нажмите 7. Показать количество овощей");
                    Console.WriteLine("Нажмите 8. Показать количество фруктов");
                    Console.WriteLine("Нажмите 9. Показать количество овощей и фруктов заданного цвета");
                    Console.WriteLine("Нажмите 10. Показать количество овощей фруктов каждого цвета");
                    Console.WriteLine("Нажмите 11. Показать овощи и фрукты с калорийностью ниже указанной");
                    Console.WriteLine("Нажмите 12. Показать овощи и фрукты с калорийностью выше указанной");
                    Console.WriteLine("Нажмите 13. Показать овощи и фрукты с калорийностью в указанном диапазоне");
                    Console.WriteLine("Нажмите 14. Показать все овощи и фрукты, у которых цвет желтый или красный");
                            
                    string fruitAndVegetablesAll = Console.ReadLine();
                    switch (fruitAndVegetablesAll)
                    {
                        case "1":
                            display.DisplayAll(conn);
                            break;
                        case "2":
                            display.DisplayName(conn);
                            break;
                        case "3":
                            display.DisplayColor(conn);
                            break;
                        case "4":
                            display.DisplayMaxColories(conn);
                            break;
                        case "5":
                            display.DisplayMinColories(conn);
                            break;
                        case "6":
                            display.DisplayAverageColories(conn);
                            break;
                        case "7":
                            display.DisplayCountVegetables(conn);
                            break;
                        case "8":
                            display.DisplayCountFruits(conn);
                            break;
                        case "9":
                            Console.WriteLine("Выберите цвет для фильтрации: ");
                            var color = Console.ReadLine();
                            display.DisplayCountFruitsAndVegetableColor(conn, color);
                            break;
                        case "10":
                            display.DisplayСolorАiltering(conn);
                            break;
                        case "11":
                            Console.WriteLine("Выберите калории для фильтрации: ");
                            var caloriesMin = Console.ReadLine();
                            display.DisplayCaloriesАilteringMin(conn, caloriesMin);
                            break;
                        case "12":
                            Console.WriteLine("Выберите калории для фильтрации: ");
                            var caloriesMax = Console.ReadLine();
                            display.DisplayCaloriesАilteringMax(conn, caloriesMax);
                            break;
                        case "13":
                            Console.WriteLine("Введите миниланьное число диапазона ");
                            var min = Console.ReadLine();
                            Console.WriteLine("Введите максимальное число диапазона ");
                            var max = Console.ReadLine();
                            display.DisplayCaloriesRangeMinMax(conn, min, max);
                            break;
                        case "14":
                            display.DisplayYellowAndRed(conn);
                            break;
                        default:
                            Console.WriteLine("Error");
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

        }       
        
    }

    //public class FruitsAndVegetables
    //{
    //    public int? Id { get; set; }
    //    public string ProductsName { get; set; }
    //    public string TypeProducts { get; set; }
    //    public string Color { get; set; }
    //    public int Calories { get; set; }
    //}
}
