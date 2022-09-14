using MSIT143_2_Team2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 房源管理
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


        }
        MingSuEntities1 hotel = new MingSuEntities1();


        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtName.Text) || "".Equals(txtPrice.Text) || "".Equals(txtIntroduce.Text)
                || "".Equals(txtMember.Text) || "".Equals(txtState.Text) || "".Equals(txtAddress.Text))
                return;
            var room = new Room
            {
                RoomName = txtName.Text,
                RoomPrice = decimal.Parse(txtPrice.Text),
                RoomIntrodution = txtIntroduce.Text,
                MemberID = Convert.ToInt32(txtMember.Text),
                RoomstatusID = Convert.ToInt32(txtState.Text),
                Address = txtAddress.Text,
                CreateDate = DateTime.Now
            };
            var equip = new Equipment
            {
                EquipmentName = txtEquip.Text
            };
            var equipp = new EquipmentCatergory
            {
                EquipmentCatergoryName = txtEquip.Text
            };
            hotel.Rooms.Add(room);

            hotel.EquipmentCatergories.Add(equipp);
            hotel.Equipments.Add(equip);
            hotel.SaveChanges();
            MessageBox.Show("新增資料成功");
            var q = from n in hotel.Rooms
                    select n;
            this.dataGridView1.DataSource = q.ToList();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtRoomID.Text))
                return;
            int i = int.Parse(txtRoomID.Text);

            var q = from n in hotel.Rooms
                    where n.RoomID == i
                    select n;
            foreach (Room R in q)
            {
                R.RoomName = txtName.Text;
                R.RoomPrice = decimal.Parse(txtPrice.Text);
                R.RoomIntrodution = txtIntroduce.Text;
                R.MemberID = Convert.ToInt32(txtMember.Text);
                R.RoomstatusID = Convert.ToInt32(txtState.Text);
                R.Address = txtAddress.Text;

            }
            hotel.SaveChanges();
            this.dataGridView1.DataSource = q.ToList();
            MessageBox.Show("修改成功");
            清空();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var q = from n in hotel.Rooms
                    join o in hotel.Rooms on n.RoomID equals o.RoomID
                    //join w in hotel.ImageReference on n.RoomID equals w.RoomID
                    //join p in hotel.Image on w.ImageID equals p.ImageID
                    select new { n.RoomID, n.RoomName, n.RoomPrice, n.RoomIntrodution, n.MemberID, n.RoomstatusID, n.Address, n.CreateDate };
            this.dataGridView1.DataSource = q.ToList();
            CellClick();


        }
        int _position = 0;

        private void button7_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtRoomID.Text);
            var q = from r in hotel.EquipmentReferences
                    where r.RoomID == i
                    select r;

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = int.Parse(txtRoomID.Text);
            var q = (from n in hotel.Rooms
                     where n.RoomID == i
                     select n).FirstOrDefault();

            hotel.Rooms.Remove(q);
            hotel.SaveChangesAsync();

            MessageBox.Show("刪除成功");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //MSIT143_2_Team2.Image image = new MSIT143_2_Team2.Image();
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();
            MSIT143_2_Team2.Image photo = new MSIT143_2_Team2.Image
            {
                Image1 = bytes
            };

            var q = from n in hotel.Images
                    where n.Image1 == bytes
                    select n.ImageID;
            int i = 0;

            foreach (int par in q) { i = par; };
            var pic = new ImageReference
            {
                ImageID = i,
                RoomID = (int)dataGridView1.CurrentRow.Cells[0].Value

            };
            hotel.ImageReferences.Add(pic);
            hotel.Images.Add(photo);
            hotel.SaveChanges();
            MessageBox.Show("上傳成功");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.pictureBox1.Image = System.Drawing.Image.FromFile(this.openFileDialog1.FileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int i = (int)dataGridView2.CurrentRow.Cells[1].Value;

            var q = (from n in hotel.Images
                     where n.ImageID == i
                     select n).FirstOrDefault();

            var c = (from n in hotel.ImageReferences
                     where n.ImageID == i
                     select n).FirstOrDefault();
            hotel.ImageReferences.Remove(c);
            hotel.Images.Remove(q);
            hotel.SaveChanges();
            MessageBox.Show("刪除成功");

        }

        private void Refresh(object sender, EventArgs e)
        {
            var q = from n in hotel.Rooms
                    select new { n.RoomID, n.RoomName, n.RoomPrice, n.RoomIntrodution, n.MemberID, n.RoomstatusID, n.Address, n.CreateDate };
            this.dataGridView1.DataSource = q.ToList();
        }

        public void CellClick()
        {
            txtRoomID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrice.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtIntroduce.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtMember.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtState.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAddress.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            int i = int.Parse(txtRoomID.Text);
            var q = from n in hotel.EquipmentReferences
                    join o in hotel.Rooms on n.RoomID equals o.RoomID
                    join w in hotel.ImageReferences on n.RoomID equals w.RoomID
                    //join p in hotel.Image on w.ImageID equals p.ImageID
                    where o.RoomID == i
                    select n;

            foreach (var text in q.ToList())
            {
                txtEquip.Text = text.EquipmentReferenceID.ToString();
            }

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
            int u = (int)dataGridView1.CurrentRow.Cells[0].Value;
            var q = from n in hotel.Rooms
                    join w in hotel.ImageReferences on n.RoomID equals w.RoomID
                    join p in hotel.Images on w.ImageID equals p.ImageID
                    where n.RoomID == u
                    select new { p.Image1, p.ImageID };
            foreach (var i in q)
            {
                System.IO.MemoryStream ms1 = new System.IO.MemoryStream(i.Image1);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms1);
                this.pictureBox1.Image = img;
            }
            this.dataGridView2.DataSource = q.ToList();


        }
        private void button9_Click(object sender, EventArgs e)
        {
            DateTime d1 = dateTimePicker1.Value;
            d1 = d1.AddDays(-1);
            var q = from p in hotel.Rooms
                    where p.CreateDate >= d1 &&
                    p.CreateDate <= dateTimePicker2.Value
                    orderby p.CreateDate
                    select p;

            dataGridView1.DataSource = q.ToList();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int u = (int)dataGridView2.CurrentRow.Cells[1].Value;
            var q = from n in hotel.Images
                    where n.ImageID == u
                    select n;
            foreach (var i in q)
            {
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] bytes = ms.GetBuffer();
                i.Image1 = bytes;
            }
            hotel.SaveChanges();
            this.dataGridView2.DataSource = q.ToList();
            MessageBox.Show("修改成功");

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //    int u = (int)dataGridView2.CurrentRow.Cells[1].Value;
            //    var q = from n in hotel.Image
            //            where n.ImageID == u
            //            select n;
            //    System.IO.MemoryStream ms = new System.IO.MemoryStream();
            //    this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            //    byte[] bytes = ms.GetBuffer();
            //    Image1 = bytes;
            //    this.pictureBox1.Image = img;
        }
        private void 清空()
        {
            //this.Controls.OfType<TextBox>().
            foreach (TextBox tb in this.Controls.OfType<TextBox>())
            {
                tb.Text = "";
            }
        }
    }
}








