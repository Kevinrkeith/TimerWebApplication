using System;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;

namespace TimerWebApplicationKevin.Model
{
    public class UserModel { }
    public class Users : BaseViewModel
    {
        public Users()
        {
            testCommand = new DelegateCommand(TestCommand);
            startButton = "Start";
        }
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
        public ICommand testCommand { get; set; }

        private void TestCommand()
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
            OnPropertyChanged(nameof(startButton));
            OnPropertyChanged(nameof(endTime));
            OnPropertyChanged(nameof(startTime));
            OnPropertyChanged(nameof(totalTime));
        }
    }
}
