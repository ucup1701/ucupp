using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TAucup
{
    public partial class Form1 : Form
    {
        class Data
        {
            int avanza;
            int xenia;
            int apv;
            int innova;
            int alphard;

            public void setAvanza(int val)
            {
                avanza = val;
            }
            public void setXenia(int val)
            {
                xenia = val;
            }
            public void setApv(int val)
            {
                apv = val;
            }
            public void setInnova(int val)
            {
                innova = val;
            }
            public void setAlphard(int val)
            {
                alphard = val;
            }

            public string getAvanza()
            {
                return Convert.ToString(avanza);
            }
            public string getXenia()
            {
                return Convert.ToString(xenia);
            }
            public string getApv()
            {
                return Convert.ToString(apv);
            }
            public string getInnova()
            {
                return Convert.ToString(innova);
            }
            public string getAlphard()
            {
                return Convert.ToString(alphard);
            }
            public string hitungbiaya(long val1, short val2)
            {
                return Convert.ToString(val1 * val2);
            }

        }

        public Form1()
        {
            InitializeComponent();
        }



        //variabel untuk proses
        long biaya_per_jam;
        short waktu;
        String mobil;
        DateTime tanggal_pinjam;
        DateTime tanggal_kembali;

        Data m = new Data();

        private void cbmobil_SelectedIndexChanged(object sender, EventArgs e)
        {

            mobil = Convert.ToString(cbmobil.SelectedItem);

            if (mobil == "Avanza")
            {
                m.setAvanza(40000);
                txtbiaya.Text = m.getAvanza();
            }
            else if (mobil == "Xenia")
            {
                m.setXenia(40000);
                txtbiaya.Text = m.getXenia();
            }
            else if (mobil == "APV")
            {
                m.setApv(50000);
                txtbiaya.Text = m.getApv();
            }
            else if (mobil == "Innova")
            {
                m.setInnova(50000);
                txtbiaya.Text = m.getInnova();
            }
            else if (mobil == "Alphard")
            {
                m.setAlphard(100000);
                txtbiaya.Text = m.getAlphard();
            }

        }

        private void tmpinjam_ValueChanged(object sender, EventArgs e)
        {


        }

        private void btnhitung_Click(object sender, EventArgs e)
        {

            if (Int64.TryParse(txtbiaya.Text, out biaya_per_jam) && Int16.TryParse(txtdurasi.Text, out waktu))
            {
                txtbayar.Text = "Rp. " + m.hitungbiaya(biaya_per_jam, waktu) + ",-";
            }
        }

        private void tmkembali_ValueChanged(object sender, EventArgs e)
        {

            tanggal_pinjam = tmpinjam.Value.Date + twpinjam.Value.TimeOfDay;
            tanggal_kembali = tmkembali.Value.Date + twkembali.Value.TimeOfDay;

            
            if (tanggal_kembali < tanggal_pinjam)
            {
                MessageBox.Show("Tanggal yang anda masukan salah");
            }
            else
            {
                TimeSpan temp = tanggal_kembali - tanggal_pinjam;
                txtdurasi.Text = Convert.ToString(Math.Round(temp.TotalHours));
            }
        }

        private void Reset_Click(object sender, EventArgs e)
        {
            txtbiaya.Clear();
            txtbayar.Clear();
            txtdurasi.Clear();
            cbmobil.SelectedIndex = -1;
            biaya_per_jam = 0;
            waktu = 0;
        }

        private void Txtdurasi_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtbiaya_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
