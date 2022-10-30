
namespace Ticari_Otomasyon
{
    partial class FrmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdmin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.TxtKullaniciad = new DevExpress.XtraEditors.TextEdit();
            this.TxtSifre = new DevExpress.XtraEditors.TextEdit();
            this.LnkLblSifremiUnuttum = new System.Windows.Forms.LinkLabel();
            this.Btn_Girisyap = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciad.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.labelControl3);
            this.panel1.Controls.Add(this.labelControl1);
            this.panel1.Location = new System.Drawing.Point(328, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(453, 487);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(453, 38);
            this.panel2.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button1.BackColor = System.Drawing.Color.DarkRed;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.button1.Location = new System.Drawing.Point(405, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "X";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(4, 461);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(409, 21);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Bu Proje Özgür RÜZGAR Tarafından Yapılmıştır. @2022";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Segoe Script", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(76, 153);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(305, 136);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "    TİCARİ\r\nOTOMASYON";
            // 
            // TxtKullaniciad
            // 
            this.TxtKullaniciad.Location = new System.Drawing.Point(34, 185);
            this.TxtKullaniciad.Name = "TxtKullaniciad";
            this.TxtKullaniciad.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtKullaniciad.Properties.Appearance.Options.UseFont = true;
            this.TxtKullaniciad.Properties.NullText = "Kullanıcı Adı";
            this.TxtKullaniciad.Size = new System.Drawing.Size(260, 34);
            this.TxtKullaniciad.TabIndex = 1;
            // 
            // TxtSifre
            // 
            this.TxtSifre.Location = new System.Drawing.Point(34, 225);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TxtSifre.Properties.Appearance.Options.UseFont = true;
            this.TxtSifre.Properties.NullText = "Şifre";
            this.TxtSifre.Properties.UseSystemPasswordChar = true;
            this.TxtSifre.Size = new System.Drawing.Size(260, 34);
            this.TxtSifre.TabIndex = 2;
            // 
            // LnkLblSifremiUnuttum
            // 
            this.LnkLblSifremiUnuttum.AutoSize = true;
            this.LnkLblSifremiUnuttum.LinkColor = System.Drawing.Color.Black;
            this.LnkLblSifremiUnuttum.Location = new System.Drawing.Point(182, 267);
            this.LnkLblSifremiUnuttum.Name = "LnkLblSifremiUnuttum";
            this.LnkLblSifremiUnuttum.Size = new System.Drawing.Size(112, 17);
            this.LnkLblSifremiUnuttum.TabIndex = 3;
            this.LnkLblSifremiUnuttum.TabStop = true;
            this.LnkLblSifremiUnuttum.Text = "Şifremi Unuttum.";
            this.LnkLblSifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkLblSifremiUnuttum_LinkClicked);
            // 
            // Btn_Girisyap
            // 
            this.Btn_Girisyap.Appearance.BackColor = System.Drawing.Color.MediumAquamarine;
            this.Btn_Girisyap.Appearance.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Btn_Girisyap.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Btn_Girisyap.Appearance.Options.UseBackColor = true;
            this.Btn_Girisyap.Appearance.Options.UseFont = true;
            this.Btn_Girisyap.Appearance.Options.UseForeColor = true;
            this.Btn_Girisyap.Location = new System.Drawing.Point(70, 307);
            this.Btn_Girisyap.Name = "Btn_Girisyap";
            this.Btn_Girisyap.Size = new System.Drawing.Size(196, 46);
            this.Btn_Girisyap.TabIndex = 4;
            this.Btn_Girisyap.Text = "Giriş Yap";
            this.Btn_Girisyap.Click += new System.EventHandler(this.Btn_Girisyap_Click);
            this.Btn_Girisyap.MouseLeave += new System.EventHandler(this.Btn_Girisyap_MouseLeave);
            this.Btn_Girisyap.MouseHover += new System.EventHandler(this.Btn_Girisyap_MouseHover);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Segoe Print", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(89, 53);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(154, 104);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "    HOŞ\r\nGELDİNİZ";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Location = new System.Drawing.Point(-2, -2);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(330, 39);
            this.panelControl1.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.Location = new System.Drawing.Point(46, 9);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(130, 21);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Ticari Otomasyon";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.MediumAquamarine;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // FrmAdmin
            // 
            this.AcceptButton = this.Btn_Girisyap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 483);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.Btn_Girisyap);
            this.Controls.Add(this.LnkLblSifremiUnuttum);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.TxtKullaniciad);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAdmin";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.TxtKullaniciad.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TxtSifre.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.TextEdit TxtKullaniciad;
        private DevExpress.XtraEditors.TextEdit TxtSifre;
        private System.Windows.Forms.LinkLabel LnkLblSifremiUnuttum;
        private DevExpress.XtraEditors.SimpleButton Btn_Girisyap;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
    }
}