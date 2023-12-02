using Microsoft.VisualBasic;
using System.Threading;

string[] rawDoc = File.ReadAllLines("../../../Data.txt");
int[] correctValues = new int[rawDoc.Length];

/*
            ------------------------------------------------        PART ONE        ------------------------------------------------
 */

static int PartOne(string[] rawDoc, int[] correctValues)
{

    for (int i = 0; i < rawDoc.Length; i++)
    {
        string numbers = "";

        foreach (char c in rawDoc[i])
            numbers += Char.IsNumber(c) ? c : "";

        correctValues[i] = Int32.Parse(numbers[0] + numbers[numbers.Length - 1].ToString());
    }

    int result = 0;

    foreach (int j in correctValues)
        result += j;

    return result;
}

Console.WriteLine($"Part One Result: {PartOne(rawDoc, correctValues)}");

/*
            ------------------------------------------------        PART TWO        ------------------------------------------------
 */
static int PartTwo(string[] rawDoc, int[] correctValues)
{
    string[] numbersString = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

    for (int i = 0; i < rawDoc.Length; i++)
    {
        string numbers = "";
        string word = rawDoc[i];

        for(int j = 0; j < word.Length; j++)
        {
            char c = word[j];

            if (Char.IsNumber(c))
                numbers += c;
            else
            {
                List<string> corrNumbers = new List<string>();

                foreach(string n in numbersString)
                    if (n.StartsWith(c))
                        corrNumbers.Add(n);

                if (corrNumbers.Count > 0)
                    foreach (string n in corrNumbers)
                    {
                        string check = "";

                        if (j + n.Length <= word.Length)
                        {
                            for(int x = 0; x < n.Length; x++)
                                check += word[j + x];

                            if (check == n)
                                numbers += (Array.IndexOf(numbersString, n) + 1).ToString();
                        }
                    }

            }
        }

        correctValues[i] = Int32.Parse(numbers[0] + numbers[numbers.Length - 1].ToString());
    }

    int result = 0;

    foreach (int j in correctValues)
        result += j;

    return result;
}

Console.WriteLine($"\nPart Two Result: {PartTwo(rawDoc, correctValues)}");