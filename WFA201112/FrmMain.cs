using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFA201112
{
    public partial class FrmMain : Form
    {
        public static string connectionString;
        public FrmMain()
        {
            AppDomain.CurrentDomain.SetData(
                "DataDirectory",
                Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly()
                    .Location.Replace(@"bin\Debug", @"\Resources")));

            connectionString =
                @"Server = (localdb)\MSSQLLocalDB;" +
                @"AttachDbFileName=|DataDirectory|jogastudio.mdf;";

            InitializeComponent();
        }

        private void BtnKilepes_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(
                "Biztos vagy benne, hogy ki akarsz lépni?",
                "megerősítés",
                MessageBoxButtons.YesNo);

            if (res == DialogResult.Yes) Application.Exit();
        }

        private void BtnOktatok_Click(object sender, EventArgs e)
        {
            var frm = new FrmOktatok(connectionString);
            frm.ShowDialog();
        }

        private void BtnProgramok_Click(object sender, EventArgs e)
        {
            var frm = new FrmProgramok(connectionString);
            frm.ShowDialog();
        }
    }
}
