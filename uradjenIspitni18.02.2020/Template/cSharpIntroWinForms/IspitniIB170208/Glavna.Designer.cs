namespace cSharpIntroWinForms.IspitniIB170208
{
    partial class Glavna
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
            this.btnGodinaStudija = new System.Windows.Forms.Button();
            this.btnPolozeniPredmeti = new System.Windows.Forms.Button();
            this.btnIzracunajSumu = new System.Windows.Forms.Button();
            this.txtSuma = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnGodinaStudija
            // 
            this.btnGodinaStudija.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGodinaStudija.Location = new System.Drawing.Point(28, 31);
            this.btnGodinaStudija.Name = "btnGodinaStudija";
            this.btnGodinaStudija.Size = new System.Drawing.Size(118, 98);
            this.btnGodinaStudija.TabIndex = 0;
            this.btnGodinaStudija.Text = "Godina studija";
            this.btnGodinaStudija.UseVisualStyleBackColor = true;
            this.btnGodinaStudija.Click += new System.EventHandler(this.btnGodinaStudija_Click);
            // 
            // btnPolozeniPredmeti
            // 
            this.btnPolozeniPredmeti.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPolozeniPredmeti.Location = new System.Drawing.Point(152, 31);
            this.btnPolozeniPredmeti.Name = "btnPolozeniPredmeti";
            this.btnPolozeniPredmeti.Size = new System.Drawing.Size(132, 98);
            this.btnPolozeniPredmeti.TabIndex = 1;
            this.btnPolozeniPredmeti.Text = "Položeni predmeti";
            this.btnPolozeniPredmeti.UseVisualStyleBackColor = true;
            this.btnPolozeniPredmeti.Click += new System.EventHandler(this.btnPolozeniPredmeti_Click);
            // 
            // btnIzracunajSumu
            // 
            this.btnIzracunajSumu.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIzracunajSumu.Location = new System.Drawing.Point(311, 75);
            this.btnIzracunajSumu.Name = "btnIzracunajSumu";
            this.btnIzracunajSumu.Size = new System.Drawing.Size(126, 54);
            this.btnIzracunajSumu.TabIndex = 2;
            this.btnIzracunajSumu.Text = "Izračunaj sumu";
            this.btnIzracunajSumu.UseVisualStyleBackColor = true;
            this.btnIzracunajSumu.Click += new System.EventHandler(this.btnIzracunajSumu_Click);
            // 
            // txtSuma
            // 
            this.txtSuma.Location = new System.Drawing.Point(311, 43);
            this.txtSuma.Name = "txtSuma";
            this.txtSuma.Size = new System.Drawing.Size(126, 20);
            this.txtSuma.TabIndex = 3;
            // 
            // Glavna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 161);
            this.Controls.Add(this.txtSuma);
            this.Controls.Add(this.btnIzracunajSumu);
            this.Controls.Add(this.btnPolozeniPredmeti);
            this.Controls.Add(this.btnGodinaStudija);
            this.Name = "Glavna";
            this.Text = "Glavna";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGodinaStudija;
        private System.Windows.Forms.Button btnPolozeniPredmeti;
        private System.Windows.Forms.Button btnIzracunajSumu;
        private System.Windows.Forms.TextBox txtSuma;
    }
}