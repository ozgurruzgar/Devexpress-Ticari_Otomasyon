﻿using System;
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
    public partial class FrmStoklar : Form
    {
        public FrmStoklar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        private void FrmStoklar_Load(object sender, EventArgs e)
        {
            //chartControl1.Series["Series 1"].Points.AddPoint("İstanbul", 4);
            //chartControl1.Series["Series 1"].Points.AddPoint("İzmir", 8);
            //chartControl1.Series["Series 1"].Points.AddPoint("Ankara", 6);
            //chartControl1.Series["Series 1"].Points.AddPoint("Adana", 5);

            SqlDataAdapter da = new SqlDataAdapter("Select URUNAD,Sum(ADET) AS ADET from TBL_URUNLER Group By URUNAD",bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;

            //Charta Stok Miktarı Listeleme
            SqlCommand komut = new SqlCommand("Select URUNAD,Sum(ADET) AS ADET from TBL_URUNLER Group By URUNAD",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(dr[0].ToString(),int.Parse(dr[1].ToString()));
            }
            bgl.baglanti().Close();


            //Charta Firma Şehir Sayısı Çekme
            SqlCommand komut2 = new SqlCommand("Select IL,Count(*) AS FİRMA from TBL_FIRMALAR Group By IL", bgl.baglanti());
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Series 1"].Points.AddPoint(dr2[0].ToString(), int.Parse(dr2[1].ToString()));
            }
            bgl.baglanti().Close();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmStokDetay fr = new FrmStokDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.ad = dr["URUNAD"].ToString();
                fr.Show();
            }
        }
    }
}
