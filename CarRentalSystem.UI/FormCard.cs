using CarRentalSystem.Business.Concrete;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
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
    public partial class FormCard : Form
    {
        Rental _rental;
        FormMain _formMain;
        public FormCard(Rental rental,FormMain formMain)
        {
            InitializeComponent();
            _rental = rental;
            _formMain = formMain;
        }
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        CarManager carManager = new CarManager(new EfCarDal());
         
        private void button1_Click(object sender, EventArgs e)
        {

            _rental.Car = null;
            _rental.Customer = null;
          
            rentalManager.Add(_rental);
            AlertUtil.Show("Araç Kiraya Verildi", FormAlert.MessageType.Success);
            _formMain.LoadData();
            Hide();
            
            
        }

        private void FormCard_Load(object sender, EventArgs e)
        {
           
            lblRental.Text = _rental.RentalDate.ToString();
            lblReturn.Text = _rental.ReturnDate.ToString();
            lblModel.Text = _rental.Car.Model.ModelName;
            lblSegment.Text = _rental.Car.Segment.SegmentName;
            lblPrice.Text = _rental.Price.ToString();
            lblBrand.Text = _rental.Car.Model.Brand.BrandName;
            
           
            lblMail.Text = _rental.Customer.Email;
            lblName.Text = _rental.Customer.Name;
            lblSurname.Text = _rental.Customer.Surname;
            lblTc.Text = _rental.Customer.IdentityNumber;
           

        }
    }
}
