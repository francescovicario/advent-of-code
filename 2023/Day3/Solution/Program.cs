using System;
using System.Reflection;

string[] data = File.ReadAllLines("../../../Data.txt");

/*
            ------------------------------------------------        PART ONE        ------------------------------------------------
*/

static bool isLineValid(int line, string[] data, List<int> indexes)
{
    string s = data[line];

    foreach (int idx in indexes)
        if (!int.TryParse(s[idx].ToString(), out int n))
            if (!s[idx].ToString().Contains("."))
                return true;

    return false;
}

static List<int> findNumbers(string[] data)
{
    List<int> numbers = new List<int>();
    
    List<List<int>> indexes = new List<List<int>>();

    for(int i = 0; i < data.Length; i++)
    {
        string chars = data[i];

        List<int> numbersFound = new List<int>();
        List<int> indexSerie = new List<int>();

        string numberSaver = "";

        for(int j = 0; j < chars.Length; j++)
        {
            if (int.TryParse(chars[j].ToString(), out int _))
            {
                if(j > 0)
                    if (!indexSerie.Contains(j-1))
                        indexSerie.Add(j-1);

                indexSerie.Add(j);
                numberSaver += chars[j];

                if(j == chars.Length - 1)
                {
                    numbersFound.Add(Int32.Parse(numberSaver));
                    indexes.Add(new List<int>(indexSerie));
                }
            }
            else
            {
                if(numberSaver != "")
                {
                    numbersFound.Add(Int32.Parse(numberSaver));
                    indexSerie.Add(j);

                    indexes.Add(new List<int>(indexSerie));
                    indexSerie.Clear();
                }

                numberSaver = "";
            }
        }

        for (int nu = 0; nu < numbersFound.Count; nu++)
        {
            int n = numbersFound[nu];

            if (i == 0)
            {
                if (isLineValid(0, data, indexes[nu]) || isLineValid(1, data, indexes[nu]))
                        numbers.Add(n);
            }
            else if (i == (data.Length - 1))
            {
                if (isLineValid(data.Length - 1, data, indexes[nu]) || isLineValid(data.Length - 2, data, indexes[nu]))
                    numbers.Add(n);
            }
            else
            {
                if (isLineValid(i, data, indexes[nu]) || isLineValid(i - 1, data, indexes[nu]) || isLineValid(i + 1, data, indexes[nu]))
                    numbers.Add(n);
            }
        }

        indexes.Clear();
    }

    return numbers;
}

int result = 0;

foreach (int n in findNumbers(data))
    result += n;

Console.WriteLine($"\nPart One Result: {result}");

/*
            ------------------------------------------------        PART TWO        ------------------------------------------------
*/

static List<int> findNumberPartTwo(int index, List<int> starIndexes, string[] data)
{
    string str = data[index];
    string numberSaver = "";
    List<int> numbersList = new List<int>();
    List<int> numbersFound = new List<int>();
    List<int> indexSerie = new List<int>();
    List<List<int>> indexes = new List<List<int>>();


    for (int s = 0; s < str.Length; s++)
    {
        if (int.TryParse(str[s].ToString(), out int _))
        {
            indexSerie.Add(s);
            numberSaver += str[s];

            if (s == str.Length - 1)
            {
                numbersFound.Add(Int32.Parse(numberSaver));
                indexes.Add(new List<int>(indexSerie));
            }
        }
        else
        {
            if (numberSaver != "")
            {
                numbersFound.Add(Int32.Parse(numberSaver));

                indexes.Add(new List<int>(indexSerie));
                indexSerie.Clear();
            }

            numberSaver = "";
        }
    }

    for(int i = 0; i < indexes.Count; i++)
        for(int j = 0; j < indexes[i].Count; j++)
            if (starIndexes.Contains(indexes[i][j]) && !numbersList.Contains(numbersFound[i]))
                numbersList.Add(numbersFound[i]);

    return numbersList;
}

static List<int> findGears(string[] data)
{
    List<int> numbers = new List<int>();

    for(int i = 0; i < data.Length; i++)
    {
        string chars = data[i];

        for(int j = 0; j < chars.Length; j++)
        {
            if (chars[j] == '*')
            {
                List<int> starIndexes = new List<int>() { j - 1, j, j + 1 };

                List<int> currentLine = new List<int>(findNumberPartTwo(i, starIndexes, data));

                List<int> lastLine = new List<int>();
                List<int> nextLine = new List<int>();

                if(i > 0)
                    lastLine = findNumberPartTwo(i - 1, starIndexes, data);

                if(i < data.Length - 1)
                    nextLine = findNumberPartTwo(i + 1, starIndexes, data);

                int count = 0;

                count += currentLine.Count;    
                count += lastLine.Count;    
                count += nextLine.Count;    

                if (count == 2)
                {
                    int product = 0;

                    if(currentLine.Count > 0)
                    {
                        product = currentLine[0];

                        if (currentLine.Count > 1)
                            product *= currentLine[1];
                    }

                    if (lastLine.Count > 0)
                    {
                        product = product == 0 ? lastLine[0] : product * lastLine[0];

                        if (lastLine.Count > 1)
                            product *= lastLine[1];
                    }

                    if (nextLine.Count > 0) 
                    {
                        product = product == 0 ? nextLine[0] : product * nextLine[0];

                        if (nextLine.Count > 1)
                            product *= nextLine[1];
                    }

                    numbers.Add(product);
                }
            }

        }

        
    }

    return numbers;
}

int result2 = 0;

foreach (int n in findGears(data))
    result2 += n;

Console.WriteLine($"\nPart Two Result: {result2}");
