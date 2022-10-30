using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmSifremiUnuttum : Form
    {
        public FrmSifremiUnuttum()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        public string yenisifre;
        private void FrmSifremiUnuttum_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Gonder_MouseHover(object sender, EventArgs e)
        {
            Btn_Gonder.BackColor = Color.Aquamarine;
        }

        private void Btn_Gonder_MouseLeave(object sender, EventArgs e)
        {
            Btn_Gonder.BackColor = Color.MediumAquamarine;
        }
        private void Btn_Gonder_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            progressBar1.Value = 25;
            progressBar1.Value = 50;
            SqlCommand kmt = new SqlCommand("Select * From TBL_ADMIN", bgl.baglanti());
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                if (TxtMail.Text == dr[2].ToString())
                {
                    SqlCommand komut = new SqlCommand("Update TBL_ADMIN set SIFRE=@P1 Where MAIL=@P2", bgl.baglanti());
                    komut.Parameters.AddWithValue("@P1", yenisifre.ToString());
                    komut.Parameters.AddWithValue("@P2", TxtMail.Text);
                    komut.ExecuteNonQuery();
                    bgl.baglanti().Close();

                    MailMessage mesajim = new MailMessage();
                    SmtpClient istemci = new SmtpClient();
                    istemci.Credentials = new System.Net.NetworkCredential("rozgur319@outlook.com", "o12332321");
                    istemci.Port = 587;
                    istemci.Host = "smtp.outlook.com";
                    istemci.EnableSsl = true;
                    mesajim.To.Add(TxtMail.Text);
                    mesajim.From = new MailAddress("rozgur319@outlook.com");
                    mesajim.Subject = "Noreply Ticari Otomasyon Yeni Sifreniz...";
                    mesajim.Body = "Merhaba Yeni Şifren : " + yenisifre + " 'dir. Ticari Otomasyon";
                    istemci.Send(mesajim);
                    progressBar1.Value = 100;
                    progressBar1.Visible = false;
                    MessageBox.Show("Yeni Şifreniz Mail Adresinize Gönderilmiştir!!!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                }
            }
            MessageBox.Show("Geçerli Bir Mail Adresi Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            progressBar1.Visible = false;
        }
    }
}

    


 

