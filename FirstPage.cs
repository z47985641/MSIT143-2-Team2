using MSIT143_2_Team2.Class;
using prjGroup2_Midterm_ver0902;
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
    public partial class FirstPage : Form
    {
        public FirstPage()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();
        private void button5_Click(object sender, EventArgs e)
        {
            MainForm mainf = new MainForm();
            //this.Visible = false;
            mainf.Visible = true;
        }

        private void FirstPage_Load(object sender, EventArgs e)
        {

        }



        private void button2_Click(object sender, EventArgs e)
        {
            找好房 findroom = new 找好房();
            //this.Visible = false;
            findroom.Visible = true;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel1.Text
            };


            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel2.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel3.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel4.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel5.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel6.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel7_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel7.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void linkLabel8_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Cmenber Cname = new Cmenber()
            {
                CityName = linkLabel8.Text
            };
            城市房間 city = new 城市房間();
            city.Cname = Cname;
            city.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            登入建立 member = new 登入建立();
            member.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            註冊會員 setmember = new 註冊會員();
            setmember.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            折扣 dis = new 折扣();
            dis.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ActivityDisplay AD = new ActivityDisplay();
            AD.Visible = true;
        }
    }


}
