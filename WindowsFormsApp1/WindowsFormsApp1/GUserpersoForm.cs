using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;
using static WindowsFormsApp1.BDD;

namespace WindowsFormsApp1
{
    public partial class GUserpersoForm : Form
    {

        public Utilisateur Updateuser { get; set; }
        public GUserpersoForm()

        {
            InitializeComponent();
        }

//-------

        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
//----------
        private void Button1_Click(object sender, EventArgs e)
        {
            Userlog();     
        }

//---------------------------------

        private void Userlog()
        {
            try
            {

                string MyConnection2 = "datasource=localhost;database=login;port=3306;username=root;password=root";

                string Query = "update login set motpasse='" + textBox2.Text + "'where id= " + Updateuser.Iduser;

                if (String.IsNullOrEmpty(textBox2.Text))
                {
                    MessageBox.Show("Veuillez entrer un mot de passe valide");
                    return;
                }

                else
                {
                    MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                    MySqlDataReader MyReader2;

                    MyConn2.Open();


                    string message = "Voulez vous vraiment continuez ? ";
                    DialogResult result = MessageBox.Show(message, "changement de mot de passe", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        MyReader2 = MyCommand2.ExecuteReader();
                        MessageBox.Show("Votre mot de passe à bien été enregistrée");

                        MyConn2.Close();
                    }
                    else
                    {
                        MyConn2.Close();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            Close();

        }

//----------------------------------------------

    }

}


