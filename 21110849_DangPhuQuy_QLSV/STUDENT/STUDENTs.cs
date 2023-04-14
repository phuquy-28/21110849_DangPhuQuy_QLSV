using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace _21110849_DangPhuQuy_QLSV
{
    class STUDENTs
    {
        public string Id { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public MemoryStream Picture { get; set; }
        public string Email { get; set; }
        public string Faculty { get; set; }
        public string Major { get; set; }
        public string Pob { get; set; }
        public string Nationality { get; set; }
        public string State { get; set; }
        MY_DB mydb = new MY_DB();

        //function to insert a new student
        public bool insertStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture,
            string email, string faculty, string major, string pob, string nationality, string state)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, gender, phone, address, picture, email, faculty, major, pob, nationality, state)" +
                " VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic, @email, @fac, @maj, @pob, @nation, @state)", mydb.getConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@fac", SqlDbType.NVarChar).Value = faculty;
            command.Parameters.Add("@maj", SqlDbType.NVarChar).Value = major;
            command.Parameters.Add("@pob", SqlDbType.NVarChar).Value = pob;
            command.Parameters.Add("@nation", SqlDbType.NVarChar).Value = nationality;
            command.Parameters.Add("@state", SqlDbType.NVarChar).Value = state;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
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

        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture,
            string email, string faculty, string major, string pob, string nationality, string state)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn, lname=@ln, bdate=@bdt, gender=@gdr, phone=@phn, address=@adrs, picture=@pic, " +
                "email=@email, faculty=@fac, major=@maj, pob=@pob, nationality=@nation, state=@state WHERE Id=@id", mydb.getConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.NVarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.NVarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.Date).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.NVarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.NChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.NVarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@email", SqlDbType.NVarChar).Value = email;
            command.Parameters.Add("@fac", SqlDbType.NVarChar).Value = faculty;
            command.Parameters.Add("@maj", SqlDbType.NVarChar).Value = major;
            command.Parameters.Add("@pob", SqlDbType.NVarChar).Value = pob;
            command.Parameters.Add("@nation", SqlDbType.NVarChar).Value = nationality;
            command.Parameters.Add("@state", SqlDbType.NVarChar).Value = state;

            mydb.openConnection();

            if ((command.ExecuteNonQuery() == 1))
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

        public DataTable getStudents(SqlCommand command)
        {
            command.Connection = mydb.getConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            for (int i = 7; i < table.Columns.Count - 1; i++)
            {
                table.Columns[i].SetOrdinal(i + 1);
            }
            return table;
        }

        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE Id =" + id, mydb.getConnection);
            //command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
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

        string exeCount(string query)
        {
            SqlCommand command = new SqlCommand(query, mydb.getConnection);
            mydb.openConnection();
            string count = command.ExecuteScalar().ToString();
            mydb.closeConnection();
            return count;
        }
        public string totalStudent()
        {
            return exeCount("select count(*) from std");
        }
        public string totalFamale()
        {
            return exeCount("select count(*) from std where gender = 'female'");
        }
        public string totalMale()
        {
            return exeCount("select count(*) from std where gender = 'male'");
        }
    }
}
