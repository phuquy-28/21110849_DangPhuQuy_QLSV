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
    internal class COURSE
    {
        MY_DB mydb = new MY_DB();

        public bool insertCourse(int id, string courseName, int hoursNumber, string description, int semester)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, label, period, description, semester) Values (@id, @name, @hours, @des, @sem)", mydb.getConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", courseName);
            command.Parameters.AddWithValue("@hours", hoursNumber);
            command.Parameters.AddWithValue("@des", description);
            command.Parameters.AddWithValue("@sem", semester);

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }

            mydb.closeConnection();
        }
        public bool updateCourse(int id, string courseName, int hoursNumber, string description, int semester)
        {
            SqlCommand command = new SqlCommand("UPDATE Course SET label=@name, period=@hours, description=@des, semester = @sem WHERE id= " + id, mydb.getConnection);
            command.Parameters.AddWithValue("@id", id);
            command.Parameters.AddWithValue("@name", courseName);
            command.Parameters.AddWithValue("@hours", hoursNumber);
            command.Parameters.AddWithValue("@des", description);
            command.Parameters.AddWithValue("@sem", semester);

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }

            mydb.closeConnection();
        }
        public bool deleteCourse(int courseID)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id=@cid", mydb.getConnection);

            command.Parameters.AddWithValue("@cid", courseID);

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
            {
                return true;
            }
            else
            {
                return false;
            }

            mydb.closeConnection();
        }
        public DataTable getCourseBySem(int semester)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE semester = @sem", mydb.getConnection);
            command.Parameters.Add("sem", SqlDbType.Int).Value = semester;

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            System.Data.DataTable table = new System.Data.DataTable();

            adapter.Fill(table);

            return table;
        }

        public System.Data.DataTable getAllCourse()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.getConnection);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            System.Data.DataTable table = new System.Data.DataTable();

            adapter.Fill(table);

            return table;
        }
        public System.Data.DataTable getCourseById(int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE id = @cid", mydb.getConnection);

            command.Parameters.AddWithValue("@cid", courseID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            System.Data.DataTable table = new System.Data.DataTable();

            adapter.Fill(table);

            return table;
        }
        public bool checkCourseName(string courseName, int courseID = 0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE label=@cName And id <> @cID", mydb.getConnection);

            command.Parameters.AddWithValue("@cName", courseName);
            command.Parameters.AddWithValue("@cID", courseID);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            System.Data.DataTable table = new System.Data.DataTable();

            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public int totalCourse()
        {
            return getAllCourse().Rows.Count;
        }
    }
}
