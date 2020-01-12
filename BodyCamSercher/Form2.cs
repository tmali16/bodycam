using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Threading;

namespace BodyCamSercher
{
    public partial class Form2 : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        SQLiteDataAdapter da;
        SQLiteDataReader dr;
        String dbName = "base.db";

        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            conn = new SQLiteConnection();
            cmd = new SQLiteCommand();

            string q = "INSERT INTO `base` (number, ik_name) VALUES ('"+number_txt.Text.Trim()+"', '"+ik_name.Text.Trim()+"')";
            string conStr = "datasource=" + dbName + "; Version=3";
            conn.ConnectionString = conStr;
            cmd.Connection = conn;
            try
            {
                conn.Open();
                cmd.CommandText = q;
                var i = cmd.ExecuteNonQuery();
                alert_lbl.Text = "Запись добавлен...";

            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка при добавлении записи", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            alert_lbl.Text = "";
        }
    }
}
