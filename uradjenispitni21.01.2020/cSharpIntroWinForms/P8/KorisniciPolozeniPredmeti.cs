using cSharpIntroWinForms.IB170208;
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
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

namespace cSharpIntroWinForms.P8
{
    public partial class KorisniciPolozeniPredmeti : Form
    {
        private Korisnik korisnik;
        private KorisniciPredmeti korisniciPredmeti;
        private Predmeti selectedPredmet;

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciPolozeniPredmeti()
        {
            InitializeComponent();
            dgvPolozeniPredmeti.AutoGenerateColumns = false;
        }

        public KorisniciPolozeniPredmeti(Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
        }

        private void KorisniciPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            Loaddata.LoadPolozeneKorisniku(dgvPolozeniPredmeti, korisnik);
            Loaddata.LoadPredmeteComboBox(cmbPredmeti);
            Loaddata.LoadOcjeneComboBox(cmbOcjene);
            selectedPredmet = cmbPredmeti.SelectedItem as Predmeti;
        }

        private void cbUcitajNepolozene_CheckedChanged(object sender, EventArgs e)
        {
            if(cbUcitajNepolozene.Checked == true)
            {
                List<Predmeti> predmeti = new List<Predmeti>();
                foreach (var p in Loaddata.konekcijaNabazu.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id).ToList())
                {
                    predmeti.Add(p.Predmet);
                }

                Loaddata.LoadNePolozenePredmete(cmbPredmeti, predmeti);
            }
            else if(cbUcitajNepolozene.Checked == false)
                Loaddata.LoadPredmeteComboBox(cmbPredmeti);

        }

        private void btnDodajPolozeni_Click(object sender, EventArgs e)
        {
            if(cmbPredmeti.SelectedItem != null && cmbOcjene.SelectedItem != null)
            {
                korisniciPredmeti = new KorisniciPredmeti();
                korisniciPredmeti.Korisnik = korisnik;
                korisniciPredmeti.Predmet = selectedPredmet;
                korisniciPredmeti.Ocjena = Int32.Parse(cmbOcjene.Text);
                korisniciPredmeti.Datum = dtpDatumPolaganja.Value.ToString("dd.MM.YYYY");

                Loaddata.konekcijaNabazu.KorisniciPredmeti.Add(korisniciPredmeti);
                Loaddata.konekcijaNabazu.SaveChanges();
                MessageBox.Show("Uspiješno ste dodali predmet");
            }
        }

        private void btnPrintajUvjerenje_Click(object sender, EventArgs e)
        {
            List<Predmeti> predmeti = new List<Predmeti>();
            foreach (var p in Loaddata.konekcijaNabazu.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id).ToList())
            {
                predmeti.Add(p.Predmet);
            }

            ReportPodatciOStudentu podatciOStudentu = new ReportPodatciOStudentu(korisnik, predmeti);
            podatciOStudentu.Show();
            Close();
        }

        private void btnASYNC_Click(object sender, EventArgs e)
        {
            AsyncMethod();
        }

        async void AsyncMethod()
        {
            await Task.Run(() => { Dodaj500Predmeta(); });
            MessageBox.Show("Uspiješno je dodano 500 predmeta");
        }

        private void Dodaj500Predmeta()
        {
            for (int i = 0; i < 500; i++)
            {
                KorisniciPredmeti predmeti = new KorisniciPredmeti();
                predmeti.Korisnik = korisnik;
                predmeti.Predmet = selectedPredmet;
                predmeti.Ocjena = 6;
                predmeti.Datum = DateTime.Now.ToString("dd.MM.yyyy");
                Loaddata.konekcijaNabazu.KorisniciPredmeti.Add(predmeti);
            }
            Loaddata.konekcijaNabazu.SaveChanges();
        }

        private void cmbOcjene_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void cmbPredmeti_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedPredmet = cmbPredmeti.SelectedItem as Predmeti;

        }
    }
}
