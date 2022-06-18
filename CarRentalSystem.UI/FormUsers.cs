using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
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
            _roleClaimManager = InstanceFactory.GetInstance<IRoleClaimService>();
        }
        UserManager userManager = new UserManager(new EfUserDal());
        RoleManager OperationClaimManager = new RoleManager(new EfRoleDal());
        private IRoleClaimService _roleClaimManager;
        private void FormUsers_Load(object sender, EventArgs e)
        {
            LoadData();
            btnUpdate.Enabled = false;  

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
            var claim = _roleClaimManager.CheckUserRoleClaims("user.add");
            if (claim.IsSuccesful) 
            {
                var result = userManager.Add(new User { Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text, RoleId = (int)comboBoxRoles.SelectedValue });

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
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
            

        }


        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("user.update");
            if (claim.IsSuccesful)
            {
                var result = userManager.Update(new User { UserId = selectedUser.UserId, Name = txtName.Text, Surname = txtSurname.Text, Email = txtMail.Text, IdentityNumber = txtINumber.Text, PhoneNumber = maskedtxtPhoneNumber.Text, Address = richTextBox1.Text, RoleId = (int)comboBoxRoles.SelectedValue, PasswordHash = selectedUser.PasswordHash, PasswordSalt = selectedUser.PasswordSalt, SecurityQuestion = selectedUser.SecurityQuestion, SecurityQuestionAnswer = selectedUser.SecurityQuestionAnswer, State = true });
                if (result.IsSuccesful)
                {
                    LoadData();
                    AlertUtil.Show("Kullanıcı Güncellendi. ", FormAlert.MessageType.Success);
                    btnUpdate.Enabled = false;
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
            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
            

        }

        private void yetkilerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("roles.view");
            if (claim.IsSuccesful)
            {
                FormRoles formRoles = new FormRoles(this);
                formRoles.Show();

            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
            
        }

        private void sfDgwUsers_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("user.delete");
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Kullanıcı Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (claim.IsSuccesful)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    User user = userManager.GetUserById(selectedUser.UserId).Data;
                    user.State = false;
                    userManager.Update(user);
                    LoadData();
                    AlertUtil.Show("Kullanıcı Silindi. ", FormAlert.MessageType.Success);
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
            

        }
        User selectedUser;
        private void sfDgwUsers_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            btnUpdate.Enabled = true;   
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
