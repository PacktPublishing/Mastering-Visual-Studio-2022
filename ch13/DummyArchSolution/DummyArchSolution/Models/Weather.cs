namespace Models;

public class Weather
{
    public float Latitude { get; set; }
    public float Longitude { get; set; }
    public float Generationtime_ms { get; set; }
    public int Utc_offset_seconds { get; set; }
    public string Timezone { get; set; }
    public string Timezone_abbreviation { get; set; }
    public float Elevation { get; set; }
    public Current_Units Current_units { get; set; }
    public Current Current { get; set; }
    public Hourly_Units Hourly_units { get; set; }
    public Hourly Hourly { get; set; }
}
