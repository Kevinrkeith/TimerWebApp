using System;

namespace TimerWebApplicationKevin.Model
{
    public class TimerModel { }

    public class TimerModelLogic
    {

        public string _currentName { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public DateTime intervalEnd { get; set; }
        public DateTime intervalStart { get; set; }
        public TimeSpan intervalTotal { get; set; }
        public TimeSpan totalTime { get; set; }

    }
}
