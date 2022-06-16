using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
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
    public partial class FormRoles : Form
    {

        enum AddingState 
        {
            add,
            update,
            delete,
            show
        }


        FormUsers _formUsers;
        public FormRoles(FormUsers formUsers)
        {
            InitializeComponent();
            _formUsers = formUsers;
            _roleClaimManager = InstanceFactory.GetInstance<IRoleClaimService>();
        }
        IRoleClaimService _roleClaimManager;
        RoleManager operationClaimManager = new RoleManager(new EfRoleDal());
        private void FormRoles_Load(object sender, EventArgs e)
        {
            LoadData();

        }

       

        private void LoadData() 
        {

            cmbDocumentTypes.DataSource = FillComboBox().ToList();
            cmbDocumentTypes.ValueMember = "Key";
            cmbDocumentTypes.DisplayMember = "Value";

            sfDgwPermissions.DataSource = _roleClaimManager.GetRoleClaims().Data;
            sfDgwPermissions.Columns["ClaimName"].FilterPredicates.Add(new Syncfusion.Data.FilterPredicate { FilterType = Syncfusion.Data.FilterType.StartsWith, FilterValue = (string)cmbDocumentTypes.SelectedValue, FilterBehavior = Syncfusion.Data.FilterBehavior.StringTyped });


            dgwRoles.DataSource = operationClaimManager.GetOperationClaims().Data;
            cmbRoles.DataSource = operationClaimManager.GetOperationClaims().Data;
            cmbRoles.ValueMember = "RoleId";
            cmbRoles.DisplayMember = "Name";


            
        }

       

        private IDictionary<string,string> FillComboBox() 
        {
            IDictionary<string,string> data = new Dictionary<string,string>();
            data.Add("car", "Araçlar");
            data.Add("customer", "Müşteriler");
            data.Add("rental", "Sözleşme");
            data.Add("user", "Kullanıcılar");
            data.Add("statistic", "İstatistikler");
            data.Add("rented", "Kiralanan Araçlar");
            data.Add("carsettings", "Ayarlar");
            data.Add("role", "Yetkiler");
            return data;
        }


        private void btnAddRole_Click(object sender, EventArgs e)
        {
            operationClaimManager.Add(new Entities.Concrete.Role { Name = txtRoleName.Text });
            LoadData();
            _formUsers.LoadData();
            AlertUtil.Show("Rol Eklendi !", FormAlert.MessageType.Success);
        }
        int id = 0;
        private void dgwRoles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoleName.Text = dgwRoles.CurrentRow.Cells[1].Value.ToString();
            id = (int)dgwRoles.CurrentRow.Cells[0].Value;
        }

        private void dgwRoles_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Rol Silme", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                operationClaimManager.Delete(new Entities.Concrete.Role { RoleId = (int)dgwRoles.CurrentRow.Cells[0].Value });
                LoadData();
                AlertUtil.Show("Rol Silindi", FormAlert.MessageType.Success);
                _formUsers.LoadData();

            }

        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            operationClaimManager.Update(new Entities.Concrete.Role { RoleId = id, Name = txtRoleName.Text });
            LoadData();
            AlertUtil.Show("Rol Güncellendi", FormAlert.MessageType.Success);
            _formUsers.LoadData();
        }

        public enum PermissionState 
        {
            view,
            add,
            update,
            delete
        }


        private void btnAddPermission_Click(object sender, EventArgs e)
        {
            List<CheckBox> checkBoxes = new List<CheckBox>();
            List<RoleClaim> roleClaims = new List<RoleClaim>();
            checkBoxes.Add(cmbAdd);
            checkBoxes.Add(cmbRemove);
            checkBoxes.Add(cmbShow);
            checkBoxes.Add(cmbUpdate);
            string selectedValue = (string)cmbDocumentTypes.SelectedValue;
            foreach (var checkBox in checkBoxes)
            {
                if (cmbAdd.Checked && checkBox == cmbAdd)
                {
                    roleClaims.Add(new RoleClaim { Name = selectedValue + ".add", RoleId = (int)cmbRoles.SelectedValue });


                }
                else if (cmbRemove.Checked && checkBox == cmbRemove) { roleClaims.Add(new RoleClaim { Name = selectedValue + ".delete", RoleId = (int)cmbRoles.SelectedValue }); }
                else if (cmbShow.Checked && checkBox == cmbShow) { roleClaims.Add(new RoleClaim { Name = selectedValue + ".view", RoleId = (int)cmbRoles.SelectedValue }); }
                else if(cmbUpdate.Checked && checkBox == cmbUpdate) { roleClaims.Add(new RoleClaim { Name = selectedValue + ".update", RoleId = (int)cmbRoles.SelectedValue }); }
            }
            _roleClaimManager.Add(roleClaims);
            LoadData();
            AlertUtil.Show("Başarıyla Yetkilendirildi", FormAlert.MessageType.Success);
        }
     
        private void cmbShow_CheckStateChanged(object sender, EventArgs e)
        {
           
        }

        private void cmbDocumentTypes_SelectedValueChanged(object sender, EventArgs e)
        {
            

            if (sfDgwPermissions.Columns["ClaimName"] !=null)
            {
                sfDgwPermissions.Columns["ClaimName"].FilterPredicates.Clear();
                sfDgwPermissions.Columns["ClaimName"].FilterPredicates.Add(new Syncfusion.Data.FilterPredicate { FilterType = Syncfusion.Data.FilterType.StartsWith, FilterValue = (string)cmbDocumentTypes.SelectedValue, FilterBehavior = Syncfusion.Data.FilterBehavior.StringTyped });


            }

        }
    }
}
