using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace 货物库存系统_张永法.sqlclass
{    /// <summary>
     /// 代理模式Proxy类
     /// 意图：为其他对象提供一种代理以控制对这个对象的访问。

    ///主要解决：在直接访问对象时带来的问题，比如说：要访问的对象在远程的机器上。在面向对象系统中，有些对象由于某些原因（比如对象创建开销很大，或者某些操作需要安全控制，或者需要进程外的访问），直接访问会给使用者或者系统结构带来很多麻烦，我们可以在访问此对象时加上一个对此对象的访问层。

    ///何时使用：想在访问一个类时做一些控制。

    ///如何解决：增加中间层。

    ///关键代码：实现与被代理类组合。
    /////根据《设计模式之禅》，代理模式有3个角色：

    //Subject抽象主题角色   例如接口InterfaceSQL
    //RealSubject具体主题角色   例如商品，货架，等真实的类
    //Proxy代理主题角色       承担一个中介的角色
    /// </summary>
    class Proxy : Interface_SQL
    {
        //初始化
        private DB_GOODS realSubject = null;
        public DataGridView dataGridView = null;


        /// <summary>
        /// 构造代理者
        /// </summary>
        /// <param name="realSub">被代理的实体（被代理的是商品、仓库还是货架）</param>
        /// <param name="dataGridView">数据表控件</param>
        public Proxy(DB_GOODS realSub, DataGridView dataGridView)
        {
            realSubject = realSub;
            this.dataGridView = dataGridView;
        }
        /// <summary>
        /// 指定被代理者
        /// </summary>
        /// <param name="realSub">被代理的实体</param>
       internal void setRealSubject(DB_GOODS realSub)
       {
         realSubject = realSub;

       }

        /// <summary>
        /// 预处理
        /// </summary>
        private void Before(MySqlConnection con)
        {

            try { con.Open(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        /// <summary>
        /// 善后处理
        /// </summary>
        private void After(MySqlConnection con)
        {
            con.Close();
        }
        /// <summary>
        /// 增删改查
        /// </summary>
        /// <param name="con"></param>
        public void recordDelete(MySqlConnection con,DataGridView dataGridView)
        {
            Before(con);
            realSubject.recordDelete(con,dataGridView );
            After(con);
        }

        public void recordInsert(MySqlConnection con)
        {
            Before(con);
            realSubject.recordInsert(con);
            After(con);
        }
        
        public void recordSelect(MySqlConnection con, DataGridView dataGridView)
        {
            Before(con);
            realSubject.recordSelect(con, dataGridView);
            After(con);
        }

        public void recordUpdate(MySqlConnection con, DataGridView dataGridView)
        {
            Before(con);
            realSubject.recordUpdate(con,dataGridView);
            After(con);
        }
    }
}
