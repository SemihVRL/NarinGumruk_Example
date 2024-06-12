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
using System.Net.Http.Headers;

namespace NarinGumruk_Example
{
    public partial class SehirForm : Form
    {
        public event Action<string> SecilenSehir;
        public SehirForm()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }
        Narin_Gumruk_ExampleProjectEntities example= new Narin_Gumruk_ExampleProjectEntities();
        private void SehirForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource= example.Sehir_TBL.ToList();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex>=0)
            {
                string StringSehir = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
               SecilenSehir?.Invoke(StringSehir);

                
            }
        }
    }
}
