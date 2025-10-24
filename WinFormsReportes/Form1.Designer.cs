namespace WinFormsReportes
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnImprimirPersonas = new Button();
            label1 = new Label();
            dataGridView1 = new DataGridView();
            idDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ageDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            birthdayDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSource1 = new BindingSource(components);
            label2 = new Label();
            label3 = new Label();
            dataGridView2 = new DataGridView();
            franjaEtariaDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            cantidadDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bindingSource2 = new BindingSource(components);
            btnGenerar = new Button();
            btnImprimirEdades = new Button();
            txtEdad1 = new TextBox();
            txtEdad2 = new TextBox();
            label4 = new Label();
            label5 = new Label();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            groupBox1 = new GroupBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // btnImprimirPersonas
            // 
            btnImprimirPersonas.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnImprimirPersonas.Location = new Point(710, 16);
            btnImprimirPersonas.Name = "btnImprimirPersonas";
            btnImprimirPersonas.Size = new Size(126, 40);
            btnImprimirPersonas.TabIndex = 0;
            btnImprimirPersonas.Text = "Imprimir";
            btnImprimirPersonas.UseVisualStyleBackColor = true;
            btnImprimirPersonas.Click += btnImprimirPersonas_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            label1.BackColor = SystemColors.ActiveCaption;
            label1.ForeColor = Color.Brown;
            label1.Location = new Point(592, 516);
            label1.Name = "label1";
            label1.Size = new Size(244, 63);
            label1.TabIndex = 1;
            label1.Text = "Para generar los reportes se usa la libreria QuestPDF con licencia developer, esto es solo para uso de desarrollo demostrativo y no comercial.";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { idDataGridViewTextBoxColumn, nameDataGridViewTextBoxColumn, ageDataGridViewTextBoxColumn, birthdayDataGridViewTextBoxColumn });
            dataGridView1.DataSource = bindingSource1;
            dataGridView1.Location = new Point(12, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(824, 180);
            dataGridView1.TabIndex = 2;
            // 
            // idDataGridViewTextBoxColumn
            // 
            idDataGridViewTextBoxColumn.DataPropertyName = "id";
            idDataGridViewTextBoxColumn.HeaderText = "id";
            idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "name";
            nameDataGridViewTextBoxColumn.HeaderText = "name";
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // ageDataGridViewTextBoxColumn
            // 
            ageDataGridViewTextBoxColumn.DataPropertyName = "age";
            ageDataGridViewTextBoxColumn.HeaderText = "age";
            ageDataGridViewTextBoxColumn.Name = "ageDataGridViewTextBoxColumn";
            // 
            // birthdayDataGridViewTextBoxColumn
            // 
            birthdayDataGridViewTextBoxColumn.DataPropertyName = "birthday";
            birthdayDataGridViewTextBoxColumn.HeaderText = "birthday";
            birthdayDataGridViewTextBoxColumn.Name = "birthdayDataGridViewTextBoxColumn";
            birthdayDataGridViewTextBoxColumn.Visible = false;
            // 
            // bindingSource1
            // 
            bindingSource1.DataSource = typeof(Persona);
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 24);
            label2.Name = "label2";
            label2.Size = new Size(197, 32);
            label2.TabIndex = 3;
            label2.Text = "Lista de personas";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 261);
            label3.Name = "label3";
            label3.Size = new Size(223, 32);
            label3.TabIndex = 5;
            label3.Text = "Reporte por edades";
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { franjaEtariaDataGridViewTextBoxColumn, cantidadDataGridViewTextBoxColumn });
            dataGridView2.DataSource = bindingSource2;
            dataGridView2.Location = new Point(12, 342);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.Size = new Size(824, 166);
            dataGridView2.TabIndex = 4;
            // 
            // franjaEtariaDataGridViewTextBoxColumn
            // 
            franjaEtariaDataGridViewTextBoxColumn.DataPropertyName = "franjaEtaria";
            franjaEtariaDataGridViewTextBoxColumn.HeaderText = "franjaEtaria";
            franjaEtariaDataGridViewTextBoxColumn.Name = "franjaEtariaDataGridViewTextBoxColumn";
            franjaEtariaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            cantidadDataGridViewTextBoxColumn.DataPropertyName = "cantidad";
            cantidadDataGridViewTextBoxColumn.HeaderText = "cantidad";
            cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingSource2
            // 
            bindingSource2.DataSource = typeof(ReporteEdades);
            // 
            // btnGenerar
            // 
            btnGenerar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnGenerar.Location = new Point(578, 291);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(126, 40);
            btnGenerar.TabIndex = 6;
            btnGenerar.Text = "Generar";
            btnGenerar.UseVisualStyleBackColor = true;
            btnGenerar.Click += btnGenerar_Click;
            // 
            // btnImprimirEdades
            // 
            btnImprimirEdades.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnImprimirEdades.Location = new Point(710, 291);
            btnImprimirEdades.Name = "btnImprimirEdades";
            btnImprimirEdades.Size = new Size(126, 40);
            btnImprimirEdades.TabIndex = 7;
            btnImprimirEdades.Text = "Imprimir";
            btnImprimirEdades.UseVisualStyleBackColor = true;
            btnImprimirEdades.Click += btnImprimirEdades_Click;
            // 
            // txtEdad1
            // 
            txtEdad1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtEdad1.Location = new Point(85, 296);
            txtEdad1.Name = "txtEdad1";
            txtEdad1.Size = new Size(53, 23);
            txtEdad1.TabIndex = 8;
            txtEdad1.Text = "0";
            // 
            // txtEdad2
            // 
            txtEdad2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            txtEdad2.Location = new Point(215, 296);
            txtEdad2.Name = "txtEdad2";
            txtEdad2.Size = new Size(53, 23);
            txtEdad2.TabIndex = 9;
            txtEdad2.Text = "99";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label4.AutoSize = true;
            label4.Location = new Point(12, 304);
            label4.Name = "label4";
            label4.Size = new Size(67, 15);
            label4.TabIndex = 10;
            label4.Text = "Edad desde";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label5.AutoSize = true;
            label5.Location = new Point(145, 304);
            label5.Name = "label5";
            label5.Size = new Size(64, 15);
            label5.TabIndex = 11;
            label5.Text = "Edad hasta";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Checked = true;
            radioButton1.Location = new Point(9, 24);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(57, 19);
            radioButton1.TabIndex = 12;
            radioButton1.TabStop = true;
            radioButton1.Text = "Barras";
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Location = new Point(72, 24);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(51, 19);
            radioButton2.TabIndex = 13;
            radioButton2.Text = "Torta";
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(293, 267);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(144, 51);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            groupBox1.Text = "Tipo";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 588);
            Controls.Add(groupBox1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(txtEdad2);
            Controls.Add(txtEdad1);
            Controls.Add(btnImprimirEdades);
            Controls.Add(btnGenerar);
            Controls.Add(label3);
            Controls.Add(dataGridView2);
            Controls.Add(label2);
            Controls.Add(dataGridView1);
            Controls.Add(label1);
            Controls.Add(btnImprimirPersonas);
            Name = "Form1";
            Text = "Demo reportes";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource2).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnImprimirPersonas;
        private Label label1;
        private DataGridView dataGridView1;
        private BindingSource bindingSource1;
        private Label label2;
        private Label label3;
        private DataGridView dataGridView2;
        private Button btnGenerar;
        private Button btnImprimirEdades;
        private BindingSource bindingSource2;
        private DataGridViewTextBoxColumn franjaEtariaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn birthdayDataGridViewTextBoxColumn;
        private TextBox txtEdad1;
        private TextBox txtEdad2;
        private Label label4;
        private Label label5;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private GroupBox groupBox1;
    }
}
