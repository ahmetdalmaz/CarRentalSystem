using CarRentalSystem.Business.Concrete;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
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
    public partial class FormForgotPassword : Form
    {
        public FormForgotPassword()
        {
            InitializeComponent();
        }
        UserManager userManager = new UserManager(new EfUserDal());
        private void btnForgotPassword_Click(object sender, EventArgs e)
        {
          var result =  userManager.ResetPassword(new Entities.Concrete.User 
            { Email = txtMail.Text, SecurityQuestion = comboBoxSecurityQuestion.Text, SecurityQuestionAnswer = txtAnswer.Text });
            if (result.IsSuccesful != true)
              
                AlertUtil.Show("Bilgileriniz uyuşmuyor..", FormAlert.MessageType.Error);

            else
            {
          
                AlertUtil.Show("Şifreniz başarıyla sıfırlandı !", FormAlert.MessageType.Success);
                Close();
            }


        }
    }
}
