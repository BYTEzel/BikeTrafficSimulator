using BikeTrafficSimulator.Models;
using BikeTrafficSimulator.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BikeTrafficSimulator.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class SimulationResults : Page
    {
        private ViewModelLocator locator;
        public SimulationResults()
        {
            this.InitializeComponent();
            locator = new ViewModelLocator();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Provide the view model for the simulation with the configuration parameter
            locator.SimulationResultViewModel.SimulationConfiguration = e.Parameter as Simulation;
            locator.SimulationResultViewModel.computeSimulationResults();
            base.OnNavigatedTo(e);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(SimulationView), locator.SimulationResultViewModel.SimulationConfiguration);
        }
    }
}
