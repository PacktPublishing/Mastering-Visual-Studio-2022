using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring;
public class AirTraffic
{
    private readonly List<AirCraft> aircrafts = [];

    public void RegisterAircraft(AirCraft aircraft)
    {
        aircrafts.Add(aircraft);
    }

    public void SendMessage(string message, AirCraft sender)
    {
        foreach (var aircraft in aircrafts)
        {
            if (aircraft != sender)
                aircraft.ReceiveMessage(message);
        }
    }
