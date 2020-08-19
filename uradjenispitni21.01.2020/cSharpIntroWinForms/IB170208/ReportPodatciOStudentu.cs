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

namespace cSharpIntroWinForms.IB170208
{
    public partial class ReportPodatciOStudentu : Form
    {
        private List<KorisniciPredmeti> korisniciPredmeti;
        private List<Predmeti> polozeniPredmeti;
        private List<Predmeti> ListNePolozeniPredmeti;
        private Korisnik korisnik;

        public ReportPodatciOStudentu()
        {
            InitializeComponent();
        }

        public ReportPodatciOStudentu(Korisnik korisnik, List<Predmeti> predmeti) : this()
        {
            this.korisnik = korisnik;
            this.polozeniPredmeti = predmeti;
            this.korisniciPredmeti = Loaddata.konekcijaNabazu.KorisniciPredmeti.Where(k => k.Korisnik.Id == korisnik.Id).ToList();
            ListNePolozeniPredmeti = nePolozeniPredmeti();
        }

        private void ReportPodatciOStudentu_Load(object sender, EventArgs e)
        {
            ReportParameter rp = new ReportParameter("ImePrezime", $"{korisnik.Ime} {korisnik.Prezime}");

            DataSet1.tblPolozeniDataTable tblPolozeniRows = new DataSet1.tblPolozeniDataTable();
            DataSet1.tblNePolozeniDataTable tblNePolozeniRows = new DataSet1.tblNePolozeniDataTable();

            //Polozeni Predmeti
            foreach (var predmet in korisniciPredmeti)
            {
                DataSet1.tblPolozeniRow red = tblPolozeniRows.NewtblPolozeniRow();
                red.Id = predmet.Id;
                red.Naziv = predmet.Predmet.Naziv;
                red.Ocjena = predmet.Ocjena;
                red.Datum = predmet.Datum;
                tblPolozeniRows.Rows.Add(red);
            }


            //Ne Polozeni Predmeti
            foreach (var predmet in ListNePolozeniPredmeti)
            {
                DataSet1.tblNePolozeniRow red = tblNePolozeniRows.NewtblNePolozeniRow();
                red.Id = predmet.Id;
                red.Naziv = predmet.Naziv;
                red.Ocjena = "NIJE POLOŽENO";
                red.Datum = "NIJE POLOŽENO";
                tblNePolozeniRows.Rows.Add(red);
            }
            ReportDataSource rds = new ReportDataSource();
            rds.Name = "tblPolozeni";
            rds.Value = tblPolozeniRows;

            ReportDataSource rds1 = new ReportDataSource();
            rds1.Name = "tblNePolozeni";
            rds1.Value = tblNePolozeniRows;

            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.LocalReport.DataSources.Add(rds1);

            reportViewer1.LocalReport.SetParameters(rp);
            this.reportViewer1.RefreshReport();
        }

        private List<Predmeti> nePolozeniPredmeti()
        {
            bool postoji;
            List<Predmeti> nePolozeni = new List<Predmeti>();
            foreach (var p in Loaddata.konekcijaNabazu.Predmeti.ToList())
            {
                postoji = false;
                foreach (var pp in polozeniPredmeti)
                {
                    if (p.Id == pp.Id)
                        postoji = true;
                }
                if (!postoji)
                    nePolozeni.Add(p);
            }

            return nePolozeni;

        }
    }
}
