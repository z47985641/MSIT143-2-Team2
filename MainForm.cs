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
using 房源管理;

namespace MSIT143_2_Team2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void 活動管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Modify modify = new Modify();
            modify.MdiParent = this;
            modify.WindowState = FormWindowState.Maximized;
            modify.Show();


        }

        private void 訂單管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            訂單管理 orderA = new 訂單管理();
            orderA.MdiParent = this;
            orderA.WindowState = FormWindowState.Maximized;
            orderA.Show();

            //this.Visible = false;
            //orderA.Visible = true;


        }

        private void 會員管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PJ.MenberView menber = new PJ.MenberView();
            menber.MdiParent = this;
            menber.WindowState = FormWindowState.Maximized;
            menber.Show();
        }

        private void 優惠管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            折扣maintaince discount = new 折扣maintaince();
            discount.MdiParent = this;
            discount.WindowState = FormWindowState.Maximized;
            discount.Show();

        }

        private void 房源管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 room = new Form1();
            room.MdiParent = this;
            room.WindowState = FormWindowState.Maximized;
            room.Show();

        }

        private void 評論系統ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.WindowState = FormWindowState.Maximized;
            form2.Show();

        }


    }
}
