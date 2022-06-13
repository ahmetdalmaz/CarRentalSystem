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
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        FormLogin formLogin = new FormLogin();

        private void button1_Click(object sender, EventArgs e)
        {
            UserManager userManager = new UserManager(new EfUserDal());
            UserOperationClaimManager userOperationClaimManager = new UserOperationClaimManager(new EfUserOperationClaim());

           var response= userManager.Register(new Entities.Dtos.RegisterDto { Email = txtMail.Text, SecurityQuestion = cmbSecurityQuestion.Text, Password = txtPassword.Text, SecurityQuestionAnswer = txtAnswerQuestion.Text, Name = txtName.Text, Surname = txtSurname.Text, IdentityNumber = txtTc.Text, Address = txtAddress.Text, PhoneNumber = maskedtxtPhone.Text, PasswordConfirmation = txtRePassword.Text });
            if (response.IsSuccesful) 
            {
           
                AlertUtil.Show("Başarıyla Kayıt Oldunuz", FormAlert.MessageType.Success);
                User user = userManager.GetByMail(txtMail.Text);
                userOperationClaimManager.Add(new UserOperationClaim { OperationClaimId = 1, UserId = user.UserId });
                Hide();
                formLogin.Show();
            }
            else
            {
                string errors = "Lütfen doğru ve eksiksiz şekilde doldurunuz \n";
                foreach (var item in response.Errors)
                {
                    errors += item+ "\n";
                }
             
               AlertUtil.Show(errors, FormAlert.MessageType.Error);
               
            }
            


        }

        private void FormRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
