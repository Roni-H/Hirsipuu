using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hirsipuu_peli_paranneltu__Roni
{
    public partial class Form2 : Form
    {

        // Taulukko
        string[] sanat = {
            "derbi", "husqvarna", "husaberg", "ktm", "yamaha",
            "honda", "tm", "suzuki", "gasgas", "beta", "sherco",
            "drac", "rieju", "samurai", "jincheng", "bmw", "aprilia",
            "vespa", "ducati", "piaggio", "kawasaki", "jawa", "harley-davidson"
                        };

        char arvoo;
        int i = 0;
        bool onko = false;
        bool loyty = false;
        int yritykset = 10;
        string randomSana;
        string arvatutKirjaimet;

        public Form2()
        {
            InitializeComponent();
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //Elämät
        private void label2_Click(object sender, EventArgs e)
        {

        }

        //Uusi peli button
        private void button3_Click(object sender, EventArgs e)
        {
            arvatutKirjaimet = "";
            label2.Text = "10";
            yritykset = 10;

            Random rnd = new Random();

            //kuva
            taso1();

            //2: Arvotaan yksi sana taulukosta ja muutetaan se stringiksi
            int sIndex = rnd.Next(sanat.Length);
            randomSana = sanat[sIndex];
            int kirjainMaara = randomSana.Length;
            teksti(randomSana);
        }

        //Arvaa button
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                arvoo = textBox2.Text[0];

                for (i = 0; i < arvatutKirjaimet.Length; i++)
                {
                    if (arvatutKirjaimet[i] == arvoo && !loyty)
                    {
                        loyty = true;
                        MessageBox.Show("Olet arvannut jo tämän kirjaimen!");
                    }
                }

                arvatutKirjaimet = arvatutKirjaimet + textBox2.Text[0];

                string arvattavaSana = randomSana;

                for (i = 0; i < arvattavaSana.Length; i++)
                {
                    if (arvattavaSana[i] == arvoo)
                    {
                        onko = true;
                        label3.Text = label3.Text.Remove(i, 1);
                        label3.Text = label3.Text.Insert(i, arvoo.ToString());
                    }
                }

                //Kun sana on arvattu peli kertoo että voitit
                if (label3.Text.ToUpper() == randomSana.ToUpper())
                    voitit();

                //Jos kirjain ei löytyny ja kirjainta ei oltu arvattu vielä TEE

                if (!arvattavaSana.Contains(arvoo) && !loyty)
                //if (!onko && !loyty)
                {
                    yritykset--;
                    label2.Text = Convert.ToString(yritykset);

                    //Asian olisi varmasti voinut tehdä helpommalla tavallakin :D
                    if (yritykset == 10)
                    {
                        taso1();
                    }
                    else if (yritykset == 9)
                    {
                        taso2();
                    }
                    else if (yritykset == 8)
                    {
                        taso3();
                    }
                    else if (yritykset == 7)
                    {
                        taso4();
                    }
                    else if (yritykset == 6)
                    {
                        taso5();

                    }
                    else if (yritykset == 5)
                    {
                        taso6();

                    }
                    else if (yritykset == 4)
                    {
                        taso7();

                    }
                    else if (yritykset == 3)
                    {
                        taso8();

                    }
                    else if (yritykset == 2)
                    {
                        taso9();
                    }
                    else if (yritykset == 1)
                    {
                        taso10();
                    }
                    else if (yritykset <= 0)
                    {
                        noMoreLifes();
                    }
                    //--

                    if (yritykset == 0)
                        havisit();
                }


                onko = false;
                loyty = false;
            }
            else
            {
                MessageBox.Show("Syötä kirjain!");
            }
        }

        //Päävalikko
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void teksti(string randomSana)
        {
            label3.Text = "";
            for (i = 0; i < randomSana.Length; i++)
            {
                label3.Text = label3.Text.Insert(i, "*");
            }

        }

        private void voitit()
        {
            MessageBox.Show("VOITIT PELIN! ONNEKSI OLKOON!");
            textBox2.Text = "";
        }
        private void havisit()
        {
            MessageBox.Show("HÄVISIT PELIN!");
            textBox2.Text = "";
            //restartGame();
        }

        private void noMoreLifes()
        {
            MessageBox.Show("Sinulla ei ole yhtään elämää jäljellä! Aloita uusi peli.");
        }

        private void restartGame()
        {
            arvatutKirjaimet = "";
            label2.Text = "10";
            yritykset = 10;
            Random rnd = new Random();
            int sIndex = rnd.Next(sanat.Length);
            randomSana = sanat[sIndex];
            int kirjainMaara = randomSana.Length;
            taso1();
            teksti(randomSana);
        }

        //Viivat jotka tulevat ohjelman startattua
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*System.Drawing.Graphics graphicsObj;

            graphicsObj = this.CreateGraphics();

            Pen myPen = new Pen(System.Drawing.Color.Black, 5);

            graphicsObj.DrawLine(myPen, 375, 50, 575, 50);*/


        }

        //Pelin kuvat
        //Taso 1
        private void taso1()
        {
            pictureBox2.Image = imageList1.Images[0];
        }
        //Taso 2
        private void taso2()
        {
            pictureBox2.Image = imageList1.Images[1];
        }
        //Taso 3
        private void taso3()
        {
            pictureBox2.Image = imageList1.Images[2];
        }
        //Taso 4
        private void taso4()
        {
            pictureBox2.Image = imageList1.Images[3];
        }
        //Taso 5
        private void taso5()
        {
            pictureBox2.Image = imageList1.Images[4];
        }
        //Taso 6
        private void taso6()
        {
            pictureBox2.Image = imageList1.Images[5];
        }
        //Taso 7
        private void taso7()
        {
            pictureBox2.Image = imageList1.Images[6];
        }
        //Taso 8
        private void taso8()
        {
            pictureBox2.Image = imageList1.Images[7];
        }
        //Taso 9
        private void taso9()
        {
            pictureBox2.Image = imageList1.Images[8];
        }
        //Taso 10
        private void taso10()
        {
            pictureBox2.Image = imageList1.Images[9];
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            //this.BackColor = Color.Black;
        }
    }
}
