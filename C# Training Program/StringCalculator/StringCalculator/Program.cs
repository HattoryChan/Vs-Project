using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;//import this namespace

namespace StringCalculator
{
    class Program 
    {
        static void Main(string[] args)
        {
            do
            {
                // StringCalculator FirstCalc = new StringCalculator();
                // FirstCalc.Greeting();
                //Console.WriteLine($"Answer is: {FirstCalc.CalculateEquation(Console.ReadLine())}");

                //Console.WriteLine("Press \"Escape\" to exit, any key to continue.");

                //  FirstCalc = null; //Clear object adress
                //string eq = Console.ReadLine();
                //eq = Convert.ToString(Convert.ToInt32(eq));
                //foreach (char t in eq)
                //{
                //     Console.Write(t);
                //}
                //string eq = "q-1,2+y";
                //Console.WriteLine(Convert.ToSingle(new string(eq.ToCharArray(1, 4))));

                StringCalculator t = new StringCalculator("(13-2,2)*((13/8)+44*456,45464)");
                t.test();
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);

            Console.ReadKey();
        }
    }

    public class StringCalculator
    {
        private string equation { get; set; }

        public StringCalculator(string equation)
        {
            this.equation = equation;
        }

        private List<int> SignSearch(string equation)
        {
            var signAndPos = new List<int>();
            
            // {sign, hisPos, sign, hisPos, ....}
            for (int i = 1; i < equation.Length; i++)
            {   
                if (equation[i] == '+' |
                    equation[i] == '-' |
                    equation[i] == '*' |
                    equation[i] == '/' )
                {
                    signAndPos.Add(Convert.ToInt32(equation[i]));
                    signAndPos.Add(i);

                    // Exclude negative and positive number
                    if (equation[i + 1] == '+' |
                        equation[i + 1] == '-')
                    {                        
                        i++;
                    }
                }                               
            }

            //foreach (var t in signAndPos)
             //   Console.WriteLine($" signAndPos: {t}");

            int prevIndex = signAndPos[1];
            for (int i = 3; i < signAndPos.Count; i+=2)
            {
                if (prevIndex == signAndPos[i]) Console.WriteLine("Misplaced signs");
                prevIndex = signAndPos[i];                
            }

            return signAndPos;
        }

        public void test()
        {
           // foreach (int t in SignSearch())
            //    Console.WriteLine(Convert.ToString(t));
            //Console.WriteLine("Numbers");
            //foreach (float t in SeparateNumber(SignSearch(), equation))
           //     Console.WriteLine(Convert.ToString(t));

            Console.WriteLine("Equation");
            Console.WriteLine(equation);
            // CalculateEquation(SignSearch(), SeparateNumber(SignSearch(), equation));
            Console.WriteLine( Convert.ToString( BracketsCalculated(BracketsPairsSearch(equation, BracketsSearch(equation))) ));
        }

        private List<float> SeparateNumber(List<int> signAndPos, string equation)
        {
            var numb = new List<float>();
            Console.WriteLine(equation);
            foreach (var t in signAndPos)
                Console.WriteLine($"sign: {t}");
                try
                {               
                    //first number
                    numb.Add(Convert.ToSingle(new string(equation.ToCharArray(0, signAndPos[1]))));     
                
                    //All next
                    for (int i = 3; i < signAndPos.Count; i += 2)
                    {                  
                    numb.Add(Convert.ToSingle(new string(equation.ToCharArray(signAndPos[i - 2] + 1, signAndPos[i] - signAndPos[i - 2] - 1))));                        
                    }
                 
                    //last number
                    numb.Add(Convert.ToSingle(new string(equation.ToCharArray(signAndPos[signAndPos.Count - 1] + 1, equation.Length - 1 - signAndPos[signAndPos.Count - 1]))));
                    
                }
                catch ( Exception ex)
                {
                Console.WriteLine(ex);
                   // Console.WriteLine("Wrong numbers");
                }
            return numb;
        }

