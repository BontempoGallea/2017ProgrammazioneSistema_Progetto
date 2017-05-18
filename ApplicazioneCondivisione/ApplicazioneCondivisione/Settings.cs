using System;
using System.Threading;
using System.Windows.Forms;

namespace ApplicazioneCondivisione
{
    public partial class Settings : MetroFramework.Forms.MetroForm
    {
        private string desc = "Il salvataggio automatico dei file\ncomporta che essi vengano direttamente scaricati,\n SENZA che alcuna finestra di avviso venga mostrata";
        private string title = "Impostazioni";
        private string beforePath = Program.pathSave;

        public Settings()
        {
            InitializeComponent();
        }

        // Azioni proprie del form
        private void Settings_Load(object sender, EventArgs e)
        {
            // Inizializzazione del titolo
            this.Text = title;

            // Inizializzazione del path automatico
            destinationPath.Text = Program.pathSave;

            //Inizializzazione della descrizione
            description.Text = desc;

            // Inizializzazione delle checkboxes
            if (Program.automaticSave) radioButtonSi.Checked = true;
            else radioButtonNo.Checked = true;

            // Inizializzazione del save button
            salvaModifiche.Enabled = false;

            // Inizializzazione delle textboxes
            textBoxNome.Text = Program.luh.getAdmin().getName();
            textBoxCognome.Text = Program.luh.getAdmin().getSurname();
        }

        // Azioni sui bottoni del form delle impostazioni
        private void Annulla_Click(object sender, EventArgs e)
        {
            Program.pathSave = beforePath;
            this.Close();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Creo un thread che andrà ad aprire un form per selezionare la cartella scelta dall'utente
            Thread t = new Thread(() =>
            {
                using (FolderBrowserDialog fbd = new FolderBrowserDialog())
                {
                    DialogResult dr = fbd.ShowDialog();
                    if(dr == DialogResult.OK)
                        Program.pathSave = fbd.SelectedPath;
                }
            });

            t.SetApartmentState(ApartmentState.STA); // Questo thread deve essere lanciato obbligatoriamente in STA
            t.Start();
            t.Join();

            if(destinationPath.Text.CompareTo(Program.pathSave) != 0)
            {
                destinationPath.Text = Program.pathSave;
                salvaModifiche.Enabled = true;
            }
        }

        private void salvaModifiche_Click(object sender, EventArgs e)
        {
            // Salvo lo stato delle checkboxes
            if (radioButtonNo.Checked) Program.automaticSave = false;
            else Program.automaticSave = true;

            // Salvo il nuovo path per il salvataggio dei files
            Program.pathSave = destinationPath.Text;

            // Salvo le modifiche a nome e cognome dell'admin
            Program.luh.getAdmin().setName(textBoxNome.Text);
            Program.luh.getAdmin().setSurname(textBoxCognome.Text);
            
            salvaModifiche.Enabled = false;
            this.Close();
        }

        private void checkBox_Click(object sender, MouseEventArgs e)
        {
            salvaModifiche.Enabled = true;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(salvaModifiche.Enabled)
            {
                switch (MessageBox.Show(this, "Salvare le modifiche prima di uscire?", "Esci da impostazioni", MessageBoxButtons.YesNo))
                {
                    case DialogResult.No:
                        Program.pathSave = beforePath;
                        break;
                    default:
                        salvaModifiche_Click(sender, e);
                        break;
                }
            }
        }

        private void textBoxNome_TextChanged(object sender, EventArgs e)
        {
            if(!(textBoxNome.Text.CompareTo(Program.luh.getAdmin().getName()) == 0))
                salvaModifiche.Enabled = true;
        }

        private void textBoxCognome_TextChanged(object sender, EventArgs e)
        {
            if (!(textBoxCognome.Text.CompareTo(Program.luh.getAdmin().getSurname()) == 0))
                salvaModifiche.Enabled = true;
        }
    }
}
