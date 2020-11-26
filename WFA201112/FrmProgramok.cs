using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA201112
{
    public partial class FrmProgramok : Form
    {
        SqlConnection conn;
        Dictionary<string, int> oktatok;
        Dictionary<string, int> pozok;

        public FrmProgramok(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            oktatok = new Dictionary<string, int>();
            pozok = new Dictionary<string, int>();
            InitializeComponent();
        }

        private void FrmProgramok_Load(object sender, EventArgs e)
        {
            FillDgv();

            conn.Open();

            var r = new SqlCommand(
                "SELECT id, nev FROM tagok WHERE mester = 1", conn)
                .ExecuteReader();

            while (r.Read())
            {
                oktatok.Add(r.GetString(1), r.GetInt32(0));
                cbOktato.Items.Add(r[1]);
            }
            r.Close();

            r = new SqlCommand(
                "SELECT * FROM pozok", conn)
                .ExecuteReader();

            while (r.Read())
            {
                pozok.Add(r.GetString(1), r.GetInt32(0));
                cbGyakorlat.Items.Add(r[1]);
            }
            conn.Close();

            cbOktato.SelectedIndex = 0;
            cbGyakorlat.SelectedIndex = 0;
        }

        private void FillDgv()
        {
            dgvProgramok.Rows.Clear();

            conn.Open();
            var r = new SqlCommand(
                "SELECT beosztas.id, idopont, tagok.nev, pozok.nev, diakok " +
                "FROM beosztas " +
                "INNER JOIN tagok ON beosztas.instruktor = tagok.id " +
                "INNER JOIN pozok ON beosztas.tananyag = pozok.id;", conn)
                .ExecuteReader();

            while (r.Read())
            {

                dgvProgramok.Rows.Add(
                    r[0],
                    r.GetDateTime(1).ToString("yyyy-MM-dd"),
                    r.GetDateTime(1).ToString("HH:mm"),
                    r[2],
                    r[3],
                    String.IsNullOrEmpty(r[4].ToString()) ? 0 : r.GetString(4).Split('-').Length);
            }
            conn.Close();
        }

        private void BtnTorles_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Biztosan törölni akarod a kijelölt rekordo(ka)t?",
                "törlés megerősítése",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (res == DialogResult.Yes && dgvProgramok.SelectedRows.Count != 0)
            {
                conn.Open();
                foreach (DataGridViewRow r in dgvProgramok.SelectedRows)
                {
                    var deleteCommand = new SqlCommand(
                        $"DELETE FROM beosztas WHERE id = {r.Cells[0].Value};", conn)
                        .ExecuteNonQuery();
                }
                conn.Close();
                FillDgv();
            }
        }

        private void BtnUjEsemeny_Click(object sender, EventArgs e)
        {

            var idopont = $"{dtpDatum.Value.ToString("yyyy-MM-dd")} {tbOra.Text}:{ tbPerc.Text}";

            if (!Foglalt(idopont))
            {
                conn.Open();
                var insertCommand = new SqlCommand(
                    "INSERT INTO beosztas VALUES " +
                    $"('{idopont}', " +
                    $"{oktatok[cbOktato.Text]}, " +
                    $"NULL, " +
                    $"{pozok[cbGyakorlat.Text]});", conn)
                    .ExecuteNonQuery();
                conn.Close();
            }
            else
            {
                MessageBox.Show(
                    "Az adott időpontra már van meghirdetve óra",
                    "időpontütközés",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            FillDgv();
        }

        private bool Foglalt(string idopont)
        {
            var dpi = idopont.Split(' ');

            foreach (DataGridViewRow row in dgvProgramok.Rows)
            {
                if (row.Cells[1].Value.ToString() == dpi[0]
                    && row.Cells[2].Value.ToString() == dpi[1])
                    return true;
            }
            return false;
        }
    }
}
