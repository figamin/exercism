using System.Text;

public static class Identifier
{
    public static string Clean(string identifier)
    {
        StringBuilder cleaned = new StringBuilder();
        for (int i = 0; i < identifier.Length; i++)
        {
            if (identifier[i] == ' ')
            {
                cleaned.Append("_");
            }
            else if (Char.IsControl(identifier[i]))
            {
                cleaned.Append("CTRL");
                //i++;
            }
            else if (identifier[i] == '-')
            {
                cleaned.Append(identifier[i + 1].ToString().ToUpper());
                i++;
            }
            else if (!Char.IsLetter(identifier[i]) || (identifier[i] >= 'α' && identifier[i] <= 'ω'))
            {
                ;
            }
            else
            {
                cleaned.Append(identifier[i]);
            }
        }
        return cleaned.ToString();
    }
}
