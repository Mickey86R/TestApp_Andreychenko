using System;
using System.Windows;

namespace TestApp_Andreychenko
{
    public partial class AddPackage : Window
    {
        public AddPackage()
        {
            InitializeComponent();
        }

        private async void addNewPackage_Click(object sender, RoutedEventArgs e)
        {
            int number = 0;
            double capacity = 0;
            double weight = 0;

            if (TryData(ref number, ref capacity, ref weight))
            {
                await Repository.AddPackage(number, capacity, weight, Convert.ToDateTime(datePicker.SelectedDate));
                this.Close();
            }
        }

        bool TryData(ref int number, ref double capacity, ref double weight)
        {
            if (!int.TryParse(numberTextBox.Text, out number))
            {
                MessageBox.Show("Номер введён неверно! (номер состоит только из цифр)");
                return false;
            }
            if (!double.TryParse(capacityTextBox.Text, out capacity))
            {
                MessageBox.Show("Грузоподъемность введена неправильно!");
                return false;
            }
            if (!double.TryParse(weightTextBox.Text, out weight))
            {
                MessageBox.Show("Масса введена неправильно!");
                return false;
            }
            if (datePicker.SelectedDate == null)
            {
                MessageBox.Show("Выберите дату производства!");
                return false;
            }

            return true;
        }
    }
}
