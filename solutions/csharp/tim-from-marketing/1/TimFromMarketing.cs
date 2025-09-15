static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        if(id == null && department == null)
        {
            return $"{name} - OWNER";
        }
        else if(department == null)
        {
            return $"[{id}] - {name} - OWNER";
        }
        else if(id == null)
        {
            string upperVer = department.ToUpper();
            return $"{name} - {upperVer}";
        }
        else
        {
            string upperVer = department.ToUpper();
            return $"[{id}] - {name} - {upperVer}";
        }
    }
}
