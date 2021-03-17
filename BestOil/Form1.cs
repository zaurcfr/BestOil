using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BestOil
{
    public partial class Form1 : Form
    {

        decimal totalGas = 0;
        decimal totalCafe = 0;
        decimal totalHotDog = 0;
        decimal totalBurger = 0;
        decimal totalFries = 0;
        decimal totalCocaCola = 0;
        decimal totalSnacks = 0;

        public Form1()
        {
            InitializeComponent();

            gasCmbbx.DisplayMember = "Name";
            gasCmbbx.Items.Add(new Gasoline
            {
                Name = "A-92",
                Price = 1
            });
            gasCmbbx.Items.Add(new Gasoline
            {
                Name = "A-95",
                Price = 1.50
            });
            gasCmbbx.Items.Add(new Gasoline
            {
                Name = "Diesel",
                Price = 0.80
            });

        }

        private void gasCmbbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            literOrPriceGrpbx.Enabled = true;
            pricePerLiterLbl.Text = ((gasCmbbx.SelectedItem as Gasoline)?.Price).ToString();
        }

        private void literRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (literRdbtn.Checked)
            {
                literNUD.Enabled = true;
                priceNUD.Enabled = false;   
            }
            else literNUD.Enabled = false;
        }

        private void literNUD_ValueChanged(object sender, EventArgs e)
        {
            totalGas = literNUD.Value * Decimal.Parse(pricePerLiterLbl.Text);
            priceOfGasLbl.Text = totalGas.ToString();
            totalLbl.Text = (totalGas + totalCafe).ToString();
        }

        private void priceRdbtn_CheckedChanged(object sender, EventArgs e)
        {
            if (priceRdbtn.Checked)
            {
                priceNUD.Enabled = true;
                literNUD.Enabled = false;
            }
            else priceNUD.Enabled = false;
        }

        private void priceNUD_ValueChanged(object sender, EventArgs e)
        {
            totalGas = priceNUD.Value;
            priceOfGasLbl.Text = totalGas.ToString();
            totalLbl.Text = (totalGas + totalCafe).ToString();
        }

        private void HotdogChckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (HotdogChckbx.Checked) HotDogNUD.Enabled = true;
            else
            {
                HotDogNUD.Enabled = false;
                totalHotDog = HotDogNUD.Value * Decimal.Parse(HotDogTxtb.Text);
                totalCafe -= totalHotDog;
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                HotDogNUD.Value = 0;
            }
        }

        private void HotDogNUD_ValueChanged(object sender, EventArgs e)
        {
            if (HotdogChckbx.Checked)
            {
                totalCafe += Decimal.Parse(HotDogTxtb.Text);
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                totalLbl.Text = (totalGas + totalCafe).ToString();
            }
        }

        private void BurgerChckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (BurgerChckbx.Checked) HamburgerNUD.Enabled = true;
            else
            {
                HamburgerNUD.Enabled = false;
                totalBurger = HamburgerNUD.Value * Decimal.Parse(HamburgerTxtb.Text);
                totalCafe -= totalBurger;
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                HamburgerNUD.Value = 0;
            }
        }

        private void HamburgerNUD_ValueChanged(object sender, EventArgs e)
        {
            if (BurgerChckbx.Checked)
            {
                totalCafe += Decimal.Parse(HamburgerTxtb.Text);
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                totalLbl.Text = (totalGas + totalCafe).ToString();
            }
        }

        private void FriesChckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (FriesChckbx.Checked) FriesNUD.Enabled = true;
            else
            {
                FriesNUD.Enabled = false;
                totalFries = FriesNUD.Value * Decimal.Parse(FriesTxtb.Text);
                totalCafe -= totalFries;
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                FriesNUD.Value = 0;
            }
        }

        private void FriesNUD_ValueChanged(object sender, EventArgs e)
        {
            if (FriesChckbx.Checked)
            {
                totalCafe += Decimal.Parse(FriesTxtb.Text);
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                totalLbl.Text = (totalGas + totalCafe).ToString();
            }
        }

        private void CocaColaChckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (CocaColaChckbx.Checked) CocaColaNUD.Enabled = true;
            else
            {
                CocaColaNUD.Enabled = false;
                totalCocaCola = CocaColaNUD.Value * Decimal.Parse(CocaColaTxtb.Text);
                totalCafe -= totalCocaCola;
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                CocaColaNUD.Value = 0;
            }
        }

        private void CocaColaNUD_ValueChanged(object sender, EventArgs e)
        {
            if (CocaColaChckbx.Checked)
            {
                totalCafe += Decimal.Parse(CocaColaTxtb.Text);
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                totalLbl.Text = (totalGas + totalCafe).ToString();
            }
        }

        private void SnacksChckbx_CheckedChanged(object sender, EventArgs e)
        {
            if (SnacksChckbx.Checked) SnackNUD.Enabled = true;
            else
            {
                SnackNUD.Enabled = false;
                totalSnacks = SnackNUD.Value * Decimal.Parse(SnackTxtb.Text);
                totalCafe -= totalSnacks;
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                SnackNUD.Value = 0;
            }
        }

        private void SnackNUD_ValueChanged(object sender, EventArgs e)
        {
            if (SnacksChckbx.Checked)
            {
                totalCafe += Decimal.Parse(SnackTxtb.Text);
                totalPriceInCafeLbl.Text = totalCafe.ToString();
                totalLbl.Text = (totalGas + totalCafe).ToString();
            }
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            saveBtn.Enabled = false;
            FileHelper.JsonSerialize("Receipt", Double.Parse(totalLbl.Text));
        }
    }
}
