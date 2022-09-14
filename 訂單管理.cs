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
    public partial class 訂單管理 : Form
    {
        public 訂單管理()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 訂單管理_Load(object sender, EventArgs e)
        {
                var q = from n in hotel.Orders
                        from r in hotel.Rooms
                        where n.RoomID == r.RoomID
                        select new
                        {
                            //order
                            訂單編號 = n.OrderID,
                            會員編號 = n.MemberID,
                            訂單備註 = n.OrderRemark,
                            訂單狀態 = n.OrderstatusID,
                            //room
                            房源編號 = n.RoomID,
                            房間名稱 = r.RoomName,
                            房間價格 = r.RoomPrice,
                            房間簡介 = r.RoomIntrodution,
                            房間狀態 = r.RoomstatusID,
                            房間地址 = r.Address,
                        };
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button1_Click(object sender, EventArgs e)
        {
                var q = from n in hotel.Orders.AsEnumerable()
                        join r in hotel.Rooms
                        on n.RoomID equals r.RoomID
                        where
                                   (String.IsNullOrEmpty(textBox1.Text) ? true : n.OrderID==int.Parse(textBox1.Text))&& 
                                   ( String.IsNullOrEmpty(textBox2.Text) ? true : n.RoomID== int.Parse(textBox2.Text))&& 
                                   ( String.IsNullOrEmpty(textBox3.Text) ? true : r.RoomPrice== int.Parse(textBox3.Text)) 
                        select new
                        {
                            //order
                            訂單編號 = n.OrderID,
                            會員編號 = n.MemberID,
                            訂單備註 = n.OrderRemark,
                            訂單狀態 = n.OrderstatusID,
                            //room
                            房源編號 = n.RoomID,
                            房間名稱 = r.RoomName,
                            房間價格 = r.RoomPrice,
                            房間簡介 = r.RoomIntrodution,
                            房間狀態 = r.RoomstatusID,
                            房間地址 = r.Address,
                        };
            this.dataGridView1.DataSource = q.ToList();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var q = from n in hotel.Orders
                    from r in hotel.Rooms
                    where n.RoomID == r.RoomID
                    select new
                    {
                        //order
                        訂單編號 = n.OrderID,
                        會員編號 = n.MemberID,
                        訂單備註 = n.OrderRemark,
                        訂單狀態 = n.OrderstatusID,
                        //room
                        房源編號 = n.RoomID,
                        房間名稱 = r.RoomName,
                        房間價格 = r.RoomPrice,
                        房間簡介 = r.RoomIntrodution,
                        房間狀態 = r.RoomstatusID,
                        房間地址 = r.Address,
                    };
            this.dataGridView1.DataSource = q.ToList();
        }
    }
}