        private float CalculateEquation(List<int> signAndPos, List<float> numb)
        {
            try
            {                
                numb = CalculateSimilarSign(signAndPos, numb, '/');
                numb = CalculateSimilarSign(signAndPos, numb, '*');
                numb = CalculateSimilarSign(signAndPos, numb, '-');
                numb = CalculateSimilarSign(signAndPos, numb, '+');
                
               // foreach (var t in numb)
                //    Console.WriteLine($"Numb array: {t}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return 0;
        }

        private List<float> CalculateSimilarSign(List<int> signAndPos, List<float> numb, char sign)
        {
            List<int> removingNumb = new List<int>();
            List<int> removingSignAndPos = new List<int>();

            switch (sign)
            {
                case '*':
                    { 
                        Console.WriteLine("Multiply");

                        for (int i = 0; i < numb.Count - 1; i++)
                        {
                            if (signAndPos[i * 2] == '*')
                            {
                                numb[i] = numb[i] * numb[i + 1];
                                removingNumb.Add(i + 1);

                                removingSignAndPos.Add(i*2);
                                removingSignAndPos.Add(i*2+1);
                            }
                        }
                        return ClearCalculatedItems(removingNumb, removingSignAndPos, signAndPos, numb);
                    }

                case '/':
                    {
                        Console.WriteLine("Devide");
                        for (int i = 0; i < numb.Count - 1; i++)
                        {
                            if (signAndPos[i * 2] == '/')
                            {
                                numb[i] = numb[i] / numb[i + 1];
                                removingNumb.Add(i + 1);

                                removingSignAndPos.Add(i * 2);
                                removingSignAndPos.Add(i * 2 + 1);
                            }
                        }
                        return ClearCalculatedItems(removingNumb, removingSignAndPos, signAndPos, numb); 
                    }

                case '+':
                    {
                        Console.WriteLine("Summ");
                        for (int i = 0; i < numb.Count - 1; i++)
                        {
                            if (signAndPos[i * 2] == '+')
                            {
                                numb[i] = numb[i] + numb[i + 1];
                                removingNumb.Add(i + 1);

                                removingSignAndPos.Add(i * 2);
                                removingSignAndPos.Add(i * 2 + 1);
                            }
                        }
                        return ClearCalculatedItems(removingNumb, removingSignAndPos, signAndPos, numb);
                    }

                case '-':
                    {
                        Console.WriteLine("Subtract");
                        for (int i = 0; i < numb.Count - 1; i++)
                        {
                            if (signAndPos[i * 2] == '-')
                            {
                                numb[i] = numb[i] - numb[i + 1];
                                removingNumb.Add(i + 1);

                                removingSignAndPos.Add(i * 2);
                                removingSignAndPos.Add(i * 2 + 1);
                            }
                        }
                        return ClearCalculatedItems(removingNumb, removingSignAndPos, signAndPos, numb);
                    }

                default:
                    return numb;
            }            
        }

        private List<float> ClearCalculatedItems(List<int> removingPos, List<int> removingSignAndPos, List<int> signAndPos, List<float> numb)
        {
            
            for (int i = 0; i < removingPos.Count; i++)
            {
                //foreach (var t in numb)
                    //Console.WriteLine($"Numb array: {t}");

                //Console.WriteLine(i);
                numb.RemoveAt(removingPos[i] - i);
            }

            
            //foreach (var t in removingSignAndPos)
                //Console.WriteLine($"removingSignAndPos array: {t}");

            for (int i = 0; i < removingSignAndPos.Count; i++)
            {
                //foreach (var t in signAndPos)
                    //Console.WriteLine($"signAndPos array: {t}");                

                //Console.WriteLine($" i: {i}, removingPos[i]: {removingSignAndPos[i] - i}");                
                signAndPos.RemoveAt(removingSignAndPos[i] - i);
            }

           // foreach (var t in signAndPos)
               // Console.WriteLine($"signAndPos array: {t}");



            return numb;
        }

        private List<int> BracketsSearch(string equation)
        {
            List<int> bracketsPos = new List<int>();

            for (int i = 0; i < equation.Length; i++)
            {
                if (equation[i] == '(' |
                    equation[i] == ')')
                {
                    bracketsPos.Add(i);
                }
            }
            if (bracketsPos.Count % 2 != 0) Console.WriteLine("Brackets are not closed");
           // Console.WriteLine("Brackets");
           // foreach (var t in bracketsPos)
           //     Console.WriteLine($"{equation[t]}  {t}");

            return bracketsPos;
        }

        private List<int> BracketsPairsSearch(string equation, List<int> bracketsPos)
        {
            List<int> bracketPairs = new List<int>();

            for (int i = bracketsPos.Count-1 ; i >= 0; i--)
            {
                if ( equation[bracketsPos[i]] == '(')
                {
                  //  Console.WriteLine($"i: {i}");
                    bracketPairs.Add(bracketsPos[i]);
                    for (int count = i; count < bracketsPos.Count; count++)
                    {
                        if (equation[bracketsPos[count]] == ')')
                        {
                           // Console.WriteLine($"c: {count}");
                            bracketPairs.Add(bracketsPos[count]);

                          //  Console.WriteLine($"Removed: i={i} bracketsPos= {bracketsPos[i]}, count={count} bracketsPos= {bracketsPos[count]}");
                            bracketsPos.RemoveAt(count);
                            bracketsPos.RemoveAt(i);
                            break;
                        }
                    }
                }
            }
           // Console.WriteLine("Brackets");
           // foreach (var br in bracketPairs)
            //    Console.WriteLine($" {br} {equation[br]}");

            return bracketPairs;
        }

        private float BracketsCalculated(List<int> bracketPairs)
        {
            string equationCopy = equation.Substring(bracketPairs[0] + 1, bracketPairs[1] - bracketPairs[0] - 1);

            Console.WriteLine($"Pairs count: {bracketPairs.Count}");
             Console.WriteLine("Brackets");
             foreach (var br in bracketPairs)
                Console.WriteLine($" {br} {equation[br]}");

            Console.WriteLine($"0 Pair: {equationCopy}");
            Console.WriteLine($"0 Equation: {equationCopy}");

            Console.Write(" Answer:");
            Console.WriteLine(Convert.ToString(CalculateEquation(SignSearch(equationCopy),
                     SeparateNumber(SignSearch(equationCopy), equationCopy))));


            for (int i = 2; i < bracketPairs.Count; i += 2)
            {
                equationCopy = equation.Substring(bracketPairs[i] + 1, bracketPairs[i + 1] - bracketPairs[i] - 1);

                Console.WriteLine($"{i} Pair:{bracketPairs[i] + 1}, {bracketPairs[i + 1] - bracketPairs[i] - 1}");
                Console.WriteLine($"{i} Equation: {equationCopy}");

                Console.Write(" Answer:");
                Console.WriteLine( Convert.ToString(CalculateEquation(SignSearch(equationCopy), 
                         SeparateNumber(SignSearch(equationCopy), equationCopy)) ));
            }
            return 0; 

        }
















        public string CalculateEquationDataTableCompute(string equation)
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
