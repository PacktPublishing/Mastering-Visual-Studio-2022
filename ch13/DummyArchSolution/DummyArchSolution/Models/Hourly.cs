namespace Models;

public class Hourly
{
    public string[] time { get; set; }
    public float[] temperature_2m { get; set; }
    public int[] relative_humidity_2m { get; set; }
    public float[] wind_speed_10m { get; set; }
}
