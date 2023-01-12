using System.Text.RegularExpressions;
using System.Windows;

namespace TestApp_Andreychenko
{
    public partial class AddAuto : Window
    {
        public AddAuto()
        {
            InitializeComponent();
        }

        private async void addNewAuto_Click(object sender, RoutedEventArgs e)
        {
            if (Regex.IsMatch(numberTextBox.Text, "^[A-Z]{1}\\d{3}[A-Z]{2}\\d{2,3}$"))
            {
                var number = Regex.Match(numberTextBox.Text, "^[A-Z]{1}\\d{3}[A-Z]{2}\\d{2,3}$").Value;

                double capacity = 0;

                if (double.TryParse(capacityTextBox.Text, out capacity))
                {
                    await Repository.AddAuto(number, capacity);

                    this.Close();
                }
                else
                    MessageBox.Show("Грузоподъемность введена неправильно!");
            }
            else
                MessageBox.Show("Номер введён неправильно! (вводятся латинские буквы)");
        }
    }
}
