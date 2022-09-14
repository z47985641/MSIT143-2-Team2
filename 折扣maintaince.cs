using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MSIT143_2_Team2
{
    public partial class 折扣maintaince : Form
    {
        public 折扣maintaince()
        {
            InitializeComponent();
        }
        MingSuEntities1 mingSu = new MingSuEntities1();

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtRoomDisID.Text) && "".Equals(txtDisName.Text) && "".Equals(txtDisInfo.Text))
                {
                    Query();
                }
                else
                {
                    IQueryable<Discount> q;
                    if ("".Equals(txtRoomDisID.Text))
                    {
                        q = from d in mingSu.Discounts
                            where (d.DiscountName.Contains(txtDisName.Text) &&
                            d.DiscountInfo.Contains(txtDisInfo.Text))
                            select d;
                    }
                    else
                    {
                        int i = int.Parse(txtRoomDisID.Text);
                        q = from d in mingSu.Discounts
                            where (d.RoomDiscountID == i &&
                            d.DiscountName.Contains(txtDisName.Text) &&
                            d.DiscountInfo.Contains(txtDisInfo.Text))
                            select d;
                    }
                    dataGridView1.DataSource = q.ToList();
                }
                CellClick();
                SetGridStyle();
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

        private void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtDisName.Text) || "".Equals(txtDisInfo.Text))
                    return;
                Discount dis = new Discount
                {
                    DiscountName = txtDisName.Text,
                    DiscountInfo = txtDisInfo.Text
                };
                mingSu.Discounts.Add(dis);
                mingSu.SaveChanges();
                MessageBox.Show("新增完成");
                Query();
                SetGridStyle();
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtRoomDisID.Text) || "".Equals(txtDisName.Text) || "".Equals(txtDisInfo.Text))
                    return;
                int i = int.Parse(txtRoomDisID.Text);
                var q = from d in mingSu.Discounts
                        where d.RoomDiscountID == i
                        select d;
                foreach (var d in q)
                {
                    d.DiscountName = txtDisName.Text;
                    d.DiscountInfo = txtDisInfo.Text;
                }
                mingSu.SaveChanges();
                MessageBox.Show("更新完成");
                Query();
                SetGridStyle();
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if ("".Equals(txtRoomDisID.Text))
                    return;
                int i = int.Parse(txtRoomDisID.Text);
                var q = (from d in mingSu.Discounts
                         where d.RoomDiscountID == i
                         select d).FirstOrDefault();
                mingSu.Discounts.Remove(q);
                mingSu.SaveChanges();
                MessageBox.Show("刪除完成");
                Query();
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CellClick();
        }

        private void 折扣maintaince_Load(object sender, EventArgs e)
        {
            try
            {
                Query();
                CellClick();
                SetGridStyle();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("資料庫無資料");
            }
            catch (Exception)
            {
                MessageBox.Show("程式執行發生問題，請重試");
            }
        }

        private void Query()
        {
            var q = from d in mingSu.Discounts
                    select d;
            dataGridView1.DataSource = q.ToList();
        }

        public void CellClick()
        {
            if (dataGridView1.Rows.Count == 0)
                return;
            txtRoomDisID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtDisName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtDisInfo.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        public void SetGridStyle()
        {
            dataGridView1.Columns[0].Width = 130;
            dataGridView1.Columns[1].Width = 140;
            dataGridView1.Columns[2].Width = 105;
            bool isColorChanged = false;
            Color bgc;
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                isColorChanged = !isColorChanged;
                bgc = Color.AliceBlue;
                if (isColorChanged)
                {
                    bgc = Color.LavenderBlush;
                }
                foreach (DataGridViewCell c in r.Cells)
                {
                    c.Style.BackColor = bgc;
                }
            }
        }
    }
}
