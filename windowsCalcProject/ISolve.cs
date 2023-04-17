using System;
using System.Text.RegularExpressions;


// ISolve interface
public interface ISolve
{
    void Accumulate(string s);
    void Clear();
    double Solve();
}

// Solver class which implements ISolve methods
public class Solver : ISolve
{
    // Variable that holds the original accumulated equation
    string equation;

    // Accumulate method
    public void Accumulate(string s)
    {
        this.equation += s;
    }

    // Clear method
    public void Clear()
    {
        this.equation = string.Empty;
    }

    // Using regex and match to recognize and identify patterns in the string
    // so we can split up the numbers from the operations.
    // My regex pattern is defined as:
    // "\d+" means one or more numbers.
    // "-?\d+" means a possible negative sign in front.
    // "\." means a decimal.
    // "|" means or.
    // "[-+*/%]" means catching any symbol and separating them.
    // "(?<!\d)" means a negative lookbehind assertion.
    // So the regex pattern is either catching a number with a decimal and another number thereafter (3.5),
    // just a number (3), or an operation (+).
    public double Solve()
    {
        Regex regex = new Regex(@"((?<!\d)-?\d+\.\d+|-?\d+|\d+\.\d+|\d+|[-+*/%])");
        MatchCollection matches = regex.Matches(this.equation);
        string[] arrayEquation = new string[matches.Count];
        double num = 0;

        // Putting the separated numbers and operations into a string array.
        for (int j = 0; j < matches.Count; j++)
            arrayEquation[j] = matches[j].ToString();

        // Doing all of the operations in the order of their precedence.
        // After an operation is completed, the result and everything from the original equation is
        // moved over to a new equation array except for the operands.

        // Multiplication
        int i = 0;
        while (arrayEquation.Contains("*"))
        {
            if(arrayEquation[i] == "*")
            {
                num = double.Parse(arrayEquation[i - 1]) * double.Parse(arrayEquation[i + 1]);

                arrayEquation[i-1] = num.ToString();
                string[] newArray = new string[arrayEquation.Length - 2];

                int index = 0;
                for (int j = 0; j < arrayEquation.Length; j++)
                {
                    if (j < i || j > i+1)
                    {
                        newArray[index] = arrayEquation[j];
                        index++;
                    }
                }

                arrayEquation = newArray;
                i = 0;
            }
            i++;
        }

        // Division
        i = 0;
        while(arrayEquation.Contains("/"))
        {
            if(arrayEquation[i] == "/")
            {
                num = double.Parse(arrayEquation[i - 1]) / double.Parse(arrayEquation[i + 1]);

                arrayEquation[i - 1] = num.ToString();
                string[] newArray = new string[arrayEquation.Length - 2];

                int index = 0;
                for (int j = 0; j < arrayEquation.Length; j++)
                {
                    if (j < i || j > i + 1)
                    {
                        newArray[index] = arrayEquation[j];
                        index++;
                    }
                }

                arrayEquation = newArray;
                i = 0;
            }
            i++;
        }

        // Modulus
        i = 0;
        while (arrayEquation.Contains("%"))
        {
            if(arrayEquation[i] == "%")
            {
                num = double.Parse(arrayEquation[i - 1]) % double.Parse(arrayEquation[i + 1]);

                arrayEquation[i - 1] = num.ToString();
                string[] newArray = new string[arrayEquation.Length - 2];

                int index = 0;
                for (int j = 0; j < arrayEquation.Length; j++)
                {
                    if (j < i || j > i + 1)
                    {
                        newArray[index] = arrayEquation[j];
                        index++;
                    }
                }

                arrayEquation = newArray;
                i = 0;
            }
            i++;
        }

        // Addition
        i = 0;
        while (arrayEquation.Contains("+"))
        {
            if(arrayEquation[i] == "+")
            {
                num = double.Parse(arrayEquation[i - 1]) + double.Parse(arrayEquation[i + 1]);

                arrayEquation[i - 1] = num.ToString();
                string[] newArray = new string[arrayEquation.Length - 2];

                int index = 0;
                for (int j = 0; j < arrayEquation.Length; j++)
                {
                    if (j < i || j > i + 1)
                    {
                        newArray[index] = arrayEquation[j];
                        index++;
                    }
                }

                arrayEquation = newArray;
                i = 0;
            }
            i++;
        }

        // Subtraction
        i = 0;
        while (arrayEquation.Contains("-"))
        {
            if(arrayEquation[i] == "-")
            {
                num = double.Parse(arrayEquation[i - 1]) - double.Parse(arrayEquation[i + 1]);

                arrayEquation[i - 1] = num.ToString();
                string[] newArray = new string[arrayEquation.Length - 2];

                int index = 0;
                for (int j = 0; j < arrayEquation.Length; j++)
                {
                    if (j < i || j > i + 1)
                    {
                        newArray[index] = arrayEquation[j];
                        index++;
                    }
                }

                arrayEquation = newArray;
                i = 0;
            }
            i++;
        }

        return num;
    }
}