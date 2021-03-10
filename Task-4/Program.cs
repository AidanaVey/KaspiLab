using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4
{
    class Elevator
    {
        public string color;
        public int number_of_storeys;
        public int max_people;

        public event EventHandler<States> StateChanged;
        public event EventHandler<int> LevelChanged;

        public int Level { get; private set; }
        public States Status { get; private set; }


        public enum States
        {
            Empty,
            Climbed_to_a_given_floor,
            Loaded_passengers,
            Unloaded_passengers
        }

        public Elevator(string color, int number_of_storeys, int max_people)
        {
            Level = 1;
            this.color = color;
            this.number_of_storeys = number_of_storeys;
            this.max_people = max_people;

            Print();
        }

        public async Task GoTo(int level) // команда "вызвать лифт на заданный этаж" и тип состояния лифта
        {
            Status = States.Empty;
            StateChanged?.Invoke(this, this.Status); //проверяем событие на null

            for (int i = 1; i <= level; i++)
            {
                await Task.Delay(1000);
                Level = i;
                LevelChanged?.Invoke(this, this.Level);
            }

            Status = States.Climbed_to_a_given_floor;
            StateChanged?.Invoke(this, this.Status);
        }

        public async Task GoTo2(int level) // команда "поехать на заданный этаж" и тип состояния лифта
        {
            Status = States.Loaded_passengers;
            StateChanged?.Invoke(this, this.Status); //проверяем событие на null

            for (int i = 1; i <= level; i++)
            {
                await Task.Delay(1000);
                Level = i;
                LevelChanged?.Invoke(this, this.Level);
            }

            Status = States.Unloaded_passengers;
            StateChanged?.Invoke(this, this.Status);
        }


        public void Print()
        {
            Console.WriteLine($"Цвет: {color}");
            Console.WriteLine($"Этажность здания: {number_of_storeys}"); ;
            Console.WriteLine("Грузоподъемность (людей):" + max_people);

        }
    }
    class Program
    {
        public static void Main(string[] args)
        {

            //у нас есть лифт
            var elevator = new Elevator("Серый", 20, 10);
            //подпишемся на изменение состояния лифта
            elevator.StateChanged +=
                (s, e) => Console.WriteLine($"Состояние лифта: {e}");
            //подпишемся на изменение этажа у лифта
            elevator.LevelChanged +=
                (s, e) => Console.WriteLine($"Лифт на этаже: {e}");

            //изначально лифт на 1 этаже
            Console.WriteLine($"Лифт на этаже: {elevator.Level}");
            //лифт пустой
            Console.WriteLine($"Состояние лифта: {elevator.Status}");
            Console.WriteLine();

            //поступил вызов с 8 этажа
            Console.WriteLine("Лифт вызывли на 8 этаж");
            elevator.GoTo(8).GetAwaiter().GetResult();

            Console.WriteLine("Лифт приехал на 8 этаж и открыл двери");
            Console.WriteLine($"Лифт на этаже: {elevator.Level}");


            Console.WriteLine();


            //поехать на заданный этаж
            Console.WriteLine("Нажали на кнопку 15 этажа");
            elevator.GoTo2(15).GetAwaiter().GetResult();

            Console.WriteLine("Лифт приехал на 15 этаж и открыл двери");
            Console.WriteLine($"Лифт на этаже: {elevator.Level}");

            Console.WriteLine();

        }
    }
}
