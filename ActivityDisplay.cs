using MSIT143_2_Team2;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjGroup2_Midterm_ver0902
{
    public partial class ActivityDisplay : Form
    {
        public ActivityDisplay()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Modify_Click(object sender, EventArgs e)
        {
            Modify m = new Modify();
            m.ShowDialog();
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            queryAll();
        }
        private void ActivityDisplay_Load(object sender, EventArgs e)
        {
            queryAll();
        }
        private void queryAll()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                var q = from d in hotel.Activities
                        select d;
                foreach (var a in q)
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.BackColor = Color.LightGray;
                    groupBox.AutoSize = true;
                    flowLayoutPanel1.Controls.Add(groupBox);

                    int titleFontSize = 15;
                    Label label1 = new Label();
                    label1.ForeColor = Color.Blue;
                    //label1.Font = new Font(label1.Font.FontFamily, 15);
                    //label1.Font = Font(FontStyle, )
                    label1.Font = new System.Drawing.Font("微軟正黑體", titleFontSize, System.Drawing.FontStyle.Bold);
                    label1.AutoSize = true;
                    label1.MaximumSize = new Size(180, 0);
                    label1.Text = a.ActivityName;
                    label1.Location = new Point(10, 20);
                    groupBox.Controls.Add(label1);

                    //string date = a.ActivityDate.
                    Label label2 = new Label();
                    label2.ForeColor = Color.Maroon;
                    label2.Font = new Font(label2.Font.FontFamily, 11);
                    label2.AutoSize = true;
                    label2.Text = a.ActivityDate.ToString();
                    label2.Location = new Point(10, titleFontSize + 65);
                    groupBox.Controls.Add(label2);

                    Label label3 = new Label();
                    label3.ForeColor = Color.Maroon;
                    label3.Font = new Font(label3.Font.FontFamily, 11);
                    label3.AutoSize = true;
                    label3.Text = "Capacity: " + a.ActivityCapacity.ToString();
                    label3.Location = new Point(10, titleFontSize + 90);
                    groupBox.Controls.Add(label3);

                    Label label4 = new Label();
                    label4.ForeColor = Color.Maroon;
                    label4.Font = new Font(label4.Font.FontFamily, 11);
                    label4.AutoSize = true;
                    label4.Text = "Info: " + a.ActivityInfo;
                    label4.Location = new Point(10, titleFontSize + 115);
                    groupBox.Controls.Add(label4);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("目前無活動");
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題");
            }
        }

        
    }
}
