
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.Responses;
using CarRentalSystem.Business.Utilities;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;

namespace CarRentalSystem.UI
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        FormMain formMain = new FormMain();
        UserManager userManager = new(new EfUserDal());
        private async void button1_Click(object sender, EventArgs e)
        {
            //Burada login fonksiyonuna bilgiler gönderiliyor.
             var result = userManager.LoginAsync(new Entities.Dtos.LoginDto { Email = txtMail.Text, Password = txtPassword.Text });
            if (result.IsSuccesful) //Eðer bilgiler baþarýyla doðrulandýysa buraya girer.
            {
                LoginCache.User =  await userManager.GetByMail(txtMail.Text); //Kullanýcý mail adresi ile bulunuyor.
                

                AlertUtil.Show(result.Message,FormAlert.MessageType.Success);
               
                  formMain.Show(); //ana sayfa açýlýyor.
                  Hide();


            }
            else //doðrulama baþarýsýzsa buraya gelir.
            {
                if (result.Errors !=null) 
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
               
                // MessageBox.Show(errors, "Giriþ Ýþlemi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

            }
          

            

        }

       

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.Show();
        }

      
    }
}