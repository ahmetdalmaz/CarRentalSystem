namespace CarRentalSystem.UI
{
    partial class FormStaticstics
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
      private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStaticstics));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioMonth = new System.Windows.Forms.RadioButton();
            this.radioDay = new System.Windows.Forms.RadioButton();
            this.cmbStaticstic = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGraph = new System.Windows.Forms.Button();
            this.chartControl1 = new Syncfusion.Windows.Forms.Chart.ChartControl();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1036, 59);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(419, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 47);
            this.label1.TabIndex = 2;
            this.label1.Text = "İSTATİSTİKLER";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(825, 240);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Başlangıç Tarihi";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker2.Location = new System.Drawing.Point(773, 278);
            this.dateTimePicker2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(264, 25);
            this.dateTimePicker2.TabIndex = 95;
            this.dateTimePicker2.Value = new System.DateTime(2022, 6, 12, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(848, 340);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 98;
            this.label2.Text = "Bitiş Tarihi";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.dateTimePicker1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dateTimePicker1.Location = new System.Drawing.Point(773, 380);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(264, 25);
            this.dateTimePicker1.TabIndex = 97;
            this.dateTimePicker1.Value = new System.DateTime(2022, 6, 12, 0, 0, 0, 0);
            // 
            // radioMonth
            // 
            this.radioMonth.AutoSize = true;
            this.radioMonth.Font = new System.Drawing.Font("Segoe UI Black", 11F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.radioMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.radioMonth.Location = new System.Drawing.Point(773, 77);
            this.radioMonth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioMonth.Name = "radioMonth";
            this.radioMonth.Size = new System.Drawing.Size(114, 24);
            this.radioMonth.TabIndex = 99;
            this.radioMonth.TabStop = true;
            this.radioMonth.Text = "Aylara Göre";
            this.radioMonth.UseVisualStyleBackColor = true;
            this.radioMonth.CheckedChanged += new System.EventHandler(this.radioMonth_CheckedChanged);
            // 
            // radioDay
            // 
            this.radioDay.AutoSize = true;
            this.radioDay.Font = new System.Drawing.Font("Segoe UI Black", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.radioDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.radioDay.Location = new System.Drawing.Point(907, 77);
            this.radioDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.radioDay.Name = "radioDay";
            this.radioDay.Size = new System.Drawing.Size(121, 24);
            this.radioDay.TabIndex = 100;
            this.radioDay.TabStop = true;
            this.radioDay.Text = "Günlere Göre";
            this.radioDay.UseVisualStyleBackColor = true;
            this.radioDay.CheckedChanged += new System.EventHandler(this.radioDay_CheckedChanged);
            // 
            // cmbStaticstic
            // 
            this.cmbStaticstic.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaticstic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbStaticstic.FormattingEnabled = true;
            this.cmbStaticstic.Items.AddRange(new object[] {
            "Toplam Gelir"});
            this.cmbStaticstic.Location = new System.Drawing.Point(762, 180);
            this.cmbStaticstic.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbStaticstic.Name = "cmbStaticstic";
            this.cmbStaticstic.Size = new System.Drawing.Size(255, 28);
            this.cmbStaticstic.TabIndex = 102;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(825, 134);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 20);
            this.label3.TabIndex = 101;
            this.label3.Text = "İstatistik Ölçütü";
            // 
            // btnGraph
            // 
            this.btnGraph.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.btnGraph.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGraph.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnGraph.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGraph.Location = new System.Drawing.Point(803, 432);
            this.btnGraph.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnGraph.Name = "btnGraph";
            this.btnGraph.Size = new System.Drawing.Size(201, 48);
            this.btnGraph.TabIndex = 103;
            this.btnGraph.Text = "Grafiğe Aktar";
            this.btnGraph.UseVisualStyleBackColor = false;
            this.btnGraph.Click += new System.EventHandler(this.btnGraph_Click);
            // 
            // chartControl1
            // 
            this.chartControl1.ChartArea.CursorLocation = new System.Drawing.Point(0, 0);
            this.chartControl1.ChartArea.CursorReDraw = false;
            this.chartControl1.IsWindowLess = false;
            // 
            // 
            // 
            this.chartControl1.Legend.Location = new System.Drawing.Point(616, 75);
            this.chartControl1.Localize = null;
            this.chartControl1.Location = new System.Drawing.Point(12, 90);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PrimaryXAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl1.PrimaryXAxis.Margin = true;
            this.chartControl1.PrimaryYAxis.LogLabelsDisplayMode = Syncfusion.Windows.Forms.Chart.LogLabelsDisplayMode.Default;
            this.chartControl1.PrimaryYAxis.Margin = true;
            this.chartControl1.Size = new System.Drawing.Size(725, 390);
            this.chartControl1.TabIndex = 104;
            this.chartControl1.Text = "Grafik";
            // 
            // 
            // 
            this.chartControl1.Title.Name = "Default";
            this.chartControl1.Titles.Add(this.chartControl1.Title);
            this.chartControl1.VisualTheme = "";
            // 
            // FormStaticstics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1042, 504);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.btnGraph);
            this.Controls.Add(this.cmbStaticstic);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioDay);
            this.Controls.Add(this.radioMonth);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormStaticstics";
            this.Text = "Araç Kiralama Sistemi";
            this.Load += new System.EventHandler(this.FormStaticstics_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

   
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioMonth;
        private System.Windows.Forms.RadioButton radioDay;
        private System.Windows.Forms.ComboBox cmbStaticstic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGraph;
        private Syncfusion.Windows.Forms.Chart.ChartControl chartControl1;
    }
}