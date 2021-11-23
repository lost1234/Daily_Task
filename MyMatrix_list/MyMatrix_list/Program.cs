using System;
using System.Collections.Generic;

namespace Matrix
{
    public class MyMatrix
    {
        public List<List<string>> CreateM(int row, int column)
        {
            List<List<string>> matrix = new List<List<string>>();
            for (int i = 0; i < row; i++)
            {
                List<string> col = new List<string>();
                for (int j = 0; j < column; j++)
                {
                    col.Add("-");
                }
                matrix.Add(col);
            }
            return matrix;
        }

        public void Print(List<List<string>> matrix)
        {
            foreach (var item in matrix)
            {
                foreach (var item1 in item)
                {
                    Console.Write(item1 + " ");
                }
                Console.WriteLine();
            }
        }

        public List<List<string>> RemoveRow(List<List<string>> matrix, int row)
        {
            matrix.RemoveAt(row);
            return matrix;
        }

        public List<List<string>> RemoveColumn(List<List<string>> matrix, int col)
        {
            for (int i = 0; i < matrix.Count; i++)
            {
                matrix[i].RemoveAt(col);
            }
            return matrix;
        }

        public List<List<string>> Transpose(List<List<string>> matrix)
        {
            int row = matrix.Count;
            int col = matrix[0].Count;
            List<List<string>> matrix_t = CreateM(col, row);

            return matrix_t;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyMatrix matrix = new MyMatrix();
            List<List<string>> matrix1 = matrix.CreateM(10, 11);
            matrix.Print(matrix1);
            matrix.RemoveRow(matrix1, 1);
            matrix.RemoveColumn(matrix1, 1);
            matrix.Transpose(matrix1);
            matrix.Print(matrix1);
            Console.ReadKey();
        }
    }
}
