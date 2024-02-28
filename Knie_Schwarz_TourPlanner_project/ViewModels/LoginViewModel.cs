﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand((_) => {
                Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
                GreetingText = $"You have logged in, {GreetingName}!";
                Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");

                //ShowPopup_Click(sender, e);   //unsure how to implement rn
            });
        }
    }
}