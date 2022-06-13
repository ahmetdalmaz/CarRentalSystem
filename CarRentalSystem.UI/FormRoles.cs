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
        }

        OperationClaimManager operationClaimManager = new OperationClaimManager(new EfOperationClaimDal());
        private void FormRoles_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData() 
        {
            dgwRoles.DataSource = operationClaimManager.GetOperationClaims().Data;
            cmbRoles.DataSource = operationClaimManager.GetOperationClaims().Data;
            cmbRoles.ValueMember = "OperationClaimId";
            cmbRoles.DisplayMember = "Name";
        
        
        }

        private void btnAddRole_Click(object sender, EventArgs e)
        {
            operationClaimManager.Add(new Entities.Concrete.OperationClaim { Name = txtRoleName.Text });
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
                operationClaimManager.Delete(new Entities.Concrete.OperationClaim { OperationClaimId = (int)dgwRoles.CurrentRow.Cells[0].Value });
                LoadData();
                AlertUtil.Show("Rol Silindi", FormAlert.MessageType.Success);
                _formUsers.LoadData();

            }

        }

        private void btnUpdateRole_Click(object sender, EventArgs e)
        {
            operationClaimManager.Update(new Entities.Concrete.OperationClaim { OperationClaimId = id, Name = txtRoleName.Text });
            LoadData();
            AlertUtil.Show("Rol Güncellendi", FormAlert.MessageType.Success);
            _formUsers.LoadData();
        }

        private void btnAddPermission_Click(object sender, EventArgs e)
        {

        }
        List<UserOperationClaim> userOperationClaims = new List<UserOperationClaim>();
        private void cmbShow_CheckStateChanged(object sender, EventArgs e)
        {
            if (cmbShow.CheckState == CheckState.Checked)
            {
                userOperationClaims.Add(new UserOperationClaim { OperationClaimId = ((OperationClaim)cmbRoles.SelectedItem).OperationClaimId, UserId = 1 });

            }
            else
            {

            }
        }
    }
}
