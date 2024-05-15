using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMirandaLuciano
{
    internal class claseNave
    {
        //propiedades
        public int vida;
        public string nombre;
        int daño;
        public PictureBox imagenNave;

        int posX;
        int posY;
        public List<PictureBox> navesEnemigas;
        public void crearNaveJugador(){
            vida = 100;
            nombre = "jugador 1";
            daño = 25;
            imagenNave = new PictureBox();
            imagenNave.SizeMode =  PictureBoxSizeMode.StretchImage;
            imagenNave.Image = Properties.Resources.nave;

        }

        public void crearNaveEnemiga()
        {
            Random random = new Random();
            Random px = new Random();
            Random py = new Random();
            imagenNave = new PictureBox();
            imagenNave.Size = new System.Drawing.Size(50, 50);
            imagenNave.SizeMode = PictureBoxSizeMode.StretchImage;
            posX = px.Next(0, 500);
            posY = py.Next(0, 100);
            imagenNave.Location = new Point(posX, posY);
        
            switch (random.Next(1, 3))
            {
                case 1:
                    vida = 25;
                    nombre = "jugadorEnemigo 1";
                    daño = 10;
                    imagenNave.Image = Properties.Resources.nave_enemiga;
                    break;

                case 2:
                    vida = 30;
                    nombre = "jugadorEnemigo 2";
                    daño = 15;
                    imagenNave.Image = Properties.Resources.nave_enemiga_2;
                    break;


                case 3:
                    vida = 35;
                    nombre = "jugadorEnemigo 3";
                    daño = 20;
                    imagenNave.Image = Properties.Resources.nave_enemiga_3;
                    break;



            }
            
 
        }
        
        


    }
}
