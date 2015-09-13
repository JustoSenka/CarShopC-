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

namespace Carshop.CarshopUI
{
    public partial class MainForm : Form
    {

        ICarShop cs = CarShopFactory.GetCarShop();

        public MainForm()
        {
            InitializeComponent();
            System.Console.WriteLine("Start");

            UpdateListItems();
        }

        private void UpdateListItems()
        {
            this.listBox1.Items.Clear();
            this.listBox1.Items.AddRange(cs.GetFilteredParts(textBox1.Text).ToArray());

            this.listBox2.Items.Clear();
            this.listBox2.Items.AddRange(cs.GetShopCartList().ToArray());

            button1.Enabled = false;
            button2.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateListItems();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cs.AddToShoppingCart(listBox1.SelectedItem);
            UpdateListItems();

            label2.Text = "Total cost: " + cs.GetTotalCost() + "$";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cs.RemoveFromShoppingCart(listBox2.SelectedItem);
            UpdateListItems();

            label2.Text = "Total cost: " + cs.GetTotalCost() + "$";
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
    }
}
