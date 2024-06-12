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
using System.Runtime.Remoting.Contexts;

namespace NarinGumruk_Example
{
    public partial class KullaniciForm : Form
    {
        public KullaniciForm()
        {
            InitializeComponent();

        }
        Narin_Gumruk_ExampleProjectEntities example = new Narin_Gumruk_ExampleProjectEntities();
        private string sehir;

        private void KullaniciForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = example.KullaniciExample_TBL.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (e.ColumnIndex == 3)
            {

                //string IndexValue = dataGridView1.Rows[e.ColumnIndex].Cells[e.RowIndex].Value.ToString();

                SehirForm sehirForm = new SehirForm();
                sehirForm.SecilenSehir += sehirForm_SecilenSehir;
                sehirForm.Show();
            }


        }

        private void sehirForm_SecilenSehir(string StringSehir)
        {
            dataGridView1.CurrentRow.Cells[3].Value = StringSehir;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
               
                if (row.Cells["DogumYeri"].Value != null && row.Cells["DogumYeri"].Value != DBNull.Value)
                {
                    string sehir = row.Cells["DogumYeri"].Value.ToString();

                    KullaniciExample_TBL kullanici = new KullaniciExample_TBL
                    {
                        DogumYeri = sehir,
                    };

                    example.KullaniciExample_TBL.Add(kullanici);
                }
            }

            example.SaveChanges();
        }



        private void button3_Click(object sender, EventArgs e)
        {
           dataGridView1.DataSource=example.KullaniciExample_TBL.ToList();
        }
    }
}
