using System;
using System.Timers;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;

namespace TimerWebApplicationKevin.Model
{
    public class UserModel { }
    public class Users : BaseViewModel
    {
        Timer myTimer = new Timer(1);
        public int Id { get; set; }
        public string _currentName { get; set; }
        public string startTime { get; set; }
        private DateTime EndTime { get; set; }
        public string endTime { get; set; }
        private TimeSpan TotalTime { get; set; }
        public string totalTime { get; set; }
        private DateTime StartTime { get; set; }
        public bool isStarted = false;
        public string startButton { get; set; }
        public ICommand startCommand { get; set; }
        public Users()
        {
            startCommand = new DelegateCommand(StartCommand);
            startButton = "Start";
        }
        private void Form_Load()
        {
            myTimer.Elapsed += UpdateEndTime;
            myTimer.Start();
            myTimer.Enabled = isStarted;
        }
        private void UpdateEndTime(Object source, ElapsedEventArgs e)
        {
            EndTime = DateTime.Now;
            TotalTime = EndTime.Subtract(StartTime);

            endTime = EndTime.ToString("HH:mm:ss:fff");
            totalTime = TotalTime.ToString();
            OnPropertyChanged(nameof(endTime));
            OnPropertyChanged(nameof(totalTime));
        }
        private void StartCommand()
        {
            Console.WriteLine("Hello");
            isStarted = !isStarted;
            if (isStarted)
            {
                startButton = "Stop";
                startTime = DateTime.Now.ToString("HH:mm:ss:fff");
                StartTime = DateTime.Now;
            }
            else
            {
                startButton = "Start";
                EndTime = DateTime.Now;
                TotalTime = EndTime.Subtract(StartTime);

                endTime = EndTime.ToString("HH:mm:ss:fff");
                totalTime = TotalTime.ToString();
            }
            Form_Load();
            OnPropertyChanged(nameof(startButton));
            OnPropertyChanged(nameof(endTime));
            OnPropertyChanged(nameof(startTime));
            OnPropertyChanged(nameof(totalTime));
        }
    }
}
