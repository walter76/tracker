using System;
using System.Timers;

namespace Tracker.Model
{
    class Chore
    {
        private Timer _timer;
        private DateTime _startTime;

        public string Description { get; set; }
        public string ElapsedTime { get; private set; }

        public event EventHandler Elapsed;

        public void StartStop()
        {
            if (string.IsNullOrEmpty(ElapsedTime))
            {
                ElapsedTime = "00:00:00";
            }

            if (_timer == null)
            {
                _timer = new Timer(1000);
                _timer.Elapsed += OnTimedEvent;
                _timer.AutoReset = true;
            }

            if (_timer.Enabled)
            {
                _timer.Enabled = false;
            }
            else
            {
                _startTime = DateTime.Now;
                _timer.Enabled = true;
            }
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            var elapsed = e.SignalTime.Subtract(_startTime);
            ElapsedTime = string.Format("{0,2:D2}:{1,2:D2}:{2,2:D2}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds);

            FireElapsedEvent();
        }

        private void FireElapsedEvent()
        {
            Elapsed?.Invoke(this, EventArgs.Empty);
        }
    }
}
