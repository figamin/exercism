using System.Globalization;

public static class HighSchoolSweethearts
{
    public static string DisplaySingleLine(string studentA, string studentB)
    {
        return $"                  {studentA} ♡ {studentB}                    ";
    }

    public static string DisplayBanner(string studentA, string studentB)
    {
        return @"     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     " + $"{studentA} +  {studentB}" + @"    **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";
    }

    public static string DisplayGermanExchangeStudents(string studentA
        , string studentB, DateTime start, float hours)
    {
        string hourString = hours.ToString("N", new CultureInfo("de-DE"));
        return $"{studentA} and {studentB} have been dating since {start.ToString("dd.MM.yyyy")} - that's {hourString.Remove(hourString.Length - 1)} hours";
    }
}
