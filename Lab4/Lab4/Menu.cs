namespace Lab4
{
    internal class Menu
    {
        //Поля класса для удобного обращения
        public string[] Option;
        public byte SelectedItem;
        public int[] Array;
        Tasks task = new Tasks();
        public Menu(string[] option, byte Item, int[] arr)
        {
            Option = option;
            SelectedItem = Item;
            Array = arr;
        }
        //Выход из "приложения"
        public void Exit()
        {
            Environment.Exit(0);
        }
        //Отображение всех элементов списка с указанием на текущий элемент
        public void Display()
        {
            Console.Clear();
            for (byte i = 0; i < Option.Length; i++)
            {
                string prefix = "";
                if (SelectedItem == i)
                {
                    prefix = "<";
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                else
                {
                    prefix = "";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine(Option[i] + prefix);
                
            }
            Console.WriteLine("Сформированный массив:");
            for (byte i = 0; i < Array.Length; i++)
            {
                Console.Write($"{Array[i]} ");
            }
        }
        public void Run()
        {
            ConsoleKeyInfo pressedKey;
            do
            {
                Display();
                pressedKey = Console.ReadKey();
                if (pressedKey.Key == ConsoleKey.UpArrow)
                {
                    SelectedItem = SelectedItem > 0 ? SelectedItem-= (byte)1 : SelectedItem=(byte)(Option.Length-1);
                }
                if (pressedKey.Key == ConsoleKey.DownArrow)
                {
                    SelectedItem = (byte)((SelectedItem + 1) % Option.Length);
                }
            } while (pressedKey.Key != ConsoleKey.Enter);
            
            switch (SelectedItem)
            {
                case 0:
                    task.GreatAvarage(Array);
                    Run();
                    break;
                case 1:
                    Array = task.KElements(Array);
                    Run();
                    break;
                case 2:
                    task.ShiftArr(Array);
                    Run();
                    break;
                case 3:
                    task.FirstEven(Array);
                    Run();
                    break;
                case 4:
                    task.InsertSort(Array);
                    Run();
                    break;
                case 5:
                    task.Binarysearch(Array);
                    Run();
                    break;
                case 6:
                    Exit();
                    break;
            }
        }
    }
}