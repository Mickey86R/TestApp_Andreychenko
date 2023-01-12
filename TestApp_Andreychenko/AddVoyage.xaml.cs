using System;
using System.Text.RegularExpressions;
using System.Windows;
using TestApp_Andreychenko.Model;

namespace TestApp_Andreychenko
{
    public partial class AddVoyage : Window
    {
        public AddVoyage()
        {
            InitializeComponent();

            var items = Repository.GetAutos().Result;

            autoComboBox.ItemsSource = items;
            autoComboBox.SelectedIndex = 0;
        }

        private async void addNewVoyage_Click(object sender, RoutedEventArgs e)
        {
            var auto = (Auto)autoComboBox.SelectedItem;

            DateTime date = new DateTime();

            if (datePicker.SelectedDate != null)
            {
                if (Regex.IsMatch(hourTextBox.Text, "^\\d{1,2}$") &&
                    Convert.ToInt32(hourTextBox.Text) < 24 &&
                    Convert.ToInt32(hourTextBox.Text) >= 0)
                {
                    date.AddHours(Convert.ToDouble(hourTextBox.Text));

                    if (Regex.IsMatch(minuteTextBox.Text, "^\\d{1,2}$") &&
                        Convert.ToInt32(minuteTextBox.Text) < 60 &&
                        Convert.ToInt32(minuteTextBox.Text) >= 0)
                    {
                        date.AddMinutes(Convert.ToDouble(minuteTextBox.Text));

                        await Repository.AddVoyage(auto.ID, date);

                        this.Close();
                    }
                    else
                        MessageBox.Show("Минуты имеют значение от 0 до 59 включительно!");
                }
                else
                    MessageBox.Show("Часы имеют значение от 0 до 23 включительно!");
            }
            else
                MessageBox.Show("Выберите дату!");
        }
    }
}
