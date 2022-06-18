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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.UI
{
    public partial class FormProfile : Form
    {
        public FormProfile()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager(new EfUserDal());
        User user = LoginCache.User;
        private void FormProfile_Load(object sender, EventArgs e)
        {
            
            txtTc.Text = user.IdentityNumber;
            txtEmail.Text = user.Email;
            txtAnswer.Text = user.SecurityQuestionAnswer;
            comboBoxSecurity.SelectedItem = user.SecurityQuestion;
            maskedtxtNo.Text = user.PhoneNumber;
        }

        private async void btnUpdatePassword_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text)|| string.IsNullOrEmpty(txtNewPassword.Text)|| string.IsNullOrEmpty(txtNewRePassword.Text))
            {
                AlertUtil.Show("Şifre alanları boş geçilemez..", FormAlert.MessageType.Error);
            }
            else if (txtNewPassword.Text != txtNewRePassword.Text)
            {

                AlertUtil.Show("Şifreleriniz uyuşmuyor..", FormAlert.MessageType.Error);
            }
            else
            {
                var result = userManager.UpdatePassword(user, txtCurrentPassword.Text, txtNewPassword.Text);
                if (result.IsSuccesful)
                {
                    AlertUtil.Show("Şifreniz başarı ile güncellendi!", FormAlert.MessageType.Success);
                    txtCurrentPassword.Clear();
                    txtNewPassword.Clear();
                    txtNewRePassword.Clear();
                    LoginCache.User = await userManager.GetByMail(user.Email);
                }

                else
                {
                    AlertUtil.Show(result.Message, FormAlert.MessageType.Error);
                }
            }
            
           
        }

        private async void btnUpdateUserInformation_Click(object sender, EventArgs e)
        {
            user.IdentityNumber = txtTc.Text;
            user.PhoneNumber = maskedtxtNo.Text;
            user.Email = txtEmail.Text;
            user.SecurityQuestion = comboBoxSecurity.Text;
            user.SecurityQuestionAnswer = txtAnswer.Text;
           var result= userManager.Update(user);
            if (result.IsSuccesful)
            {
                AlertUtil.Show("Bilgileriniz Güncellendi!", FormAlert.MessageType.Success);
                LoginCache.User.Email = txtEmail.Text;
                LoginCache.User =await userManager.GetByMail(user.Email);
            }
            else
            {

            }


        }
    }
}
