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
    public partial class FormUsers : Form
    {
        public FormUsers()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager(new EfUserDal());
        RoleManager OperationClaimManager = new RoleManager(new EfRoleDal());
        
        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        public void LoadData() 
        {

            sfDgwUsers.AutoGenerateColumnsMode = Syncfusion.WinForms.DataGrid.Enums.AutoGenerateColumnsMode.SmartReset;
            sfDgwUsers.DataSource = userManager.GetUsers().Data;
          
            comboBoxRoles.DataSource = OperationClaimManager.GetOperationClaims().Data;
            comboBoxRoles.ValueMember = "RoleId";
            comboBoxRoles.DisplayMember = "Name";

            sfDgwUsers.Columns["PasswordHash"].Visible = false;
            sfDgwUsers.Columns["PasswordSalt"].Visible = false;
            sfDgwUsers.Columns["Gender"].Visible = false;
            sfDgwUsers.Columns["State"].Visible = false;
            sfDgwUsers.Columns["SecurityQuestion"].Visible = false;
            sfDgwUsers.Columns["SecurityQuestionAnswer"].Visible = false;
            sfDgwUsers.Columns["RoleId"].Visible = false;

        }


        private void btnAdd_Click(object sender, EventArgs e)
        {

           var result= userManager.Add(new User { Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text,RoleId = (int)comboBoxRoles.SelectedValue });
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
            userManager.Update(new User { UserId = selectedUser.UserId, Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text, RoleId = (int)comboBoxRoles.SelectedValue, PasswordHash = selectedUser.PasswordHash, PasswordSalt = selectedUser.PasswordSalt, SecurityQuestion = selectedUser.SecurityQuestion, SecurityQuestionAnswer = selectedUser.SecurityQuestionAnswer, State = true});
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
            selectedUser= (User)sfDgwUsers.CurrentItem;
           
          
            txtName.Text = selectedUser.Name;
            txtSurname.Text = selectedUser.Surname;
            maskedtxtPhoneNumber.Text = selectedUser.PhoneNumber;
            txtMail.Text = selectedUser.Email;
            richTextBox1.Text = selectedUser.Address;
            comboBoxRoles.SelectedValue = selectedUser.RoleId;
            txtINumber.Text = selectedUser.IdentityNumber;
        }
    }
}
