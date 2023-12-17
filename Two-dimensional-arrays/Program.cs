using System;
using System.IO;
class Program
{
    static void Main()
    {
        var matrix = ReadMatrixFromFile("C:\\Users\\eles7\\source\\repos\\Two-dimensionalarray\\123.txt");
        var friendlyCountArray = CalculateFriendlyCount(matrix);
        PrintMatrix(friendlyCountArray);
    }
    static int[,] ReadMatrixFromFile(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        var matrix = new int[lines.Length, lines[0].Split(' ').Length];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                matrix[i, j] = int.Parse(lines[i].Split(' ')[j]);

        return matrix;
    }
    static int[,] CalculateFriendlyCount(int[,] matrix)
    {
        var friendlyCountArray = new int[matrix.GetLength(0), matrix.GetLength(1)];

        for (int i = 0; i < matrix.GetLength(0); i++)
            for (int j = 0; j < matrix.GetLength(1); j++)
                friendlyCountArray[i, j] = CountFriendlyNeighbors(matrix, i, j);

        return friendlyCountArray;
    }
    static int CountFriendlyNeighbors(int[,] matrix, int row, int col)
    {
        int count = 0;

        for (int i = row - 1; i <= row + 1; i++)
            for (int j = col - 1; j <= col + 1; j++)
                if (IsValidIndex(matrix, i, j) && matrix[i, j] == matrix[row, col] && !(i == row && j == col))
                    count++;

        return count;
    }
    static bool IsValidIndex(int[,] matrix, int row, int col) =>
        row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
    static void PrintMatrix(int[,] matrix)
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}