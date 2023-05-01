using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    class Program
    {
        static void Main(string[] args)
        {
            ParkingLot pk = new ParkingLot();
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Добавить запись");
                Console.WriteLine("2. Редактировать запись");
                Console.WriteLine("3. Удалить запись");
                Console.Write("4. Просмотреть записи\n>> ");
                int com = Convert.ToInt32(Console.ReadLine());
                switch (com)
                {
                    case 1: pk.AddClient(); break;
                    case 2: pk.Redaction(); break;
                    case 3: pk.Removing(); break;
                    case 4: pk.Output(); Console.ReadLine(); break;
                    default: Console.WriteLine("ЭЭ, введите правильный индекс"); Console.ReadLine(); break;
                }
            }
            Console.ReadLine();
        }
    }
}
