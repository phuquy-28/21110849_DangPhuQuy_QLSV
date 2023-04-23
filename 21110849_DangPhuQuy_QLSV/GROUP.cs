using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110849_DangPhuQuy_QLSV
{
    internal class GROUP
    {
        MY_DB mydb = new MY_DB();
        public bool insertGroup(int id, string namegrp, int userid)
        {
            SqlCommand command = new SqlCommand("insert into mygroups (id, name, userid) values (@id, @name, @userid)", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.NChar).Value = namegrp;
            command.Parameters.Add("@userid", SqlDbType.Int).Value = userid;

            mydb.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }

        public bool updateGroup (int id, string namegrp)
        {
            SqlCommand command = new SqlCommand("update mygroups set name = @new where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@new", SqlDbType.NChar).Value = namegrp;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }

        }

        public bool deleteGroup(int id)
        {
            SqlCommand command = new SqlCommand("delete from mygroups where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;

            mydb.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                mydb.closeConnection();
                return true;
            }
            else
            {
                mydb.closeConnection();
                return false;
            }
        }

        public DataTable selectGroupList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
