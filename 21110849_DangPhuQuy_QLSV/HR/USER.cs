using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace _21110849_DangPhuQuy_QLSV
{
    internal class USER
    {
        MY_DB db = new MY_DB();
        
        public DataTable getUserById(Int32 userId)
        {
            SqlCommand cmd = new SqlCommand("select * from hr where id = @uid", db.getConnection);
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userId;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            return table;
        }

        public bool insertUser(int id, string fname, string lname, string userName, string passWord, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("insert into hr (id, f_name, l_name, uname, pwd, fig) values (@id, @fn, @ln, @un, @pass, @pic)", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = passWord;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false; 
            }
        }
        
        public bool insertPendingUser(int id, string fname, string lname, string userName, string passWord, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("insert into pendingHr (id, f_name, l_name, uname, pwd, fig) values (@id, @fn, @ln, @un, @pass, @pic)", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = userName;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = passWord;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false; 
            }
        }

        public bool usernameExist(string username, string operation, int userid = 0)
        {
            string query = "";
            if (operation == "register")
            {
                query = "select * from hr where uname = @un";
            }
            else if (operation == "edit")
            {
                query = "select * from hr where uname = @un and id <> @uid";
            }

            SqlCommand command = new SqlCommand(query, db.getConnection);

            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool pendingUsernameAndUserIdExist(string username, int userid = 0)
        {
            string query = "select * from pendingHr where uname = @un or id = @id";

            SqlCommand command = new SqlCommand(query, db.getConnection);

            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@id", SqlDbType.Int).Value = userid;

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool updaterUser(int userid, string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("update hr set f_name = @fn, l_name = @ln, uname = @un, pwd = @pass, fig = @pic where id = @uid", db.getConnection);
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            cmd.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool deleteHr(int userid)
        {
            SqlCommand cmd = new SqlCommand("delete from hr where id = @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = userid;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }
        public bool deletePendingHr(int userid)
        {
            SqlCommand cmd = new SqlCommand("delete from pendingHr where id = @id", db.getConnection);
            cmd.Parameters.Add("@id", SqlDbType.VarChar).Value = userid;

            db.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            else
            {
                db.closeConnection();
                return false;
            }
        }

        public bool UserIdExist(int userid)
        {
            DataTable table = new DataTable();
            table = getUserById(userid);
            if (table.Rows.Count > 0)
                return true;
            return false;
        }
    }
}
