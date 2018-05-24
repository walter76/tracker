using System;
using System.Timers;

namespace Tracker.Model
{
    class Chore
    {
        private Timer _timer;
        private DateTime _startTime;

        public string Description { get; set; }
        
        public void Start()
        {
            if (_timer == null)
            {
                _timer = new Timer(1000);
                _timer.Elapsed += OnTimedEvent;
                _timer.AutoReset = true;
            }

            _startTime = DateTime.Now;
            _timer.Enabled = true;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var elapsed = e.SignalTime.Subtract(_startTime);
            Console.WriteLine("The elapsed event was raised at {0:c}", elapsed);
        }
    }
}
