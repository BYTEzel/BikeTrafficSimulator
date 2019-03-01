using System;
using BikeTrafficSimulator.Views;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace BikeTrafficSimulator.ViewModels
{

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        public const string SimulationPageKey = "SimulationPage";

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            
            SimpleIoc.Default.Register<SimulationViewModel>();
            Messenger.Default.Register<NotificationMessage>(this, NotifyUserMethod);
        }

        private void NotifyUserMethod(NotificationMessage obj)
        {
            throw new NotImplementedException();
        }

        public SimulationViewModel SimulationViewModel
        {
            get => ServiceLocator.Current.GetInstance<SimulationViewModel>();
        }
    }
}
