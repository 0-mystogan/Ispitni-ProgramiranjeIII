using cSharpIntroWinForms.IspitniIB170208;
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik = new Korisnik();

        KorisniciPredmeti korisniciPredmeti = new KorisniciPredmeti();
        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
            korisnik = LoadData.konekcijaNabazu.Korisnici.FirstOrDefault();
        }
        public KorisniciPolozeniPredmeti(Korisnik korisnik):this()
        {
            this.korisnik = korisnik;
        }
        private void KorisniciPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            LoadData.LoadKorsinicPredemti(dgvPolozeniPredmeti);
            LoadData.LoadPredmete(cmbPredmeti);
            LoadData.LoadGodineStudija(cmbGodineStudija);
        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if (ValidirajUnos())
            {
                Predmeti predmet = cmbPredmeti.SelectedItem as Predmeti;
                GodineStudija godineStudija = cmbGodineStudija.SelectedItem as GodineStudija;
                if(ProvjeriPredmet(predmet, godineStudija))
                {
                    korisniciPredmeti.Korisnik = korisnik;
                    korisniciPredmeti.Predmet = predmet;
                    korisniciPredmeti.GodineStudija = godineStudija;
                    korisniciPredmeti.Ocjena = Int32.Parse(txtOcjena.Text);
                    korisniciPredmeti.Datum = dtpDatumPolaganja.Value.ToString("dd.MM.yyyy");
                    LoadData.konekcijaNabazu.KorisniciPredmeti.Add(korisniciPredmeti);
                    LoadData.konekcijaNabazu.SaveChanges();
                    MessageBox.Show($"Uspiješno ste dodali premet {predmet}");
                    LoadData.LoadKorsinicPredemti(dgvPolozeniPredmeti);
                }
                else
                    MessageBox.Show($"Položili ste {predmet} na {godineStudija} fakulteta");
            }
        }

        private bool ProvjeriPredmet(Predmeti predmet, GodineStudija godineStudija)
        {
            foreach (var KP in LoadData.konekcijaNabazu.KorisniciPredmeti.Where(x => x.Korisnik.Id == korisnik.Id).ToList())
            {
                if (KP.GodineStudija.Naziv == godineStudija.Naziv)
                {
                    if (KP.Predmet.Naziv == predmet.Naziv)
                        return false;
                }
            }
            return true;
        }

        private bool ValidirajUnos()
        {
            return Validator.ObaveznoPolje(cmbPredmeti, errObavezno, Validator.porObaveznaVrijednost) &&
                Validator.ObaveznoPolje(txtOcjena, errObavezno, Validator.porObaveznaVrijednost) &&
                Validator.ObaveznoPolje(cmbGodineStudija, errObavezno, Validator.porObaveznaVrijednost) &&
                Validator.ObaveznoPolje(dtpDatumPolaganja, errObavezno, Validator.porObaveznaVrijednost);
        }

        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            GodineStudija godineStudija = cmbGodineStudija.SelectedItem as GodineStudija;
            if(godineStudija!= null)
            {
                ReportPolozeniPredmeti reportPolozeni = new ReportPolozeniPredmeti(godineStudija, korisnik);
                reportPolozeni.Show();
            }
        }
    }
}
