using System;

namespace DigitalClock
{
    class Program
    {
        
        static void Main(string[] args)
        {
            ClockPublisher clockPublisher = new ClockPublisher();
            ClockSubcriber clockSubscriber = new ClockSubcriber();
            clockSubscriber.Subcribe(clockPublisher);

            clockPublisher.Run();
        }
    }
}
