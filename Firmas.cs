using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace pryMirandaLuciano
{
    public partial class Firmas : Form
    {
        Point puntoInicial;
        List<Point> points = new List<Point>();
        bool dibujar = false;
        List<List<Point>> firmas = new List<List<Point>>();
        List<Point> firma = new List<Point>();
        Bitmap firmaBitmap;
        Bitmap bitmap; // Bitmap utilizado para dibujar en el PictureBox
        Graphics grafico; // Objeto Graphics para dibujar en el Bitmap
        public Firmas()
        {
            InitializeComponent();
            iniciarFirma();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Firmas_Load(object sender, EventArgs e)
        {

        }
        //se termina de dibujar la firma
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            dibujar = false;

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            firma.Add(e.Location);
            dibujar = true;
            puntoInicial = e.Location;
        }
        private void iniciarFirma()
        {
            firmaBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = firmaBitmap;
            Graphics.FromImage(firmaBitmap).Clear(Color.White);
        }
    }
}
