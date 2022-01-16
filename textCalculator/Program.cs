using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Name
{
    class Program
    {
        static void Main()
        {
            // default values................
            string word = "";
            string equation = "";
            string equationTmp = "";
            string[] textNumbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "minus", "plus" };
            int n = 0;
            string tmpForNumber = "";
            int answerInNumber = 0;
            string tmpForAnswer = "";
            string answerInString = "";
            string input = Console.ReadLine();
            // from text numbers to string equation
            for (int i = 0; i < input.Length; i++)
            {
                word += input[i];
                foreach (string s in textNumbers)
                {
                    if (s == word)
                    {
                        if (n == 10) equation += "-";
                        else if (n == 11) equation += "+";
                        else equation += $"{n}";
                        word = "";
                    }
                    n++;
                }
                n = 0;
            }
            equationTmp = equation;
            //from string equation to calculation
            string firstEqualatinElement = equation.Substring(0, 1);
            if (firstEqualatinElement == "-" || firstEqualatinElement == "+")
            {
                tmpForNumber += firstEqualatinElement;
                equation = equation.Substring(1);
                firstEqualatinElement = equation.Substring(0, 1);
            }
            while (equation.Length > 0)
            {
                tmpForNumber += firstEqualatinElement;
                equation = equation.Substring(1);
                if (equation.Length > 0) firstEqualatinElement = equation.Substring(0, 1);
                else answerInNumber += int.Parse(tmpForNumber);
                if (firstEqualatinElement == "-" || firstEqualatinElement == "+")
                {
                    answerInNumber += int.Parse(tmpForNumber);
                    tmpForNumber = "";
                    tmpForNumber += firstEqualatinElement;
                    equation = equation.Substring(1);
                    firstEqualatinElement = equation.Substring(0, 1);
                }
            }
            // from calculation to answer in text numbers
            char[] numbers = answerInNumber.ToString().ToCharArray();
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i].ToString() == "-") answerInString += "minus";
                else answerInString += textNumbers[int.Parse(numbers[i].ToString())];
            }
            // output

            string output = $"Equation -> {equationTmp}\nAnswer in number -> {answerInNumber}\nAnswer in string -> {answerInString}";
            Console.WriteLine(output);

        }
    }
}
