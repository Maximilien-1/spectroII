using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Interface_Spectrographe
{

    public partial class C_Affichage : Form
    {

        int OctetsCount = 0;
        private int[] l_AmplitudeSpectre = new int[1024];
        int resolution = 1024;
        private C_RaiesSpectrales[] Spectre;
        public C_Affichage()
        {


            InitializeComponent();
            //Resolution = nombres de barres affichées, 1024 : 1 barre par pixel, res max

            Spectre = new C_RaiesSpectrales[resolution];

            //variable des boucles for
            int iBcl = 0;
            for (iBcl = 0; iBcl < resolution; iBcl++)
            {
                Spectre[iBcl] = new C_RaiesSpectrales
                {


                    Size = new Size(1,0),
                    Location = new Point(1050 - iBcl, 600),
                    BackColor = CouleurLongueurOnde(400 + (iBcl * 300 / resolution))

                };
                this.Controls.Add(Spectre[iBcl]);

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private int Clamp(int valeur, int min, int max)
        {
            if (valeur < min) return min;
            if (valeur > max) return max;
            return valeur;
        }
        private Color CouleurLongueurOnde(double Lambda)
        {
            double gamma = 0.8;
            int rouge;
            int vert;
            int bleu;
            double intensite;

            if (Lambda >= 380 && Lambda <= 440)
            {
                rouge = (int)(-(Lambda - 440) / (440 - 380) * 255);
                vert = 0;
                bleu = 255;
            }
            else if (Lambda > 440 && Lambda <= 490)
            {
                rouge = 0;
                vert = (int)((Lambda - 440) / (490 - 440) * 255);
                bleu = 255;
            }
            else if (Lambda > 490 && Lambda <= 510)
            {
                rouge = 0;
                vert = 255;
                bleu = (int)(-(Lambda - 510) / (510 - 490) * 255);
            }
            else if (Lambda > 510 && Lambda <= 580)
            {
                rouge = (int)((Lambda - 510) / (580 - 510) * 255);
                vert = 255;
                bleu = 0;
            }
            else if (Lambda > 580 && Lambda <= 645)
            {
                rouge = 255;
                vert = (int)(-(Lambda - 645) / (645 - 580) * 255);
                bleu = 0;
            }
            else if (Lambda > 645 && Lambda <= 780)
            {
                rouge = 255;
                vert = 0;
                bleu = 0;
            }
            else
            {
                rouge = 0;
                vert = 0;
                bleu = 0;
            }


            if (Lambda >= 380 && Lambda <= 420)
                intensite = 0.3 + 0.7 * (Lambda - 380) / (420 - 380);
            else if (Lambda >= 420 && Lambda <= 645)
                intensite = 1.0;
            else if (Lambda >= 645 && Lambda <= 780)
                intensite = 0.3 + 0.7 * (780 - Lambda) / (780 - 645);
            else
                intensite = 0.0;

            // Clamp des valeurs RGB entre 0 et 255
            rouge = Clamp(rouge, 0, 255);
            vert = Clamp(vert, 0, 255);
            bleu = Clamp(bleu, 0, 255);

            // Retour de la couleur
            return Color.FromArgb(255, rouge, vert, bleu);
        }

        private void m_STM32_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
           
            /* if (m_STM32.BytesToRead % 3 == 0) {

                     byte[] data = new byte[3];
                     m_STM32.Read(data, 0, 3);
                     m_Debug.Invoke(new Action(() =>
                     {
                         m_Debug.Text = data[2].ToString(); // Affiche la taille de la lecture
                     }));

             }
            */


            //verifier qu'il y a bien 3 octet
            if (m_STM32.BytesToRead >= 3)
            {
                byte[] data = new byte[3];

                m_STM32.Read(data, 0, 1);
                //verifier les trois premiers bits du premier octet
                if ((data[0] & 0b1111110) == 0b00100000) //bits 5-7 comparés
                {
                    m_STM32.Read(data, 1, 2);  // lire les deux suivants


                    data[0] &= 0b00000011;
         

                    int pixelNumber = (int)((data[0] << 8) | data[1]);  //numéro de pixel (10 bits)
                    int amplitude = data[2]; //amplitude

                    //affichage
                    Spectre[pixelNumber].Invoke(new Action(() =>
                    {
                     


                        Spectre[pixelNumber].Size = new Size(1, amplitude);
                        Spectre[pixelNumber].Location = new Point(1050 - pixelNumber, 600 -  amplitude);
                        
                           
                    })
                    );
                }
                else
                {


                    m_STM32.DiscardInBuffer();
                }


            }

        }


        private void LecturePixel(){



        }
        private void label1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void m_BppConnectSerial_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.m_SerialChoice == null)
                {
                    MessageBox.Show("le contrôle m_SerialPortChoice n'est pas défini.");

                }
                else
                {
                    if (m_BppConnectSerial.Text == "Connect")
                    {
                        
                        this.m_STM32.PortName = this.m_SerialChoice.Text;
                        this.m_STM32.Open();
                    }
                    else if (m_BppConnectSerial.Text == "Disconnect")
                    {


        
                     
                        this.m_STM32.Close();


                    }
                }
                if (this.m_STM32.IsOpen == true)
                {
                    m_BppConnectSerial.Text = "Disconnect";
                }
                else
                {
                    m_BppConnectSerial.Text = "Connect";
                } 

            }
            catch (Exception x_exception)
            {

                MessageBox.Show(x_exception.Message);
            }
        }
       
       
        

        private void m_SerialChoice_TextChanged(object sender, EventArgs e)
        {

        }


        unsafe private void InversertTableau(bool[] tableau, int taille)
        {
            int i; 
            bool temp; 
            for (i = 0; i < taille / 2; i++)
            {
                temp = tableau[i]; 
                tableau[i] = tableau[taille - i - 1];
                tableau[taille - i - 1] = temp;
            }
        }

        private void m_Debug_Click(object sender, EventArgs e)
        {
            m_Debug.Text = m_STM32.BytesToRead.ToString();
        }
    }
}
