using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//import this namespace

namespace StringCalculator
{
    class Program : StringCalculator
    {
        static void Main(string[] args)
        {
            StringCalculator FirstCalc = new StringCalculator();

            do
            {
                FirstCalc.Greeting();
                Console.WriteLine($"Answer is: {FirstCalc.CalculateEquation(Console.ReadLine())}");

                Console.WriteLine("Press \"Escape\" to exit, any key to continue.");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);


            Console.ReadKey();
        }
    }

    public class StringCalculator
    {
        public string CalculateEquation(string equation)
        {            
            try
            {
                string value = new DataTable().Compute(equation, null).ToString();

                if (String.IsNullOrEmpty(value)) return "Write your equation please.";
                else return value; 
            }
            catch (EvaluateException)
            {
                return "We found a letter in your equation, delete it please.";
            }
            catch (SyntaxErrorException)
            {
                return "We found incorrect character in your equation, delete it please.";
            }
            catch (Exception ex)
            {
                return $"Error info: {ex}";
            }
        }

        public void Greeting()
        {
            Console.WriteLine("Write your equation here: ");
        }
    }
}
