using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.Business.Utilities;
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
    public partial class FormCustomers : Form
    {
        FormRental _formRental;
        public FormCustomers(FormRental formRental)
        {
            InitializeComponent();
            _formRental = formRental;

            _customerManager = InstanceFactory.GetInstance<ICustomerService>();
            _roleClaimService = InstanceFactory.GetInstance<IRoleClaimService>();
        }
     
        private ICustomerService _customerManager;
        private IRoleClaimService _roleClaimService;
        private void FormCustomers_Load(object sender, EventArgs e)
        {
            IsFormNull();
            LoadData();
        }


    
        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimService.CheckUserRoleClaims("customer.update");
            if (claim.IsSuccesful)
            {
                var result = _customerManager.Update(new Customer { CustomerId = selectedCustomer.CustomerId, Address = txtAddress.Text, Email = txtMail.Text, IdentityNumber = txtTc.Text, Name = txtName.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Surname = txtSurname.Text, State = true });
                if (result.IsSuccesful)
                {
                    AlertUtil.Show("Güncelleme Başarılı", FormAlert.MessageType.Success);
                    LoadData();
                    _formRental.LoadData();

                }
                else
                {
                    string errors = "";
                    foreach (string error in result.Errors)
                    {
                        errors += error + "\n";
                    }
                    AlertUtil.Show(errors, FormAlert.MessageType.Error);
                }


            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
                

            
            
           
        }
        private void IsFormNull() 
        {
            if (_formRental == null)
            {
                btnAddCustomer.Visible = false; btnUpdateCustomer.Visible = false;
            }
            else
            {
                btnAddCustomer.Visible = true; btnUpdateCustomer.Visible = true;
            }
            

        }
        private void LoadData() 
        {
            
            sfDgwCustomers.DataSource = _customerManager.GetAll().Data;
            sfDgwCustomers.Style.SelectionStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            sfDgwCustomers.Style.SelectionStyle.TextColor = Color.White;
        }

       

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimService.CheckUserRoleClaims("customer.add");
            if (claim.IsSuccesful) 
            {
                var result = _customerManager.Add(new Customer { Name = txtName.Text, Email = txtMail.Text, IdentityNumber = txtTc.Text, Surname = txtSurname.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = txtAddress.Text, State = true });
                if (result.IsSuccesful)
                {
                    AlertUtil.Show("Müşteri Eklendi", FormAlert.MessageType.Success);
                    LoadData();
                    _formRental.LoadData();
                }
                else
                {
                    string errors = "";
                    foreach (string error in result.Errors)
                    {
                        errors += error + "\n";
                    }
                    AlertUtil.Show(errors, FormAlert.MessageType.Error);

                }

            }

            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
        }


        Customer selectedCustomer;
        private void sfDgwCustomers_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            selectedCustomer = (Customer)sfDgwCustomers.CurrentItem;
            txtName.Text = selectedCustomer.Name;
            txtSurname.Text = selectedCustomer.Surname;
            maskedtxtPhoneNumber.Text = selectedCustomer.PhoneNumber;
            txtMail.Text = selectedCustomer.Email;
            txtTc.Text = selectedCustomer.IdentityNumber;
            txtAddress.Text = selectedCustomer.Address;

        }

        private void sfDgwCustomers_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Araç Silme", MessageBoxButtons.YesNo);
            var claim = _roleClaimService.CheckUserRoleClaims("customer.delete");
            if (claim.IsSuccesful)
            {
                var selectedCustomer = (Customer)sfDgwCustomers.CurrentItem;

                if (dialogResult == DialogResult.Yes)
                {
                    Customer customer = _customerManager.GetCustomerById((int)selectedCustomer.CustomerId).Data;
                    customer.State = false;
                    _customerManager.Update(customer);
                    LoadData();
                    if (_formRental != null)
                        _formRental.LoadData();
                }
            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }

            
        }
    }
}
