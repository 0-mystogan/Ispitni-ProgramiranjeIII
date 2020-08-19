using cSharpIntroWinForms.P10;
using cSharpIntroWinForms.P9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIntroWinForms.IspitniIB170208
{
    class LoadData
    {
        public static KonekcijaNaBazu konekcijaNabazu { get; } = new KonekcijaNaBazu();

        public static void LoadSource(DataGridView dataGridView, List<GodineStudija> godineStudija = null)
        {
            try
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = godineStudija ?? konekcijaNabazu.GodineStudija.ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadKorsinicPredemti(DataGridView dataGridView)
        {
            try
            {
                dataGridView.DataSource = null;
                dataGridView.DataSource = konekcijaNabazu.KorisniciPredmeti.Where(x => x.Korisnik.Id == 1).ToList();
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadPredmete(ComboBox comboBox)
        {
            try
            {
                comboBox.DataSource = konekcijaNabazu.Predmeti.ToList();
                comboBox.DisplayMember = "Naziv";
                comboBox.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MboxHelper.PrikaziGresku(ex);
            }
        }

        public static void LoadGodineStudija(ComboBox comboBox)
        {
            try
            {
                comboBox.DataSource = konekcijaNabazu.GodineStudija.Where(g => g.Aktivna == true).ToList();
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
