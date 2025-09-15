class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        int[] lastWeek = { 0, 2, 5, 3, 7, 8, 4 };
        return lastWeek;
    }

    public int Today() => birdsPerDay[birdsPerDay.Length - 1];

    public void IncrementTodaysCount() => birdsPerDay[birdsPerDay.Length - 1]++;

    public bool HasDayWithoutBirds() => Array.Exists(birdsPerDay, count => count == 0);

    public int CountForFirstDays(int numberOfDays)
    {
        int counter = 0;
        for(int i = 0; i < numberOfDays; i++)
        {
            counter += birdsPerDay[i];
        }
        return counter;
    }

    public int BusyDays()
    {
        int counter = 0;
        foreach(int count in birdsPerDay)
        {
            if(count >= 5)
            {
                counter++;
            }
        }
        return counter;
    }
}
