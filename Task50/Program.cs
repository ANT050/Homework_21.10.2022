/*Задача 50. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

Например, задан массив:

1 4 7 2
5 9 2 3
8 4 2 4

17 -> такого числа в массиве нет*/

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
            resultMatrix[i, j] = rnd.Next(0, 100); ;
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

//Нахождение значения элемента массива
dynamic ValueOfTheMatrixElement(int rowNumber, int columnNumber, int[,] matrix)//dynamic - позволяет опустить проверку типов во время компиляции
{
    if (rowNumber == 0 | columnNumber == 0)
        throw new Exception($"\nЭлемент двумерного массива {(rowNumber, columnNumber)} -> Элемент массива отсутствует\n");

    if (rowNumber > matrix.GetLength(0) | columnNumber > matrix.GetLength(1))
        return "Элемент массива отсутствует\n";
    else
        return matrix[rowNumber - 1, columnNumber - 1];
}

try
{
    int rows = EnteringRowsColumnsMatrix("\nВведите количество строк двумерного массива: ");
    int сolumns = EnteringRowsColumnsMatrix("Введите количество столбцов двумерного массива: ");
    Console.WriteLine();

    int[,] matrix = InitMatrix(rows, сolumns);
    PrintMatrix(matrix);

    int rowNumber = EnteringRowsColumnsMatrix("\nВведите номер строки: ");
    int columnNumber = EnteringRowsColumnsMatrix("Введите номер столбца: ");

    var resultMeaning = ValueOfTheMatrixElement(rowNumber, columnNumber, matrix);
    Console.WriteLine($"Элемент двумерного массива {(rowNumber, columnNumber)} -> {resultMeaning}\n");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
