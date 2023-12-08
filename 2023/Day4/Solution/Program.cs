using System;
using System.Reflection.Metadata.Ecma335;

string[] data = File.ReadAllLines("../../../Data.txt");

/*
            ------------------------------------------------        PART ONE        ------------------------------------------------
*/

static int findScore (string line)
{
    int score = 0;

    string[] splitLine = line.Substring(line.IndexOf(": ") + 2).Split("|");

    string[] winningNumbers = Array.FindAll(splitLine[0].Split(" "), value => value.Trim() != "");
    string[] holdingNumbers = Array.FindAll(splitLine[1].Split(" "), value => value.Trim() != "");

    for(int i = 0; i < winningNumbers.Length; i++)
        if (holdingNumbers.Contains(winningNumbers[i]))
            score = score == 0 ? score + 1 : score * 2;

    return score;
}

int result = 0;

foreach (string line in data)
    result += findScore(line);

Console.WriteLine($"Part One Result: {result}");

/*
            ------------------------------------------------        PART TWO        ------------------------------------------------
*/

int[] totalCopies = new int[data.Length];

for(int c = 0; c < totalCopies.Length; c++)
    totalCopies[c] = 1;

static int findScore2(string line)
{
    int score = 0;

    string[] splitLine = line.Substring(line.IndexOf(": ") + 2).Split("|");

    string[] winningNumbers = Array.FindAll(splitLine[0].Split(" "), value => value.Trim() != "");
    string[] holdingNumbers = Array.FindAll(splitLine[1].Split(" "), value => value.Trim() != "");

    for (int i = 0; i < winningNumbers.Length; i++)
        if (holdingNumbers.Contains(winningNumbers[i]))
            score++;

    return score;
}


for(int j = 0; j < data.Length; j++)
{
    int lineScore = findScore2(data[j]);

    for(int x = 0; x < totalCopies[j]; x++)
        for (int k = 1; k <= lineScore; k++)
            totalCopies[j + k] += 1;

}

Console.WriteLine($"Part Two Result: {totalCopies.Aggregate((acc, x) => acc + x)}");