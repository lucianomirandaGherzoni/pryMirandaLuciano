using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace pryMirandaLuciano
{
    public partial class galaga : Form
    {
        int contador = 0;
        claseNave objNaveJugador;
        claseNave objNaveEnemiga;
        public List<PictureBox> navesEnemigas = new List<PictureBox>();

        private int velocidadDisparo = 50;
        private PictureBox disparo;
        private List<PictureBox> disparos = new List<PictureBox>();
        public galaga()
        {
            InitializeComponent();
        }

        private void galaga_Load(object sender, EventArgs e)
        {
            objNaveJugador = new claseNave();
            objNaveEnemiga = new claseNave();
            objNaveJugador.crearNaveJugador();
            MessageBox.Show( " nombre: " + objNaveJugador.nombre +  " vida: " + objNaveJugador.vida);
            objNaveJugador.imagenNave.Location = new Point (250,600);
            Controls.Add(objNaveJugador.imagenNave);

        }

        //movimientos de la nave
        private void galaga_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                if (objNaveJugador.imagenNave.Location.X < 500)
                {
                    objNaveJugador.imagenNave.Location = new Point(objNaveJugador.imagenNave.Location.X + 5, objNaveJugador.imagenNave.Location.Y);
                }


            }
            if (e.KeyCode == Keys.Left)
            {
                if (objNaveJugador.imagenNave.Location.X > 0)
                {
                    objNaveJugador.imagenNave.Location = new Point(objNaveJugador.imagenNave.Location.X - 5, objNaveJugador.imagenNave.Location.Y);
                }


            }
            if (e.KeyCode == Keys.Space)
            {
                crearDisparo();

                timerDisparo.Stop();
                timerDisparo.Start();
                this.Focus();
            }
        }

        // creacion de naves enemigas

        private void timerNaveEnemigas_Tick(object sender, EventArgs e)
        {
            if (contador < 10)
            {

                objNaveEnemiga.crearNaveEnemiga();

                bool existe = false;
                foreach (PictureBox naveExistente in navesEnemigas) { 
                
                 if (objNaveEnemiga.imagenNave.Bounds.IntersectsWith(naveExistente.Bounds))
                    {
                        existe = true;
                        break;
                    }
                }
                if (!existe)
                {
                    Controls.Add(objNaveEnemiga.imagenNave);
                    navesEnemigas.Add(objNaveEnemiga.imagenNave);
                    contador++;
                }
            }
            else
            {
                timerNaveEnemigas.Stop();
            }
        }

        //Disparo

        public void crearDisparo ()
        {
            disparo = new PictureBox();
            disparo.Image = Properties.Resources.disparo;
            disparo.BackColor = Color.Transparent;
            disparo.Size = new Size(30, 30);
            disparo.SizeMode = PictureBoxSizeMode.StretchImage;
            disparo.Location = new Point(objNaveJugador.imagenNave.Location.X + objNaveJugador.imagenNave.Width / 2 - disparo.Width / 2, objNaveJugador.imagenNave.Location.Y);
            Controls.Add(disparo);
            disparos.Add(disparo);

        }

        private void timerDisparo_Tick(object sender, EventArgs e)
        {
            ActualizarPosicionDisparo();
        }
        private void ActualizarPosicionDisparo()
        {
            if (disparo != null)
            {
                disparo.Top -= velocidadDisparo;

                // no permite que hayan 2 balas disparadas al mismo tiempo
                if (disparos.Count >= 2)
                {
                    PictureBox segundoDisparo = disparos[disparos.Count - 2];
                    Controls.Remove(segundoDisparo);
                    disparos.Remove(segundoDisparo);
                    segundoDisparo.Dispose();
                }

                //desaparece el disparo si llega al limite del formulario
                if (disparo.Top + disparo.Height < 0)
                {
                    timerDisparo.Stop();
                    disparo.Dispose();
                }
            }
        }
        private void DetectarColisiones()
        {
            foreach (PictureBox disparo in disparos)
            {
                Rectangle balaHitbox = new Rectangle(disparo.Location, disparo.Size);

                foreach (Control enemigos in this.Controls)
                {
                    if (enemigos.Tag != null)
                    {
                        Rectangle enemigosHitbox = new Rectangle(enemigos.Location, enemigos.Size);

                        if (balaHitbox.IntersectsWith(enemigosHitbox))
                        {

                            // Eliminar tanto la bala como el enemigo
                            this.Controls.Remove(disparo);
                            this.Controls.Remove(enemigos);
                            disparo.Dispose();
                            enemigos.Dispose();
                            break;
                        }
                    }
                }
            }
        }
    }
}