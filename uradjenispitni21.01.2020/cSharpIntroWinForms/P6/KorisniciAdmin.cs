using cSharpIntroWinForms.IB170208;
using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P8;
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

namespace cSharpIntroWinForms
{
    public partial class KorisniciAdmin : Form
    {

        KonekcijaNaBazu konekcijaNaBazu = DLWMS.DB;

        public KorisniciAdmin()
        {
            InitializeComponent();
            dgvKorisnici.AutoGenerateColumns = false;
        }

        private void KorisniciAdmin_Load(object sender, EventArgs e)
        {
            Loaddata.LoadSource(dgvKorisnici);
        }

        private void txtPretraga_TextChanged(object sender, EventArgs e)
        {
            List<Korisnik> rezultatKorisnici = new List<Korisnik>();
            foreach (var korsinik in Loaddata.konekcijaNabazu.Korisnici.ToList())
            {
                if (korsinik.Ime.ToLower().Contains(txtPretraga.Text.ToLower()) || korsinik.Prezime.ToLower().Contains(txtPretraga.Text.ToLower()))
                {
                    rezultatKorisnici.Add(korsinik);
                }
            }
            Loaddata.LoadSource(dgvKorisnici, rezultatKorisnici);
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Korisnik korisnik = dgvKorisnici.SelectedRows[0].DataBoundItem as Korisnik;
            if(korisnik != null)
            {
                if(e.ColumnIndex == 5)
                {
                    KorisniciPolozeniPredmeti korisniciPolozeni = new KorisniciPolozeniPredmeti(korisnik);
                    korisniciPolozeni.Show();
                }
            }
        }
    }
}
