using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            if (Program.automaticSave) checkBoxYes.Checked = true;
            else checkBoxNo.Checked = true;
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.pathSave = beforePath;
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
            destinationPath.Text = Program.pathSave;
        }

        private void salvaModifiche_Click(object sender, EventArgs e)
        {
            if (checkBoxNo.Checked && checkBoxYes.Checked)
                MessageBox.Show("ERRORE SALVATAGGIO AUTOMATICO:\nNon puoi selezionare due opzioni contemporaneamente!");
            else
            {
                // Salvo lo stato delle checkboxes
                if (checkBoxNo.Checked) Program.automaticSave = false;
                else Program.automaticSave = true;

                // Salvo il nuovo path per il salvataggio dei files
                Program.pathSave = destinationPath.Text;

                this.Close();
            }
        }

        
    }
}
