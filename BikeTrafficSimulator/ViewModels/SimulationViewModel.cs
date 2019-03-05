﻿using BikeTrafficSimulator.Models;
using BikeTrafficSimulator.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;

namespace BikeTrafficSimulator.ViewModels
{
    public class SimulationViewModel : ViewModelBase
    {
        private string title;
        private Simulation simulationConfiguration;
        private TrafficLight currentTrafficLight;
        private Biker currentBiker;
        private string messages;

        public ICommand AddTrafficLightCommand { get; private set; }
        public ICommand DeleteTrafficLightCommand { get; private set; }
        public ICommand AddBikerCommand { get; private set; }
        public ICommand DeleteBikerCommand { get; private set; }



        public SimulationViewModel()
        {
            Title = "Simulation Configuration";
            SimulationConfiguration = new Simulation();

            AddBikerCommand           = new RelayCommand(AddBiker);
            DeleteBikerCommand        = new RelayCommand(DeleteBiker);
            AddTrafficLightCommand    = new RelayCommand(AddTrafficLight);
            DeleteTrafficLightCommand = new RelayCommand(DeleteTrafficLight);
        }

        public bool ValidateValues()
        {
            bool checkOk = true;
            Messages = string.Empty;

            if (SimulationConfiguration.Track.LengthKm <= 0)
            {
                checkOk = false;
                Messages += "Track length must be > 0.\n";
            }

            if (SimulationConfiguration.Bikers.Count <= 0)
            {
                checkOk = false;
                Messages += "Please create at least one biker.\n";
            }

            if (SimulationConfiguration.TrafficLights.Count <= 0)
            {
                checkOk = false;
                Messages += "Please create at least one traffic light.\n";
            }

            foreach (Biker biker in SimulationConfiguration.Bikers)
            {
                if (biker.Acceleration <= 0)
                {
                    checkOk = false;
                    Messages +=  biker.Name + ": Acceleration must be > 0.\n";
                }

                if (biker.VelocityMax <= 0)
                {
                    checkOk = false;
                    Messages += biker.Name + ": Maximum velocity must be > 0.\n";
                }
            }

            foreach (TrafficLight tl in SimulationConfiguration.TrafficLights) 
            {
                if (tl.TimeRedMin <= 0)
                {
                    checkOk = false;
                    Messages += tl.Name + ": Maximum red time must be > 0.\n";
                }

                if (tl.TimeGreenMin <= 0)
                {
                    checkOk = false;
                    Messages += tl.Name + ": Maximum green time must be > 0.\n";
                }
            }
            return checkOk;
        }

        private void DeleteTrafficLight()
        {
            SimulationConfiguration.TrafficLights.Remove(CurrentTrafficLight);
        }

        private void AddTrafficLight()
        {
            SimulationConfiguration.TrafficLights.Add(new TrafficLight() { Name = "Anonymus traffic light", TimeGreenMin = 10m, TimeRedMin = 2m });
        }

        private void DeleteBiker()
        {
            SimulationConfiguration.Bikers.Remove(CurrentBiker);
        }

        private void AddBiker()
        {
            SimulationConfiguration.Bikers.Add(new Biker() { Name = "Nameless Biker" });
        }

        public string Title { get => title; set => Set(() => Title, ref title, value); }
        public Simulation SimulationConfiguration { get => simulationConfiguration; set => Set(() => SimulationConfiguration, ref simulationConfiguration, value); }
        public TrafficLight CurrentTrafficLight { get => currentTrafficLight; set => Set(() => CurrentTrafficLight, ref currentTrafficLight, value); }
        public Biker CurrentBiker { get => currentBiker; set => Set(() => CurrentBiker, ref currentBiker, value); }
        public string Messages { get => messages; set => Set(() => Messages, ref messages, value); }
    }
}
