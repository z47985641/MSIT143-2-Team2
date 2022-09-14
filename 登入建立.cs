using MSIT143_2_Team2.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSIT143_2_Team2
{
    public partial class 登入建立 : Form
    {
        public 登入建立()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();

        private void button1_Click_1(object sender, EventArgs e)
        {
            string  i = (textBox2.Text);
            string a = (textBox1.Text);

            var q = from n in hotel.Members
                    where n.MemberPassword == i && n.MemberAccount==a
                    select n;
            if (!q.Any())
            {
                MessageBox.Show("請輸入正確");
            }
            else
            {
                foreach (var b in q)
                {
                    Cmenber.enter= b.MemberID;
                    Cmenber.auth = Convert.ToInt32(b.Authority);  
                }
                MessageBox.Show("歡迎登入!" + textBox1.Text);

                if(Cmenber.auth ==1)
                {
                    找好房 room = new 找好房();
                    room.Visible = true;
                }
                else {  
                    MainForm Main = new MainForm();
                    Main.Visible = true;
                }
               
                this.Close();
            }
            



        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
