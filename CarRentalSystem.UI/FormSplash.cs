using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.Business.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRentalSystem.UI
{
    public partial class FormSplash : Form
    {
        public FormSplash()
        {
            InitializeComponent();
            _userManager = InstanceFactory.GetInstance<IUserService>();
            CreateForm();
        }
        private void FormSplash_Load(object sender, EventArgs e)
        {
         

        }
        IUserService _userManager;
        private void FormSplash_Shown(object sender, EventArgs e)
        {

            _ = DoWork();

        }
        

        private async Task DoWork()
        {
        
            Form? form = null;
            await Task.Run(() =>
            {
                  
                    var result = _userManager.GetAdminUser().Data;
             
         
                    if (result != null)
                    {
                        FormLogin formLogin = new FormLogin();
                        form = formLogin;

                    }
                    else
                    {
                        FormRegister formRegister = new FormRegister();
                        form = formRegister;
                    }
                
              
                
            });
          
            form.Show();
       
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void CreateForm()
        {


            GraphicsPath graphicpath = new GraphicsPath();

            graphicpath.StartFigure();

            graphicpath.AddArc(0, 0, 25, 25, 180, 90);

            graphicpath.AddLine(25, 0, this.Width - 25, 0);

            graphicpath.AddArc(this.Width - 25, 0, 25, 25, 270, 90);

            graphicpath.AddLine(this.Width, 25, this.Width, this.Height - 25);

            graphicpath.AddArc(this.Width - 25, this.Height - 25, 25, 25, 0, 90);

            graphicpath.AddLine(this.Width - 25, this.Height, 25, this.Height);

            graphicpath.AddArc(0, this.Height - 25, 25, 25, 90, 90);

            graphicpath.CloseFigure();

            this.Region = new Region(graphicpath);

        }
    }

   
}
