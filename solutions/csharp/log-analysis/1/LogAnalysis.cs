public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string str, string delimiter) => str.Substring(str.IndexOf(delimiter) + delimiter.Length);
    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string str, string delimiter1, string delimiter2)
    {
        int startIndex = str.IndexOf(delimiter1) + delimiter1.Length;
        int endIndex = str.IndexOf(delimiter2, startIndex);
        return str.Substring(startIndex, endIndex - startIndex);
    }
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string str) => str.Substring(str.IndexOf(": ") + 2);
    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string str) => str.Substring(1, str.IndexOf(']') - 1);
}