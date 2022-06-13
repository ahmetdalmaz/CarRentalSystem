﻿using CarRentalSystem.Business.Concrete;
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
    public partial class FormCarSettings : Form
    {
        FormCars _formCars;
        public FormCarSettings(FormCars formCars)
        {
            InitializeComponent();
            _formCars = formCars;

        }
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        SegmentManager segmentManager = new SegmentManager(new EfSegmentDal());
        
        private void btnAddBrand_Click(object sender, EventArgs e)
        {
            brandManager.Add(new Entities.Concrete.Brand { BrandName = txtBrandName.Text, State = true});
            LoadData();
            _formCars.LoadData();
        }

        private void btnUpdateBrand_Click(object sender, EventArgs e)
        {
            brandManager.Update(new Entities.Concrete.Brand { BrandId = (int)dataGridBrands.CurrentRow.Cells[0].Value ,BrandName=txtBrandName.Text});
            LoadData();
            _formCars.LoadData();
        }

       

        private void FormCarSettings_Load(object sender, EventArgs e)
        {
            LoadData();
        }



        private void LoadData() 
        {
            dataGridBrands.DataSource = brandManager.GetBrands();
            dataGridModels.DataSource = modelManager.GetModels();
            dataGridSegments.DataSource = segmentManager.GetSegments();
            cmbBrands.DataSource = brandManager.GetBrands();
            cmbBrands.ValueMember = "BrandId";
            cmbBrands.DisplayMember = "BrandName";
        }

        private void btnAddModel_Click(object sender, EventArgs e)
        {
            modelManager.Add(new Entities.Concrete.Model { BrandId = (int)cmbBrands.SelectedValue, ModelName = txtModelName.Text });
            LoadData();
            _formCars.LoadData();

        }

        private void btnUpdateModel_Click(object sender, EventArgs e)
        {
            modelManager.Update(new Entities.Concrete.Model { ModelId = (int)dataGridModels.CurrentRow.Cells[0].Value , BrandId = (int)cmbBrands.SelectedValue, ModelName = txtModelName.Text });
            LoadData();
            _formCars.LoadData();
        }

        private void btnAddSegment_Click(object sender, EventArgs e)
        {
            segmentManager.Add(new Entities.Concrete.Segment 
            {  SegmentName = txtSegmentName.Text, MonthlyPrice = int.Parse(txtMonthlyPrice.Text), DailyPrice = int.Parse(txtDailyPrice.Text), WeeklyPrice = int.Parse(txtWeeklyPrice.Text) });
            LoadData();
            _formCars.LoadData();
        }

        private void btnUpdateSegment_Click(object sender, EventArgs e)
        {
            segmentManager.Update(new Entities.Concrete.Segment
            { SegmentId = (int)dataGridSegments.CurrentRow.Cells[0].Value, SegmentName = txtSegmentName.Text, MonthlyPrice = int.Parse(txtMonthlyPrice.Text), DailyPrice = int.Parse(txtDailyPrice.Text), WeeklyPrice = int.Parse(txtWeeklyPrice.Text) });
            LoadData();
            _formCars.LoadData();
        }

        private void dataGridBrands_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBrandName.Text = dataGridBrands.CurrentRow.Cells[1].Value.ToString();
        }

        private void dataGridBrands_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Marka Silme", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                brandManager.Delete(new Entities.Concrete.Brand { BrandId = (int)dataGridBrands.CurrentRow.Cells[0].Value });
                LoadData();
                _formCars.LoadData();
            }
            
        }

        private void dataGridModels_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtModelName.Text = dataGridModels.CurrentRow.Cells[1].Value.ToString();
            cmbBrands.SelectedValue = dataGridModels.CurrentRow.Cells[2].Value;
        }

        private void dataGridModels_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Model Silme", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                modelManager.Delete(new Entities.Concrete.Model { ModelId = (int)dataGridModels.CurrentRow.Cells[0].Value });
                LoadData();
                _formCars.LoadData();
            }
        }

        private void dataGridSegments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSegmentName.Text = dataGridSegments.CurrentRow.Cells[1].Value.ToString();
            txtDailyPrice.Text = dataGridSegments.CurrentRow.Cells[2].Value.ToString();
            txtWeeklyPrice.Text = dataGridSegments.CurrentRow.Cells[3].Value.ToString();
            txtMonthlyPrice.Text = dataGridSegments.CurrentRow.Cells[4].Value.ToString();
        }

        private void dataGridSegments_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Segment Silme", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                segmentManager.Delete(new Entities.Concrete.Segment { SegmentId = (int)dataGridSegments.CurrentRow.Cells[0].Value });
                LoadData();
                _formCars.LoadData();
            }
        }

       
    }
}
