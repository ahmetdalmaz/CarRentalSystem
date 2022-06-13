
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.UI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        UserManager userManager = new UserManager(new EfUserDal());
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        CarManager carManager = new CarManager(new EfCarDal());
      
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            User user = LoginCache.User;
            labelName.Text = user.Name.ToUpper() + " " + user.Surname.ToUpper();
            LoadData();

            
        }

        

        public void LoadData() 
        {
            CarCountCalculate();
            PriceCalculate();
           
        }

        private void PriceCalculate() 
        {

            var pastSales =  rentalManager.GetAllByDate(DateTime.Now.Month - 1).Data;
            var lastSales = rentalManager.GetAllByDate(DateTime.Now.Month).Data;

            
                  /*  label13.Text = string.Format("{0} {1} ile karşılaştırıldı", pastSales.First().DateProcessed.ToString("MMMM"), (DateTime.Now.Year).ToString());
                    label14.Text = string.Format("{0} {1} ile karşılaştırıldı", pastSales.First().DateProcessed.ToString("MMMM"), (DateTime.Now.Year).ToString());*/
           label13.Text = string.Format("{0} {1} ile karşılaştırıldı", DateTime.Now.AddMonths(-1).ToString("MMMM"), (DateTime.Now.Year).ToString());
           label14.Text = string.Format("{0} {1} ile karşılaştırıldı", DateTime.Now.AddMonths(-1).ToString("MMMM"), (DateTime.Now.Year).ToString());

            double pastSalesTotal = 0, lastSalesTotal = 0, pastSalesCount = 0, lastSalesCount = 0;
            pastSales.ForEach(rentals => {
                pastSalesTotal += rentals.Price;
                pastSalesCount++;
                });

            lastSales.ForEach(rentals => { lastSalesTotal += rentals.Price; lastSalesCount++; });
            RentalCountCalculate(pastSalesCount, lastSalesCount);
            double compareSales = ((lastSalesTotal - pastSalesTotal) / pastSalesTotal) * 100;
            

            if (compareSales < 0)
            {

                pictureBox7.Image = Properties.Resources.arrow_angle;
                label11.Text = "%" + (int)Math.Abs(compareSales);

                label11.ForeColor = Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(80)))), ((int)(((byte)(81)))));


            }
            else if (compareSales == double.PositiveInfinity || compareSales == double.NegativeInfinity)
            {
                pictureBox7.Image = Properties.Resources.arrow_up;
                label11.Text = "%" + (int)100;
                label11.ForeColor = Color.LimeGreen;

            }
            else if (compareSales.Equals(double.NaN))
            {
                pictureBox7.Image = Properties.Resources.arrow_up;
                label11.Text = "%" + (int)0;
                label11.ForeColor = Color.LimeGreen;

            }
            else
            {
                    pictureBox7.Image = Properties.Resources.arrow_up;
                    label11.Text = "%" + (int)compareSales;
                    label11.ForeColor = Color.LimeGreen;
            }
        }

     

        private void CarCountCalculate() 
        {
            var rentalCount = rentalManager.GetRentalState("k").Data;
            var carCount = carManager.GetCarCount().Data;
            var availableCarCount = carCount - (rentalCount);
            lblAvailableCarCount.Text = availableCarCount.ToString();
            lblRentalCount.Text = rentalCount.ToString();

        }

        private void RentalCountCalculate(double previousCount, double lastCount) 
        {
            double compareCount = ((lastCount - previousCount)/previousCount)*100;

           
             if (compareCount == double.PositiveInfinity || compareCount == double.NegativeInfinity)
             {
                pictureBox6.Image = Properties.Resources.arrow_up;
                label9.Text = "%" + (int)100;
                label9.ForeColor = Color.LimeGreen;

             }
            else if (compareCount < 0)
            {

                pictureBox6.Image = Properties.Resources.arrow_angle;
                label9.Text = "%" + (int)Math.Abs(compareCount);

                label9.ForeColor = Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(80)))), ((int)(((byte)(81)))));


            }
            else if (compareCount.Equals(double.NaN))
            {
                pictureBox6.Image = Properties.Resources.arrow_up;
                label9.Text = "%" + (int)0;
                label9.ForeColor = Color.LimeGreen;

            }
            else
            {
                pictureBox6.Image = Properties.Resources.arrow_up;
                label9.Text = "%" + (int)compareCount;
                label9.ForeColor = Color.LimeGreen;
            }



        }


        private void btnCars_Click(object sender, EventArgs e)
        {
            try
            {
                FormCars formCars = new FormCars(this);
                formCars.Show();
            }
            catch (SecurityException ex)
            {
                throw;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FormProfile formProfile = new FormProfile();
            formProfile.Show();
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            FormCustomers customers = new FormCustomers(null);
            customers.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormUsers formUsers = new FormUsers();
            formUsers.Show();
        }
        
        private void btnRentals_Click(object sender, EventArgs e)
        {
            try
            {
                FormRental formRental = new FormRental(this);
                formRental.Show();
            }
            catch (SecurityException ex)
            {
                AlertUtil.Show(ex.Message, FormAlert.MessageType.Error);

            }
            
        }

        private void btnRentedCars_Click(object sender, EventArgs e)
        {
            FormRentedCars formRentedCars = new FormRentedCars(this);
            formRentedCars.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            FormStaticstics formStaticstics = new FormStaticstics();
            formStaticstics.Show();
        }
    }
}
