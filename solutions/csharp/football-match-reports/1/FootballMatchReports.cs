public static class PlayAnalyzer
{
    public static string AnalyzeOnField(int shirtNum)
    {
        switch (shirtNum)
        {
            case 1:
                return "goalie";
            case 2:
                return "left back";
            case 3:
            case 4:
                return "center back";
            case 5:
                return "right back";
            case 6:
            case 7:
            case 8:
                return "midfielder";
            case 9:
                return "left wing";
            case 10:
                return "striker";
            case 11:
                return "right wing";
            default:
                return "UNKNOWN";
        }
    }

    public static string AnalyzeOffField(object report)
    {
        switch (report)
        {
            case int analyzeInt:
                return $"There are {analyzeInt} supporters at the match.";
            case string analyzeString:
                return analyzeString;
            case Injury analyzeInjury:
                return $"Oh no! {analyzeInjury.GetDescription()} Medics are on the field.";
            case Incident analyzeIncident:
                return analyzeIncident.GetDescription();
            case Manager analyzeManager:
                if (analyzeManager.Club == null)
                {
                    return analyzeManager.Name;
                }
                return $"{analyzeManager.Name} ({analyzeManager.Club})";

            default:
                return String.Empty;
        }
    }
}
