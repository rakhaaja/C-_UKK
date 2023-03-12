using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace zeamart_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=zeamart";
            string query = "INSERT INTO tbl_data(NAMA,JUMLAH,TYPE,HARGABELI,HARGAJUAL)VALUES('" + this.NAMA .Text + "','" + this.JUMLAH.Text + "','" + this.TYPE.Text + "','" + this.HARGABELI.Text + "','" + this.HARGAJUAL.Text + "')";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Successfully saved");
            conn.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=zeamart";
            string query = "UPDATE tbl_data SET NAMA='" + this.NAMA.Text + "',JUMLAH='" + this.JUMLAH.Text + "',TYPE='" + this.TYPE.Text + "',HARGABELI='" + this.HARGABELI.Text + "',HARGAJUAL='" + this.HARGAJUAL.Text + "' WHERE IDBARANG='" + this.IDBARANG
                .Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Record has been updated successfully");
            conn.Close();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=zeamart";
            string query = "SELECT * FROM tbl_data";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataAdapter da = new MySqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string connection = "server=localhost;user id=root;password=;database=zeamart";
            string query = "DELETE FROM tbl_data WHERE IDBARANG='" + this.IDBARANG.Text + "'";
            MySqlConnection conn = new MySqlConnection(connection);
            MySqlCommand cmd = new MySqlCommand(query, conn);
            MySqlDataReader dr;
            conn.Open();
            dr = cmd.ExecuteReader();
            MessageBox.Show("Data has been succesfully deleted!!");
            conn.Close();
        }
    }
}
