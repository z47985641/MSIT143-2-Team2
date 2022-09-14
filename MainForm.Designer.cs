
namespace MSIT143_2_Team2
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.會員管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.房源管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.評論系統ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.訂單管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.優惠管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.活動管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.會員管理ToolStripMenuItem,
            this.房源管理ToolStripMenuItem,
            this.評論系統ToolStripMenuItem,
            this.訂單管理ToolStripMenuItem,
            this.優惠管理ToolStripMenuItem,
            this.活動管理ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1132, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 會員管理ToolStripMenuItem
            // 
            this.會員管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("會員管理ToolStripMenuItem.Image")));
            this.會員管理ToolStripMenuItem.Name = "會員管理ToolStripMenuItem";
            this.會員管理ToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.會員管理ToolStripMenuItem.Text = "會員管理";
            this.會員管理ToolStripMenuItem.Click += new System.EventHandler(this.會員管理ToolStripMenuItem_Click);
            // 
            // 房源管理ToolStripMenuItem
            // 
            this.房源管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("房源管理ToolStripMenuItem.Image")));
            this.房源管理ToolStripMenuItem.Name = "房源管理ToolStripMenuItem";
            this.房源管理ToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.房源管理ToolStripMenuItem.Text = "房源管理";
            this.房源管理ToolStripMenuItem.Click += new System.EventHandler(this.房源管理ToolStripMenuItem_Click);
            // 
            // 評論系統ToolStripMenuItem
            // 
            this.評論系統ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("評論系統ToolStripMenuItem.Image")));
            this.評論系統ToolStripMenuItem.Name = "評論系統ToolStripMenuItem";
            this.評論系統ToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.評論系統ToolStripMenuItem.Text = "評論系統";
            this.評論系統ToolStripMenuItem.Click += new System.EventHandler(this.評論系統ToolStripMenuItem_Click);
            // 
            // 訂單管理ToolStripMenuItem
            // 
            this.訂單管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("訂單管理ToolStripMenuItem.Image")));
            this.訂單管理ToolStripMenuItem.Name = "訂單管理ToolStripMenuItem";
            this.訂單管理ToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this.訂單管理ToolStripMenuItem.Text = "訂單管理";
            this.訂單管理ToolStripMenuItem.Click += new System.EventHandler(this.訂單管理ToolStripMenuItem_Click);
            // 
            // 優惠管理ToolStripMenuItem
            // 
            this.優惠管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("優惠管理ToolStripMenuItem.Image")));
            this.優惠管理ToolStripMenuItem.Name = "優惠管理ToolStripMenuItem";
            this.優惠管理ToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.優惠管理ToolStripMenuItem.Text = "優惠";
            this.優惠管理ToolStripMenuItem.Click += new System.EventHandler(this.優惠管理ToolStripMenuItem_Click);
            // 
            // 活動管理ToolStripMenuItem
            // 
            this.活動管理ToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("活動管理ToolStripMenuItem.Image")));
            this.活動管理ToolStripMenuItem.Name = "活動管理ToolStripMenuItem";
            this.活動管理ToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.活動管理ToolStripMenuItem.Text = "活動";
            this.活動管理ToolStripMenuItem.Click += new System.EventHandler(this.活動管理ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 631);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "後臺管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 會員管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 房源管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 評論系統ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 訂單管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 優惠管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 活動管理ToolStripMenuItem;
    }
}

