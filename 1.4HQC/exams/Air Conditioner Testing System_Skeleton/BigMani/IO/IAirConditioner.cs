namespace BigMani.IO
{
    public interface IAirConditioner
    {
        string Manufacturer { get; set; }

        string Model { get; set; }

        int VolumeCovered { get; set; }

        int ElectricityUsed { get; set; }

        int Test();
    }
}