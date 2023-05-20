using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Data.Entity;
using System.ComponentModel;
using System.Drawing;
using System.Data;

namespace HW_2023_04_19
{
    public class Display
    {

        //Задание 3

        //1
        public void DisplayAll(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from FruitsAndVegetables", conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    int line = 0;
                    do
                    {
                        while (rdr.Read())
                        {
                            if (line == 0)
                            {
                                for (int i = 0; i < rdr.FieldCount; i++)
                                {
                                    Console.Write(rdr.GetName(i).ToString() + " ");
                                }
                            }
                            Console.WriteLine();
                            line++;
                            Console.WriteLine(rdr[0] + " " + rdr[1] + " " + rdr[2] + rdr[3] + " " + rdr[4]);
                        }

                    } while (rdr.NextResult());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //2
        public void DisplayName(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from FruitsAndVegetables", conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["ProductsName"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //3
        public void DisplayColor(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from FruitsAndVegetables", conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["Color"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //4
        public void DisplayMaxColories(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select from FruitsAndVegetables", conn))
                {
                    cmd.CommandText = "select MAX(Calories) from FruitsAndVegetables";
                    object maxCalories = cmd.ExecuteScalar();
                    Console.WriteLine("Максимальнaя калорийность: {0}", maxCalories);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //5
        public void DisplayMinColories(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from FruitsAndVegetables", conn))
                {
                    cmd.CommandText = "select MIN(Calories) from FruitsAndVegetables";
                    object minCalories = cmd.ExecuteScalar();
                    Console.WriteLine("Минимальная калорийность: {0}", minCalories);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //6
        public void DisplayAverageColories(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select * from FruitsAndVegetables", conn))
                {
                    cmd.CommandText = "select avg(Calories) from FruitsAndVegetables";
                    object averageCalories = cmd.ExecuteScalar();
                    Console.WriteLine("Средняя калорийность: {0}", averageCalories);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        //Задание 4

        //7
        public void DisplayCountVegetables(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select COUNT(*) from FruitsAndVegetables WHERE TypeProducts = 'Vegetable'", conn))
                {
                    var countVegetables = cmd.ExecuteScalar();
                    Console.WriteLine("В таблице {0} овощ/ей: ", countVegetables);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //8
        public void DisplayCountFruits(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select COUNT(*) from FruitsAndVegetables WHERE TypeProducts = 'Fruit'", conn))
                {
                    var countFruit = cmd.ExecuteScalar();
                    Console.WriteLine("В таблице {0} фрукт/ов: ", countFruit);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //9
        public void DisplayCountFruitsAndVegetableColor(SqlConnection conn, string color)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"select COUNT(*) from FruitsAndVegetables WHERE Color = '{color}'", conn))
                {
                    /*SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@p1";
                    cmd.Parameters.Add(@"p1", SqlDbType.NVarChar);
                    sqlParameter.Value = color;*/
                    var countFruit = cmd.ExecuteScalar();
                    Console.WriteLine($"В таблице {countFruit} овощей и фруктов {color} цветa: ");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //10
        public void DisplayСolorАiltering(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand("select Color, COUNT(TypeProducts) from FruitsAndVegetables GROUP BY Color", conn))
                {
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr[0] + " " + rdr[1]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //11
        public void DisplayCaloriesАilteringMin(SqlConnection conn, string calories)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"select * from FruitsAndVegetables WHERE Calories < {calories}", conn))
                {
                    /*SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@p1";
                    cmd.Parameters.Add(@"p1", SqlDbType.NVarChar);
                    sqlParameter.Value = calories;*/
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["ProductsName"] + " " + rdr["Calories"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //12
        public void DisplayCaloriesАilteringMax(SqlConnection conn, string calories)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"select * from FruitsAndVegetables WHERE Calories > {calories}", conn))
                {
                    /*SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@p1";
                    cmd.Parameters.Add(@"p1", SqlDbType.NVarChar);
                    sqlParameter.Value = calories;*/
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["ProductsName"] + " " + rdr["Calories"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //13
        public void DisplayCaloriesRangeMinMax(SqlConnection conn, string min, string max)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"select * from FruitsAndVegetables WHERE Calories > {min} and Calories < {max}", conn))
                {
                    /*SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@p1";
                    cmd.Parameters.Add(@"p1", SqlDbType.NVarChar);
                    sqlParameter.Value = min;*/

                    /*SqlParameter sqlParameter = new SqlParameter();
                    sqlParameter.ParameterName = "@p1";
                    cmd.Parameters.Add(@"p1", SqlDbType.NVarChar);
                    sqlParameter.Value = max;*/
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["ProductsName"] + " " + rdr["Calories"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void DisplayYellowAndRed(SqlConnection conn)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand($"select * from FruitsAndVegetables WHERE Color = 'Yellow' OR Color = 'Red'", conn))
                {                    
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Console.WriteLine(rdr["ProductsName"] + " " + rdr["Color"]);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
