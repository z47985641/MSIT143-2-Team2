using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSIT143_2_Team2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();
        int j = 0;

        private void starBox1_Click(object sender, EventArgs e)
        {
            StarChange(1);
        }

        private void StarChange(int i)
        {
            if (i == 1)
            {
                starBox1.Image = Properties.Resources.star_good;
                starBox2.Image = Properties.Resources.star_white;
                starBox3.Image = Properties.Resources.star_white;
                starBox4.Image = Properties.Resources.star_white;
                starBox5.Image = Properties.Resources.star_white;
                j = 1;
            }
            else if (i == 2) 
            {
                starBox1.Image = Properties.Resources.star_good;
                starBox2.Image = Properties.Resources.star_good;
                starBox3.Image = Properties.Resources.star_white;
                starBox4.Image = Properties.Resources.star_white;
                starBox5.Image = Properties.Resources.star_white;
                j = 2;
            }
            else if (i == 3)
            {
                starBox1.Image = Properties.Resources.star_good;
                starBox2.Image = Properties.Resources.star_good;
                starBox3.Image = Properties.Resources.star_good;
                starBox4.Image = Properties.Resources.star_white;
                starBox5.Image = Properties.Resources.star_white;
                j = 3;
            }
            else if (i == 4)
            {
                starBox1.Image = Properties.Resources.star_good;
                starBox2.Image = Properties.Resources.star_good;
                starBox3.Image = Properties.Resources.star_good;
                starBox4.Image = Properties.Resources.star_good;
                starBox5.Image = Properties.Resources.star_white;
                j = 4;
            }
            else if (i == 5)
            {
                starBox1.Image = Properties.Resources.star_good;
                starBox2.Image = Properties.Resources.star_good;
                starBox3.Image = Properties.Resources.star_good;
                starBox4.Image = Properties.Resources.star_good;
                starBox5.Image = Properties.Resources.star_good;
                j = 5;
            }
        }

        private void starBox2_Click(object sender, EventArgs e)
        {
            StarChange(2);
        }

        private void starBox3_Click(object sender, EventArgs e)
        {
            StarChange(3);
        }

        private void starBox4_Click(object sender, EventArgs e)
        {
            StarChange(4);
        }

        private void starBox5_Click(object sender, EventArgs e)
        {
            StarChange(5);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtBox1.Text) || "".Equals(txtBox2.Text) || "".Equals(txtBox3.Text))
                return;
            //int j = Convert.ToInt32(txtBox2.Text);
            //var q = from c in hotel.Comments
            //        where c.RoomID == 
            //        select c;

            Comment CC = new Comment()
            {
                CommentDetail = txtBox3.Text,
                CommentID = Convert.ToInt32(txtBox1.Text),
                RoomID = Convert.ToInt32(txtBox2.Text),
                CommentPoint = j,
            };

            //foreach (var cc in q)
            //{
            //    cc.CommentDetail = txtBox3.Text;
            //    cc.CommentID = Convert.ToInt32(txtBox1.Text);
            //    //for (int i = 0; i < cc.CommentPoint; i++)
            //    //{
            //    //    star[i] = MSIT143_2_Team2.Properties.Resources.star_good;
            //    //}
            //}
            hotel.Comments.Add(CC);
            hotel.SaveChanges();
            MessageBox.Show("已儲存");
            QueryAll();
            SetGridStyle();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            QueryAll();
            CellClick();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtBox1.Text) && "".Equals(txtBox2.Text) && "".Equals(txtBox3.Text))
                {
                    QueryAll();
                }
                else
                {
                    if ("".Equals(txtBox2.Text))
                    {
                        var q1 = from c in hotel.Comments
                            where (c.CommentID.ToString().Contains(txtBox1.Text) &&
                            c.CommentDetail.Contains(txtBox3.Text))
                            select new { c.CommentID, c.RoomID, c.CommentPoint, c.CommentDetail };

                            dataGridView1.DataSource = q1.ToList();
                    }
                    else
                    {
                        int i = int.Parse(txtBox2.Text);
                        var q2 = from c in hotel.Comments
                            where (c.RoomID == i &&
                            c.CommentID.ToString().Contains(txtBox1.Text) &&
                            c.CommentDetail.Contains(txtBox3.Text))
                            select new { c.CommentID, c.RoomID, c.CommentPoint, c.CommentDetail };

                        dataGridView1.DataSource = q2.ToList();
                    }
                }
                CellClick();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("查無資料");
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtBox1.Text) || "".Equals(txtBox2.Text))
                    return;
                int i = int.Parse(txtBox1.Text);
                int k = int.Parse(txtBox2.Text);
                var q = (from c in hotel.Comments
                         where (c.CommentID == i && c.RoomID == k)
                         select c).FirstOrDefault();
                hotel.Comments.Remove(q);
                hotel.SaveChanges();
                MessageBox.Show("刪除完成");
                QueryAll();
                CellClick();
                SetGridStyle();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("資料庫已無資料");
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }

        private void QueryAll()
        {
            var q = from c in hotel.Comments
                select new {c.CommentID, c.RoomID, c.CommentPoint, c.CommentDetail};

            dataGridView1.DataSource = q.ToList();
            SetGridStyle();
        }

        private void SetGridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "評論編號";
            dataGridView1.Columns[1].HeaderText = "房源編號";
            dataGridView1.Columns[2].HeaderText = "星數";
            dataGridView1.Columns[3].HeaderText = "內容";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }

        public void CellClick()
        {
            txtBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            for (int i = 0; i <= (int)dataGridView1.CurrentRow.Cells[2].Value; i++)
            {
                StarChange(i);
            }
        }

        private void starBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StarCancel();
        }

        private void StarCancel()
        {
            starBox1.Image = Properties.Resources.star_white;
            starBox2.Image = Properties.Resources.star_white;
            starBox3.Image = Properties.Resources.star_white;
            starBox4.Image = Properties.Resources.star_white;
            starBox5.Image = Properties.Resources.star_white;
        }

        private void starBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StarCancel();
        }

        private void starBox3_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StarCancel();
        }

        private void starBox4_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StarCancel();
        }

        private void starBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            StarCancel();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtBox1.Text) || "".Equals(txtBox2.Text) || "".Equals(txtBox3.Text))
                    return;
                int i = int.Parse(txtBox1.Text);
                int k = int.Parse(txtBox2.Text);
                var q = from c in hotel.Comments
                        where (c.CommentID == i && c.RoomID == k)
                        select c;
                foreach (var c in q)
                {
                    c.CommentDetail = txtBox3.Text;
                    c.CommentPoint = j;
                }
                hotel.SaveChanges();
                MessageBox.Show("更新完成");
                QueryAll();
                SetGridStyle();
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }
    }
}
