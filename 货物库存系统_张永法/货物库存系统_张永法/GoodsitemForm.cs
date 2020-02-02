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
using 货物库存系统_张永法.sqlclass;

namespace 货物库存系统_张永法
{
    public partial class GoodsitemForm : Form
    {   ///创造商品类实例
        static string strConnection = "server=127.0.0.1;port=3306;user=root;password=admin; database=market;CharSet=utf8;";
        MySqlConnection  adapter = new MySqlConnection (strConnection );
        Proxy proxy = null;
        /// <summary>
        /// 变量初始化
        /// </summary>
        string name = "肥皂";
        string type = "生活用品";
        string price = "26";
        string unit = "块";
        string count = "6";
        /// <summary>
        /// 构造函数
        /// </summary>
        public GoodsitemForm()
        {
            InitializeComponent();
            // 初始化代理者（代理商品类），并查询整个商品表
            proxy = new Proxy(new DB_GOODS(name, type, price, unit, count), new DataGridView());
            proxy.recordSelect(adapter , dataGridView1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Goodsitem_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 设置adapter
        /// </summary>
        internal void setAdapter(MySqlDataAdapter adp)
        {

        }
        internal void setCmd(MySqlCommand cmd)
        {

        }
        /// <summary>
        /// 查询商品按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            proxy.recordSelect(adapter, dataGridView1);
        }

        /// <summary>
        /// 增添商品按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            price = Convert.ToString(textBox3.Text);   //if(textBox3.Text.Trim ()== String.Empty)
            type = Convert.ToString(textBox2.Text);
            name = Convert.ToString(textBox1.Text);
            unit = Convert.ToString(textBox4.Text);
            count = Convert.ToString(textBox5.Text);
            // 实例化商品类，并委托给代理者类添加到数据库
            DB_GOODS goods = new DB_GOODS(name, type, price, unit, count);
            proxy.setRealSubject(goods);
            proxy.recordInsert(adapter);
            proxy.recordSelect(adapter, dataGridView1);
        }
        /// <summary>
        /// 修改按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)   //流程是先选中指定行，然后输入要修改的信息，再点击修改，弹出对话框修改完成，清空输入框内容
        {   //判断文本框是否为空值，空值则判断为null。
           if (textBox3.Text.Trim() != String.Empty) { price = null; } else { price = Convert.ToString(textBox3.Text); }
           if (textBox3.Text.Trim() != String.Empty) { type = null; } else { type = Convert.ToString(textBox2.Text); }
           if (textBox3.Text.Trim() != String.Empty) { name = null; } else { name = Convert.ToString(textBox1.Text); }
           if (textBox3.Text.Trim() != String.Empty) { unit = null; } else { unit = Convert.ToString(textBox4.Text); }
           if (textBox3.Text.Trim() != String.Empty) { count = null; } else { count = Convert.ToString(textBox5.Text); }
            // 实例化商品类，并委托给代理者类添加到数据库
            DB_GOODS goods = new DB_GOODS(name, type, price, unit, count);
            proxy.setRealSubject(goods);
            proxy.recordUpdate(adapter,dataGridView1);
            proxy.recordSelect(adapter, dataGridView1);

        }
        /// <summary>
        /// 删除按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            // 实例化商品类，并委托给代理者类添加到数据库
            DB_GOODS goods = new DB_GOODS(name, type, price, unit, count);
            proxy.setRealSubject(goods);
            proxy.recordDelete(adapter,dataGridView1 );
            proxy.recordSelect(adapter, dataGridView1);
        }


    }

}
