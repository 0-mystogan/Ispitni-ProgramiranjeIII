using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IspitniIB170208
{
    public partial class GodineStudijaForm : Form
    {
        GodineStudija GodineStudija = new GodineStudija();
        bool Edit;
        public GodineStudijaForm()
        { 
            InitializeComponent();
            dgvGodineStudija.AutoGenerateColumns = false;
        }

        private void GodineStudijaForm_Load(object sender, EventArgs e)
        {
            LoadData.LoadSource(dgvGodineStudija);
        }

        private void btnSacuvaj_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                string newString = IzbrisiSpaces(txtNaziv.Text);
                if (!Edit && DaLiPostoji(newString))
                {
                    GodineStudija.Naziv = newString;
                }
                else if(!Edit && !DaLiPostoji(newString))
                {
                    MessageBox.Show("Godina studija već postoji!!");
                    return;
                }
                GodineStudija.Aktivna = chkAktivna.Checked;

                if (!Edit)
                {
                    LoadData.konekcijaNabazu.GodineStudija.Add(GodineStudija);
                    LoadData.konekcijaNabazu.SaveChanges();
                    MessageBox.Show("Uspiješno ste dodali godinu studija");
                }
                else
                {
                    LoadData.konekcijaNabazu.Entry(GodineStudija).State = EntityState.Modified;
                    LoadData.konekcijaNabazu.SaveChanges();
                    MessageBox.Show("Uspiješno ste editovali godinu studija");
                }
                Close();
            }
        }

        private string IzbrisiSpaces(string text)
        {
            string wospaces = text.Replace(" ", String.Empty);
            return wospaces;
        }

        private void dgvGodineStudija_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
        private void dgvGodineStudija_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GodineStudija = dgvGodineStudija.SelectedRows[0].DataBoundItem as GodineStudija;
            if (GodineStudija != null)
            {
                UcitajPodatke(GodineStudija);
            }
        }

        private void UcitajPodatke(GodineStudija godineStudija)
        {
            txtNaziv.Text = godineStudija.Naziv;
            chkAktivna.Checked = godineStudija.Aktivna;
            Edit = true;
        }

        private bool DaLiPostoji(string text)
        {
            foreach (var godina in LoadData.konekcijaNabazu.GodineStudija.ToList())
            {
                if (godina.Naziv == text)
                    return false;
            }
            return true;
        }

        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(txtNaziv, errObavezno, Validator.porObaveznaVrijednost);
        }

       
    }
}
