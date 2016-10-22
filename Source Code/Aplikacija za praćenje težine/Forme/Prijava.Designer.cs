namespace AplikacijaZaPracenjeTezine
{
    partial class Prijava
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Prijava));
            this.korisnickoIme = new System.Windows.Forms.TextBox();
            this.lozinka = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button1 = new System.Windows.Forms.Button();
            this.lozinkaL = new System.Windows.Forms.Label();
            this.korisnickoImeL = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // korisnickoIme
            // 
            this.korisnickoIme.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.korisnickoIme.ForeColor = System.Drawing.Color.Black;
            this.korisnickoIme.Location = new System.Drawing.Point(107, 13);
            this.korisnickoIme.Name = "korisnickoIme";
            this.korisnickoIme.Size = new System.Drawing.Size(143, 20);
            this.korisnickoIme.TabIndex = 1;
            // 
            // lozinka
            // 
            this.lozinka.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.lozinka.Location = new System.Drawing.Point(107, 39);
            this.lozinka.Name = "lozinka";
            this.lozinka.PasswordChar = '*';
            this.lozinka.Size = new System.Drawing.Size(143, 20);
            this.lozinka.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.statusStrip1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lozinka);
            this.panel1.Controls.Add(this.lozinkaL);
            this.panel1.Controls.Add(this.korisnickoIme);
            this.panel1.Controls.Add(this.korisnickoImeL);
            this.panel1.Location = new System.Drawing.Point(-1, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 113);
            this.panel1.TabIndex = 4;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 91);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(262, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(168, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 24);
            this.button1.TabIndex = 5;
            this.button1.Text = "Uredu";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lozinkaL
            // 
            this.lozinkaL.AutoSize = true;
            this.lozinkaL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lozinkaL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.lozinkaL.Location = new System.Drawing.Point(46, 42);
            this.lozinkaL.Name = "lozinkaL";
            this.lozinkaL.Size = new System.Drawing.Size(55, 13);
            this.lozinkaL.TabIndex = 2;
            this.lozinkaL.Text = "Lozinka:";
            // 
            // korisnickoImeL
            // 
            this.korisnickoImeL.AutoSize = true;
            this.korisnickoImeL.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.korisnickoImeL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.korisnickoImeL.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.korisnickoImeL.Location = new System.Drawing.Point(8, 16);
            this.korisnickoImeL.Name = "korisnickoImeL";
            this.korisnickoImeL.Size = new System.Drawing.Size(93, 13);
            this.korisnickoImeL.TabIndex = 0;
            this.korisnickoImeL.Text = "Korisničko ime:";
            // 
            // Prijava
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(259, 114);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Prijava";
            this.Text = "Prijava";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label korisnickoImeL;
        private System.Windows.Forms.TextBox korisnickoIme;
        private System.Windows.Forms.Label lozinkaL;
        private System.Windows.Forms.TextBox lozinka;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    }
}