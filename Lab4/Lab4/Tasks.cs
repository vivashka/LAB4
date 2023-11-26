using LabLibrary;

namespace Lab4
{
    internal class Tasks
    {
        Program program = new Program();
        Random random = new Random();
        public void PrintArray(int[] arr)
        {
            Console.WriteLine();
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]} ");
            }
        }

        public void ShiftArr(int[] arr)
        {
            Console.WriteLine("\nВведите число на сколько элементов вправо сдвинутся элементы?");
            int shiftM = LabLib.ExtensionDoWhile<int>();
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = arr[i];
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = tempArr[(i + shiftM) % arr.Length];
            }
            PrintArray(arr);
            PrintArray(tempArr);
            Console.ReadKey();
        }
        public void GreatAvarage(int[] arr)
        {
            double count = 0;
            int summ = 0;
            //Считаем сумму всех элементов
            //Считаем колчиество элементов
            for (int i = 0; i < arr.Length; i++)
            {
                count++;
                summ += arr[i];
            }
            Console.WriteLine("Все элементы больше среднего арифметического элементов массива (Любая клавиша - продолжить)");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > (summ / count))
                {
                    Console.Write($"{arr[i]} ");
                }
            }
            Console.ReadKey();
        }
        public int[] KElements(int[] arr)
        {
            //добавить k элементов в начало или! через рандом добавлять эти элементы
            Console.WriteLine("\nВведите число элементов");
            //nuget package для обработчика ошибок
            int amount = LabLib.ExtensionDoWhile<int>();
            Console.WriteLine("Сформировать числа: 1 - самостоятельно, 0 - автамотически");
            int choice = LabLib.ExtensionDoWhile<int>();
            //Запоминаем прошлый массив
            int[] tempArr = new int[arr.Length];
            for (int i = 0; i < tempArr.Length; i++)
            {
                tempArr[i] = arr[i];
            }
            //Даём пользователью выбрать можно через case но тут всего 2 элемента, так что я решил через if
            arr = new int[arr.Length + amount];
            if (choice == 0)
            {
                for (int i = 0; i < amount; i++)
                {
                    arr[i] = random.Next(100);
                }
            }
            else if (choice == 1)
            {
                for (int i = 0; i < amount; i++)
                {
                    arr[i] = LabLib.ExtensionDoWhile<int>();
                }
            }
            for (int i = 0; i < tempArr.Length; i++)
            {
                arr[i + amount] = tempArr[i];
            }
            PrintArray(arr);
            Console.ReadKey();
            return arr;
        }
        public void FirstEven(int[] arr)
        {
            bool isFind = false;
            for (int i = 0; i < arr.Length; i++)
            {
                //проверям первый ли это элемент и проверяем делимость на два
                if (!isFind && (arr[i] % 2 == 0))
                {
                    Console.WriteLine($"\nПервый четный элемен = {arr[i]}");
                    isFind = true;
                }
            }
            Console.ReadKey();
        }
        public void InsertSort(int[] arr)
        {
            for(int i = 1; i < arr.Length; i++)
            {
                //Сохраняем текущий элемент, чтобы цикл for корректно выдала следующие позиции в списке
                int sortElement = i;
                //важно вначале сравнить больше ли элемент нуля, чтобы цикл не запустился лишний раз
                //Ибо он может выйти за границы массива
                while (sortElement > 0 && arr[sortElement - 1] > arr[sortElement])
                {
                    //Временная переменная для обмена значений в позициях
                    int tempElement = arr[sortElement - 1];
                    arr[sortElement - 1] = arr[sortElement];
                    arr[sortElement] = tempElement;
                    //уменьшаем отсортированный элемент массива, чтобы сравнивать его
                    //с более ранним после перезапуска цикла
                    sortElement--;
                }
                
            }
            PrintArray(arr);
        }
        public void Binarysearch(int[] arr)
        {
            int start = 0;
            int end = arr.Length - 1;
            int middle;
            Console.WriteLine("\nБинарный поиск возможен только в отсотрированном массиве." +
                "\nОн будет отсортирован принудительно." +
                "\nВведите элемент, который хотите найти:");
            int target = LabLib.ExtensionDoWhile<int>();
            InsertSort(arr);
            Console.WriteLine("");
            byte counter = 0;
            while (start <= end)
            {
                //Делим массив на половину в отсортированном массиве
                middle = (end + start) / 2;
                counter++;
                //Если элемент находится в середине, то выводим его
                if (target == arr[middle])
                {
                    Console.WriteLine($"Найденный элемент на позиции - {middle+1}. Количество сравнений - {counter}");
                    Console.ReadKey();
                    return;
                }
                //Если элемент 
                else if (target < arr[middle])
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            Console.WriteLine($"Элемент не найден. Количество сравнений - {counter}"); ;
            Console.ReadKey();
        }
    }
}