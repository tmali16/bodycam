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
using System.IO;

namespace BodyCamSercher
{
    public partial class Form1 : Form
    {
        SQLiteConnection conn;
        SQLiteCommand cmd;
        String dbName = "base.db";
        SQLiteDataReader dr;
        Form2 frm;
        List<Int32> ik_name;
        string id = null;
        IniFiles ini = new IniFiles("config.ini");
        FolderBrowserDialog fbd;
        string folder_path;

        public Form1()
        {
            InitializeComponent();
        }
        void connect()
        {
            conn = new SQLiteConnection();
            cmd = new SQLiteCommand();
            SQLiteDataAdapter da = new SQLiteDataAdapter();            
            
            if (!File.Exists(dbName))
            {
                SQLiteConnection.CreateFile(this.dbName);
                string q = "CREATE TABLE if not exists base (id INTEGER NOT NUll PRIMARY KEY AUTOINCREMENT," +
                    "`number` TEXT," +
                    "`ik_name` TEXT);";
                string conStr = "datasource=" + dbName + "; Version=3";
                cmd.CommandText = q;
                try
                {                    
                    conn.ConnectionString = conStr;
                    conn.Open();
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                }catch(SQLiteException ex)
                {
                    MessageBox.Show( ex.Message, "Ошибка создания базы", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    conn.Close();
                }
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string q = (this.id != null ? "and ik_name='"+this.id+"'" : "");
            this.get("select * from base where number like '"+serchBox.Text.Trim()+"%' "+q);
        }

        void get(string q = "select * from base")
        {
            this.read_ini();
            conn = new SQLiteConnection();
            cmd = new SQLiteCommand();
            SQLiteDataAdapter da = new SQLiteDataAdapter();
            dataGridView1.Columns[2].ValueType = typeof(int);
            string conStr = "datasource=" + dbName + "; Version=3";
            //q = "select * from base ";
            conn.ConnectionString = conStr;
            conn.Open();
            cmd.CommandText = q;
            cmd.Connection = conn;
            try
            {
                dr = cmd.ExecuteReader();
                int i = 0;
                dataGridView1.Rows.Clear();
                while (dr.Read())
                {
                    dataGridView1.Rows.Add();
                    dataGridView1.Rows[i].Cells[0].Value = dr[1].ToString();
                    dataGridView1.Rows[i].Cells[1].Value = "Учреждение №" + dr[2].ToString();
                    if (Directory.Exists(@""+this.folder_path+"\\"+dr[1].ToString()))
                    {
                        dataGridView1.Rows[i].Cells[2].Value = Directory.GetFiles(@"" + this.folder_path + "\\" + dr[1].ToString(), "*.*", SearchOption.TopDirectoryOnly).Length;

                    }
                    else
                    {
                        dataGridView1.Rows[i].Cells[2].Value = "0";
                    }
                    i++;
                }
            }
            catch(SQLiteException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка чтение данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.connect();
            this.read_ini();
            this.get();
            this.get_ik();            
        }

        void read_ini()
        {
            this.folder_path = ini.ReadINI("Folder", "path");
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frm = new Form2();
            this.frm.ShowDialog();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.get();
            ik_name_cmb.SelectedIndex = -1;
        }

        void get_ik()
        {
            conn = new SQLiteConnection();
            cmd = new SQLiteCommand();
            SQLiteDataAdapter da = new SQLiteDataAdapter();

            string conStr = "datasource=" + dbName + "; Version=3";
            conn.ConnectionString = conStr;
            conn.Open();
            cmd.CommandText = "select distinct ik_name from base ORDER BY ik_name";
            cmd.Connection = conn;
            try
            {
                dr = cmd.ExecuteReader();
                int i = 0;
                ik_name_cmb.Items.Clear();
                ik_name = new List<Int32>();
                while (dr.Read())
                {
                    ik_name.Add(Convert.ToInt32(dr[0]));
                    ik_name_cmb.Items.Add("Учреждение №"+dr[0].ToString());
                }
            }
            catch (SQLiteException ex)
            {
                MessageBox.Show("Ошибка чтение данных", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void ik_name_cmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ik_name_cmb.SelectedIndex != -1) { 
                id = ik_name[ik_name_cmb.SelectedIndex].ToString();
                this.get("select * from base where ik_name="+id);
            }
            else
            {
                ik_name = null;
                id = null;
            }
        }

        private void reset_btn_Click(object sender, EventArgs e)
        {
            ik_name_cmb.SelectedIndex = -1;
            serchBox.Text = "";
            this.get();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = @""+this.folder_path+"\\" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (Directory.Exists(path))
            {
                System.Diagnostics.Process.Start(path);
            }
            else
            {
                MessageBox.Show("Папка не найдена!");
            }
            
        }

        private void указатьПутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbd = new FolderBrowserDialog();
            DialogResult res = fbd.ShowDialog();
            if(res == DialogResult.OK)
            {
                ini.Write("Folder", "path", fbd.SelectedPath.ToString());
            }
        }

    }
}
