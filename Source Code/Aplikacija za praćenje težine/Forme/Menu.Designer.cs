namespace AplikacijaZaPracenjeTezine
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dnevnikIshraneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dnevnikAktivnostiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.težinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proliToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.evidentirajTežinuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izvještajiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.postavkeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.promijeniŠifruToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisničkiPodaciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjaviSeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomoćToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.korisničkoUpustvoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oNamaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Left;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dnevnikIshraneToolStripMenuItem,
            this.dnevnikAktivnostiToolStripMenuItem,
            this.težinaToolStripMenuItem,
            this.profilToolStripMenuItem,
            this.izvještajiToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Table;
            this.menuStrip1.Location = new System.Drawing.Point(0, 24);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(217, 375);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dnevnikIshraneToolStripMenuItem
            // 
            this.dnevnikIshraneToolStripMenuItem.Image = global::AplikacijaZaPracenjeTezine.Properties.Resources.SlikaHarana;
            this.dnevnikIshraneToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dnevnikIshraneToolStripMenuItem.Name = "dnevnikIshraneToolStripMenuItem";
            this.dnevnikIshraneToolStripMenuItem.Size = new System.Drawing.Size(206, 76);
            this.dnevnikIshraneToolStripMenuItem.Text = "Dnevnik ishrane";
            this.dnevnikIshraneToolStripMenuItem.Click += new System.EventHandler(this.dnevnikIshraneToolStripMenuItem_Click);
            // 
            // dnevnikAktivnostiToolStripMenuItem
            // 
            this.dnevnikAktivnostiToolStripMenuItem.Image = global::AplikacijaZaPracenjeTezine.Properties.Resources.SlikaPica;
            this.dnevnikAktivnostiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.dnevnikAktivnostiToolStripMenuItem.Name = "dnevnikAktivnostiToolStripMenuItem";
            this.dnevnikAktivnostiToolStripMenuItem.Size = new System.Drawing.Size(183, 76);
            this.dnevnikAktivnostiToolStripMenuItem.Text = "Dnevnik pića";
            this.dnevnikAktivnostiToolStripMenuItem.Click += new System.EventHandler(this.dnevnikAktivnostiToolStripMenuItem_Click);
            // 
            // težinaToolStripMenuItem
            // 
            this.težinaToolStripMenuItem.Image = global::AplikacijaZaPracenjeTezine.Properties.Resources.LikaAktivnost;
            this.težinaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.težinaToolStripMenuItem.Name = "težinaToolStripMenuItem";
            this.težinaToolStripMenuItem.Size = new System.Drawing.Size(214, 68);
            this.težinaToolStripMenuItem.Text = "Dnevnik aktivnosti";
            this.težinaToolStripMenuItem.Click += new System.EventHandler(this.težinaToolStripMenuItem_Click);
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.AutoSize = false;
            this.profilToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proliToolStripMenuItem,
            this.evidentirajTežinuToolStripMenuItem});
            this.profilToolStripMenuItem.Image = global::AplikacijaZaPracenjeTezine.Properties.Resources.SlikaTezina1;
            this.profilToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(188, 68);
            this.profilToolStripMenuItem.Text = "Dnevnik težine";
            // 
            // proliToolStripMenuItem
            // 
            this.proliToolStripMenuItem.Name = "proliToolStripMenuItem";
            this.proliToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.proliToolStripMenuItem.Text = "Profil korisnika";
            this.proliToolStripMenuItem.Click += new System.EventHandler(this.proliToolStripMenuItem_Click);
            // 
            // evidentirajTežinuToolStripMenuItem
            // 
            this.evidentirajTežinuToolStripMenuItem.Name = "evidentirajTežinuToolStripMenuItem";
            this.evidentirajTežinuToolStripMenuItem.Size = new System.Drawing.Size(199, 26);
            this.evidentirajTežinuToolStripMenuItem.Text = "Evidentiraj težinu";
            this.evidentirajTežinuToolStripMenuItem.Click += new System.EventHandler(this.evidentirajTežinuToolStripMenuItem_Click);
            // 
            // izvještajiToolStripMenuItem
            // 
            this.izvještajiToolStripMenuItem.Image = global::AplikacijaZaPracenjeTezine.Properties.Resources.ReportSlika1;
            this.izvještajiToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.izvještajiToolStripMenuItem.Name = "izvještajiToolStripMenuItem";
            this.izvještajiToolStripMenuItem.Size = new System.Drawing.Size(204, 68);
            this.izvještajiToolStripMenuItem.Text = "Pregled napretka";
            this.izvještajiToolStripMenuItem.Click += new System.EventHandler(this.izvještajiToolStripMenuItem_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.postavkeToolStripMenuItem,
            this.pomoćToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip2.Size = new System.Drawing.Size(486, 24);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // postavkeToolStripMenuItem
            // 
            this.postavkeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.promijeniŠifruToolStripMenuItem,
            this.korisničkiPodaciToolStripMenuItem,
            this.odjaviSeToolStripMenuItem});
            this.postavkeToolStripMenuItem.Name = "postavkeToolStripMenuItem";
            this.postavkeToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.postavkeToolStripMenuItem.Text = "Postavke";
            // 
            // promijeniŠifruToolStripMenuItem
            // 
            this.promijeniŠifruToolStripMenuItem.Name = "promijeniŠifruToolStripMenuItem";
            this.promijeniŠifruToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.promijeniŠifruToolStripMenuItem.Text = "Promijeni šifru";
            this.promijeniŠifruToolStripMenuItem.Click += new System.EventHandler(this.promijeniŠifruToolStripMenuItem_Click);
            // 
            // korisničkiPodaciToolStripMenuItem
            // 
            this.korisničkiPodaciToolStripMenuItem.Name = "korisničkiPodaciToolStripMenuItem";
            this.korisničkiPodaciToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.korisničkiPodaciToolStripMenuItem.Text = "Korisnički podaci";
            this.korisničkiPodaciToolStripMenuItem.Click += new System.EventHandler(this.korisničkiPodaciToolStripMenuItem_Click);
            // 
            // odjaviSeToolStripMenuItem
            // 
            this.odjaviSeToolStripMenuItem.Name = "odjaviSeToolStripMenuItem";
            this.odjaviSeToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.odjaviSeToolStripMenuItem.Text = "Odjavi se";
            this.odjaviSeToolStripMenuItem.Click += new System.EventHandler(this.odjaviSeToolStripMenuItem_Click);
            // 
            // pomoćToolStripMenuItem
            // 
            this.pomoćToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.korisničkoUpustvoToolStripMenuItem,
            this.oNamaToolStripMenuItem});
            this.pomoćToolStripMenuItem.Name = "pomoćToolStripMenuItem";
            this.pomoćToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomoćToolStripMenuItem.Text = "Pomoć";
            // 
            // korisničkoUpustvoToolStripMenuItem
            // 
            this.korisničkoUpustvoToolStripMenuItem.Name = "korisničkoUpustvoToolStripMenuItem";
            this.korisničkoUpustvoToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.korisničkoUpustvoToolStripMenuItem.Text = "Korisničko upustvo";
            this.korisničkoUpustvoToolStripMenuItem.Click += new System.EventHandler(this.korisničkoUpustvoToolStripMenuItem_Click);
            // 
            // oNamaToolStripMenuItem
            // 
            this.oNamaToolStripMenuItem.Name = "oNamaToolStripMenuItem";
            this.oNamaToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.oNamaToolStripMenuItem.Text = "O nama";
            this.oNamaToolStripMenuItem.Click += new System.EventHandler(this.oNamaToolStripMenuItem_Click);
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::AplikacijaZaPracenjeTezine.Properties.Resources.PozadinaMenija1;
            this.ClientSize = new System.Drawing.Size(486, 399);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Menu";
            this.Text = "Meni";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem dnevnikAktivnostiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem težinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izvještajiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dnevnikIshraneToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem postavkeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomoćToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem proliToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem promijeniŠifruToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjaviSeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem evidentirajTežinuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisničkiPodaciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem korisničkoUpustvoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oNamaToolStripMenuItem;
    }
}