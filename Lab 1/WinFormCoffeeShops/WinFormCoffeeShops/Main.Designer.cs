using System.Windows.Forms;

namespace WinFormCoffeeShops
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idCafeneaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adresaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dimensiuneMPDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numarMeseDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numarAngajatiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numarClientiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cafeneleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.coffeeToGoDataSet = new WinFormCoffeeShops.CoffeeToGoDataSet();
            this.cafeneleTableAdapter = new WinFormCoffeeShops.CoffeeToGoDataSetTableAdapters.CafeneleTableAdapter();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prenumeAutorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numarSteleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idCafeneaDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fkrecenziiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recenziiBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.recenziiTableAdapter = new WinFormCoffeeShops.CoffeeToGoDataSetTableAdapters.RecenziiTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cafeneleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffeeToGoDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkrecenziiBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recenziiBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idCafeneaDataGridViewTextBoxColumn,
            this.numeDataGridViewTextBoxColumn,
            this.adresaDataGridViewTextBoxColumn,
            this.dimensiuneMPDataGridViewTextBoxColumn,
            this.numarMeseDataGridViewTextBoxColumn,
            this.numarAngajatiDataGridViewTextBoxColumn,
            this.numarClientiDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.cafeneleBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(28, 64);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.RowHeadersWidth = 62;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 10F);
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1260, 300);
            this.dataGridView1.TabIndex = 1;
            // 
            // idCafeneaDataGridViewTextBoxColumn
            // 
            this.idCafeneaDataGridViewTextBoxColumn.DataPropertyName = "IdCafenea";
            this.idCafeneaDataGridViewTextBoxColumn.HeaderText = "IdCafenea";
            this.idCafeneaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idCafeneaDataGridViewTextBoxColumn.Name = "idCafeneaDataGridViewTextBoxColumn";
            this.idCafeneaDataGridViewTextBoxColumn.Width = 101;
            // 
            // numeDataGridViewTextBoxColumn
            // 
            this.numeDataGridViewTextBoxColumn.DataPropertyName = "Nume";
            this.numeDataGridViewTextBoxColumn.HeaderText = "Nume";
            this.numeDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numeDataGridViewTextBoxColumn.Name = "numeDataGridViewTextBoxColumn";
            this.numeDataGridViewTextBoxColumn.Width = 150;
            // 
            // adresaDataGridViewTextBoxColumn
            // 
            this.adresaDataGridViewTextBoxColumn.DataPropertyName = "Adresa";
            this.adresaDataGridViewTextBoxColumn.HeaderText = "Adresa";
            this.adresaDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.adresaDataGridViewTextBoxColumn.Name = "adresaDataGridViewTextBoxColumn";
            this.adresaDataGridViewTextBoxColumn.Width = 101;
            // 
            // dimensiuneMPDataGridViewTextBoxColumn
            // 
            this.dimensiuneMPDataGridViewTextBoxColumn.DataPropertyName = "DimensiuneMP";
            this.dimensiuneMPDataGridViewTextBoxColumn.HeaderText = "DimensiuneMP";
            this.dimensiuneMPDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.dimensiuneMPDataGridViewTextBoxColumn.Name = "dimensiuneMPDataGridViewTextBoxColumn";
            this.dimensiuneMPDataGridViewTextBoxColumn.Width = 101;
            // 
            // numarMeseDataGridViewTextBoxColumn
            // 
            this.numarMeseDataGridViewTextBoxColumn.DataPropertyName = "NumarMese";
            this.numarMeseDataGridViewTextBoxColumn.HeaderText = "NumarMese";
            this.numarMeseDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numarMeseDataGridViewTextBoxColumn.Name = "numarMeseDataGridViewTextBoxColumn";
            this.numarMeseDataGridViewTextBoxColumn.Width = 102;
            // 
            // numarAngajatiDataGridViewTextBoxColumn
            // 
            this.numarAngajatiDataGridViewTextBoxColumn.DataPropertyName = "NumarAngajati";
            this.numarAngajatiDataGridViewTextBoxColumn.HeaderText = "NumarAngajati";
            this.numarAngajatiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numarAngajatiDataGridViewTextBoxColumn.Name = "numarAngajatiDataGridViewTextBoxColumn";
            this.numarAngajatiDataGridViewTextBoxColumn.Width = 101;
            // 
            // numarClientiDataGridViewTextBoxColumn
            // 
            this.numarClientiDataGridViewTextBoxColumn.DataPropertyName = "NumarClienti";
            this.numarClientiDataGridViewTextBoxColumn.HeaderText = "NumarClienti";
            this.numarClientiDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numarClientiDataGridViewTextBoxColumn.Name = "numarClientiDataGridViewTextBoxColumn";
            this.numarClientiDataGridViewTextBoxColumn.Width = 102;
            // 
            // cafeneleBindingSource
            // 
            this.cafeneleBindingSource.DataMember = "Cafenele";
            this.cafeneleBindingSource.DataSource = this.coffeeToGoDataSet;
            // 
            // coffeeToGoDataSet
            // 
            this.coffeeToGoDataSet.DataSetName = "CoffeeToGoDataSet";
            this.coffeeToGoDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cafeneleTableAdapter
            // 
            this.cafeneleTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.numeAutorDataGridViewTextBoxColumn,
            this.prenumeAutorDataGridViewTextBoxColumn,
            this.numarSteleDataGridViewTextBoxColumn,
            this.idCafeneaDataGridViewTextBoxColumn1,
            this.descriereDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.fkrecenziiBindingSource;
            this.dataGridView2.Location = new System.Drawing.Point(28, 433);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 62;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Times New Roman", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView2.RowTemplate.Height = 28;
            this.dataGridView2.Size = new System.Drawing.Size(1400, 300);
            this.dataGridView2.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Width = 150;
            // 
            // numeAutorDataGridViewTextBoxColumn
            // 
            this.numeAutorDataGridViewTextBoxColumn.DataPropertyName = "NumeAutor";
            this.numeAutorDataGridViewTextBoxColumn.HeaderText = "NumeAutor";
            this.numeAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numeAutorDataGridViewTextBoxColumn.Name = "numeAutorDataGridViewTextBoxColumn";
            this.numeAutorDataGridViewTextBoxColumn.Width = 150;
            // 
            // prenumeAutorDataGridViewTextBoxColumn
            // 
            this.prenumeAutorDataGridViewTextBoxColumn.DataPropertyName = "PrenumeAutor";
            this.prenumeAutorDataGridViewTextBoxColumn.HeaderText = "PrenumeAutor";
            this.prenumeAutorDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.prenumeAutorDataGridViewTextBoxColumn.Name = "prenumeAutorDataGridViewTextBoxColumn";
            this.prenumeAutorDataGridViewTextBoxColumn.Width = 150;
            // 
            // numarSteleDataGridViewTextBoxColumn
            // 
            this.numarSteleDataGridViewTextBoxColumn.DataPropertyName = "NumarStele";
            this.numarSteleDataGridViewTextBoxColumn.HeaderText = "NumarStele";
            this.numarSteleDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.numarSteleDataGridViewTextBoxColumn.Name = "numarSteleDataGridViewTextBoxColumn";
            this.numarSteleDataGridViewTextBoxColumn.Width = 150;
            // 
            // idCafeneaDataGridViewTextBoxColumn1
            // 
            this.idCafeneaDataGridViewTextBoxColumn1.DataPropertyName = "IdCafenea";
            this.idCafeneaDataGridViewTextBoxColumn1.HeaderText = "IdCafenea";
            this.idCafeneaDataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.idCafeneaDataGridViewTextBoxColumn1.Name = "idCafeneaDataGridViewTextBoxColumn1";
            this.idCafeneaDataGridViewTextBoxColumn1.Width = 150;
            // 
            // descriereDataGridViewTextBoxColumn
            // 
            this.descriereDataGridViewTextBoxColumn.DataPropertyName = "Descriere";
            this.descriereDataGridViewTextBoxColumn.HeaderText = "Descriere";
            this.descriereDataGridViewTextBoxColumn.MinimumWidth = 8;
            this.descriereDataGridViewTextBoxColumn.Name = "descriereDataGridViewTextBoxColumn";
            this.descriereDataGridViewTextBoxColumn.Width = 150;
            // 
            // fkrecenziiBindingSource
            // 
            this.fkrecenziiBindingSource.DataMember = "fk_recenzii";
            this.fkrecenziiBindingSource.DataSource = this.cafeneleBindingSource;
            // 
            // recenziiBindingSource
            // 
            this.recenziiBindingSource.DataMember = "Recenzii";
            this.recenziiBindingSource.DataSource = this.coffeeToGoDataSet;
            // 
            // recenziiTableAdapter
            // 
            this.recenziiTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(404, 803);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(329, 56);
            this.button2.TabIndex = 3;
            this.button2.Text = "Salvare";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonCloseAndSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Cafenele";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 398);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Recenzii";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 902);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Main";
            this.Text = "CoffeeShopsApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cafeneleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.coffeeToGoDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fkrecenziiBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recenziiBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private CoffeeToGoDataSet coffeeToGoDataSet;
        private System.Windows.Forms.BindingSource cafeneleBindingSource;
        private CoffeeToGoDataSetTableAdapters.CafeneleTableAdapter cafeneleTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCafeneaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn adresaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dimensiuneMPDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarMeseDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarAngajatiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarClientiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource recenziiBindingSource;
        private CoffeeToGoDataSetTableAdapters.RecenziiTableAdapter recenziiTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prenumeAutorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numarSteleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idCafeneaDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriereDataGridViewTextBoxColumn;
        private Button button2;
        private BindingSource fkrecenziiBindingSource;
        private Label label1;
        private Label label2;
    }
}

