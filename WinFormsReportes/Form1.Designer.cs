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
            button1 = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(40, 29);
            button1.Name = "button1";
            button1.Size = new Size(126, 40);
            button1.TabIndex = 0;
            button1.Text = "Imprimir";
            button1.UseVisualStyleBackColor = true;
            button1.Click += btnImprimir_Click;
            // 
            // label1
            // 
            label1.Location = new Point(40, 86);
            label1.Name = "label1";
            label1.Size = new Size(244, 103);
            label1.TabIndex = 1;
            label1.Text = "Para generar los reportes se usa la libreria QuestPDF con licencia developer, esto es solo para uso de desarrollo y no comercial.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(346, 262);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Label label1;
    }
}
