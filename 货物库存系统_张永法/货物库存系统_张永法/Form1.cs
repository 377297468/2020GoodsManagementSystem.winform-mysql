using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace 货物库存系统_张永法
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GoodsitemForm goodsitem = new GoodsitemForm();
            goodsitem.Show();
        }
        //初始化数据库变量
        static string conStr = "server=127.0.0.1;port=3306;user=root;password=admin; database=world;CharSet=utf8;";//password 输入你所建立数据库的密码
        static string name = "Name";

        /// <summary>
        /// 检测数据库是否连接上
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

       
    }
}
