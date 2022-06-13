using CarRentalSystem.UI.Properties;
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
    public partial class FormAlert : Form
    {
        public FormAlert()
        {
            InitializeComponent();
        }

        public enum AlertAction 
        {
         
            start,
            wait,
            close
        }

        public enum MessageType 
        {
            Success,
            Error,
            Warning
           
        }

        private AlertAction action;
        private int x, y;
        private const int maxWidth = 418;
      


   
        



        public void ShowAlert(string message, MessageType type) 
        {
            TopMost = true;
            Opacity = 0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            for (int i = 1; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                FormAlert frm = (FormAlert)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width + 15;
                    this.y = Screen.PrimaryScreen.WorkingArea.Height - this.Height * i - 5 * i;
                    this.Location = new Point(this.x, this.y);
                    break;

                }

            }


            this.x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;


            switch (type)
            {
                case MessageType.Success:
                    this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case MessageType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case MessageType.Warning:
                    this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.lblMessage.Text = message;

            this.Show();
            this.action = AlertAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();

           


        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = AlertAction.close;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case AlertAction.wait:
                    timer1.Interval = 5000;
                    action = AlertAction.close;
                    break;
                case FormAlert.AlertAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = FormAlert.AlertAction.wait;
                        }
                    }
                    break;
                case AlertAction.close:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        private void lblMessage_Click(object sender, EventArgs e)
        {

        }

        private void FormAlert_Load(object sender, EventArgs e)
        {
            
            
           
        }
    }
}
