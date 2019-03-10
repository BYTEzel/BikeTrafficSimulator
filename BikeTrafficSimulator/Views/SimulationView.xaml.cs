using BikeTrafficSimulator.ViewModels;
using System.Linq;
using Windows.UI.Xaml.Controls;

// Die Elementvorlage "Leere Seite" wird unter https://go.microsoft.com/fwlink/?LinkId=234238 dokumentiert.

namespace BikeTrafficSimulator.Views
{
    /// <summary>
    /// Eine leere Seite, die eigenständig verwendet oder zu der innerhalb eines Rahmens navigiert werden kann.
    /// </summary>
    public sealed partial class SimulationView : Page
    {
        public SimulationView()
        {
            InitializeComponent();
        }

        public void NavigateToSimulationRun()
        {
            ViewModelLocator locator = new ViewModelLocator();
            if (locator.SimulationViewModel.ValidateValues())
            {
                Frame.Navigate(typeof(SimulationResults));
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
    }
}
