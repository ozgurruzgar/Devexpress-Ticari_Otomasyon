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
using DevExpress.Charts;
using System.Xml;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        SqlBaglantisi bgl = new SqlBaglantisi();
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }
        void AzalanStoklar()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute AZALANSTOKLAR",bgl.baglanti());
            da.Fill(dt);
            GridAzalanStok.DataSource = dt;
        }
        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select Top 7 NOTTARIH,NOTBASLIK,NOTDETAY From TBL_NOTLAR order by NOTID Desc",bgl.baglanti());
            da.Fill(dt);
            GridAjanda.DataSource = dt;
        }
        void Son10Hareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Execute Firmahareket2", bgl.baglanti());
            da.Fill(dt);
            GridFirmaHareketleri.DataSource = dt;
        }
        void Fihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,TELEFON1 From TBL_FIRMALAR",bgl.baglanti());
            da.Fill(dt);
            GridFihrist.DataSource = dt;
        }
        void Haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://hurriyet.com.tr/rss/anasayfa");
            while(xmloku.Read())
            {
              if(xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            AzalanStoklar();
            Ajanda();
            Son10Hareket();
            Fihrist();
            Haberler();

            webBrowser1.Navigate("https://www.turkiye.gov.tr/doviz-kurlari");
        }
    }
}
