class RemoteControlCar
{
    private int _speed;
    private int _batteryDrainPercentage;
    private int _metersDriven = 0;
    private int _battery = 100;
    
    // TODO: define the constructor for the 'RemoteControlCar' class
    public RemoteControlCar(int speed, int batteryDrain)
    {
        _speed = speed;
        _batteryDrainPercentage = batteryDrain;
    }
    
    public bool BatteryDrained() => _battery < _batteryDrainPercentage;

    public int DistanceDriven() => _metersDriven;

    public void Drive()
    {
        if(_battery - _batteryDrainPercentage >= 0)
        {
            _battery -= _batteryDrainPercentage;
            _metersDriven += _speed;
        }
    }

    public static RemoteControlCar Nitro() => new RemoteControlCar(50, 4);

    public int getBattery() => _battery;
    public int getBatteryDrainPercentage() => _batteryDrainPercentage;
    public int getSpeed() => _speed;
}

class RaceTrack
{
    private int _distance;
    // TODO: define the constructor for the 'RaceTrack' class
    public RaceTrack(int distance)
    {
        _distance = distance;
    }
    public bool TryFinishTrack(RemoteControlCar car) => _distance <= ((car.getBattery() / car.getBatteryDrainPercentage()) * car.getSpeed());

}
