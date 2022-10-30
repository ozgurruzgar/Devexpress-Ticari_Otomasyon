using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }       


        private void Btn_Girisyap_Click(object sender, EventArgs e)
        {
            //Giriş Yap Butonu
            SqlCommand komut = new SqlCommand("Select * From TBL_ADMIN Where KULLANICIAD=@P1 and SIFRE=@P2", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtKullaniciad.Text);
            komut.Parameters.AddWithValue("@P2", TxtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnaModul fr = new FrmAnaModul();
                fr.kullanici = TxtKullaniciad.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı Veya Şifre Hatalı!!1", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bgl.baglanti().Close();
            }
        }

        private void LnkLblSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmSifremiUnuttum fr = new FrmSifremiUnuttum();
            string[] Kelimeler = { "a", "B", "c", "D", "E", "f", "G", "K", "l" };
            string uret = "";
            Random rnd = new Random();
            for (int i = 0; i <= 7; i++)
            {
                string sifre = uret += Kelimeler[rnd.Next(Kelimeler.Length)];
                fr.yenisifre = sifre;
                fr.Show();
            }
        }

        private void Btn_Girisyap_MouseHover(object sender, EventArgs e)
        {
            //imlec butonun üzerinden ayrılınca arka plan rengi değişimi
            Btn_Girisyap.BackColor = Color.Aquamarine;
        }

        private void Btn_Girisyap_MouseLeave(object sender, EventArgs e)
        {
            //imlec butonun üzerinden ayrılınca arka plan rengi değişimi
            Btn_Girisyap.BackColor = Color.MediumAquamarine;
        }
    }
}
