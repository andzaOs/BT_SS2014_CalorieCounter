namespace AplikacijaZaPracenjeTezine
{
    partial class KorisnickiPodaci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KorisnickiPodaci));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.prezime = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.datumRodjenja = new System.Windows.Forms.DateTimePicker();
            this.spolZensko = new System.Windows.Forms.RadioButton();
            this.spolMusko = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.ime = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.visina = new System.Windows.Forms.NumericUpDown();
            this.tezina = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.izuzetnoTeskaAktivnost = new System.Windows.Forms.RadioButton();
            this.teskaAktivnost = new System.Windows.Forms.RadioButton();
            this.umjerenaAktivnost = new System.Windows.Forms.RadioButton();
            this.laganaAktivnost = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.zeljenaTezina = new System.Windows.Forms.NumericUpDown();
            this.datumOstvarenjaCilja = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.ciljUdebljatiSe = new System.Windows.Forms.RadioButton();
            this.ciljOdrzati = new System.Windows.Forms.RadioButton();
            this.ciljSmrsati = new System.Windows.Forms.RadioButton();
            this.dodaj = new System.Windows.Forms.Button();
            this.izadji = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tezina)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zeljenaTezina)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.prezime);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.datumRodjenja);
            this.groupBox1.Controls.Add(this.spolZensko);
            this.groupBox1.Controls.Add(this.spolMusko);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ime);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(264, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Podaci o korisniku";
            // 
            // prezime
            // 
            this.prezime.Location = new System.Drawing.Point(104, 55);
            this.prezime.Name = "prezime";
            this.prezime.Size = new System.Drawing.Size(147, 20);
            this.prezime.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(43, 58);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Prezime:";
            // 
            // datumRodjenja
            // 
            this.datumRodjenja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumRodjenja.Location = new System.Drawing.Point(104, 83);
            this.datumRodjenja.Name = "datumRodjenja";
            this.datumRodjenja.Size = new System.Drawing.Size(148, 20);
            this.datumRodjenja.TabIndex = 8;
            // 
            // spolZensko
            // 
            this.spolZensko.AutoSize = true;
            this.spolZensko.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spolZensko.Location = new System.Drawing.Point(104, 137);
            this.spolZensko.Name = "spolZensko";
            this.spolZensko.Size = new System.Drawing.Size(65, 17);
            this.spolZensko.TabIndex = 7;
            this.spolZensko.Text = "žensko";
            this.spolZensko.UseVisualStyleBackColor = true;
            // 
            // spolMusko
            // 
            this.spolMusko.AutoSize = true;
            this.spolMusko.Checked = true;
            this.spolMusko.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.spolMusko.Location = new System.Drawing.Point(104, 114);
            this.spolMusko.Name = "spolMusko";
            this.spolMusko.Size = new System.Drawing.Size(61, 17);
            this.spolMusko.TabIndex = 6;
            this.spolMusko.TabStop = true;
            this.spolMusko.Text = "muško";
            this.spolMusko.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Spol:";
            // 
            // ime
            // 
            this.ime.Location = new System.Drawing.Point(104, 27);
            this.ime.Name = "ime";
            this.ime.Size = new System.Drawing.Size(147, 20);
            this.ime.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Datum rođenja:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ime:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.visina);
            this.groupBox2.Controls.Add(this.tezina);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(282, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(194, 172);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Podaci o tjelesnoj konstrukciji";
            // 
            // visina
            // 
            this.visina.DecimalPlaces = 1;
            this.visina.Location = new System.Drawing.Point(6, 109);
            this.visina.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.visina.Name = "visina";
            this.visina.Size = new System.Drawing.Size(134, 20);
            this.visina.TabIndex = 7;
            // 
            // tezina
            // 
            this.tezina.DecimalPlaces = 1;
            this.tezina.Location = new System.Drawing.Point(6, 54);
            this.tezina.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.tezina.Name = "tezina";
            this.tezina.Size = new System.Drawing.Size(134, 20);
            this.tezina.TabIndex = 6;
            this.tezina.ValueChanged += new System.EventHandler(this.tezina_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(144, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "(cm)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(146, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "(kg)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Visina:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Težina:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.izuzetnoTeskaAktivnost);
            this.groupBox3.Controls.Add(this.teskaAktivnost);
            this.groupBox3.Controls.Add(this.umjerenaAktivnost);
            this.groupBox3.Controls.Add(this.laganaAktivnost);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(12, 190);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(165, 145);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Nivo aktivnosti";
            // 
            // izuzetnoTeskaAktivnost
            // 
            this.izuzetnoTeskaAktivnost.AutoSize = true;
            this.izuzetnoTeskaAktivnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.izuzetnoTeskaAktivnost.Location = new System.Drawing.Point(22, 112);
            this.izuzetnoTeskaAktivnost.Name = "izuzetnoTeskaAktivnost";
            this.izuzetnoTeskaAktivnost.Size = new System.Drawing.Size(107, 17);
            this.izuzetnoTeskaAktivnost.TabIndex = 3;
            this.izuzetnoTeskaAktivnost.Text = "izuzetno teška";
            this.izuzetnoTeskaAktivnost.UseVisualStyleBackColor = true;
            // 
            // teskaAktivnost
            // 
            this.teskaAktivnost.AutoSize = true;
            this.teskaAktivnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teskaAktivnost.Location = new System.Drawing.Point(22, 86);
            this.teskaAktivnost.Name = "teskaAktivnost";
            this.teskaAktivnost.Size = new System.Drawing.Size(56, 17);
            this.teskaAktivnost.TabIndex = 2;
            this.teskaAktivnost.Text = "teška";
            this.teskaAktivnost.UseVisualStyleBackColor = true;
            // 
            // umjerenaAktivnost
            // 
            this.umjerenaAktivnost.AutoSize = true;
            this.umjerenaAktivnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.umjerenaAktivnost.Location = new System.Drawing.Point(22, 58);
            this.umjerenaAktivnost.Name = "umjerenaAktivnost";
            this.umjerenaAktivnost.Size = new System.Drawing.Size(76, 17);
            this.umjerenaAktivnost.TabIndex = 1;
            this.umjerenaAktivnost.Text = "umjerena";
            this.umjerenaAktivnost.UseVisualStyleBackColor = true;
            // 
            // laganaAktivnost
            // 
            this.laganaAktivnost.AutoSize = true;
            this.laganaAktivnost.Checked = true;
            this.laganaAktivnost.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laganaAktivnost.Location = new System.Drawing.Point(22, 27);
            this.laganaAktivnost.Name = "laganaAktivnost";
            this.laganaAktivnost.Size = new System.Drawing.Size(63, 17);
            this.laganaAktivnost.TabIndex = 0;
            this.laganaAktivnost.TabStop = true;
            this.laganaAktivnost.Text = "lagana";
            this.laganaAktivnost.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.zeljenaTezina);
            this.groupBox4.Controls.Add(this.datumOstvarenjaCilja);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.ciljUdebljatiSe);
            this.groupBox4.Controls.Add(this.ciljOdrzati);
            this.groupBox4.Controls.Add(this.ciljSmrsati);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(183, 190);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(293, 145);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Cilj";
            // 
            // zeljenaTezina
            // 
            this.zeljenaTezina.DecimalPlaces = 1;
            this.zeljenaTezina.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeljenaTezina.Location = new System.Drawing.Point(149, 107);
            this.zeljenaTezina.Name = "zeljenaTezina";
            this.zeljenaTezina.Size = new System.Drawing.Size(88, 20);
            this.zeljenaTezina.TabIndex = 14;
            // 
            // datumOstvarenjaCilja
            // 
            this.datumOstvarenjaCilja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datumOstvarenjaCilja.Location = new System.Drawing.Point(149, 52);
            this.datumOstvarenjaCilja.Name = "datumOstvarenjaCilja";
            this.datumOstvarenjaCilja.Size = new System.Drawing.Size(123, 20);
            this.datumOstvarenjaCilja.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(243, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(29, 13);
            this.label10.TabIndex = 13;
            this.label10.Text = "(kg)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(146, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Željena težina:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(146, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(134, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Datum ostvarenja clja:";
            // 
            // ciljUdebljatiSe
            // 
            this.ciljUdebljatiSe.AutoSize = true;
            this.ciljUdebljatiSe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciljUdebljatiSe.Location = new System.Drawing.Point(17, 105);
            this.ciljUdebljatiSe.Name = "ciljUdebljatiSe";
            this.ciljUdebljatiSe.Size = new System.Drawing.Size(90, 17);
            this.ciljUdebljatiSe.TabIndex = 8;
            this.ciljUdebljatiSe.Text = "udebljati se";
            this.ciljUdebljatiSe.UseVisualStyleBackColor = true;
            // 
            // ciljOdrzati
            // 
            this.ciljOdrzati.AutoSize = true;
            this.ciljOdrzati.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciljOdrzati.Location = new System.Drawing.Point(17, 67);
            this.ciljOdrzati.Name = "ciljOdrzati";
            this.ciljOdrzati.Size = new System.Drawing.Size(101, 17);
            this.ciljOdrzati.TabIndex = 7;
            this.ciljOdrzati.Text = "održati težinu";
            this.ciljOdrzati.UseVisualStyleBackColor = true;
            // 
            // ciljSmrsati
            // 
            this.ciljSmrsati.AutoSize = true;
            this.ciljSmrsati.Checked = true;
            this.ciljSmrsati.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ciljSmrsati.Location = new System.Drawing.Point(17, 29);
            this.ciljSmrsati.Name = "ciljSmrsati";
            this.ciljSmrsati.Size = new System.Drawing.Size(64, 17);
            this.ciljSmrsati.TabIndex = 6;
            this.ciljSmrsati.TabStop = true;
            this.ciljSmrsati.Text = "smršati";
            this.ciljSmrsati.UseVisualStyleBackColor = true;
            // 
            // dodaj
            // 
            this.dodaj.Location = new System.Drawing.Point(320, 341);
            this.dodaj.Name = "dodaj";
            this.dodaj.Size = new System.Drawing.Size(75, 22);
            this.dodaj.TabIndex = 4;
            this.dodaj.Text = "Izmijeni";
            this.dodaj.UseVisualStyleBackColor = true;
            this.dodaj.Click += new System.EventHandler(this.dodaj_Click);
            // 
            // izadji
            // 
            this.izadji.Location = new System.Drawing.Point(401, 341);
            this.izadji.Name = "izadji";
            this.izadji.Size = new System.Drawing.Size(75, 22);
            this.izadji.TabIndex = 6;
            this.izadji.Text = "Izađi";
            this.izadji.UseVisualStyleBackColor = true;
            this.izadji.Click += new System.EventHandler(this.izadji_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 367);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(485, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // KorisnickiPodaci
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(485, 389);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.izadji);
            this.Controls.Add(this.dodaj);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "KorisnickiPodaci";
            this.Text = "Korisnički podaci";
            this.Load += new System.EventHandler(this.KorisnickiPodaci_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.visina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tezina)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.zeljenaTezina)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ime;
        private System.Windows.Forms.RadioButton spolZensko;
        private System.Windows.Forms.RadioButton spolMusko;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton izuzetnoTeskaAktivnost;
        private System.Windows.Forms.RadioButton teskaAktivnost;
        private System.Windows.Forms.RadioButton umjerenaAktivnost;
        private System.Windows.Forms.RadioButton laganaAktivnost;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton ciljUdebljatiSe;
        private System.Windows.Forms.RadioButton ciljOdrzati;
        private System.Windows.Forms.RadioButton ciljSmrsati;
        private System.Windows.Forms.DateTimePicker datumRodjenja;
        private System.Windows.Forms.NumericUpDown tezina;
        private System.Windows.Forms.NumericUpDown zeljenaTezina;
        private System.Windows.Forms.DateTimePicker datumOstvarenjaCilja;
        private System.Windows.Forms.Button dodaj;
        private System.Windows.Forms.Button izadji;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TextBox prezime;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown visina;


    }
}

