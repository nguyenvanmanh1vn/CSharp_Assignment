using System;

namespace DigitalClock
{
    public class Clock{
        public int Hour {get;set;}// Naming convention : PascalCase
        public int Minute {get;set;}
        public int Second {get;set;}

        public Clock(int hour, int minute, int second)// Naming convention parameter: camelCase
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }
    }
}