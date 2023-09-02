public class Program
{
    static void Main(string[] arg)
    {
        if (arg.Contains("csv")) {
            foreach (int[] array in Methods.GenerateTwoDArrayFromFile(arg[0]))
            {
                Console.WriteLine(string.Join(",", array));
            }
        }
        else {
            Console.WriteLine(string.Join(",", Methods.GenerateStringFromFile(arg[0])));
        }
    }
}

public static class Methods
{
    public static int[][] GenerateTwoDArrayFromFile(string fileName) {
        List<int[]> tempList = new List<int[]>();
        foreach (string line in File.ReadLines(fileName))
        {
            tempList.Add(GenerateStringFromFile(line));
        }
        return tempList.ToArray();
    }

    public static int[] GenerateStringFromFile(string fileName) {
        try
        {
            return GenerateArrayFromString(File.ReadAllText(fileName));
        }
        catch (FileNotFoundException)
        {
            
            throw new ArgumentException("File doesn't exist");
        }
    }

    public static int[] GenerateArrayFromString(string text) {
        List<int> retval = new List<int>();
        string buffer = "";
        
        foreach (var value in text)
        {
            if (char.IsNumber(value)) {
                buffer += value;
            }
            else if (buffer != "") {
                retval.Add(int.Parse(buffer));
                buffer = "";
            }
        }

        return retval.ToArray();
    }
}