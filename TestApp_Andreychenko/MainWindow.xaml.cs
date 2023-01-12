using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TestApp_Andreychenko.Model;

namespace TestApp_Andreychenko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //TestContext db;

        public MainWindow()
        {
            InitializeComponent();

            //db = new TestContext();
            autoComboBox.ItemsSource = Repository.GetAutos().Result;
            autoComboBox.SelectedIndex = 0;
        }

        private async void addAutoButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddAuto();
            window.ShowDialog();
            autoComboBox.ItemsSource = await Repository.GetAutos();
        }

        private void addPackageButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddPackage();
            window.ShowDialog();
        }

        private void addVoyageButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddVoyage();
            window.ShowDialog();
        }

        private void addBringingButton_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddBringing();
            window.ShowDialog();
        }

        async Task FillingGridView()
        {
            using (var db = new TestContext())
            {
                var currentAuto = autoComboBox.SelectedItem as Auto;

                var listVoyages = await db.Voyages.Where(v => v.AutoID == currentAuto.ID).ToListAsync<Voyage>();

                List<Bringing> listBringings = new List<Bringing>();
                foreach (var item in listVoyages)
                {

                    var list = await db.Bringings.Where(b => b.VoyageID == item.ID).ToListAsync<Bringing>();

                    foreach (var itemBr in list)
                    {
                        itemBr.Voyage = db.Voyages.First(v => v.ID == itemBr.VoyageID);
                        itemBr.Package = db.Packages.First(p => p.ID == itemBr.PackageID);
                    }

                    listBringings.AddRange(list);
                }

                dataGrid.ItemsSource = listBringings;
            }
        }

        async Task FillingChart()
        {
            chartAuto.Reset();

            using (var db = new TestContext())
            {
                var auto = autoComboBox.SelectedItem as Auto;
                var voyageList = db.Voyages.Where(v => v.AutoID == auto.ID);

                List<Bringing> bringingList = new List<Bringing>();
                foreach (var item in voyageList)
                    bringingList.AddRange(db.Bringings.Where(b => b.VoyageID == item.ID));

                foreach (var item in bringingList)
                    item.Voyage = voyageList.First(v => v.ID == item.VoyageID);

                var dates = voyageList.Select(v => v.Date).Distinct().ToList();
                List<double> sumsNetto = new List<double>();
                List<double> sumsBrutto = new List<double>();

                foreach (var item in dates)
                {

                    sumsNetto.Add(bringingList.Where(b => b.Voyage.Date == item).Select(b => b.WeightNetto).Sum());
                    sumsBrutto.Add(bringingList.Where(b => b.Voyage.Date == item).Select(b => b.WeightBrutto).Sum());
                }

                chartAuto.Plot.XAxis.DateTimeFormat(true);

                if (dates.Count != 0 && sumsNetto.Count != 0)
                {
                    var lineNetto = chartAuto.Plot.AddScatter(dates.Select(x => x.ToOADate()).ToArray(), 
                                                                sumsNetto.ToArray(), 
                                                                label: "Масса нетто");
                    lineNetto.LineColor = System.Drawing.Color.Blue;

                    var lineBrutto = chartAuto.Plot.AddScatter(dates.Select(x => x.ToOADate()).ToArray(), 
                                                                sumsBrutto.ToArray(), 
                                                                label: "Масса брутто");
                    lineBrutto.LineColor = System.Drawing.Color.Orange;

                    chartAuto.Plot.Legend();

                    chartAuto.Refresh();
                }
            }
        }

        private async void autoComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            await FillingGridView();
            await FillingChart();
        }
    }
}
