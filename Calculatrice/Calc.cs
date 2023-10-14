using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CalculatorQuest;

public class Calc
{
    private string[] signs = { "+", "-", "x", "/", "%" };

    public static string Operator(string str)
    {
        MatchCollection matches = Regex.Matches(str, @"-?\d+(?:\,\d+)?");

        double[] result = matches
            .Select(match => Convert.ToDouble(match.Value))
            .ToArray();
        if (result.Length > 2 || result.Length >= 2 && str.Contains("^²") || result.Length >= 2 && str.Contains("\u221a"))
        {
            return "Only one Operation";
        } else if (str.Length == 0 || result.Length == 0)
        {
            return "Please enter an operation";
        } else if (result.Length == 1)
        {
            if (str.Contains("^²"))
            {
                return (result[0] * result[0]).ToString();
            } else if (str.Contains("\u221a"))
            {
                if (str[str.Length - 2].ToString() == "\u221a")
                {
                    return "Invalid format";
                }
                else
                {
                    return Math.Sqrt(result[0]).ToString();
                }
            }
            else
            {
                return result[0].ToString();
            }
        }

        if (str.Contains("+"))
        {
            return (result[0] + result[1]).ToString();
        }

        if (str.Contains("-"))
        {
            return (result[0] - result[1]).ToString();
        }

        if (str.Contains("x"))
        {
            return (result[0] * result[1]).ToString();
        }

        if (str.Contains("/"))
        {
            if (result[0] == 0 || result[1] == 0)
            {
                return "Division by 0 is impossible";
            }
            else
            {
                return (result[0] / result[1]).ToString();
            }
        }

        if (str.Contains("%"))
        {
            return (result[0] % result[1]).ToString();
        }

        if (str.Contains("+/-"))
        {
        }
        
        return result[0].ToString();
    }
} 