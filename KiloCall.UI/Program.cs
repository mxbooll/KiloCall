using KiloCall.Core.Controller;
using System;

namespace KiloCall.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение KiloCall");

            Console.Write("Введите имя пользователя: ");
            var name = Console.ReadLine();

            Console.Write("Введите пол: ");
            var gender = Console.ReadLine();

            Console.Write("Введите дату рождения: ");
            var birthday = DateTime.Parse(Console.ReadLine()); // TODO: переписать

            Console.Write("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());

            Console.Write("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthday, weight, height);
            userController.Save();
        }
    }
}
