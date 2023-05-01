using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    class ParkingLot
    {
        const float COST_PER_HOUR = 75.5f;
        private List<Client> clientList = new List<Client>();
        public void AddClient(Client client)
        {
            clientList.Add(client);
        }
        public void AddClient()
        {
            string FIO, carMark, carModel, stateSign;
            Console.WriteLine("Введите Ф.И.О. в формате 'Фамилия И.О.': ");
            FIO = Console.ReadLine();

            foreach (Client c in clientList)
                if (c.GetFIO() == FIO)
                {
                    Appeal(c); return;
                }

            Console.WriteLine("Введите марку автомобиля: ");
            carMark = Console.ReadLine();
            Console.WriteLine("Введите модель автомобиля: ");
            carModel = Console.ReadLine();
            Console.WriteLine("Введите государственный знак: ");
            stateSign = Console.ReadLine();
            clientList.Add(new Client(FIO, carMark, carModel, stateSign));
            Appeal(clientList[clientList.Count() - 1]);
        }
        public void Appeal(Client client)
        {
            Console.WriteLine("Введите длительность парковки: ");
            int hours = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите место парковки: ");
            int place = Convert.ToInt32(Console.ReadLine());
            Random rand = new Random();
            DateTime parkingTime = DateTime.Now.AddHours(-rand.Next(5, 100));
            DateTime departureTime = parkingTime.AddHours(hours);
            client.AddAppeal(new ParkingLotAppeal(parkingTime, departureTime, place, hours * COST_PER_HOUR));
        }
        public void Redaction()
        {
            Output();
            Console.WriteLine("Введите индекс: ");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < 1 || index > clientList.Count())
            {
                Console.WriteLine("Такого индекса нет"); 
                Console.ReadLine(); return;
            }
            clientList[index - 1].Redact();
            Console.WriteLine("Редактирование завершено");
            Console.ReadLine();
            Output();
        }
        public void Removing()
        {
            Output();
            Console.WriteLine("Введите индекс: ");
            int index = Convert.ToInt32(Console.ReadLine());
            if (index < 1 || index > clientList.Count())
            {
                Console.WriteLine("Такого индекса нет"); 
                Console.ReadLine(); return;
            }
            clientList.RemoveAt(index - 1);
            Console.WriteLine("Удаление завершено");
            Console.ReadLine();
            Output();
        }

        public void Output()
        {
            Console.WriteLine("  ________________________________________________________________________________________________________________________");
            Console.WriteLine(" | № |      Ф. И. О.      |   Марка   |  Модель  |   Знак   | Место | Стоимость |       Приезд       |       Отъезд       |");
            Console.WriteLine(" |___|____________________|___________|__________|__________|_______|___________|____________________|____________________|");
            for (int i = 1; i <= clientList.Count(); i++) clientList[i - 1].PrintClient(i);
        }
    }
}
