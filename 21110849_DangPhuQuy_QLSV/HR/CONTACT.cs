using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110849_DangPhuQuy_QLSV
{
    internal class CONTACT
    {
        MY_DB mydb = new MY_DB();

        public bool insertContact(int userid, string fname, string lname, int groupid, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("insert into mycontact (userid, fname, lname, group_id, phone, email, address, pic) values (@id, @fn, @ln, @grp, @phone, @mail, @adrs, @pic)", mydb.getConnection);

            cmd.Parameters.Add("@id", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@grp", SqlDbType.Int).Value = groupid;
            cmd.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
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

        public bool updateContact(int userid, string fname, string lname, int groupid, string phone, string email, string address, MemoryStream picture)
        {
            SqlCommand cmd = new SqlCommand("update mycontact set fname = @fn, lname = @ln, group_id = @grp, phone = @phn, email = @mail, address = @add, pic = @pic where userid = @uid", mydb.getConnection);

            cmd.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            cmd.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            cmd.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            cmd.Parameters.Add("@grp", SqlDbType.Int).Value = groupid;
            cmd.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            cmd.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            cmd.Parameters.Add("@add", SqlDbType.VarChar).Value = address;
            cmd.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            mydb.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
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

        public bool deleteContact(int contactid)
        {
            SqlCommand command = new SqlCommand("delete from mycontact where id = @id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactid;

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

        public DataTable selectContactList(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getContactById(int contactid)
        {
            SqlCommand command = new SqlCommand("select fname, lname, group_id, phone, email, address, pic, userid from mycontact where userid = @id ", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
