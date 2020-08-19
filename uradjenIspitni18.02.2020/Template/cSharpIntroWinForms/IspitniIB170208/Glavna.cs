using cSharpIntroWinForms.P8;
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

namespace cSharpIntroWinForms.IspitniIB170208
{
    public partial class Glavna : Form
    {
        public Glavna()
        {
            InitializeComponent();
        }

        private void btnGodinaStudija_Click(object sender, EventArgs e)
        {
            GodineStudijaForm godinaStudija = new GodineStudijaForm();
            godinaStudija.Show();
        }

        private void btnPolozeniPredmeti_Click(object sender, EventArgs e)
        {
            KorisniciPolozeniPredmeti polozeniPredmeti = new KorisniciPolozeniPredmeti();
            polozeniPredmeti.Show();
        }

        private void btnIzracunajSumu_Click(object sender, EventArgs e)
        {
            AsycMethod();
        }

        async void AsycMethod()
        {
            double rezultat = 0;
            await Task.Run(() => { rezultat = IzracunajSumu();});
            PrikaziRezultat(rezultat);
        }

        private void PrikaziRezultat(double rezultat)
        {
            txtSuma.Text = String.Empty;
            txtSuma.Text = rezultat.ToString();
        }
        
        private double IzracunajSumu()
        {
            long broj = Int64.Parse(txtSuma.Text);
            double suma = 0;
            for (int i = 1; i < broj; i++)
            {
                suma += i;
            }
            return suma;
        }
    }
}
