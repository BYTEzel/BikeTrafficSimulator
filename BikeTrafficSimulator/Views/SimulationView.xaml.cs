using BikeTrafficSimulator.Models;
using BikeTrafficSimulator.ViewModels;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BikeTrafficSimulator.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class SimulationView : Page
    {
        private ViewModelLocator locator;

        public SimulationView()
        {
            InitializeComponent();
            locator = new ViewModelLocator();
        }

        public void NavigateToSimulationRun()
        {
            
            if (locator.SimulationViewModel.ValidateValues())
            {
                Frame.Navigate(typeof(SimulationResults), locator.SimulationViewModel.SimulationConfiguration);
            }
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            NavigateToSimulationRun();
        }

        private void TextBox_OnlyNumbers(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !(char.IsDigit(c) || c==','));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // Check, if the model was already instantiated before (this is the case if we navigate back from the simulation results)
            if (e.Parameter != null)
                locator.SimulationViewModel.SimulationConfiguration = e.Parameter as Simulation;
            base.OnNavigatedTo(e);
        }
    }
}
