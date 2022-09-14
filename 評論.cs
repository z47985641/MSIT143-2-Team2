using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MSIT143_2_Team2;
using System.Resources;
using Image = System.Drawing.Image;

namespace MSIT143_Topic_0831
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string[] pic ={ "star_good.jpg",
                        "star_white.jpg"};
        int i = 0;
        MingSuEntities1 hotel = new MingSuEntities1();
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (i == 1) i = 0;
            i++;
            starBox1.Image = new Bitmap(pic[i]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ("".Equals(txtBox1.Text) || "".Equals(txtBox2.Text) || "".Equals(txtBox3.Text))
            return;
            List<Image> star = new List<Image>();
            star.Add(starBox1.Image);
            star.Add(starBox2.Image);
            star.Add(starBox3.Image);
            star.Add(starBox4.Image);
            star.Add(starBox5.Image);
            //int j = Convert.ToInt32(txtBox2.Text);
            //var q = from c in hotel.Comments
            //        where c.RoomID == 
            //        select c;

            Comment CC = new Comment()
            {
                CommentDetail = txtBox3.Text,
                CommentID = Convert.ToInt32(txtBox1.Text),
                RoomID = Convert.ToInt32(txtBox2.Text),
       
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            starBox1.Image = MSIT143_2_Team2.Properties.Resources.star_white;
            starBox2.Image = MSIT143_2_Team2.Properties.Resources.star_white;
            starBox3.Image = MSIT143_2_Team2.Properties.Resources.star_white;
            starBox4.Image = MSIT143_2_Team2.Properties.Resources.star_white;
            starBox5.Image = MSIT143_2_Team2.Properties.Resources.star_white;
        }

        private void starBox1_MouseMove(object sender, MouseEventArgs e)
        {
            starBox1.Image = MSIT143_2_Team2.Properties.Resources.star_good;               
        }

        private void starBox2_MouseMove(object sender, MouseEventArgs e)
        {
            starBox2.Image = MSIT143_2_Team2.Properties.Resources.star_good;
        }

        private void starBox3_MouseMove(object sender, MouseEventArgs e)
        {
            starBox3.Image = MSIT143_2_Team2.Properties.Resources.star_good;
        }

        private void starBox4_MouseMove(object sender, MouseEventArgs e)
        {
            starBox4.Image = MSIT143_2_Team2.Properties.Resources.star_good;
        }

        private void starBox5_MouseMove(object sender, MouseEventArgs e)
        {
            starBox5.Image = MSIT143_2_Team2.Properties.Resources.star_good;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
