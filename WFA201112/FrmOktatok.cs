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
    public partial class FrmOktatok : Form
    {
        SqlConnection conn;
        Dictionary<string, int> mesterek;
        public FrmOktatok(string connectionString)
        {
            conn = new SqlConnection(connectionString);
            mesterek = new Dictionary<string, int>();
            InitializeComponent();
        }

        private void FrmOktatok_Load(object sender, EventArgs e)
        {
            conn.Open();
            var cmd = new SqlCommand("SELECT id, nev FROM tagok WHERE mester = 1;", conn);
            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                mesterek.Add(r.GetString(1), r.GetInt32(0));
            }
            conn.Close();

            foreach (var nev in mesterek.Keys)
                lbOktatok.Items.Add(nev);
        }

        private void LbOktatok_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            Graphics g = e.Graphics;
            Brush brush = ((e.State & DrawItemState.Selected) == DrawItemState.Selected) ?
            Brushes.Orange : new SolidBrush(e.BackColor);
            g.FillRectangle(brush, e.Bounds);
            e.Graphics.DrawString(
            (sender as ListBox).Items[e.Index].ToString(), e.Font,
                new SolidBrush(e.ForeColor), e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void LbOktatok_SelectedIndexChanged(object sender, EventArgs e)
        {
            rtbIdopontok.Clear();
            conn.Open();

            var cmd = new SqlCommand(
                $"SELECT idopont " +
                $"FROM beosztas " +
                $"WHERE instruktor = {mesterek[lbOktatok.SelectedItem.ToString()]};",
                //$"SELECT idopont " +
                //$"FROM beosztas " +
                //$"INNER JOIN tagok ON beosztas.instruktor = tagok.id " +
                //$"WHERE nev = '{lbOktatok.SelectedItem}';",
                conn);

            var r = cmd.ExecuteReader();
            while (r.Read())
            {
                rtbIdopontok.Text += 
                    $"{r.GetDateTime(0).ToString("yyyy-MM-dd")}   " +
                    $"{r.GetDateTime(0).ToString("hh:mm")}\n";
            }
            conn.Close();
        }
    }
}
