using CarRentalSystem.Business.Concrete;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.UI
{
    public partial class FormRentedCars : Form
    {
        FormMain _formMain;
        public FormRentedCars(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;
        }

        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        private void FormRentedCars_Load(object sender, EventArgs e)
        {
            LoadData();
            btnCancel.Enabled = false;
            btnRental.Enabled = false;

        }

        private void LoadData()
        {
            sfDgwRentedCars.DataSource = rentalManager.GetRentedCars().Data;
           
        }

        

        

        int rentalId;

        private void btnCancel_Click(object sender, EventArgs e)
        {
                Rental rental = rentalManager.GetById(rentalId).Data;
                rental.State = "i";
                rentalManager.Update(rental);
                LoadData();
                AlertUtil.Show("Rezerve İşlemi İptal Edildi", FormAlert.MessageType.Success);
                _formMain.LoadData();

        }

        private void btnRental_Click(object sender, EventArgs e)
        {
            Rental rental = rentalManager.GetById(rentalId).Data;
            rental.State = "t";
            rentalManager.Update(rental);
            LoadData();
            AlertUtil.Show("Araç Teslim Alındı", FormAlert.MessageType.Success);
            _formMain.LoadData();
        }
        RentedCarsDto selectedCar;
        private void sfDgwRentedCars_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            selectedCar = (RentedCarsDto)sfDgwRentedCars.CurrentItem;
            txtCustomerTc.Text = selectedCar.CustomerIdentityNumber;
            txtCustomerName.Text = selectedCar.CustomerName;
            txtRentalDate.Text = selectedCar.RentalDate.ToString();
            txtReturnDate.Text = selectedCar.ReturnDate.ToString();
            txtCarBrand.Text = selectedCar.CarBrand;
            txtCarModel.Text = selectedCar.CarModel;
            txtCarColor.Text = selectedCar.CarColor;
            rentalId = selectedCar.RentalId;
            string rentalState = selectedCar.RentalState;
            switch (rentalState)
            {
                case "k":
                    lblRentalState.Text = "KİRADA";
                    btnCancel.Enabled = false;
                    btnRental.Enabled = true;

                    break;
                case "r":
                    lblRentalState.Text = "REZERVE";
                    btnCancel.Enabled = true;
                    btnRental.Enabled = false;
                    break;

            }

        }

        
    }
}
