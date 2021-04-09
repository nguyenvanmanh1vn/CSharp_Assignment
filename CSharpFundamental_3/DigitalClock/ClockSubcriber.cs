using System;

namespace DigitalClock
{
    public class ClockSubcriber
    {
        public void Subcribe(ClockPublisher publisher)
        {
            publisher.SecondChange += new ClockPublisher.SecondChangeHandler(TimeHasChanged);
        }

        private void TimeHasChanged(ClockPublisher clockPublisher, Clock time)
        {
            Console.WriteLine($"The current time is {time.Hour} : {time.Minute} : {time.Second}");
        }
    }
}