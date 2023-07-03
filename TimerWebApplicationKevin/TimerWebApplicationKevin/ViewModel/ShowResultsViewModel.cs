﻿using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using TimerWebApplicationKevin.Misc;
using TimerWebApplicationKevin.Model;

namespace TimerWebApplicationKevin.ViewModel
{
    public class ShowResultsViewModel : BaseViewModel
    {
        private bool started = false;
        public string _startTime { get; set; }
        public string _totalTime { get; set; }
        public string _endTime { get; set; }
        public string currentName { get; set; }
        public string _startTimer { get; private set; }
        public string _timeData { get; set; }

        public ICommand SubmitButton { get; private set; }
        public ICommand ExitButton { get; private set; }
        public ICommand StartTime { get; private set; }
        public ICommand Interval { get; private set; }
        public ICommand NavigateLoginCommand { get; set; }
        public ICommand AddUserCommand { get; set; }
        public ICommand ButtonCommand { get; set; }
        public ICommand testCommand { get; set; }
        private ObservableCollection<TimerModelLogic> timeCollection;
        private ObservableCollection<Users> userCollection;
        private int _Id;

        private void ButtonAction(int? index)
        {
            MessageBox.Show($"{index}");
        }
        public ObservableCollection<Users> UserCollection
        {
            get
            {
                return userCollection;
            }
            set
            {
                userCollection = value;
                OnPropertyChanged(nameof(userCollection));
            }
        }
        public ObservableCollection<TimerModelLogic> timerModels
        {
            get
            {
                return timeCollection;
            }

            set
            {
                timeCollection = value;
                OnPropertyChanged(nameof(timerModels));
            }
        }
        public ShowResultsViewModel(NavigationStore navi)
        {
            _startTimer = "Start Timer";
            OnPropertyChanged(nameof(_startTimer));
            ExitButton = new DelegateCommand(exitButton);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(navi, () => new LoginViewModel(navi));
            timeCollection = new ObservableCollection<TimerModelLogic>();
            userCollection = new ObservableCollection<Users>();
            AddUserCommand = new DelegateCommand(AddUser);
            _Id = 0;
        }

        private void AddUser()
        {
            userCollection.Add(new Users { Id = _Id, _currentName = this.currentName });
            _Id++;
            OnPropertyChanged(nameof(userCollection));
        }
        private void exitButton()
        {
            MessageBox.Show("GoodBye");
            Environment.Exit(0);
        }
    }
}