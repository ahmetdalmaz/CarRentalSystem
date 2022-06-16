namespace CarRentalSystem.UI
{
    partial class FormRoles
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRoles));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnUpdateRole = new System.Windows.Forms.Button();
            this.btnAddRole = new System.Windows.Forms.Button();
            this.dgwRoles = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.sfDgwPermissions = new Syncfusion.WinForms.DataGrid.SfDataGrid();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbUpdate = new System.Windows.Forms.CheckBox();
            this.cmbRemove = new System.Windows.Forms.CheckBox();
            this.cmbAdd = new System.Windows.Forms.CheckBox();
            this.cmbShow = new System.Windows.Forms.CheckBox();
            this.cmbDocumentTypes = new System.Windows.Forms.ComboBox();
            this.cmbRoles = new System.Windows.Forms.ComboBox();
            this.btnUpdatePermission = new System.Windows.Forms.Button();
            this.btnAddPermission = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRoles)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDgwPermissions)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabControl1.Location = new System.Drawing.Point(0, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(704, 278);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnUpdateRole);
            this.tabPage1.Controls.Add(this.btnAddRole);
            this.tabPage1.Controls.Add(this.dgwRoles);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtRoleName);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(696, 245);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Roller";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnUpdateRole
            // 
            this.btnUpdateRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.btnUpdateRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnUpdateRole.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdateRole.Location = new System.Drawing.Point(218, 128);
            this.btnUpdateRole.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdateRole.Name = "btnUpdateRole";
            this.btnUpdateRole.Size = new System.Drawing.Size(152, 45);
            this.btnUpdateRole.TabIndex = 80;
            this.btnUpdateRole.Text = "Güncelle";
            this.btnUpdateRole.UseVisualStyleBackColor = false;
            this.btnUpdateRole.Click += new System.EventHandler(this.btnUpdateRole_Click);
            // 
            // btnAddRole
            // 
            this.btnAddRole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.btnAddRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRole.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnAddRole.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddRole.Location = new System.Drawing.Point(37, 128);
            this.btnAddRole.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddRole.Name = "btnAddRole";
            this.btnAddRole.Size = new System.Drawing.Size(152, 45);
            this.btnAddRole.TabIndex = 79;
            this.btnAddRole.Text = "Ekle";
            this.btnAddRole.UseVisualStyleBackColor = false;
            this.btnAddRole.Click += new System.EventHandler(this.btnAddRole_Click);
            // 
            // dgwRoles
            // 
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.dgwRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwRoles.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.dgwRoles.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgwRoles.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(80)))), ((int)(((byte)(81)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwRoles.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgwRoles.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgwRoles.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgwRoles.EnableHeadersVisualStyles = false;
            this.dgwRoles.Location = new System.Drawing.Point(390, 6);
            this.dgwRoles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgwRoles.Name = "dgwRoles";
            this.dgwRoles.ReadOnly = true;
            this.dgwRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwRoles.Size = new System.Drawing.Size(290, 200);
            this.dgwRoles.TabIndex = 78;
            this.dgwRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRoles_CellClick);
            this.dgwRoles.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgwRoles_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(26, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "Rol Adı";
            // 
            // txtRoleName
            // 
            this.txtRoleName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtRoleName.Location = new System.Drawing.Point(143, 51);
            this.txtRoleName.Margin = new System.Windows.Forms.Padding(5);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.Size = new System.Drawing.Size(181, 26);
            this.txtRoleName.TabIndex = 76;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.sfDgwPermissions);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.cmbUpdate);
            this.tabPage2.Controls.Add(this.cmbRemove);
            this.tabPage2.Controls.Add(this.cmbAdd);
            this.tabPage2.Controls.Add(this.cmbShow);
            this.tabPage2.Controls.Add(this.cmbDocumentTypes);
            this.tabPage2.Controls.Add(this.cmbRoles);
            this.tabPage2.Controls.Add(this.btnUpdatePermission);
            this.tabPage2.Controls.Add(this.btnAddPermission);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(696, 245);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Rol Yetkileri";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // sfDgwPermissions
            // 
            this.sfDgwPermissions.AccessibleName = "Table";
            this.sfDgwPermissions.AllowFiltering = true;
            this.sfDgwPermissions.Location = new System.Drawing.Point(373, 16);
            this.sfDgwPermissions.Name = "sfDgwPermissions";
            this.sfDgwPermissions.ShowGroupDropArea = true;
            this.sfDgwPermissions.Size = new System.Drawing.Size(320, 211);
            this.sfDgwPermissions.Style.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.sfDgwPermissions.Style.CheckBoxStyle.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDgwPermissions.Style.CheckBoxStyle.CheckedBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDgwPermissions.Style.CheckBoxStyle.IndeterminateBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDgwPermissions.Style.HyperlinkStyle.DefaultLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.sfDgwPermissions.TabIndex = 93;
            this.sfDgwPermissions.Text = "sfDataGrid1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(20, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 92;
            this.label3.Text = "Sayfa";
            // 
            // cmbUpdate
            // 
            this.cmbUpdate.AutoSize = true;
            this.cmbUpdate.Location = new System.Drawing.Point(122, 146);
            this.cmbUpdate.Name = "cmbUpdate";
            this.cmbUpdate.Size = new System.Drawing.Size(108, 24);
            this.cmbUpdate.TabIndex = 91;
            this.cmbUpdate.Text = "Güncelleme";
            this.cmbUpdate.UseVisualStyleBackColor = true;
            // 
            // cmbRemove
            // 
            this.cmbRemove.AutoSize = true;
            this.cmbRemove.Location = new System.Drawing.Point(262, 116);
            this.cmbRemove.Name = "cmbRemove";
            this.cmbRemove.Size = new System.Drawing.Size(65, 24);
            this.cmbRemove.TabIndex = 90;
            this.cmbRemove.Text = "Silme";
            this.cmbRemove.UseVisualStyleBackColor = true;
            // 
            // cmbAdd
            // 
            this.cmbAdd.AutoSize = true;
            this.cmbAdd.Location = new System.Drawing.Point(153, 116);
            this.cmbAdd.Name = "cmbAdd";
            this.cmbAdd.Size = new System.Drawing.Size(77, 24);
            this.cmbAdd.TabIndex = 89;
            this.cmbAdd.Text = "Ekleme";
            this.cmbAdd.UseVisualStyleBackColor = true;
            // 
            // cmbShow
            // 
            this.cmbShow.AutoSize = true;
            this.cmbShow.Location = new System.Drawing.Point(20, 116);
            this.cmbShow.Name = "cmbShow";
            this.cmbShow.Size = new System.Drawing.Size(118, 24);
            this.cmbShow.TabIndex = 88;
            this.cmbShow.Text = "Görüntüleme";
            this.cmbShow.UseVisualStyleBackColor = true;
            this.cmbShow.CheckStateChanged += new System.EventHandler(this.cmbShow_CheckStateChanged);
            // 
            // cmbDocumentTypes
            // 
            this.cmbDocumentTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDocumentTypes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbDocumentTypes.FormattingEnabled = true;
            this.cmbDocumentTypes.Items.AddRange(new object[] {
            "Araçlar"});
            this.cmbDocumentTypes.Location = new System.Drawing.Point(119, 73);
            this.cmbDocumentTypes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbDocumentTypes.Name = "cmbDocumentTypes";
            this.cmbDocumentTypes.Size = new System.Drawing.Size(181, 28);
            this.cmbDocumentTypes.TabIndex = 87;
            this.cmbDocumentTypes.SelectedValueChanged += new System.EventHandler(this.cmbDocumentTypes_SelectedValueChanged);
            // 
            // cmbRoles
            // 
            this.cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRoles.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRoles.FormattingEnabled = true;
            this.cmbRoles.Location = new System.Drawing.Point(119, 23);
            this.cmbRoles.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbRoles.Name = "cmbRoles";
            this.cmbRoles.Size = new System.Drawing.Size(181, 28);
            this.cmbRoles.TabIndex = 86;
            // 
            // btnUpdatePermission
            // 
            this.btnUpdatePermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.btnUpdatePermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdatePermission.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnUpdatePermission.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUpdatePermission.Location = new System.Drawing.Point(211, 182);
            this.btnUpdatePermission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnUpdatePermission.Name = "btnUpdatePermission";
            this.btnUpdatePermission.Size = new System.Drawing.Size(152, 45);
            this.btnUpdatePermission.TabIndex = 85;
            this.btnUpdatePermission.Text = "Güncelle";
            this.btnUpdatePermission.UseVisualStyleBackColor = false;
            // 
            // btnAddPermission
            // 
            this.btnAddPermission.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            this.btnAddPermission.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddPermission.Font = new System.Drawing.Font("Segoe UI", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.btnAddPermission.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAddPermission.Location = new System.Drawing.Point(30, 182);
            this.btnAddPermission.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnAddPermission.Name = "btnAddPermission";
            this.btnAddPermission.Size = new System.Drawing.Size(152, 45);
            this.btnAddPermission.TabIndex = 84;
            this.btnAddPermission.Text = "Ekle";
            this.btnAddPermission.UseVisualStyleBackColor = false;
            this.btnAddPermission.Click += new System.EventHandler(this.btnAddPermission_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Black", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(63)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(20, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 82;
            this.label2.Text = "Rol Adı";
            // 
            // FormRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 279);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRoles";
            this.Text = "Araç Kiralama Sistemi";
            this.Load += new System.EventHandler(this.FormRoles_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwRoles)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sfDgwPermissions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private Button btnUpdateRole;
        private Button btnAddRole;
        private DataGridView dgwRoles;
        private Label label1;
        private TextBox txtRoleName;
        private TabPage tabPage2;
        private Button btnUpdatePermission;
        private Button btnAddPermission;
        private Label label2;
        private Label label3;
        private CheckBox cmbUpdate;
        private CheckBox cmbRemove;
        private CheckBox cmbAdd;
        private CheckBox cmbShow;
        private ComboBox cmbDocumentTypes;
        private ComboBox cmbRoles;
        private Syncfusion.WinForms.DataGrid.SfDataGrid sfDgwPermissions;
    }
}