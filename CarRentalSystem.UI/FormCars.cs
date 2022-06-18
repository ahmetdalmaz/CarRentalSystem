using CarRentalSystem.Business.Abstract;
using CarRentalSystem.Business.Concrete;
using CarRentalSystem.Business.DependencyResolver;
using CarRentalSystem.DataAccess.Concrete.EntityFramework;
using CarRentalSystem.Entities.Concrete;
using CarRentalSystem.Entities.Dtos;
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
    public partial class FormCars : Form
    {
        FormMain _formMain;
        public FormCars(FormMain formMain)
        {
            InitializeComponent();
            _formMain = formMain;
            carManager =   InstanceFactory.GetInstance<ICarService>();
            _roleClaimManager = InstanceFactory.GetInstance<IRoleClaimService>();

        }
        private ICarService carManager;
        IRoleClaimService _roleClaimManager;
        BrandManager brandManager = new BrandManager(new EfBrandDal());
        ModelManager modelManager = new ModelManager(new EfModelDal());
        SegmentManager segmentManager = new SegmentManager(new EfSegmentDal());
        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("settings.view");
            if (claim.IsSuccesful)
            {
                FormCarSettings formCarSettings = new FormCarSettings(this);
                formCarSettings.Show();
            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
            
        }

        private void FormCars_Load(object sender, EventArgs e)
        {
            LoadData();

        }


        public async void LoadData() 
        {
            comboBoxBrands.DataSource =(await brandManager.GetAllAsync()).Data;
            comboBoxBrands.ValueMember = "BrandId";
            comboBoxBrands.DisplayMember = "BrandName";

            comboBoxSegments.DataSource = (await segmentManager.GetAllAsync()).Data;
            comboBoxSegments.ValueMember = "SegmentId";
            comboBoxSegments.DisplayMember = "SegmentName";

            sfDgwCars.DataSource = await carManager.GetCarDetails();
            sfDgwCars.Style.SelectionStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(105)))), ((int)(((byte)(106)))));
            sfDgwCars.Style.SelectionStyle.TextColor = Color.White;



        }

        public async void LoadModels() 
        {
            Brand brand = (Brand)comboBoxBrands.SelectedItem;
            if (brand != null)
                comboBoxModels.DataSource = (await modelManager.GetModelsByBrandId(brand.BrandId)).ToList();

            comboBoxModels.ValueMember = "ModelId";
            comboBoxModels.DisplayMember = "ModelName";

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("car.add");
            if (claim.IsSuccesful)
            {
                var result = carManager.Add(new Car { Color = comboBoxColors.Text, FuelType = comboBoxFuelTypes.Text, Kilometre = (txtKilometre.Text), ModelId = (int)comboBoxModels.SelectedValue, SegmentId = (int)comboBoxSegments.SelectedValue, Plate = txtPlate.Text });
                if (result.IsSuccesful)
                {
                    LoadData();
                    _formMain.LoadData();
                    AlertUtil.Show(result.Message, FormAlert.MessageType.Success);
                }
                else
                {
                    string errors = "Lütfen doğru ve eksiksiz şekilde doldurunuz \n";
                    foreach (var item in result.Errors)
                    {
                        errors += item + "\n";
                    }

                    AlertUtil.Show(errors, FormAlert.MessageType.Error);
                }


            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }
        }

        private void comboBoxBrands_SelectedValueChanged(object sender, EventArgs e)
        {
            LoadModels();
        }

      

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var claim = _roleClaimManager.CheckUserRoleClaims("car.update");

            if (claim.IsSuccesful)
            {
                var result = carManager.Update(new Car { CarId = selectedCar.CarId, Color = comboBoxColors.Text, FuelType = comboBoxFuelTypes.Text, Kilometre = (txtKilometre.Text), ModelId = (int)comboBoxModels.SelectedValue, SegmentId = (int)comboBoxSegments.SelectedValue, Plate = txtPlate.Text, State = true });
                if (result.IsSuccesful)
                {
                    LoadData();
                    AlertUtil.Show(result.Message, FormAlert.MessageType.Success);
                }
                else
                {
                    string errors = "Lütfen doğru ve eksiksiz şekilde doldurunuz \n";
                    foreach (var item in result.Errors)
                    {
                        errors += item + "\n";
                    }

                    AlertUtil.Show(errors, FormAlert.MessageType.Error);
                }

            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }

           
            
        }


        private void sfDgwCars_Click(object sender, EventArgs e)
        {

        }
        CarDetailDto selectedCar;
        private void sfDgwCars_SelectionChanged(object sender, Syncfusion.WinForms.DataGrid.Events.SelectionChangedEventArgs e)
        {
            selectedCar = (CarDetailDto)sfDgwCars.CurrentItem;
            txtPlate.Text = selectedCar.Plate;
            comboBoxBrands.SelectedIndex = comboBoxBrands.FindStringExact(selectedCar.BrandName);
            comboBoxColors.SelectedIndex = comboBoxColors.FindStringExact(selectedCar.Color);
            comboBoxFuelTypes.SelectedIndex = comboBoxFuelTypes.FindStringExact(selectedCar.FuelType);
            comboBoxModels.SelectedIndex = comboBoxModels.FindStringExact(selectedCar.ModelName);
            txtKilometre.Text = selectedCar.Kilometre;
            comboBoxSegments.SelectedIndex = comboBoxSegments.FindStringExact(selectedCar.SegmentName);

        }

        private void sfDgwCars_CellDoubleClick(object sender, Syncfusion.WinForms.DataGrid.Events.CellClickEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Silmek İstediğinize Emin misiniz ? ", "Araç Silme", MessageBoxButtons.YesNo);
            var claim = _roleClaimManager.CheckUserRoleClaims("car.delete");
            if (claim.IsSuccesful)
            {
                if (dialogResult == DialogResult.Yes)
                {
                    Car car = carManager.GetCarById((int)selectedCar.CarId);
                    car.State = false;
                    carManager.Update(car);
                    LoadData();

                }
            }
            else
            {
                AlertUtil.Show(claim.Message, FormAlert.MessageType.Error);
            }

            

        }
    }
}
