using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.Entities.Concrete;
using Syncfusion.Windows.Forms.Chart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.UI
{
    public partial class FormStaticstics : Form
    {
        IRentalService _rentalManager;
        ICarService _carManager;
        public FormStaticstics()
        {
            InitializeComponent();
            _rentalManager = InstanceFactory.GetInstance<IRentalService>();
            _carManager = InstanceFactory.GetInstance<ICarService>();
        }
        List<Rental> rentals = null;


        private enum Liste 
        {
            [Display(Name ="Toplam Gelir")]
            totalGelir
        }
        private void btnGraph_Click(object sender, EventArgs e)
        {
            IDictionary<string,double> chartValues = new Dictionary<string, double>();
            chartValues.Clear();

            if (radioMonth.Checked)
            {

                if (cmbStaticstic.Text == "Toplam Gelir")
                {
                    var list = rentals.Where(x=>DateTime.Parse(x.RentalDate.ToString("MMMM/yyyy"))<=DateTime.Parse(dateTimePicker1.Value.ToString("MMMM/yyyy")) && DateTime.Parse(x.RentalDate.ToString("MMMM/yyyy"))>=DateTime.Parse(dateTimePicker2.Value.ToString("MMMM/yyyy"))).GroupBy(x => x.RentalDate.Month).ToList();

                    foreach (var item in list)
                    {
                        string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(item.Key);
                        double price = 0;
                        foreach (var rental in item)
                        {
                            price += rental.Price;
                        }
                        chartValues.Add(month, price);
                    }  
                    WriteChart("Aylar", chartValues, ChartValueType.Category);
                }


                else if (cmbStaticstic.Text == "Araç Satış Sayısı") 
                {
                    //CarSales();
                }

                

            }

            else if(radioDay.Checked)
            {

                if (cmbStaticstic.Text == "Toplam Gelir")
                {
                    var list = rentals.Where(x=>x.RentalDate.Date<=dateTimePicker1.Value.Date && x.RentalDate.Date>=dateTimePicker2.Value.Date).GroupBy(x => x.RentalDate.Date).ToList();

                    foreach (var item in list)
                    {
                        DateTime date = item.Key;
                        double price = 0;
                        foreach (var rental in item)
                        {
                            price += rental.Price;

                        }
                        chartValues.Add(date.ToString("d MMMM yyyy"), price);
                    }
                    WriteChart("Günler", chartValues, ChartValueType.Category);
                }

            }
             
        }
        private void WriteChart(string name, IDictionary<string,double> data,ChartValueType chartValueType) 
        {
            chartControl1.Series.Clear();
            ChartSeries chartSeries = new ChartSeries(name);
            chartSeries.SortPoints = false;
            chartControl1.PrimaryXAxis.ValueType = chartValueType;

            foreach (var item in data)
            {
                chartSeries.Points.Add(item.Key,item.Value);
            }
            chartControl1.Series.Add(chartSeries);

        }

        private void CarSales() 
        {
            ChartSeries chartSeries = new ChartSeries("Araç Sayısı");

            var list = rentals.Where(x=> DateTime.Parse(x.RentalDate.ToString("MMMM/yyyy")) <= DateTime.Parse(dateTimePicker1.Value.ToString("MMMM/yyyy")) && DateTime.Parse(x.RentalDate.ToString("MMMM/yyyy")) >= DateTime.Parse(dateTimePicker2.Value.ToString("MMMM/yyyy"))).GroupBy(x => x.RentalDate.Date).ToList();


            foreach (var item in list)
            {
              
               
                int count = 0;
                foreach (var rental in item)
                {
                    count += 1;

                }

                chartSeries.Points.Add(item.Key,count);

            }
            chartControl1.Series.Add(chartSeries);

        }


        private void CustomerCount() 
        {
            ChartSeries chartSeries = new ChartSeries("Müşteri Sayısı");




        }

        private void FormStaticstics_Load(object sender, EventArgs e)
        {
            rentals = _rentalManager.GetAllByState().Data;
            chartControl1.Series.Add(new ChartSeries());

        }

        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "MMMM/yyyy";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.MinDate = rentals[0].RentalDate;
            


            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "MMMM/yyyy";
            dateTimePicker2.ShowUpDown = true;
            dateTimePicker2.MinDate = rentals[0].RentalDate;
        }

        private void radioDay_CheckedChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.ShowUpDown = false;
            dateTimePicker2.Format = DateTimePickerFormat.Short;
            dateTimePicker2.ShowUpDown = false;
        }
    }
}
