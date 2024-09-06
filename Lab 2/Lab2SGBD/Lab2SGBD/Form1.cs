using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Lab2SGBD
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        string connectionString;
        SqlDataAdapter dataAdapter;
        DataSet dataSet;

        public Form1()
        {
            InitializeComponent();

            this.connectionString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            this.connection = new SqlConnection(this.connectionString);
            dataAdapter = new SqlDataAdapter();
            dataSet = new DataSet();
        }

        private void createTextBoxesForColumns()
        {
            int y = 30;
            for (int i = 0; i < Int32.Parse(ConfigurationManager.AppSettings["columnNumberOfChild"]); i++)
            {
                string columnField = ConfigurationManager.AppSettings["columnsChild"].Split(',')[i];

                Label label = new Label();
                label.Text = columnField;
                label.Location = new Point(0, y - 25);
                panel1.Controls.Add(label);

                TextBox textBox = new TextBox();
                textBox.Name = columnField;
                textBox.Location = new Point(0, y);
                textBox.Size = new System.Drawing.Size(160, 30);
                panel1.Controls.Add(textBox);

                y += 70;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            createTextBoxesForColumns();
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["selectParent"], connection);
                connection.Open();
                dataAdapter.SelectCommand = cmd;
                dataAdapter.Fill(dataSet, ConfigurationManager.AppSettings["tableParent"]);
                dataGridViewParent.DataSource = dataSet.Tables[ConfigurationManager.AppSettings["tableParent"]];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void refreshChildTable()
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["selectChild"], connection);
                int selectedParent = (int)dataGridViewParent.Rows[dataGridViewParent.SelectedCells[0].RowIndex].Cells[0].Value;
                if (selectedParent >= 0)
                {
                    cmd.Parameters.AddWithValue("@id", selectedParent);
                }

                connection.Open();
                dataAdapter.SelectCommand = cmd;
                if (dataSet.Tables.Contains(ConfigurationManager.AppSettings["tableChild"]))
                {
                    dataSet.Tables[ConfigurationManager.AppSettings["tableChild"]].Clear();
                }
                dataAdapter.Fill(dataSet, ConfigurationManager.AppSettings["tableChild"]);
                dataGridViewChild.DataSource = dataSet.Tables[ConfigurationManager.AppSettings["tableChild"]];
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridViewParent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewParent.Rows.Count > 0)
            {
                buttonAdd.Enabled = true;
            }
            refreshChildTable();
        }

        private void dataGridViewChild_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewChild.Rows.Count > 0)
            {
                buttonUpdate.Enabled = true;
                buttonDelete.Enabled = true;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["update"], connection);
                dataAdapter.UpdateCommand = cmd;
                int selected = -1;
                if (dataGridViewChild.Rows.Count > 0)
                    selected = (int)dataGridViewChild.Rows[dataGridViewChild.SelectedCells[0].RowIndex].Cells[0].Value;
                dataAdapter.UpdateCommand.Parameters.AddWithValue("@id", selected);

                int columnIndex = 1;
                foreach (string column in ConfigurationManager.AppSettings["columnsChild"].Split(','))
                {
                    TextBox textbox = (TextBox)panel1.Controls[column];
                    if (textbox.Text != "")
                    {
                        dataAdapter.UpdateCommand.Parameters.AddWithValue("@" + textbox.Name, textbox.Text);
                    }
                    else
                        dataAdapter.UpdateCommand.Parameters.AddWithValue("@" + textbox.Name, dataGridViewChild.Rows[dataGridViewChild.SelectedCells[0].RowIndex].Cells[columnIndex].Value.ToString());
                    columnIndex++;
                }

                connection.Open();
                dataAdapter.UpdateCommand.ExecuteNonQuery();
                connection.Close();
                refreshChildTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["delete"], connection);
                    dataAdapter.DeleteCommand = cmd;
                    int selected = -1;
                    if (dataGridViewChild.Rows.Count > 0)
                        selected = (int)dataGridViewChild.Rows[dataGridViewChild.SelectedCells[0].RowIndex].Cells[0].Value;
                    dataAdapter.DeleteCommand.Parameters.AddWithValue("@Id", selected);

                    connection.Open();
                    dataAdapter.DeleteCommand.ExecuteNonQuery();
                    connection.Close();
                    refreshChildTable();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand pre = new SqlCommand(ConfigurationManager.AppSettings["max"], connection);
                    SqlDataReader reader = pre.ExecuteReader();
                    int id = 1;
                    while (reader.Read())
                    {
                        id = reader.GetInt32(0) + 1;
                    }
                    connection.Close();

                    SqlCommand cmd = new SqlCommand(ConfigurationManager.AppSettings["insert"], connection);
                    dataAdapter.InsertCommand = cmd;
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@id", id);
                    int selected = -1;
                    if (dataGridViewParent.Rows.Count > 0)
                        selected = (int)dataGridViewParent.Rows[dataGridViewParent.SelectedCells[0].RowIndex].Cells[0].Value;
                    dataAdapter.InsertCommand.Parameters.AddWithValue("@IdParent", selected);

                    foreach (string column in ConfigurationManager.AppSettings["columnsChild"].Split(','))
                    {
                        TextBox textbox = (TextBox)panel1.Controls[column];
                        if (textbox.Text != "")
                            dataAdapter.InsertCommand.Parameters.AddWithValue("@" + textbox.Name, textbox.Text);
                        else
                            throw new Exception(textbox.Name + " invalid");
                    }


                    connection.Open();
                    dataAdapter.InsertCommand.ExecuteNonQuery();
                    connection.Close();
                    refreshChildTable();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}