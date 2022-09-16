/*
Задайте массив заполненный случайными положительными трёхзначными числами. Напишите программу, которая покажет количество чётных чисел в массиве.
[345, 897, 568, 234] -> 2
*/

int size = 0, cntEvenElement = 0;

if (!InputControl())
    return;

int[] array = InitArray(size);

CheckArray(array, ref cntEvenElement);

PrintArray(array, cntEvenElement);

# region methods

bool InputControl()
{
    int tryCount = 3;
    string inputStr = string.Empty;
    bool resInputCheck = false;

    while (!resInputCheck)
    {
        Console.WriteLine($"\r\nЗадайте размерность массива (количество попыток: {tryCount}):");
        inputStr = Console.ReadLine() ?? string.Empty;

        resInputCheck = int.TryParse(inputStr, out size) && size > 0;

        if (!resInputCheck)
        {
            tryCount--;

            if (tryCount == 0)
            {
                Console.WriteLine("\r\nВы исчерпали все попытки.\r\nВыполнение программы будет остановлено.");
                return false;
            }
        }
    }

    return true;
}

int[] InitArray(int sizeArray)
{
    int[] array = new int[sizeArray];

    for (int i = 0; i < sizeArray; i++)
    {
        array[i] = new Random().Next(100, 1000);        
    }

    return array;
}

void CheckArray(int[] array, ref int cnt)
{    
    foreach(var item in array)
    {
        if (item % 2 == 0)
            cnt++;
    }
}

void PrintArray(int[] array, int result)
{
    foreach (int elem in array)
    {
        Console.Write($"{(elem == array.First() ? "[" + elem : (elem == array.Last() ? "," + elem + "] -> " + result : "," + elem))}");
    }
}

#endregion