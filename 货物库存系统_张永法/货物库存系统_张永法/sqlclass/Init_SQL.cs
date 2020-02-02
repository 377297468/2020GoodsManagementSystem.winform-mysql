using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 货物库存系统_张永法.sqlclass
{
    public  class Init_SQL 
    {//初始化变量
        public static string conStr = "server=127.0.0.1;port=3306;user=root;password=admin; database=world;CharSet=utf8;MultipleActiveResultSets=True";//password 输入你所建立数据库的密码
        public static string name = "Name";

        /// <summary>
        /// 连接数据库函数
        /// </summary>
        public  void Mysql_connet()
        {
            MySqlConnection con = new MySqlConnection(conStr);
            try
            {
                con.Open();//建立连接，可能出现异常,使用try catch语句
                MessageBox.Show("恭喜，已经建立连接！");
            }
            catch (MySqlException exe)
            {
                MessageBox.Show(exe.Message);//有错则报出错误
            }
            finally
            {
                con.Close();//关闭通道
            }

        }
    }
}
