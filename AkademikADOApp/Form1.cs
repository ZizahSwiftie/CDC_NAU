using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AkademikADOApp
{
    public partial class Form1 : Form
    {
        string connString = 
        @"Data Source=AZIZAH\AZIZAH; Initial Catalog=DBAkademikADO; Integrated Security=True";
        SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connString);
                conn.Open();

                lblStatus.Text = "Status : Database Connected"; 
                MessageBox.Show("Koneksi ke database berhasil!"); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Koneksi gagal : " + ex.Message);
            }
        }
        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn != null && conn.State == System.Data.ConnectionState.Open)
                {
                    conn.Close(); 
                    lblStatus.Text = "Status : Database Disconnected";
                    MessageBox.Show("Koneksi database telah diputus!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memutus koneksi : " + ex.Message);
            }
        }
    }
}
