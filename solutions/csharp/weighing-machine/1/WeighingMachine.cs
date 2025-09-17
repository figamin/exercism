class WeighingMachine
{
    private int internalPrecision;
    private double weight;
    private double tareAdjustment;
    // TODO: define the 'Precision' property
    public WeighingMachine(int precision)
    {
        internalPrecision = precision;
        tareAdjustment = 5;
    }
    public int Precision
    {
        get { return internalPrecision; }
    }

    // TODO: define the 'Weight' property
    public double Weight
    {
        get { return weight; }
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            weight = value;
        }
    }

    // TODO: define the 'DisplayWeight' property
    public string DisplayWeight
    {
        get
        {
            double result = weight - tareAdjustment;
            string temp = result.ToString($"F{internalPrecision}");
            return $"{temp} kg";
        }

    }

    // TODO: define the 'TareAdjustment' property
    public double TareAdjustment
    {
        get { return tareAdjustment; }
        set
        {
            tareAdjustment = value;
        }
    }
    
}
