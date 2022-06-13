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
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager(new EfUserDal());
        OperationClaimManager OperationClaimManager = new OperationClaimManager(new EfOperationClaimDal());
        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        public void LoadData() 
        {

            sfDgwUsers.DataSource = userManager.GetUsers().Data.Select(x => new {x.UserId, x.Name, x.Surname, x.Email, x.IdentityNumber,x.Address,x.PhoneNumber}).ToList();
            comboBoxRoles.DataSource = OperationClaimManager.GetOperationClaims().Data;
            comboBoxRoles.ValueMember = "OperationClaimId";
            comboBoxRoles.DisplayMember = "Name";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

           var result= userManager.Add(new User { Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text });
            if (result.IsSuccesful)
            {
                AlertUtil.Show(result.Message, FormAlert.MessageType.Success);
            }

            else
            {
                if (result.Errors != null)
                {

                    string errors = "";

                    foreach (var item in result.Errors)
                    {
                        errors += item + "\n";

                    }
                    AlertUtil.Show(errors, FormAlert.MessageType.Error);

                }
                else
                {
                    AlertUtil.Show(result.Message, FormAlert.MessageType.Error);
                }
            }
            LoadData();

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            userManager.Update(new User { UserId = 11, Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text, State = true});
            LoadData();
            AlertUtil.Show("Kullanıcı Güncellendi. ", FormAlert.MessageType.Success);
        }

        private void yetkilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormRoles formRoles = new FormRoles(this);
            formRoles.Show();
        }

        private void sfDgwUsers_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Kullanıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                User user = userManager.GetUserById(selectedUser.UserId).Data;
                user.State = false;
                userManager.Update(user);
                LoadData();
                AlertUtil.Show("Kullanıcı Silindi. ", FormAlert.MessageType.Success);
            }

        }
        User selectedUser;
        private void sfDgwUsers_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            var user = sfDgwUsers.CurrentItem;
          
            txtName.Text = selectedUser.Name;
            txtSurname.Text = selectedUser.Surname;
            maskedtxtPhoneNumber.Text = selectedUser.PhoneNumber;
            txtMail.Text = selectedUser.Email;
            richTextBox1.Text = selectedUser.Address;

        }
    }
}
