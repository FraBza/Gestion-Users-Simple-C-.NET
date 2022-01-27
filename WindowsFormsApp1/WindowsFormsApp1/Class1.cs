using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{

    public class BDD

    {

        public MySqlConnection cnn;
        public string connexionString = null;
        public MySqlDataReader myReader;
        public class Utilisateur
        {

            public string Login { get; set; }
            public string Motdepasse { get; set; }
            public string Iduser { get; set; }

            public int Admin { get; set; }


        }

//-----------------------------------------

        public void Connexion()
        {


            connexionString = "server=localhost;database=login;uid=root;pwd=root;";
            cnn = new MySqlConnection(connexionString);
            try
            {
                cnn.Open();
                //MessageBox.Show("Connection Open ! "
            }
            catch (Exception)
            {
                string message = "Connexion impossible";
                DialogResult result = MessageBox.Show(message, "ERREUR", MessageBoxButtons.OK);

                if (result == DialogResult.Yes)
                {

                }
                Environment.Exit(0);
            }
        }

//-------------------------
        public bool Loguser(string utilisateur, string motdepasse, BDD Mabase, Utilisateur Luser)
        {
            Mabase.cnn.Close();
            MySqlCommand SelectCommand = Mabase.cnn.CreateCommand();

            SelectCommand.CommandText = " select * from login where user='" + utilisateur + "' and motpasse='" + motdepasse + "'";
            Mabase.cnn.Open();

            myReader = SelectCommand.ExecuteReader();

            while (myReader.Read())
            {
                Luser.Login = myReader.GetValue(1).ToString();
                Luser.Motdepasse = myReader.GetValue(2).ToString();
                Luser.Iduser = myReader.GetValue(0).ToString();
                Luser.Admin = (int)myReader.GetValue(3);


                if (Luser.Login != "")
                {
                    myReader.Close();
                    SelectCommand.Dispose();
                    return true;
                }

            }
            if (Luser.Login == "")
                return false;

            return false;

        }
//-----------------------------------------------
    }
}
