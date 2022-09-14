using MSIT143_2_Team2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSIT143_2_Team2
{
    public partial class 找好房 : Form
    {
        public 找好房()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();
        public int num;
        private void button1_Click(object sender, EventArgs e)
        {
            num -= 1;
            this.label1.Text = num.ToString();
        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            num += 1;
            this.label1.Text = num.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            num += 1;
            this.label4.Text = num.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            num -= 1;
            this.label4.Text = num.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            num += 1;
            this.label6.Text = num.ToString();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            num += 1;
            this.label6.Text = num.ToString();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
        }

        private void 找好房_Load(object sender, EventArgs e)
        {
            var q = from n in hotel.Rooms
                    //group n by
                        select new {房間名稱=n.RoomName, 房間價格=n.RoomPrice, 
                            房間簡介=n.RoomIntrodution,房間狀態=n.RoomstatusID, 房間地址=n.Address };
            this.dataGridView2.DataSource = q.ToList();

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //textBox1.Text = "輸入城市、區域、景點或住宿名稱....";
            //textBox1.Focus();
            //textBox1.Text = "";
        }

        private void 找好房_Activated(object sender, EventArgs e)
        {
            textBox1.Text = "輸入城市、區域、景點或住宿名稱....";
            textBox1.Focus();

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            
            //textBox1.Text = "";
        }


        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox1.Text = "";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length <= 1)
            {
            MessageBox.Show("請輸入關鍵字搜尋");
            }
            else
            {
                var q = from n in hotel.Rooms
                        join r in hotel.ImageReferences
                        on n.RoomID equals r.RoomID
                        join c in hotel.Images
                        on r.ImageID equals c.ImageID
                        where n.Address.Contains(textBox1.Text)
                        //select n;
                        select new
                        {
                            房源編號 = n.RoomID,
                            房間名稱 = n.RoomName,
                            房間價格 = n.RoomPrice,
                            房間簡介 = n.RoomIntrodution,
                            房間狀態 = n.RoomstatusID,  //跳過
                            房間地址 = n.Address,
                        };

                this.dataGridView2.DataSource = q.ToList();
            }
        }



        Cmenber cmenber = new Cmenber();
        int index = -1;

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            index = e.RowIndex;
            //string id = dataGridView2.Rows[index].Cells[0].Value.ToString();
            下訂單 order = new 下訂單();
            //order.Visible = true;

            Cmenber cmenber = new Cmenber();
            cmenber.roomid = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            cmenber.roomname = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            cmenber.roomprice = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            cmenber.roominfo = dataGridView2.CurrentRow.Cells[3].Value.ToString();
            cmenber.roomaddr = dataGridView2.CurrentRow.Cells[5].Value.ToString();

            order._cmenber = cmenber;
            order.ShowDialog();
            //cmenber.roomid = dataGridView2.Rows[index].Cells[0].Value.ToString();
            //cmenber.roomname = dataGridView2.Rows[index].Cells[1].Value.ToString();
            //cmenber.roomprice = dataGridView2.Rows[index].Cells[2].Value.ToString();
            //cmenber.roominfo = dataGridView2.Rows[index].Cells[3].Value.ToString();
            //cmenber.roomaddr = dataGridView2.Rows[index].Cells[5].Value.ToString();
            //MessageBox.Show(id);
        }

    }
}
