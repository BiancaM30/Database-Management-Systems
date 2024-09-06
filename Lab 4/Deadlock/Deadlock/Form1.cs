using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Deadlock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ThreadStart deadlock1 = new ThreadStart(Deadlock1);
            ThreadStart deadlock2 = new ThreadStart(Deadlock2);

            Thread d1 = new Thread(deadlock1);
            Thread d2 = new Thread(deadlock2);

            d1.Start();
            d2.Start();
        }

        private void Deadlock1()
        {
            Deadlock("deadlock1");
        }

        private void Deadlock2()
        {
            Deadlock("deadlock2");
        }

        void Deadlock(String deadlock)
        {
            SqlConnection connection = new SqlConnection("Data Source=DESKTOP-4VPFGVP\\SQLEXPRESS;Initial Catalog=CoffeeToGo;Integrated Security=True");

            string cmd;
            if (deadlock == "deadlock1")
            {
                cmd = "SET TRANSACTION ISOLATION LEVEL SERIALIZABLE BEGIN TRAN UPDATE Cafenele SET Adresa = 'Florilor 13' WHERE IdCafenea = 1 WAITFOR DELAY '00:00:05' UPDATE Furnizori SET ProduseLivrate = 'Consumabile' WHERE Nume = 'Hendi' COMMIT TRAN";
            }
            else
            {
                cmd = "SET DEADLOCK_PRIORITY HIGH SET TRANSACTION ISOLATION LEVEL SERIALIZABLE BEGIN TRAN UPDATE Furnizori SET ProduseLivrate = 'Expresoare' WHERE Nume = 'Hendi' WAITFOR DELAY '00:00:05' UPDATE Cafenele SET Adresa = 'Mihai Eminescu 15' WHERE IdCafenea = 1 COMMIT TRAN";
            }

            MessageBox.Show(deadlock + " started!");

            SqlCommand command = new SqlCommand(cmd, connection);
            connection.Open();
            int rows_affected = 0;
            try
            {
                rows_affected = command.ExecuteNonQuery();
                MessageBox.Show(deadlock + " success!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(deadlock + " failed! Transaction will be reruned!" + Environment.NewLine
                    + Environment.NewLine + ex.Message);
                int tryNumber = 1;
                while (tryNumber <= 4 && rows_affected < 2)
                {
                    try
                    {
                        rows_affected = command.ExecuteNonQuery();
                        MessageBox.Show(deadlock + " succes on rerun number: " + tryNumber);
                        Application.Exit();
                    }
                    catch (Exception exe)
                    {
                        MessageBox.Show(deadlock + " failed on rerun number: " + tryNumber);
                    }
                    finally
                    {
                        tryNumber++;
                    }
                }
                if (tryNumber == 5)
                {
                    MessageBox.Show(deadlock + " aborted! - Maximum number of reruns has been reached");
                }
            }
        }
    }
}
