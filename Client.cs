using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ЛР1
{
    class Client
    {
        private string FIO, carMark, carModel, stateSign;
        private List<ParkingLotAppeal> appealHistory = new List<ParkingLotAppeal>();

        public Client() { }
        public Client(string FIO, string carMark, string carModel, string stateSign)
        {
            this.FIO = FIO;
            this.carMark = carMark;
            this.carModel = carModel;
            this.stateSign = stateSign;
        }

        public void AddAppeal(ParkingLotAppeal appeal)
        {
            appealHistory.Add(appeal);
        }
        public string GetFIO()
        {
            return FIO;
        }

        public void PrintClient(int index)
        {
            bool isFirst = true;
            Console.Write(" | {0} |{1, -20}|{2,  -11}|{3, -10}|{4, -10}", index, FIO, carMark,carModel,stateSign);

            appealHistory.ForEach(x => { x.PrintAppeal(isFirst); isFirst = false; });
            Console.WriteLine(" |___|____________________|___________|__________|__________|_______|___________|____________________|____________________|");
        }

        public void Redact()
        {
            string field;
            Console.WriteLine("Чтобы оставить поле без изменений, нажмите Enter");
            Console.Write("Новая фамилия: ");
            field = Console.ReadLine();
            if (field != "") FIO = field;
            Console.Write("Новая марка автомобиля: ");
            field = Console.ReadLine();
            if (field != "") carMark = field;
            Console.Write("Новая модель автомобиля: ");
            field = Console.ReadLine();
            if (field != "") carModel = field;
            Console.Write("Новый государственный знак: ");
            field = Console.ReadLine();
            if (field != "") stateSign = field;
        }
    }
}
