using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IB170208
{
    class Loaddata
    {
        public static KonekcijaNaBazu konekcijaNabazu { get; } = new KonekcijaNaBazu();
        
    
        public static List<Ocjene> DodajOcjene()
        {
            List<Ocjene> ocjene = new List<Ocjene>();

            Ocjene o6 = new Ocjene() { Id = 1, Vrijednost = 6 };
            Ocjene o7 = new Ocjene() { Id = 2, Vrijednost = 7 };
            Ocjene o8 = new Ocjene() { Id = 3, Vrijednost = 8 };
            Ocjene o9 = new Ocjene() { Id = 4, Vrijednost = 9 };
            Ocjene o10 = new Ocjene() { Id = 5, Vrijednost = 10 };

            ocjene.Add(o6);
            ocjene.Add(o7);
            ocjene.Add(o8);
            ocjene.Add(o9);
            ocjene.Add(o10);

            return ocjene;
        }

        public static void LoadSource(DataGridView dataGridView, List<Korisnik> korisnici = null)
        {
            try
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = korisnici ?? konekcijaNabazu.Korisnici.ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadPolozeneKorisniku (DataGridView dataGridView, Korisnik korisnik)
        {
            try
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = konekcijaNabazu.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id).ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadPredmeteComboBox(ComboBox comboBox)
        {
            try
            {
                comboBox.DataSource = null;
                comboBox.DataSource = konekcijaNabazu.Predmeti.ToList();
                comboBox.DisplayMember = "Naziv";
                comboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadOcjeneComboBox(ComboBox comboBox)
        {
            try
            {
                comboBox.DataSource = null;
                comboBox.DataSource = DodajOcjene();
                comboBox.DisplayMember = "Vrijednost";
                comboBox.ValueMember = "Id";

            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadNePolozenePredmete(ComboBox comboBox, List<Predmeti> predmeti)
        { 
            try
            {
                bool postoji;
                List<Predmeti> nePolozeni = new List<Predmeti>();
                foreach (var p in konekcijaNabazu.Predmeti.ToList())
                {
                    postoji = false;
                    foreach (var pp in predmeti)
                    {
                        if (p.Id == pp.Id)
                            postoji = true;
                    }
                    if(!postoji)
                        nePolozeni.Add(p);
                }


                comboBox.DataSource = null;
                comboBox.DisplayMember = null;
                comboBox.ValueMember = null;
                comboBox.DataSource = nePolozeni;
                comboBox.DisplayMember = "Naziv";
                comboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

    }
}
