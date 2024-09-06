using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormCoffeeShops
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();


        }



        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'coffeeToGoDataSet.Recenzii' table. You can move, or remove it, as needed.
            this.recenziiTableAdapter.Fill(this.coffeeToGoDataSet.Recenzii);
            // TODO: This line of code loads data into the 'coffeeToGoDataSet.Cafenele' table. You can move, or remove it, as needed.
            this.cafeneleTableAdapter.Fill(this.coffeeToGoDataSet.Cafenele);

        }



        private void buttonCloseAndSave_Click(object sender, EventArgs e)
        {
            /*this.Validate();
            this.recenziiBindingSource.EndEdit();
            this.recenziiTableAdapter.Update(this.coffeeToGoDataSet);*/
            if (MessageBox.Show("Salavti?", "Titlu", MessageBoxButtons.YesNo) ==
              DialogResult.Yes)
            {
                this.Validate();
                this.recenziiBindingSource.EndEdit();
                this.recenziiTableAdapter.Update(this.coffeeToGoDataSet);

            }

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            {
                if (MessageBox.Show("Salavti?", "Titlu", MessageBoxButtons.YesNo) ==
               DialogResult.Yes)
                {
                    this.Validate();
                    this.recenziiBindingSource.EndEdit();
                    this.recenziiTableAdapter.Update(this.coffeeToGoDataSet);
                }
            }
        }


    }
}
