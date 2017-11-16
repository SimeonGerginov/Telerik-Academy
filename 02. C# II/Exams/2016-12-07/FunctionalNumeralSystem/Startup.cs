using System;
using System.Numerics;

namespace FunctionalNumeralSystem
{
    public class Startup
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.None);
            var product = new BigInteger(1);

            foreach (var number in numbers)
            {
                var replacedNumber = number
                    .Replace("standardml", "9")
                    .Replace("commonlisp", "D")
                    .Replace("ocaml", "0")
                    .Replace("haskell", "1")
                    .Replace("scala", "2")
                    .Replace("f#", "3")
                    .Replace("lisp", "4")
                    .Replace("rust", "5")
                    .Replace("ml", "6")
                    .Replace("clojure", "7")
                    .Replace("erlang", "8")
                    .Replace("racket", "A")
                    .Replace("elm", "B")
                    .Replace("mercury", "C")
                    .Replace("scheme", "E")
                    .Replace("curry", "F");

                var numberInDecimal = new BigInteger(Convert.ToInt64(replacedNumber, 16));

                product *= numberInDecimal;
            }

            Console.WriteLine(product);
        }
    }
}
