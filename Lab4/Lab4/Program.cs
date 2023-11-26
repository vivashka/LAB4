using System.Text;
using System.Xml.Linq;
using LabLibrary;

namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //На не английском всё ломается в консоли
            Console.OutputEncoding = Encoding.UTF8;

            Tasks program = new Tasks();
            int[] array = new int[0];
            byte SelectedItem = 0;
            string[] option = { "Элементы больше среднего арифметического",
                "'N' - элементов в начало массива",
                "Сдвинуть на M элементов вправо",
                "Найти первый четный",
                "Сортировка простым включением", 
                "Бинарный поиск элемента",
                "Выход"};

            Console.WriteLine("Лабораторная работа 4. Хотите ввести новый массив или сгенерировать его автоматически?");
            Menu menu = new Menu(option, SelectedItem, program.KElements(array));
            menu.Run();
        }
    }
}