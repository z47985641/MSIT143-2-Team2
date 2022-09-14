using MSIT143_2_Team2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSIT143_2_Team2
{
    public partial class 城市房間 : Form
    {
        public 城市房間()
        {
            InitializeComponent();
            
        }
        MingSuEntities1 hotel = new MingSuEntities1();

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        public Cmenber Cname
        {
            set { CM = value;  Cityname = CM.CityName; }
        }
        string Cityname;
        Cmenber CM = new Cmenber();
        private void 城市房間_Load(object sender, EventArgs e)
        {
                var q = from n in hotel.Rooms
                        where n.Address == Cityname
                        select n;
                this.dataGridView1.DataSource = q.ToList();
        }
    }
}
