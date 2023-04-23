using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21110849_DangPhuQuy_QLSV
{
    internal class SCORE
    {
        MY_DB mydb = new MY_DB();

        //thêm điểm
        public bool insertScore(int studentID, int courseID, float scoreValue, string descrip)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO score (student_id, course_id, student_score, description) " +
                "VALUES (@sid, @cid, @score, @des)", mydb.getConnection);
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentID;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = courseID;
            cmd.Parameters.Add("@score", SqlDbType.Float).Value = scoreValue;
            cmd.Parameters.Add("@des", SqlDbType.NVarChar).Value = descrip;

            mydb.openConnection();

            if (cmd.ExecuteNonQuery() == 1)
                return true;
            else
                return false;
        }

        //Ktra trùng
        public bool studentScoreExist(int studentId, int courseId)
        {
            SqlCommand cmd = new SqlCommand("select * " +
                "from score " +
                "where student_id = @sid and course_id = @cid", mydb.getConnection);
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = courseId;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();

            adapter.Fill(table);

            if (table.Rows.Count == 0)
                return false;
            else
                return true;
        }

        //tính trung bình
        public DataTable getAvgScoreCourse()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;

            cmd.CommandText = "select course.label, avg(score.student_score) as AverageScore " +
                "from course, score " +
                "where course.id = score.course_id " +
                "group by course.label ";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);

            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //delete score bằng student_id, và course_id
        public bool deleteScore(int studentId, int courseId)
        {
            SqlCommand cmd = new SqlCommand("delete from score where student_id = @sid and course_id = @cid", mydb.getConnection);
            
            cmd.Parameters.Add("@sid", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = courseId;

            mydb.openConnection();
            if (cmd.ExecuteNonQuery() == 1)
                return true;
            else
                return false;
        }

        //function to get student score
        public DataTable getStudentScore()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT std.Id, std.fname, std.lname, score.course_id, course.label, score.student_score " +
                "FROM std JOIN score ON std.Id = score.student_id " +
                "JOIN course ON score.course_id = course.id";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //function to get course score by scoreId
        public DataTable getCourseScore(int courseId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT std.Id, std.fname, std.lname, score.course_id, course.label, score.student_score " +
                "FROM std JOIN score ON std.Id = score.student_id " +
                "JOIN course ON score.course_id = course.id" +
                "WHERE course.id = " + courseId;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        
        public DataTable getCourseScore(string courseName)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT std.Id, std.fname, std.lname, std.bdate, score.student_score " +
                "FROM std JOIN score ON std.Id = score.student_id " +
                "JOIN course ON score.course_id = course.id " +
                "WHERE label = @courseName";
            cmd.Parameters.AddWithValue("@courseName", courseName);


            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        //function to get student score by scoreId
        public DataTable getStudentScore(int studentId)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT std.Id, std.fname, std.lname, score.course_id, course.label, score.student_score " +
                "FROM std JOIN score ON std.Id = score.student_id " +
                "JOIN course ON score.course_id = course.id" +
                "WHERE course.id = " + studentId;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getResultStudent()
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT std.Id, fname, lname, AVG(student_score)AS Average, " +
                "CASE WHEN AVG(student_score) >= 5 THEN 'Pass' ELSE 'fail' END AS pass " +
                "FROM dbo.std " +
                "JOIN dbo.score ON std.Id = score.student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                "GROUP BY std.Id, fname, lname";

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseStdList(string cname)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY std.Id) AS STT, std.Id, fname, lname, bdate " +
                "FROM std JOIN dbo.score ON std.Id = student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                "WHERE course.label = @cname ";
            cmd.Parameters.Add("@cname", SqlDbType.NVarChar).Value = cname;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
