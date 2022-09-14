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
    public partial class 折扣 : Form
    {
        public 折扣()
        {
            InitializeComponent();
        }
        MingSuEntities1 hotel = new MingSuEntities1();

        private void 折扣_Load(object sender, EventArgs e)
        {
            QueryAll();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void QueryAll()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                var q = from d in hotel.Discounts
                        select d;
                foreach (var d in q)
                {
                    GroupBox groupBox = new GroupBox();
                    groupBox.BackColor = Color.Azure;
                    flowLayoutPanel1.Controls.Add(groupBox);
                    Label label1 = new Label();
                    label1.ForeColor = Color.SteelBlue;
                    label1.Font = new Font(label1.Font.FontFamily, 14, FontStyle.Bold);
                    label1.AutoSize = true;
                    label1.MaximumSize = new Size(180, 0);
                    label1.Text = d.DiscountName;
                    label1.Location = new Point(10, 15);
                    groupBox.Controls.Add(label1);
                    Label label2 = new Label();
                    label2.ForeColor = Color.MidnightBlue;
                    label2.Font = new Font(label2.Font.FontFamily, 11);
                    label2.AutoSize = true;
                    label2.Text = d.DiscountInfo;
                    label2.Location = new Point(10, 65);
                    groupBox.Controls.Add(label2);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("目前無優惠活動");
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }
    }
}
