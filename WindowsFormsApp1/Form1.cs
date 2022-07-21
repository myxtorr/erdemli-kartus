using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;


//Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\Users\bahadır\source\repos\WinFormsApp1\erdemli.accdb
namespace WindowsFormsApp1
{


    public partial class Form1 : Form
    {
        Random r = new Random();
        public Form1()
        {
            InitializeComponent();
            

        }
        OleDbConnection baglanti = new OleDbConnection("Provider = Microsoft.ACE.OLEDB.12.0; Data Source = C:\\Users\\bahadır\\source\\repos\\WinFormsApp1\\erdemli.accdb");
        OleDbCommand komut;
        OleDbDataAdapter adtr;
        DataTable tablo = new DataTable();
        OleDbCommandBuilder err;
        DataSet ds = new DataSet();


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            komut = new OleDbCommand("select *from kartus", baglanti);
            adtr = new OleDbDataAdapter(komut);
            adtr.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            tablo.Rows.Add(txt1.Text, txt2.Text,txt3.Text);
            dataGridView1.DataSource = tablo;
            MessageBox.Show("işlem tamamdır");

            //txt1.Text,



        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void kartusara_TextChanged(object sender, EventArgs e)
        {
            string aranan = kartusara.Text.Trim().ToUpper();
            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in dataGridView1.Rows[i].Cells)
                    {
                        if (cell.Value != null)
                        {
                            if (cell.Value.ToString().ToUpper() == aranan)
                            {
                                cell.Style.BackColor = Color.DarkTurquoise;
                                break;
                            }
                        }
                    }
                }
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Lüffen silinecek satırı seçin.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //err = new OleDbCommandBuilder(adtr);
            //adtr.Update(tablo);
            //MessageBox.Show("işlem tamamdır");
            //OleDbCommand komut = new OleDbCommand("insert into kartus (kimlik no,kartus adi,adeti,) values ('" + Convert.ToInt32(txt1.Text) + "','" + txt2.Text + "','" + txt3.Text + "',')", baglanti);
            komut = new OleDbCommand();
            baglanti.Open();
            komut.Connection = baglanti;
            komut.CommandText = "insert into kartus (kimlik,kartusadi, adeti) values (@pkimlik, @pkartusadi, @padeti)";

            komut.Parameters.AddWithValue("@pkimlik", txt1.Text);
            komut.Parameters.AddWithValue("@pkartusadi", txt2.Text);
            komut.Parameters.AddWithValue("@padeti", txt3.Text);

            komut.ExecuteNonQuery();
            baglanti.Close();


            //OleDbCommand = new OleDbCommand("insert into kartus(kimlik,kartus adi,adeti) values("txt1.Text.ToString() + "," + txt2.Text.ToString() + ","txt3.Text.ToString() + ",",)", baglanti);


        }

        private void button2_Click(object sender, EventArgs e)
        {
         
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int sayi, i;
            listBox1.Items.Clear();
            for (i = 0; i < 10; i++)
            {
                sayi = r.Next(-100, 100);
                listBox1.Items.Add(sayi);
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {

            int sayi, i;
            listBox1.Items.Clear();
            for (i = 0; i < 10; i++)
            {
                sayi = r.Next(0, 10050);
                listBox1.Items.Add(sayi);
            }
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txt1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }
    }
    
}
