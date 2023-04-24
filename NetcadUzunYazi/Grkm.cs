using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCMacro;

namespace NetcadUzunYazi
{
    public partial class Grkm : Form
    {
        bool dragging;
        System.Drawing.Point offset;

        public Grkm()
        {
            InitializeComponent();
        }

        private void Grkm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            offset = e.Location;
        }

        private void Grkm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                System.Drawing.Point currentScreenPos = PointToScreen(e.Location);
                Location = new
                System.Drawing.Point(currentScreenPos.X - offset.X,
                currentScreenPos.Y - offset.Y);
            }
        }

        private void Grkm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        
        public void MetniParcala(string metin, int maksimumUzunluk, List<string> parcalar)
        {
            int index = 0;

            while (index < metin.Length)
            {
                if (metin.Length - index <= maksimumUzunluk)
                {
                    parcalar.Add(metin.Substring(index));
                    break;
                }

                int sonIndex = index + maksimumUzunluk;

                while (sonIndex > index && metin[sonIndex] != ' ')
                {
                    sonIndex--;
                }

                if (sonIndex == index)
                {
                    sonIndex += maksimumUzunluk;
                }
                else
                {
                    sonIndex++;
                }

                parcalar.Add(metin.Substring(index, sonIndex - index).Trim());
                index = sonIndex;
            }
        }
        
        private void btn6699648845121_Click(object sender, EventArgs e)
        {
            if (tb325346457457.Text.Trim() == "")
            { tb325346457457.Text = "1"; }

            double yaziboyu = Convert.ToDouble(tb325346457457.Text);

            if (rtb56456346345345.Text.Trim() == "")
            { rtb56456346345345.Text = "Netcad Modül Örneği - www.github.com/grkm"; }
            string yazi = rtb56456346345345.Text;

            int maksimumUzunluk = 50;
            List<string> parcalar = new List<string>();

            MetniParcala(yazi, maksimumUzunluk, parcalar);

            double genislik = 1.60;
            if (cb213123123.SelectedIndex == 0) { genislik = 1.20; }
            else if (cb213123123.SelectedIndex == 1) { genislik = 1.40; }
            else if (cb213123123.SelectedIndex == 2) { genislik = 1.60; }
            else if (cb213123123.SelectedIndex == 3) { genislik = 1.80; }
            else { genislik = 2; }

            double nx = yaziboyu*genislik;
            NCSObj sonucyazdir = new NCSObj();
            bool SelectPoint1;
            NCCoor koordinat1 = new NCCoor();
            koordinat1 = sonucyazdir.newc(0, 0, 0);
            SelectPoint1 = sonucyazdir.SelectPoint("Sonuçları Seçilen Yere Yazdır", koordinat1, 2);
            
            for (int i = 0; i < parcalar.Count; i++)
            {
                sonucyazdir.AddObject(sonucyazdir.MakeText(koordinat1, parcalar[i], 0, 0, yaziboyu, 0, "1", sonucyazdir.CreateLayer("GRKM_YAZI", 4)));

                koordinat1.x = koordinat1.x - nx;
            }
        }

        private void Grkm_Load(object sender, EventArgs e)
        {
            cb213123123.SelectedIndex = 2;
        }

        private void btnCloseAnaEkran_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizeAnaEkran_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
