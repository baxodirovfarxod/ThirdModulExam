namespace FileManagment.Service.Extra;
public class WorkingWithDelegete
{
    public delegate bool myDelegate(int firstNum, int secondNum, int thirdNum);

    public WorkingWithDelegete()
    {
        myDelegate myMethods = FirstNumLargeOther;
        myMethods += SecondNumLargeOther;
        myMethods += ThirdNumLargeOther;
        myMethods += FirstTwoNumLargeThirdNum;
        myMethods += LastTwoNumLargeThirdNum;

        Func<string, int> counter = CountXlsxFile;
    }

    public int CountXlsxFile(string filePath)
    {
        var count = 0;
        var allFiles = Directory.GetFileSystemEntries(filePath);
        foreach (var file in allFiles)
        {
            if (Path.GetExtension(file) == ".xlsx")
            {
                count++;
            }
        }

        return count;
    }

    public static bool FirstNumLargeOther(int firstNum, int secondNum, int thirdNum)
    {
        return firstNum > secondNum && firstNum > thirdNum;
    }

    public static bool SecondNumLargeOther(int firstNum, int secondNum, int thirdNum)
    {
        return firstNum < secondNum && secondNum > thirdNum;
    }

    public static bool ThirdNumLargeOther(int firstNum, int secondNum, int thirdNum)
    {
        return thirdNum > secondNum && firstNum < thirdNum;
    }

    public static bool FirstTwoNumLargeThirdNum(int firstNum, int secondNum, int thirdNum)
    {
        var res = firstNum + secondNum;
        return res > thirdNum;
    }

    public static bool LastTwoNumLargeThirdNum(int firstNum, int secondNum, int thirdNum)
    {
        var res = thirdNum + secondNum;
        return res > firstNum;
    }

}
