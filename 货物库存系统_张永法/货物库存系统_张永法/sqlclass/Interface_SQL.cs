using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace 货物库存系统_张永法.sqlclass
{
    
    public  interface Interface_SQL
    {
        void recordInsert(MySqlConnection con);
        void recordDelete(MySqlConnection con, DataGridView dataGridView);
        void recordUpdate(MySqlConnection con, DataGridView dataGridView);
        void recordSelect(MySqlConnection con, DataGridView dataGridView);
    }

}
