using cSharpIntroWinForms.P10;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace cSharpIntroWinForms.IspitniIB170208
{
    public partial class ReportPolozeniPredmeti : Form
    {
        private GodineStudija godineStudija;
        private Korisnik korisnik;
        private List<KorisniciPredmeti> polozeniPredmeti;

        public ReportPolozeniPredmeti()
        {
            InitializeComponent();
        }

        public ReportPolozeniPredmeti(GodineStudija godineStudija, Korisnik korisnik) : this()
        {
            this.korisnik = korisnik;
            this.godineStudija = godineStudija;
            polozeniPredmeti = LoadData.konekcijaNabazu.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id).ToList();
        }

        private void ReportPolozeniPredmeti_Load(object sender, EventArgs e)
        {
            ReportParameterCollection rpc = new ReportParameterCollection();
            rpc.Add(new ReportParameter("ImePrezime", $"{korisnik.Ime} {korisnik.Prezime}"));
            rpc.Add(new ReportParameter("KorisnickoIme", $"{korisnik.KorisnickoIme}"));
            rpc.Add(new ReportParameter("GodinaStudija", $"{godineStudija.Naziv}"));

            DLWMS.tblPolozeniDataTable tbl = new DLWMS.tblPolozeniDataTable();
            for (int i = 0; i < polozeniPredmeti.Count(); i++)
            {
                if(polozeniPredmeti[i].GodineStudija.Id == godineStudija.Id)
                {
                    DLWMS.tblPolozeniRow red = tbl.NewtblPolozeniRow();
                    red.Rb = i + 1;
                    red.Naziv = polozeniPredmeti[i].Predmet.Naziv;
                    red.Ocjena = polozeniPredmeti[i].Ocjena;
                    red.Datum = polozeniPredmeti[i].Datum;
                    tbl.Rows.Add(red);
                }
            }

            ReportDataSource rds = new ReportDataSource();
            rds.Name = "tblPolozeni";
            rds.Value = tbl;

            reportViewer1.LocalReport.SetParameters(rpc);
            reportViewer1.LocalReport.DataSources.Add(rds);
            this.reportViewer1.RefreshReport();
        }
    }
}
