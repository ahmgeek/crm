using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for UniqueId
/// </summary>
public static class GetUniqueId
{
    public static string GetRandomString()
    {
        Random rand = new Random((int)DateTime.Now.Ticks);
        int randomIndex1 = rand.Next(100, 999);
        int randomIndex2 = rand.Next(10000, 99999);
        string randstring = RandomString(3);

        string result = "#" + randstring + "-" + randomIndex1.ToString() + "-" + randomIndex2.ToString();
        return result;
    }

    private static Random random = new Random((int)DateTime.Now.Ticks);
    private static string RandomString(int size)
    {
        StringBuilder builder = new StringBuilder();
        char ch;
        for (int i = 0; i < size; i++)
        {
            ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
            builder.Append(ch);
        }

        return builder.ToString();
    }
}