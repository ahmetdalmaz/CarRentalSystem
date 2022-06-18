using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
using Syncfusion.Data;
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
            data.Add("settings", "Araç Ayarları");
            data.Add("role", "Yetkiler");
            return data;
        }


        private void btnAddRole_Click(object sender, EventArgs e)
        {

            var result = operationClaimManager.Add(new Entities.Concrete.Role { Name = txtRoleName.Text });

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
        private void UpdateCheckBox() 
        {
            cmbAdd.CheckState = CheckState.Unchecked;
            cmbRemove.CheckState = CheckState.Unchecked;
            cmbUpdate.CheckState = CheckState.Unchecked;
            cmbShow.CheckState = CheckState.Unchecked;

        }

        private void btnUpdatePermission_Click(object sender, EventArgs e)
        {
            if (selectedClaims.Count>0)
            {
                List<CheckBox> checkBoxes = new List<CheckBox>();
                List<RoleClaim> roleClaims = new List<RoleClaim>();

                string[] selectedClaimNames = new string[selectedClaims.Count];
                checkBoxes.Add(cmbAdd);
                checkBoxes.Add(cmbRemove);
                checkBoxes.Add(cmbShow);
                checkBoxes.Add(cmbUpdate);
                string selectedValue = (string)cmbDocumentTypes.SelectedValue;
                for (int i = 0; i < selectedClaims.Count; i++)
                {
                    selectedClaimNames[i] = selectedClaims[i].ClaimName;

                }

                foreach (var checkBox in checkBoxes)
                {
                    if (checkBox == cmbAdd)
                    {
                        if (checkBox.Checked)
                        {
                            if (!selectedClaimNames.Contains((selectedValue + ".add")))
                            {
                                _roleClaimManager.Add(new List<RoleClaim> { new RoleClaim { Name = selectedValue + ".add", RoleId = (int)cmbRoles.SelectedValue } });
                                LoadData();

                            }
                        }
                        else
                        {
                            if (selectedClaimNames.Contains((selectedValue + ".add")))
                            {
                                int claimId = selectedClaims.Find(x => x.ClaimName == (selectedValue + ".add")).RoleClaimId;
                                _roleClaimManager.Delete(new List<RoleClaim> { new RoleClaim { RoleClaimId = claimId } });
                                LoadData();

                            }
                        }
                    }


                    else if (checkBox == cmbRemove) 
                    {
                        if (checkBox.Checked)
                        {
                            if (!selectedClaimNames.Contains((selectedValue + ".delete")))
                            {
                                _roleClaimManager.Add(new List<RoleClaim> { new RoleClaim { Name = selectedValue + ".delete", RoleId = (int)cmbRoles.SelectedValue } });
                                LoadData();

                            }
                        }
                        else
                        {
                            if (selectedClaimNames.Contains((selectedValue + ".delete")))
                            {
                                int claimId = selectedClaims.Find(x => x.ClaimName == (selectedValue + ".delete")).RoleClaimId;
                                _roleClaimManager.Delete(new List<RoleClaim> { new RoleClaim { RoleClaimId = claimId } });
                                LoadData();

                            }
                        }

                    }
                    else if (checkBox == cmbShow) 
                    {
                        if (checkBox.Checked)
                        {
                            if (!selectedClaimNames.Contains((selectedValue + ".view")))
                            {
                                _roleClaimManager.Add(new List<RoleClaim> { new RoleClaim { Name = selectedValue + ".view", RoleId = (int)cmbRoles.SelectedValue } });
                                LoadData();

                            }
                        }
                        else
                        {
                            if (selectedClaimNames.Contains((selectedValue + ".view")))
                            {
                                int claimId = selectedClaims.Find(x => x.ClaimName == (selectedValue + ".view")).RoleClaimId;
                                _roleClaimManager.Delete(new List<RoleClaim> { new RoleClaim { RoleClaimId = claimId } });
                                LoadData();

                            }
                        }
                    }
                    else if (checkBox == cmbUpdate) 
                    {
                        if (checkBox.Checked)
                        {
                            if (!selectedClaimNames.Contains((selectedValue + ".update")))
                            {
                                _roleClaimManager.Add(new List<RoleClaim> { new RoleClaim { Name = selectedValue + ".update", RoleId = (int)cmbRoles.SelectedValue } });
                                LoadData();

                            }
                        }
                        else
                        {
                            if (selectedClaimNames.Contains((selectedValue + ".update")))
                            {
                                int claimId = selectedClaims.Find(x => x.ClaimName == (selectedValue + ".update")).RoleClaimId;
                                _roleClaimManager.Delete(new List<RoleClaim> { new RoleClaim { RoleClaimId = claimId } });
                                LoadData();

                            }
                        }

                    }
                }
                AlertUtil.Show("Yetki Güncellendi", FormAlert.MessageType.Success);
                selectedClaims.Clear();
            }
            else
            {
                AlertUtil.Show("Lüften listeden seçim yapın", FormAlert.MessageType.Warning);
            }




        }
        List<RoleClaimDto> selectedClaims = new List<RoleClaimDto>();
        private void sfDgwPermissions_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            UpdateCheckBox();
            selectedClaims.Clear();
            sfDgwPermissions.SelectAll();
            RecordsList records = sfDgwPermissions.View.Records;
          
            foreach (var item in records.GetSource())
            {
                RoleClaimDto claim = (RoleClaimDto)item;
                selectedClaims.Add(claim);
            }
            

        
            if (selectedClaims.Count>0)
            {

                foreach (var item in selectedClaims)
                {

                    string[] items = item.ClaimName.Split(".");
                    string state = items[1];
                    switch (state)
                    {
                        case "add":
                            cmbAdd.Checked = true;
                            break;
                        case "update":
                            cmbUpdate.Checked = true;
                            break;
                        case "delete":
                            cmbRemove.Checked = true;
                            break;
                        case "view":
                            cmbShow.Checked = true;
                            break;
                    }


                }


                cmbRoles.SelectedIndex = cmbRoles.FindStringExact(selectedClaims[0].RoleName);

            }
            
            


        }

        private void cmbRoles_SelectedValueChanged(object sender, EventArgs e)
        {
            if (sfDgwPermissions.Columns["RoleName"] != null)
            {
                sfDgwPermissions.Columns["RoleName"].FilterPredicates.Clear();
                sfDgwPermissions.Columns["RoleName"].FilterPredicates.Add(new Syncfusion.Data.FilterPredicate { FilterType = Syncfusion.Data.FilterType.StartsWith, FilterValue = ((Role)cmbRoles.SelectedItem).Name, FilterBehavior = Syncfusion.Data.FilterBehavior.StringTyped });


            }
        }
    }
}
