using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TextFormats.NavigateFormats.TXT_Format;

namespace TextFormats.NavigateFormats
{
    public class NavigateProgram
    {
        public void Navigate(string? path)
        {
            if (path.Contains(".txt")) //TXT формат
            {
                Console.WriteLine("Выбранный формат: TXT");
                NavigateTXT navigateTXT = new NavigateTXT();
                navigateTXT.WorkTXT(path);
            }
            else if (path.Contains(".csv")) //CSV формат
            {
                Console.WriteLine("Выбранный формат: CSV");
                NavigateCSV navigateCSV = new NavigateCSV();
                navigateCSV.WorkCSV(path);
            }
            else if (path.Contains(".json")) //JSON формат
            {
                Console.WriteLine("Выбранный формат: JSON");
                NavigateJSON navigateJSON = new NavigateJSON();
                navigateJSON.WorkJSON(path);
            }
            else if (path.Contains(".xml")) //XML формат
            {
                Console.WriteLine("Выбранный формат: XML");
                NavigateXAML navigateXAML = new NavigateXAML();
                navigateXAML.WorkXAML(path);
            }
            else if (path.Contains(".yaml")) //YAML формат
            {
                Console.WriteLine("Выбранный формат: YAML");
                NavigateYAML navigateYAML = new NavigateYAML();
                navigateYAML.WorkYAML(path);
            }
            else { Console.WriteLine("Данный формат не поддерживается"); } // Отсутсвие поддержки иных форматов текстовых файлов
        }

        public void NavigateInterface() //Интерфейс взаимодействия с навигацией
        {
            Console.WriteLine("Выберите, что вы хотите сделать\n" +
                              "1 - Вывод данных на экран\n" +
                              "2 - Запись данных в файл\n" +
                              "3 - Сортировка данных по выбранному параметру\n" +
                              "4 - Поиск данных по подстроке");
        }
        public void SortInterface() //Интерфейс взаимодействия с сортировкой
        {
            Console.WriteLine("Выберите, по какому полю вы хотите отсортировать\n" +
                              "1 - По айди\n" +
                              "2 - По имени\n" +
                              "3 - По роли\n" +
                              "4 - По дате регистрации\n" +
                              "5 - По активности");
        }
        public void SortInterfaceStatus() //Интерфейс выбора сортировки
        {
            Console.WriteLine("Выберите, как вы хотите отсортировать\n" +
                              "1 - По возрастанию\n" +
                              "2 - По убыванию");
        }
    }
}
