using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
//https://ask.csdn.net/questions/221714
namespace 货物库存系统_张永法.sqlclass
{
  public   class DB_GOODS : sqlclass.Init_SQL, sqlclass.Interface_SQL
    {
        /// <summary>
        /// 商品信息
        /// </summary>
        string name = "";
        string type = "";
        string price = "0";
        string unit = "";
        string count = "0";

      

        public DB_GOODS(string name, string type, string price, string unit, string  count)
        {
            this.name = name;
            this.type = type;
            this.price = price;
            this.unit = unit;
            this.count = count;
        }
            /// <summary>
            /// 删除
            /// </summary>
            /// <param name="con"></param>
            public void recordDelete(MySqlConnection con, DataGridView dataGridView)
            {   
                string delID = "";
                if (dataGridView.CurrentRow != null)
                {
                    delID = (dataGridView.CurrentRow.Cells[1].Value).ToString();//获取要删除的那一行
                   
                }
                else
                {
                    MessageBox.Show("删除失败");
                }

          
               try
               {
                     List<int> selectList = new List<int>();   //创建一个列表存储勾选行的id
                    for (int i = 0; i < dataGridView.Rows.Count; i++)  //遍历datagridview所有行，看第一列“选择”是否被勾选
                    {
                        if ((bool)dataGridView.Rows[i].Cells[0].EditedFormattedValue  == true) //DataGridViewCheckBoxColumn列判断是否选中
                        {
                            selectList.Add(Convert .ToInt32(dataGridView.Rows[i].Cells[1].Value)  );//把第二列“ID”存储到selectlist列表中
                        }
                    }
                    for (int j = 0; j < selectList.Count; j++)  //遍历selectlist列表中的元素，将数据添加为SQL语句
                {
                           MySqlCommand cmd = new MySqlCommand($"DELETE FROM  `goods` WHERE ID={selectList[j]}", con);  //sql删除选中行语句
                           MySqlDataReader dataReader = cmd.ExecuteReader();     
                           ((GoodsitemForm)dataGridView.Parent).setCmd(cmd);
                           dataReader.Close();  //***！！！重点：dataReader不能多次重复打开，使用完以后要及时关闭，否则会报错。！！！***
                }
              
               }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            /// <summary>
            /// 增添商品
            /// </summary>
            /// <param name="con"></param>
            public void recordInsert(MySqlConnection con)
            {
                MySqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "INSERT INTO `goods` (`name`, `type`, `price`, `unit`, `count`) VALUES(@name, @type, @price, @unit, @count)";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@type", type);
                cmd.Parameters.AddWithValue("@price", price);
                cmd.Parameters.AddWithValue("@unit", unit);
                cmd.Parameters.AddWithValue("@count", count);
                try { cmd.ExecuteNonQuery(); }
                catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
            }

            /// <summary>
            /// 查询
            /// </summary>
            /// <param name="con"></param>
            /// <param name="dataGridView"></param>
            public void recordSelect(MySqlConnection con, DataGridView dataGridView)
            {
                // 用MySqlDataAdapter的方法填充数据表
                try
                {
                    DataSet ds = new DataSet();
                    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT* FROM `goods`", con);
                    MySqlCommandBuilder cb = new MySqlCommandBuilder(adapter);
                    adapter.Fill(ds, "GOODS");
                    dataGridView.DataSource = ds;
                    dataGridView.DataMember = "GOODS";
                  //  ((GoodsitemForm)dataGridView.Parent).setAdapter(adapter);       
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
           /// <summary>
           /// 修改（更新）数据
           /// </summary>
           /// <param name="con"></param>
            public void recordUpdate(MySqlConnection con, DataGridView dataGridView)
            {
                string delID = "";
                if (dataGridView.CurrentRow != null)
                {
                    delID = (dataGridView.CurrentRow.Cells[1].Value).ToString();//获取要修改的那一行

                }
                else
                {
                    MessageBox.Show("修改失败，请选中要修改的数据行");
                }

                            try
                            {
                                MySqlCommand cmd = new MySqlCommand($"UPDATE  `goods` SET name={name} WHERE ID={delID}", con);
                                cmd.ExecuteNonQuery();
                            }
                            catch 
                            {      
                            }

                            try
                            {
                                MySqlCommand cmd = new MySqlCommand($"UPDATE  `goods` SET type='{type }'  WHERE ID={delID}", con);
                                cmd.ExecuteNonQuery();
                            }
                            catch
                            {
                            }
  
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand($"UPDATE  `goods` SET price='{price}' WHERE ID={delID}", con);
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }

                        try
                        {
                            MySqlCommand cmd = new MySqlCommand($"UPDATE  `goods` SET unit='{unit}' WHERE ID={delID}", con);
                           cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                        try
                        {
                            MySqlCommand cmd = new MySqlCommand($"UPDATE  `goods` SET count='{count}' WHERE ID={delID}", con);
                            cmd.ExecuteNonQuery();
                        }
                        catch
                        {
                        }
                       
          

        }
        }

}
