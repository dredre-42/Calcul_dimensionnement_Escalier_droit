using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace découverte_Visual_Studio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
    


        }

        private void calculer_Click(object sender, EventArgs e)
        {
            lancerCalcul();
        }

        void dessiner(double h, double l, int num)
        {
            // le premier point est en bas à gauche
            //      mais x = 0 et y = num 
            // le deuxième point = l'axe y du premier point + h
            // le 3ème = l'axe x du 2ème + l
            // faire ça le nombre de marche donc num
            // dessiner en reliant tout ses points

            Bitmap image = new Bitmap(dessin.Width, dessin.Height);
            using(Graphics g = Graphics.FromImage(image))
            {

                //int i = 0;
                //while int i < num
                //      h += h


                Point ptOrigin = new Point(0, dessin.Height);
                Point ptavant = ptOrigin;

                string err = "Bonjour";
                string err2 = " truc";
                err += " !!!!!" + err2;
                lblerreur.Text = err;


                for (int i = 0; i < num; i++)
                {


                    Point pt1 = ptavant;

                    Point pt2 = new Point(pt1.X, Convert.ToInt32(Math.Round(pt1.Y - h, 0)));

                    Point pt3 = new Point(Convert.ToInt32(Math.Round(pt2.X + l, 0)), pt2.Y);

                    g.DrawLine(new Pen(Color.Black), pt1.X, pt1.Y, pt2.X, pt2.Y);
                    g.DrawLine(new Pen(Color.Black), pt2.X, pt2.Y, pt3.X, pt3.Y);

                    if (i != 0)
                    {
                        ptavant = pt3;
                    }
                

                }



            }

            dessin.Image = image;
        }
        void lancerCalcul()
        {
            double H = 0;
            double hcible = 0;

            if (boxhcible.Text == "")
            {
                hcible = 15;
            }
            else if (double.TryParse(boxhcible.Text, out hcible) == false)
            {
                hcible = 15;
            }

            else
            {
                hcible = Convert.ToDouble(this.boxhcible.Text);
            }

            if (boxH.Text == "" || double.TryParse(boxH.Text, out H) == false)
            {
                H = 300;
            }
            else
            {
                H = Convert.ToDouble(this.boxH.Text);
            }

            calculerEscalier(H, hcible);


        }

        void calculerEscalier(double H, double hcible)
        {
          
            // Calcul
            //définir le nombre de marche - num
            //définir la hauteur de marche - h
            //définir la largueur de marche - l
            //63=2h+l
            int num = Convert.ToInt32(Math.Round(H / hcible, 0));
            double h = H / num;
            double l = 63 - (2 * hcible);
            double L = l * num;


            // h hauteur d'une marche
            //l longueur d'une marche
            //nom nombre de marches
            lblh.Text = h.ToString();
            lblhh.Text = H.ToString();
            lbll.Text = l.ToString();
            lblll.Text = L.ToString();
            lblnum.Text = num.ToString();

            dessiner(h, l, num);
        }

        private void Form1_ResizeEnd(Object sender, EventArgs e)

        {
            lancerCalcul();
        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblh_Click(object sender, EventArgs e)
        {

        }

        private void lbll_Click(object sender, EventArgs e)
        {

        }

        private void boxhcible_TextChanged(object sender, EventArgs e)
        {
            //lancerCalcul();
        }
        private void boxH_TextChanged(object sender, EventArgs e)
        {
          //  lancerCalcul();
        }

    }
}
