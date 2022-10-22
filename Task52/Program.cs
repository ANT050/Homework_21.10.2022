/*Задача 52. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.

Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.*/

// Получение строк и столбцов с консоли, проверка на правильность ввода
int EnteringRowsColumnsMatrix(string message)
{
    int result = 0;
    bool isCorrect = false;

    while (!isCorrect)
    {
        Console.Write(message);
        isCorrect = int.TryParse(Console.ReadLine(), out result);

        if (!isCorrect)
            Console.WriteLine("\nВведите корректное число!\n");
    }
    return result;
}

//Создание двумерного массива, заполненный случайными числами
int[,] InitMatrix(int rows, int columns)
{
    int[,] resultMatrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            resultMatrix[i, j] = rnd.Next(0, 10);
        }
    }
    return resultMatrix;
}

//Вывод двумерного массива в консоли
void PrintMatrix(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i, j]}\t");
        }
        Console.WriteLine();
    }
}

//Подсчет среднего арифметического столбца
double ArithmeticMeanOfTheColumn(int[,] matrix, int columnNumber, int rows, int сolumns)
{
    if (columnNumber == 0 | columnNumber > сolumns)
        throw new Exception($"Столбец {(columnNumber)} отсутствует\n");

    double average = 0;
    double summ = 0;

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        summ = summ + matrix[i, columnNumber - 1];
    }

    average = Math.Round((summ / rows), 2);
    return average;
}

try
{
    int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
    int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
   
    Console.WriteLine();
    int[,] matrix = InitMatrix(rows, сolumns);
    PrintMatrix(matrix);

    int columnNumber = EnteringRowsColumnsMatrix("\nВведите номер столбца: ");

    double resultAverage = ArithmeticMeanOfTheColumn(matrix, columnNumber, rows, сolumns);
    Console.WriteLine($"Среднее арифметическое столбца {columnNumber} = {resultAverage}\n");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
