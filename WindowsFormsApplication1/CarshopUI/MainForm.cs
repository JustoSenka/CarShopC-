using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Carshop.Carshop;
using System.Diagnostics;

namespace Carshop.CarshopUI
{
    public partial class MainForm : Form
    {

        ICarShop cs = CarShopFactory.GetCarShop
            (Storehouse: Properties.Resources.Storehouse, Cars: Properties.Resources.Cars);

        public MainForm()
        {
            InitializeComponent();
            System.Console.WriteLine("Start");

            UpdateListItems();
        }

        private void UpdateListItems()
        {
            FilterOptions fo = FilterOptions.None;
            if (checkBox1.Checked) fo = fo | FilterOptions.HideYear;
            if (checkBox2.Checked) fo = fo | FilterOptions.HideModel;

            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(cs.GetFilteredParts(textBox1.Text, fo).ToArray());

            this.listBox2.Items.Clear();
            this.listBox2.Items.AddRange(cs.GetShopCartList().ToArray());

            button1.Enabled = false;
            button2.Enabled = false;
            if (listBox2.Items.Count == 0) button3.Enabled = false;
            else button3.Enabled = true;

            label2.Text = "Total cost: " + cs.GetTotalCost() + "$";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateListItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.AddToShoppingCart(listBox1.SelectedItem);
            UpdateListItems();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cs.RemoveFromShoppingCart(listBox2.SelectedItem);
            UpdateListItems();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button1.Enabled = true;
                button2.Enabled = false;
                listBox2.SelectedIndex = -1;
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex != -1)
            {
                button1.Enabled = false;
                button2.Enabled = true;
                listBox1.SelectedIndex = -1;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cs.SellCart();
            UpdateListItems();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Process.Start("Log.txt");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListItems();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListItems();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
