using System;
using System.Windows.Forms;
using static WindowsFormsApp1.BDD;


namespace WindowsFormsApp1
{
    public partial class Mainform : Form
    {

        // public BDD bdd = new BDD();
        public Utilisateur userloc = new Utilisateur();

        GUserpersoForm Form3 = new GUserpersoForm();
        LoginForm Form2 = new LoginForm();
        Ajoutcombo Form5 = new Ajoutcombo();

        public Mainform()
        {

            InitializeComponent();
            //  bdd.Connexion();
            timer1.Start();
            label2.Parent = pictureBox1;
            label1.Parent = pictureBox1;

        }

      //-------

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2.ShowDialog();
            userloc = Form2.userloc;
            gererLesUtilisateursadminToolStripMenuItem.Visible = (userloc.Admin == 1);
        }

        //-------

        private void SortirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Leavemenu();
        }

        //-------

        private void CreditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menucredit();
        }

     //-------

        private void ChangerDeNomDutilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3.Updateuser = userloc;
            Form3.ShowDialog();
        }

     //-------

        private void GererLesUtilisateursadminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menuadmin();
        }

        //-------
        private void AideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aide();
        }

        //-------

        private void Timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            this.label2.Text = dateTime.ToString();
        }

        private void Label2_Click(object sender, EventArgs e)
        {
           

        }


        //-------------------------

        private void Leavemenu()
        {
            string message = "Fermer l'application ? ";

            DialogResult result = MessageBox.Show(message, "Retour au bureau", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

//---------------------------

        private void Menucredit()
        {
            string message = "Ce petit programme à été crée par Soufiane - Fraba- Afifi  dans le cadre de la decouverte. Mon premier programme en utilisant le language de programation C#.";
            string title = "A propos";
             MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        //--------------------------

        private void Menuadmin()
        {
            try
            {
                //if(userloc.Admin==1)
                Form5.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }
//--------------------------
        private void Aide()
        {
            string message = "Bienvenue dans votre fenetre principale,d'ici vous avez acces à tous les onglets disponibles.\n\n" +
                "1: Vous pouvez vous deconnecter  \n\n2: Vous pouvez changer votre mot de passe depuis l'onglet \"Utilisateur\".\n\n" +
                "3: Encore depuis le meme onglet vous pouvez accédes à la base de données et modifier, supprimer, et ajouter des utilisateurs !\n\n" +
                "4 : Dans l'onglet à propos vous pouvez trouver les informations sur l'application et ce petit mode d'emplois. ";
            string title = "A propos";
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void utilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void gererLutilisateurToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }







        //--------------------------------
    }

}
