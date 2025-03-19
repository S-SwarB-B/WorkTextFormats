
using TextFormats.NavigateFormats;

namespace TextFormats
{
    internal class Programm
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите название файла в одном из форматов (*.txt, *.csv, *.json, *.xml, *.yaml"); //Диалоговое окно с пользователем
            string? path = Console.ReadLine(); //Ввод названия файла и типа файла
            if (File.Exists(path)) //Проверка на наличие файла
            {
                NavigateProgram navigateProgram = new NavigateProgram(); //Переход в навигационное поле
                navigateProgram.Navigate(path);
            }
            else 
            {
                Console.WriteLine($"Файла не существует или название введено не правильно"); //Сообщение об отсутсвии файла
            } 
        }
    }
}