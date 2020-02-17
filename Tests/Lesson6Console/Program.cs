using System;
using System.Threading.Tasks;

namespace Lesson6Console
{
    class Program
    {
        static int height = 100, width = 100;
        
        static int[,] arrResult = new int[height, width];
        static int[,] arr1 = new int[height, width];
        static int[,] arr2 = new int[height, width];
        
        static void Main(string[] args)
        {            
            FillArray(arr1);
            FillArray(arr2);

            PrintArray(arr1);
            Console.WriteLine();
            PrintArray(arr2);
            Console.WriteLine();

            SetArrResAsync(arr1, arr2);
            

            Console.ReadKey();
        }

        static void FillArray(int[,] arr)
        {
            Random rnd = new Random();
            for(int i = 0; i< height; i++)
            {
                for(int j=0; j< width; j++)
                {
                    arr[i, j] = rnd.Next(10) + 1;
                }
            }
        }

        static void PrintArray(int[,] arr)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    string a;
                    if (arr[i, j] == 10) a = "";
                    else a = " ";
                    Console.Write(arr[i, j] + " " + a);
                }
                Console.WriteLine();
            }
        }        

        static async void SetArrResAsync(int[,] a, int[,] b)
        {
            var res = await MultiplicationAsync(a, b).ConfigureAwait(true);

            for (int i = 0; i < height; i++)
                for (int j = 0; j < width; j++)
                    arrResult[i, j] = res[i, j];
            
            PrintArray(arrResult);
        }

        static async Task<int[,]> MultiplicationAsync(int[,] a, int[,] b)
        {            
            int[,] r = new int[a.GetLength(0), b.GetLength(1)];

            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
                    for (int k = 0; k < b.GetLength(0); k++)
                    {                                                
                        r[i, j] += await GetCalcResultAsync(a[i, k], b[k, j]);
                    }
                }
            }
            
            return r;
        }

        static Task<int> GetCalcResultAsync(int a, int b)
        {
            return Task.Run(() => GetMultiplyAsync(a, b));
        }

        static async Task<int> GetMultiplyAsync(int a, int b)
        {
            return a * b;
        }
    }
}
