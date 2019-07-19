using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roaring_Algoritm
{

    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            ReadPdfFile("C/:");
            Console.ReadKey();
        }

        //pdf to text program
        private static string ReadPdfFile(String fileName)
        {
            StringBuilder text = new StringBuilder();

            if(File.Exists(fileName))
            {

            }
            return text.ToString();
        }

        // Big or small number
        private static void bigOrSmallNumber()
        {
            int val = 0;
            Console.WriteLine("Input your number: ");
            val = int.Parse(Console.ReadLine());

            if ((val / 10) > (val % 10))
            {
                Console.Write(" Bigger: {0}, Less: {1} ", val / 10, val%10);
            }
            else if ((val / 10) < (val % 10))
            {
                Console.Write(" Bigger: {0}, Less: {1} ", val % 10, val/10);
            }
            else
            {
                Console.WriteLine("Values are equivalent!");
            }
        }

        //algebraic sum
        private static void algebraicSum()
        {
            //Y=X1 + X2 + ... + Xn
            //X= Z^3 - B + A^2 / tg^2K
            //Z,A,B,K - getted from users

            double N, Z, A, B, K;
            double Y = 0;

            Console.WriteLine("Input N: ");
            N = Convert.ToDouble(Console.ReadLine());         
           
            for(int i=0; i<N; i++)
            {
                Console.WriteLine("Input value to X{0}:", i);
                Console.WriteLine("Input Z: ");
                Z = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input A: ");
                A = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input B: ");
                B = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Input K: ");
                K = Convert.ToDouble(Console.ReadLine());

                Y += Math.Pow(Z,3) - B + Math.Pow(A,2) / Math.Pow(Math.Tan(K),2);
            }
            Console.WriteLine("Y = {0:0.00}", Y);
        }

        //Meter to kilometer conversion 
        private static void meterToKilometer()
        {
            Console.WriteLine("Input meter: ");
            Console.WriteLine("Kilometer: {0}", Convert.ToDouble(Console.ReadLine()) / 1000);
        }

        //To Upper function
        private static void ToUpperStr()
        {
            Console.WriteLine("Input string: ");
            Console.WriteLine("Your upper string: {0}", Console.ReadLine().ToUpper());
        }


        //бинарный алгоритм поиска в отсортированном списке
        private static void binaryAlgotitm()
        {
            Console.WriteLine("Binary algoritm: ");
            int[] arr = {1, 2, 3, 4, 5, 6, 7, 8};
            int high, low, mid, guess, item, count;
            item = 6;
            low = 0;
            high = arr.Length - 1;
            count = 0;

            Console.WriteLine("Array length: {0}, Item: {1}", arr.Length, item);
            Console.WriteLine("Array: ");
            for (int i = 0; i < arr.Length; i++)
                Console.Write("{" + arr[i] + "} ");
            Console.Write('\n');            

            while (low <= high)
            {
                count++;
                mid = (low + high) / 2;
                guess = arr[mid];

                if (guess == item)
                {
                    Console.WriteLine("Position number: {0}, Count: {1}", guess, count);
                    return;
                }
                if (guess > item)
                    high = mid - 1;
                else
                    low = mid + 1;
            }
            Console.WriteLine("Item not found(NULL), Count: {0}", count);
        }
    }
}
