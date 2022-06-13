using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
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
    public partial class FormRental : Form
    {
        FormMain _formMain;
        private IRentalService _rentalManager;
        private IModelService _modelManager;
        private ISegmentService _segmentManager;
        private IBrandService _brandManager;
        private ICustomerService _customerManager;
        private ICarService _carManager;
        public FormRental(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;

            _rentalManager = InstanceFactory.GetInstance<IRentalService>();
            _modelManager = InstanceFactory.GetInstance<IModelService>();
            _segmentManager = InstanceFactory.GetInstance<ISegmentService>();
            _brandManager = InstanceFactory.GetInstance<IBrandService>();
            _customerManager = InstanceFactory.GetInstance<ICustomerService>();
            _carManager = InstanceFactory.GetInstance<ICarService>();

        }
        

        
        User user = LoginCache.User;
        private void FormRental_Load(object sender, EventArgs e)
        {
            dateTimePickerRental.MinDate = DateTime.Now;
            dateTimePickerReturn.MinDate = DateTime.Now;

            LoadData();
            LoadSegments();
            LoadBrands();
            Search();
           
           


        }

        
        public async void Search() 
        {

            var result = await _rentalManager.GetAvailableCars(DateTime.Parse(dateTimePickerRental.Text), DateTime.Parse(dateTimePickerReturn.Text), cmbColors.Text, comboBoxFuelTypes.Text, null, cmbModels.Text, cmbSegments.Text);
            dgwRentals.DataSource = result.Data;
   
        }

        
        public async void LoadData() 
        {

            cmbIdentityNo.DataSource =  (await _customerManager.GetAllAsync()).Data.Where(x=>x.State==true).Select(c => new { c.CustomerId, c.IdentityNumber }).ToList();
            cmbIdentityNo.DisplayMember = "IdentityNumber";
            cmbIdentityNo.ValueMember = "CustomerId";
            cmbIdentityNo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbIdentityNo.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        public async void LoadSegments()
        {
            cmbSegments.DataSource = (await _segmentManager.GetAllAsync()).Data;
            cmbSegments.ValueMember = "SegmentId";
            cmbSegments.DisplayMember = "SegmentName";

        }
        public async void LoadBrands()
        {
            cmbBrands.DataSource = (await _brandManager.GetAllAsync()).Data;
            cmbBrands.ValueMember = "BrandId";
            cmbBrands.DisplayMember = "BrandName";
            LoadModels();

        }



        private async void LoadModels() 
        {
            Brand brand = (Brand)cmbBrands.SelectedItem;

            if (brand is not null)
            {
                cmbModels.DataSource = (await _modelManager.GetModelsByBrandId(((Brand)cmbBrands.SelectedItem).BrandId));
                cmbModels.ValueMember = "ModelId";
                cmbModels.DisplayMember = "ModelName";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void cmbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadModels();
        }

        private async void PriceCalculate() 
        {
            Segment segment = await _segmentManager.GetSegmentById(((Segment)cmbSegments.SelectedItem).SegmentId);
            double price = 0;
            int day;
          
            TimeSpan timeSpan = dateTimePickerReturn.Value - dateTimePickerRental.Value;
            day = timeSpan.Days;

            if (timeSpan.Minutes == 59)
            {
                day++;

            }
           
                
            if (timeSpan.Days<7 ||timeSpan.Days == 0)
                price = segment.DailyPrice;
            else if (timeSpan.Days >= 7 && timeSpan.Days < 30)
                price = segment.WeeklyPrice;
            else if (timeSpan.Days >= 30)
                price = segment.MonthlyPrice;
            if(timeSpan.Days == 0) 
            {
                rental.Price = timeSpan.Days+1 * price;

            }
            else
            {
                rental.Price = day * price;
            }

            
            textBox4.Text = rental.Price.ToString();


        }

        
        Customer customer;
        Rental rental = new Rental();
        private void btnNext_Click(object sender, EventArgs e)
        {

            if (dgwRentals.CurrentRow == null)
            {
                AlertUtil.Show("Lütfen Listeden Bir Araç Seçiniz..",FormAlert.MessageType.Error);
            }
            else
            {


                rental.CarId = (int)dgwRentals.CurrentRow.Cells[0].Value;
                Car car = _carManager.GetCarById(rental.CarId);
                rental.CustomerId = customer.CustomerId;
                rental.RentalDate = dateTimePickerRental.Value;
                rental.ReturnDate = dateTimePickerReturn.Value;
                rental.DateProcessed = DateTime.Now;
                rental.UserId = user.UserId;
                rental.Customer = customer;
                car.Model = new Model { ModelName = cmbModels.Text };
                car.Segment = new Segment { SegmentName = cmbSegments.Text };
                car.Model.Brand = new Brand { BrandName = cmbBrands.Text };
                rental.Car = car;



                FormCard formCard = new FormCard(rental, _formMain);

                formCard.Show();
                Hide();
            }
        }

        private void dgwRentals_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cmbBrands.SelectedIndex = cmbBrands.FindStringExact(dgwRentals.CurrentRow.Cells[2].Value.ToString());
            cmbModels.SelectedIndex = cmbModels.FindStringExact(dgwRentals.CurrentRow.Cells[3].Value.ToString());
            cmbColors.SelectedIndex = cmbColors.FindStringExact(dgwRentals.CurrentRow.Cells[4].Value.ToString());
            cmbSegments.SelectedIndex = cmbSegments.FindStringExact(dgwRentals.CurrentRow.Cells[5].Value.ToString());
            comboBoxFuelTypes.SelectedIndex = comboBoxFuelTypes.FindStringExact(dgwRentals.CurrentRow.Cells[7].Value.ToString());
            PriceCalculate();
        }

        private void cmbIdentityNo_TextChanged(object sender, EventArgs e)
        {


            if (cmbIdentityNo.Text.Length == 11)
            {
                  customer = _customerManager.GetCustomerByIdentityNumber(cmbIdentityNo.Text).Data;
                if (customer != null)
                {
                    txtName.Text = customer.Name;
                    txtSurname.Text = customer.Surname;
                    txtPhoneNumber.Text = customer.PhoneNumber;
                    txtAddress.Text = customer.Address;
                    txtMail.Text = customer.Email;

                }

            }
          

        }

        private void btnAddToCard_Click(object sender, EventArgs e)
        {

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            FormCustomers formCustomers = new FormCustomers(this);
            formCustomers.Show();
        }
    }
}
