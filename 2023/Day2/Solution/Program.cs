string[] data = File.ReadAllLines("../../../Data.txt");

/*
            ------------------------------------------------        PART ONE        ------------------------------------------------
 */

bool[] isValidList = new bool[data.Length];
int idSum = 0;

int numRedCubes = 12;
int numGreenCubes = 13;
int numBlueCubes = 14;

static bool checkValid(string s, int red, int green, int blue)
{
    bool isValid = true;

    string game = s.Substring(s.IndexOf(":") + 2).Trim();
    string[] sets = game.Split("; ");

    foreach (string set in sets)
    {
        string[] subsets = set.Trim().Split(", ");

        foreach (string sub in subsets)
        {
            string[] subset = sub.Split(" ");

            if (subset[1].Contains("blue"))
                if(Int32.Parse(subset[0]) > blue)
                    isValid = false;

            if (subset[1].Contains("green"))
                if(Int32.Parse(subset[0]) > green)
                    isValid = false;

            if (subset[1].Contains("red"))
                if(Int32.Parse(subset[0]) > red)
                    isValid = false;
        }
    }
    
    return isValid;
}

for (int i = 0; i < data.Length; i++)
    isValidList[i] = checkValid(data[i], numRedCubes, numGreenCubes, numBlueCubes);

for (int j = 0; j < isValidList.Length; j++)
    idSum += isValidList[j] ? j + 1 : 0;

Console.WriteLine($"Part One Result: {idSum}");

/*
            ------------------------------------------------        PART TWO        ------------------------------------------------
 */

int[] gamePowers = new int[data.Length];
int powersSum = 0;

static int PartTwo(string s)
{
    string game = s.Substring(s.IndexOf(":") + 2).Trim();

    int maxBlue = 0;
    int maxGreen = 0;
    int maxRed = 0;

    string[] sets = game.Split("; ");

    foreach (string set in sets)
    {
        string[] subsets = set.Trim().Split(", ");

        foreach (string sub in subsets)
        {
            string[] subset = sub.Split(" ");

            if (subset[1].Contains("blue"))
                if (Int32.Parse(subset[0]) > maxBlue)
                    maxBlue = Int32.Parse(subset[0]);

            if (subset[1].Contains("green"))
                if (Int32.Parse(subset[0]) > maxGreen)
                    maxGreen = Int32.Parse(subset[0]);

            if (subset[1].Contains("red"))
                if (Int32.Parse(subset[0]) > maxRed)
                    maxRed = Int32.Parse(subset[0]);
        }
    }

    return maxBlue * maxGreen * maxRed;
}

for (int i = 0; i < data.Length; i++)
    gamePowers[i] = PartTwo(data[i]);

for (int j = 0; j < gamePowers.Length; j++)
    powersSum += gamePowers[j];

Console.WriteLine($"Part Two Result: {powersSum}");