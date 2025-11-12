// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    void Drive();
    int DistanceTravelled { get; set; }
}
public class ProductionRemoteControlCar : IRemoteControlCar, IComparable
{
    public int DistanceTravelled { get; set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(object? otherCarObject)
    {
        ProductionRemoteControlCar otherCar = otherCarObject as ProductionRemoteControlCar;
        if (otherCar == null || otherCar.NumberOfVictories < NumberOfVictories)
        {
            return 1;
        }
        else
        {
            return -1;
        }
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        int comparison = prc1.CompareTo(prc2);
        if (comparison == 1)
        {
            return new List<ProductionRemoteControlCar> { prc2, prc1 };
        }
        else
        {
            return new List<ProductionRemoteControlCar> { prc1, prc2 };
        }
    }
}
