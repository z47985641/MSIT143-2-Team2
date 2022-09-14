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
    public partial class 註冊會員 : Form
    {
        public 註冊會員()
        {
            InitializeComponent();
        }

        MingSuEntities1 hotel = new MingSuEntities1();
        private void button3_Click(object sender, EventArgs e)
        {
            label2.Text = IsStrongPassword(textBox1.Text) ? "密碼強度高" : "密碼強度低";
            //label4.Text = IsIDCorrect(textBox2.Text) ? "身份證字號格式正確" : "身份證字號格式錯誤";
        }

        bool IsStrongPassword(string Password)
        {
            return Regex.IsMatch(Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$");
        }

        bool IsIDCorrect(string ID)
        {
            return Regex.IsMatch(ID, @"^(?=.*[A-Z]){1}[1-2]{1}[0-9]{8}$");
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //label2.Text = IsStrongPassword(textBox1.Text) ? "密碼強度高" : "密碼強度低";
            if (IsStrongPassword(textBox1.Text))
            {
                label2.Text = "密碼強度高";
                timer1.Enabled = false;
                label2.BackColor = Color.Transparent;
                label2.ForeColor = Color.Black;
            }
            else
            {
                label2.Text = "密碼強度低";
                timer1.Enabled = true;
            }
        }


        bool flag = true;

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (flag)
            {
                label2.BackColor = Color.Yellow;
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.BackColor = Color.Red;
                label2.ForeColor = Color.Yellow;
            }
            flag = !flag;
        }



        bool IsgoodPassword(string Password)
        {
            return Regex.IsMatch(Password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,16}$");
        }

        bool IsCorrect(string ID)
        {
            return Regex.IsMatch(ID, @"^(?=.*[A-Z]){1}[1-2]{1}[0-9]{8}$");
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label2.Text = IsgoodPassword(textBox1.Text) ? "密碼強度高" : "密碼強度低";
            //label4.Text = IsCorrect(textBox2.Text) ? "身份證字號格式正確" : "身份證字號格式錯誤";

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            this.pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] bytes = ms.GetBuffer();



            Member member = new Member
            {
                MemberName = textBox5.Text, //會員名稱
                MemberAccount = textBox3.Text,//會員帳號
                MemberPassword = textBox1.Text,//會員密碼
                BirthDate = DateTime.Parse(textBox4.Text),//出生年月日
                MemberPhone=textBox6.Text,//會員電話
                //CityID=int.Parse(comboBox1.Text)//居住地址
                CityID= changeCityNameToCityID(comboBox1.Text),//居住地址
                MemberEmail= textBox2.Text,//居住地址
                Authority = comboBox2.Text,//身分驗證
                MemberImage = bytes
            };

            City city = new City
            {
                CityName =comboBox1.Text
            };

            hotel.Members.Add(member);
            try
            {
            hotel.SaveChanges();
            }
            catch (Exception ex)
            {
                string error = ex.ToString();
            }
            MessageBox.Show("新增完成");
        }
        bool flag1 = true;
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (flag1)
            {
                label2.BackColor = Color.LightBlue;
                label2.ForeColor = Color.Red;
            }
            else
            {
                label2.BackColor = Color.Red;
                label2.ForeColor = Color.LightBlue;
            }
            flag1 = !flag1;
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            //label2.Text = IsStrongPassword(textBox1.Text) ? "密碼強度高" : "密碼強度低";
            if (IsgoodPassword(textBox1.Text))
            {
                label2.Text = "密碼強度高";
                timer1.Enabled = false;
                label2.BackColor = Color.Transparent;
                label2.ForeColor = Color.Black;
            }
            else
            {
                label2.Text = "密碼強度低";
                timer1.Enabled = true;
            }

        }

        public string namePath = "";



        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible =false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            namePath = openFileDialog.FileName;
            System.Drawing.Image img = System.Drawing.Image.FromFile(openFileDialog.FileName);
            System.Drawing.Image image = new System.Drawing.Bitmap(img);
            img.Dispose();
            pictureBox1.Image = image;
        }

        public int changeCityNameToCityID(string CityName = "") 
        {
            int CityID = 0;
            switch (CityName) 
            {
                case "臺北市":
                    CityID = 1;
                    break;
                case "新北市":
                    CityID = 2;
                    break;
                case "桃園市":
                    CityID = 3;
                    break;
                case "臺中市":
                    CityID = 4;
                    break;
                case "臺南市":
                    CityID = 5;
                    break;
                case "高雄市":
                    CityID = 6;
                    break;
                case "基隆市":
                    CityID = 7;
                    break;
                case "新竹市":
                    CityID = 8;
                    break;
                case "嘉義市":
                    CityID = 9;
                    break;
                case "新竹縣":
                    CityID = 10;
                    break;
                case "苗栗縣":
                    CityID = 11;
                    break;
                case "彰化縣":
                    CityID = 12;
                    break;
                case "南投縣":
                    CityID = 13;
                    break;
                case "雲林縣":
                    CityID = 14;
                    break;
                case "嘉義縣":
                    CityID = 15;
                    break;
                case "屏東縣":
                    CityID = 16;
                    break;
                case "宜蘭縣":
                    CityID = 17;
                    break;
                case "花蓮縣":
                    CityID = 18;
                    break;
                case "臺東縣":
                    CityID = 19;
                    break;
                case "澎湖縣":
                    CityID = 20;
                    break;

            }


            return CityID;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            var CityName = new List<string> 
            { 
                "臺北市", "新北市", "桃園市", "臺中市", "臺南市" ,
                "高雄市", "基隆市", "新竹市", "嘉義市", "新竹縣" ,
                "苗栗縣", "彰化縣", "南投縣", "雲林縣", "嘉義縣" ,
                "屏東縣", "宜蘭縣", "花蓮縣", "臺東縣", "澎湖縣"
            };
            #region 隨機產生8位數字當電話號碼使用
            int[] randomArray = new int[8];
            Random rnd = new Random();  //產生亂數初始值
            string ph = "";
            for (int i = 0; i < 8; i++)
            {
                randomArray[i] = rnd.Next(1, 9);   //亂數產生，亂數產生的範圍是1~9
                ph += randomArray[i].ToString();
            }
            #endregion
            #region 中文三個字隨機
            //獲取GB2312編碼頁（表） 
            Encoding gb = Encoding.GetEncoding("gb2312");
            //調用函數產生4個隨機中文漢字編碼 
            object[] bytes = CreateRegionCode(4);
            //根據漢字編碼的字節數組解碼出中文漢字 
            string str1 = gb.GetString((byte[])Convert.ChangeType(bytes[0], typeof(byte[]))); 
            string str2 = gb.GetString((byte[])Convert.ChangeType(bytes[1], typeof(byte[])));
            string str3 = gb.GetString((byte[])Convert.ChangeType(bytes[2], typeof(byte[])));
            //string str4 = gb.GetString((byte[])Convert.ChangeType(bytes[3], typeof(byte[])));
            #endregion
            #region 英文六位數隨機
            var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var characters1 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var Charsarr = new char[6];
            var Charsarr1 = new char[5];
            var random = new Random();
            for (int i = 0; i < Charsarr1.Length; i++)
            {
                Charsarr1[i] = characters1[random.Next(characters1.Length)];
            }
            for (int i = 0; i < Charsarr.Length; i++)
            {
                Charsarr[i] = characters[random.Next(characters.Length)];
            }

            var resultString = new String(Charsarr);
            var resultString1 = new String(Charsarr1);

            #endregion
            var Authority = new List<string>
            {
                "1","2"
            };
            textBox5.Text = resultString; //
            textBox3.Text = resultString1;
            textBox1.Text = resultString1;
            textBox6.Text = "09"+ph;
            textBox2.Text = resultString1+"@gmail.com";
            textBox4.Text = DateTime.Now.ToString("yyyy/MM/dd");
            comboBox1.Text = CityName[random.Next(CityName.Count)];
            comboBox2.Text = Authority[random.Next(Authority.Count)];

        }

        public static object[] CreateRegionCode(int strlength)
        {
            //定義一個字符串數組儲存漢字編碼的組成元素 
            string[] rBase = new String[16] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" };
            Random rnd = new Random();
            //定義一個object數組用來 
            object[] bytes = new object[strlength];
            /*每循環一次產生一個含兩個元素的十六進制字節數組，並將其放入object數組中 
            每個漢字有四個區位碼組成 
            區位碼第1位和區位碼第2位作爲字節數組第一個元素 
            區位碼第3位和區位碼第4位作爲字節數組第二個元素 
           */
            for (int i = 0; i < strlength; i++)
            {
                //區位碼第1位 
                int r1 = rnd.Next(11, 14);
                string str_r1 = rBase[r1].Trim();
                //區位碼第2位 
                rnd = new Random(r1 * unchecked((int)DateTime.Now.Ticks) + i);

                //更換隨機數發生器的 種子避免產生重複值;

                int r2;

                if (r1 == 13)
                {
                    r2 = rnd.Next(0, 7);
                }
                else
                {
                    r2 = rnd.Next(0, 16);
                }
                string str_r2 = rBase[r2].Trim();
                //區位碼第3位 
                rnd = new Random(r2 * unchecked((int)DateTime.Now.Ticks) + i);
                int r3 = rnd.Next(10, 16);
                string str_r3 = rBase[r3].Trim();
                //區位碼第4位 
                rnd = new Random(r3 * unchecked((int)DateTime.Now.Ticks) + i);
                int r4;
                if (r3 == 10)
                {
                    r4 = rnd.Next(1, 16);
                }
                else if (r3 == 15)
                {
                    r4 = rnd.Next(0, 15);
                }
                else
                {
                    r4 = rnd.Next(0, 16);
                }
                string str_r4 = rBase[r4].Trim();
                //定義兩個字節變量存儲產生的隨機漢字區位碼 
                byte byte1 = Convert.ToByte(str_r1 + str_r2, 16);
                byte byte2 = Convert.ToByte(str_r3 + str_r4, 16);
                //將兩個字節變量存儲在字節數組中 
                byte[] str_r = new byte[] { byte1, byte2 };
                //將產生的一個漢字的字節數組放入object數組中 
                bytes.SetValue(str_r, i);
            }
            return bytes;
        }
    }
}
