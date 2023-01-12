using System.Windows;
using TestApp_Andreychenko.Model;

namespace TestApp_Andreychenko
{
    public partial class AddBringing : Window
    {
        public AddBringing()
        {
            InitializeComponent();

            var voyageItems = Repository.GetVoyages().Result;
            voyageComboBox.ItemsSource = voyageItems;
            voyageComboBox.SelectedIndex = 0;

            var packageItems = Repository.GetPackages().Result;
            packageComboBox.ItemsSource = packageItems;
            packageComboBox.SelectedIndex = 0;
        }

        private async void addNewBringing_Click(object sender, RoutedEventArgs e)
        {
            var voyage = voyageComboBox.SelectedItem as Voyage;
            var package = packageComboBox.SelectedItem as Package;
            double weightBr = 0;
            double weightNet = 0;

            if (TryData(ref weightBr, ref weightNet))
            {
                await Repository.AddBringing(voyage.ID, package.ID, weightBr, weightNet);
                this.Close();
            }
        }

        bool TryData(ref double weightBrutto, ref double weightNetto)
        {
            if (!double.TryParse(bruttoTextBox.Text, out weightBrutto))
            {
                MessageBox.Show("Масса брутто введена неверно!");
                return false;
            }
            if (!double.TryParse(nettoTextBox.Text, out weightNetto))
            {
                MessageBox.Show("Масса нетто введена неверно!");
                return false;
            }
            if (weightNetto > weightBrutto)
            {
                MessageBox.Show("Масса нетто не может быть больше брутто");
                return false;
            }

            return true;
        }
    }
}
