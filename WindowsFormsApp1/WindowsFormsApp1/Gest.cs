using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Ajoutcombo : Form
    {

        public string connexion = "datasource = localhost; database = login; port = 3306; username = root; password = root";
        public string query = "select * from login";

        public Ajoutcombo()
        {
            InitializeComponent();
        }

//----------

        private void Button1_Click(object sender, EventArgs e)
        {
            //Retrieve();
            Datashow();
        }

//----------

        private void Button3_Click(object sender, EventArgs e)
        {
            Del();
        }

//----------
        private void Button2_Click_1(object sender, EventArgs e)
        {
            Add();
        }

//----------
        private void Button4_Click_1(object sender, EventArgs e)
        {
            Updatde();
        }

//----------

        private void SeDeconnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sedeco();
        }

//-------

        private void QuitterLaFenêtreToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Leavefenetre();
        }

//-------

        private void CommentÇaMarcheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commentmarche();
        }

//------------------------------

        private void Commentmarche()
        {
            string message = "Sur cette fenetre vous etes en capacité de\n 1: Supprimer des utilisateurs \n 2: Ajouter des utilisateurs \n 3: Mettre a jour les permissions des utilisateurs" +
                "\n Il vous suffit simplement de remplir les champs comme indiquez et de respecter les consignes.\n ";

            MessageBox.Show(message, "Informations d'usage", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

//----------------------------

        private void Leavefenetre()
        {
            string message = "Voulez vous vraiment retourne à l'ecran d'acceuil ? ";

            DialogResult result = MessageBox.Show(message, "Menu", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

//----------------------------

            private void Sedeco()
            {
                string message1 = "Voulez-vous vraiment vous deconnectez ?";

                DialogResult result = MessageBox.Show(message1, "Fin de connexion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }
        }

//-----------------------------
        private void Updatde()
        {
            try
            {

                string Query = "UPDATE login.login SET groupid  = (" + comboBox2.SelectedIndex.ToString() + ") WHERE user = ('" + textBox1.Text + "')";


                MySqlConnection MyConn2 = new MySqlConnection(connexion);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;

                MyConn2.Open();



                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Utilisateur mis à jour");

                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

//-------------------------
        private void Del()
        {
            {
                try
                {


                    string Query = "DELETE FROM login WHERE user = '" + textBox1.Text + "'";


                    MySqlConnection MyConn2 = new MySqlConnection(connexion);

                    MyConn2.Open();

                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;


                    MyReader2 = MyCommand2.ExecuteReader();

                    MyConn2.Close();
                    MessageBox.Show("Utilisateur Supprimer");


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Une erreur c'est produite veuillez reesayer");

                }
            }

        }

//--------------------------

        private void Datashow()
        {
            string Query = ("SELECT* FROM login");


            MySqlConnection conn = new MySqlConnection(connexion);
            MySqlCommand cmd = new MySqlCommand(Query, conn);

            try
            {
                MySqlDataAdapter sda = new MySqlDataAdapter
                {
                    SelectCommand = cmd
                };
                DataTable dta = new DataTable();
                sda.Fill(dta);
                BindingSource bdsour = new BindingSource
                {
                    DataSource = dta
                };
                dataGridView1.AutoGenerateColumns = true;
                dataGridView1.DataSource = bdsour;
                sda.Update(dta);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

//-----------------------------

        private void Add()
        {
            try
            {
                string query = "INSERT  INTO  login.login (user,motpasse,groupid) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "'," + comboBox2.SelectedIndex.ToString() + ")";
                //string query1 = "select * from login where user =" + textBox1.Text + ")";


                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Veuillez entrer un nom d'utilisateur valide");
                    return;
                }

                if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Veuillez entrer un mot de passe valide");
                    return;
                }
                if (comboBox2.SelectedItem == null)
                {
                    MessageBox.Show("Veuillez entrer les permissions de l'utilisateur");
                    return;
                }
                else
                {
                    MySqlConnection MyConn2 = new MySqlConnection(connexion);
                    MySqlCommand MyCommand2 = new MySqlCommand(query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyConn2.Open();



                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Utilisateur ajouter");

                    MyConn2.Close();
                }


            }
            catch (Exception)
            {
                MessageBox.Show("Un utilisateur existe deja à se nom");

            }
        }

//---------------------------
        


        /*private void Retrieve()
        {
            try
            {
                MySqlConnection MyConn2 = new MySqlConnection(connexion);

                MyConn2.Open();

                MySqlCommand command = new MySqlCommand(query, MyConn2);


                MySqlDataReader reader = command.ExecuteReader();

                comboBox1.Items.Clear();
                while (reader.Read())
                {
                    comboBox1.Items.Add(reader["user"]);
                }
                MyConn2.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/


//--------------------------------------------------------
    }
}
