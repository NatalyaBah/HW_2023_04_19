using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace HW_2023_04_19
{
    public class MyClassMemu
    {
        public void MyMenu(SqlConnection conn)
        {
            Console.WriteLine("Если хотите подключится к БД, нажмите 1. Если хотите отключиться от БД, нажмите 2");
            string result = Console.ReadLine();
            try
            {
                switch (result)
                {
                    case "1":
                        conn.Open();
                        Console.WriteLine("Вы успешно подключились к БД");
                        break;
                    case "2":
                        if (conn != null)
                            conn.Close();
                        Console.WriteLine("Вы успешно отключились от БД");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Такого раздела нет, попробуйте ещё раз");
                        break;
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка подключения к БД");
            }
        }
    }
}
