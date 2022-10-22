/*Задача 47. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

m = 3, n = 4.

0,5      7     -2   -0,2
  1   -3,3      8   -9,9
  8    7,8   -7,1      9 */


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
double[,] InitMatrix(int rows, int columns)
{
    double[,] resultMatrix = new double[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {  
            resultMatrix[i, j] = Math.Round(rnd.Next(-10, 11) + rnd.NextDouble(), 1); ;
        }
    }
    return resultMatrix;
}

//Вывод двумерного массива в консоли
void PrintMatrix(double[,] matrix)
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

int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
double[,] matrix = InitMatrix(rows, сolumns);
Console.WriteLine();
PrintMatrix(matrix);
Console.WriteLine();