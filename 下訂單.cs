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
using static MSIT143_2_Team2.找好房;

namespace MSIT143_2_Team2
{
    public partial class 下訂單 : Form
    {
        public 下訂單()
        {
            InitializeComponent();
        }
        Cmenber cmenber = new Cmenber();
        MingSuEntities1 hotel = new MingSuEntities1();

        public Cmenber _cmenber
        {
            get
            {

                return cmenber;
            }
            set
            {

                cmenber = value;
            }
            
        }

        private void 下訂單_Load(object sender, EventArgs e)
        {

            label15.Text = cmenber.roomid;
            label16.Text = cmenber.roomname;
            label17.Text = cmenber.roominfo;
            label18.Text = cmenber.roomaddr;
            label19.Text = cmenber.roomprice;

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //int i = int.Parse(textBox10.Text);
            //i = Convert.ToInt32(textBox10.Text);

            Order room = new Order
            {
                MemberID =Cmenber.enter,
                //MemberID= Convert.ToInt32(textBox1.Text),
                OrderstatusID = 3,
                OrderRemark=textBox5.Text,
                RoomID=Convert.ToInt32(label15.Text)
            };
            hotel.Orders.Add(room);
            hotel.SaveChanges();
            MessageBox.Show("下訂資料成功");


        }
    }
}
