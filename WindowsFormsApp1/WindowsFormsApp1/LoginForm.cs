using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static WindowsFormsApp1.BDD;

namespace WindowsFormsApp1
{

    public partial class LoginForm : Form
    {
        public BDD Bbase = new BDD();
        public Utilisateur userloc = new Utilisateur();
        public bool log = false;
        public int compteur = 3;
        public MySqlConnection cnn;
        public string connexionString = null;

//-----------

        public LoginForm()

        {

            InitializeComponent();
            Bbase.Connexion();
            clé.Parent = pictureBox1;
            pictureBox2.Parent =pictureBox1;
            pictureBox3.Parent = pictureBox1;
            

        }

//--------

        private void Form2_Closing(object sender, FormClosingEventArgs e)
        {
            if (log == false)
            {

                Application.Exit();
            }
            else
            {

            }

        }

//----------
        private void Button1_Click_1(object sender, EventArgs e)
        {
            Log();
        }

//----------

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


//----------------------


        private void Log()
        {
            log = Bbase.Loguser(textBox1.Text, textBox2.Text, Bbase, userloc);

            if (log == true)

            {
                Close();
                MessageBox.Show("Bonjour " + userloc.Login + " bienvenue");

            }

            else
            {
                compteur -= 1;
                label1.Text = "Nombre d'essais restant  : " + compteur.ToString();


                MessageBox.Show("Mauvais identifant ou mot de passe incorect");
                if (compteur == 0)
                {
                    Close();
                }
            }
        }

        

        private void LoginForm_Load(object sender, EventArgs e)
        {
#if DEBUG
            textBox1.Text = "soufiane";
            textBox2.Text = "stage10e*";
#endif
        }

        private void Clé_Click(object sender, EventArgs e)
        {

        }




        //----------------------------------------

    }
}
