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

namespace Ticari_Otomasyon
{
    public partial class FrmMail : Form
    {
        public string mail;
        public FrmMail()
        {
            InitializeComponent();
        }

        private void FrmMail_Load(object sender, EventArgs e)
        {
            TxtMail.Text = mail.ToString();
        }
        private void Btn_Gönder_Click(object sender, EventArgs e)
        {
            MailMessage mesajim = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("Mail", "Şifre");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.Host = "smtp.hotmail.com";
            istemci.EnableSsl = true;
            mesajim.To.Add(TxtMail.Text);
            mesajim.From = new MailAddress("Mail");
            mesajim.Subject = TxtKonu.Text;
            mesajim.Body = RchMesaj.Text;
            istemci.Send(mesajim);
            MessageBox.Show("Yeni Şifreniz Mail Adresinize Gönderilmiştir!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void Btn_Gonder_MouseHover(object sender, EventArgs e)
        {
            Btn_Gonder.BackColor = Color.LightSkyBlue;
        }
        private void Btn_Gonder_MouseLeave(object sender, EventArgs e)
        {
            Btn_Gonder.BackColor = Color.SkyBlue;
        }
    }
}
