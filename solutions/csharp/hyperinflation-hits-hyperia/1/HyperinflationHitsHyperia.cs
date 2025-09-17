public static class CentralBank
{
    public static string DisplayDenomination(long @base, long multiplier)
    {
        try
        {
            checked
            {
                long sum = @base * multiplier;
                return sum.ToString();
            }
        }
        catch (OverflowException)
        {
            return "*** Too Big ***";
        }
    }

    public static string DisplayGDP(float @base, float multiplier)
    {
        float sum = @base * multiplier;
        if (float.IsInfinity(sum))
        {
            return "*** Too Big ***";
        }
        return sum.ToString();
    }

    public static string DisplayChiefEconomistSalary(decimal salaryBase, decimal multiplier)
    {
        try
        {
            decimal sum = salaryBase * multiplier;
            return sum.ToString();
        }
        catch (OverflowException)
        {
            return "*** Much Too Big ***";
        }
    }
}
