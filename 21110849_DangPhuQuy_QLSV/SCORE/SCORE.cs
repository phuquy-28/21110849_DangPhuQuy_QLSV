using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

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

            cmd.CommandText = "select course.label, ROUND(avg(score.student_score), 2) as AverageScore " +
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
            cmd.CommandText = "SELECT PivotTable.Id AS Id, PivotTable.fname AS [First name], PivotTable.lname AS [Last name], [Nhap mon lap trinh], [Toan roi rac], [Ky thuat lap trinh], [Co so du lieu], [Mang may tinh can ban] AS [Mang may tinh], " +
                "(ISNULL([Nhap mon lap trinh], 0) + ISNULL([Toan roi rac], 0) + ISNULL([Ky thuat lap trinh], 0) + ISNULL([Co so du lieu], 0) + ISNULL([Mang may tinh can ban], 0))/NULLIF(CAST((CASE WHEN [Nhap mon lap trinh] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Toan roi rac] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Ky thuat lap trinh] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Co so du lieu] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Mang may tinh can ban] IS NOT NULL THEN 1 ELSE 0 END) AS FLOAT), 0) AS [Average Score], " +
                "      CASE WHEN (ISNULL([Nhap mon lap trinh], 0) + ISNULL([Toan roi rac], 0) + ISNULL([Ky thuat lap trinh], 0) + ISNULL([Co so du lieu], 0) + ISNULL([Mang may tinh can ban], 0))/NULLIF(CAST((CASE WHEN [Nhap mon lap trinh] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Toan roi rac] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Ky thuat lap trinh] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Co so du lieu] IS NOT NULL THEN 1 ELSE 0 END + CASE WHEN [Mang may tinh can ban] IS NOT NULL THEN 1 ELSE 0 END) AS FLOAT), 0) >= 5 THEN 'Pass' ELSE 'Fail' END AS [Result] " +
                "FROM ( " +
                " SELECT std.Id, fname, lname, label, student_score " +
                " FROM dbo.std " +
                "JOIN dbo.score ON std.Id = score.student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                ") AS SourceTable " +
                "PIVOT ( " +
                "  MAX(student_score) " +
                "  FOR label IN ([Nhap mon lap trinh], [Toan roi rac], [Ky thuat lap trinh], [Co so du lieu], [Mang may tinh can ban]) " +
                ") AS PivotTable";

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

        public int getNumPass()
        {
            DataTable dt = getResultStudent();
            int passCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Result"].ToString().ToLower() == "pass")
                {
                    passCount++;
                }
            }
            return passCount;
        }

        public int getNumFail()
        {
            DataTable dt = getResultStudent();
            int failCount = 0;

            foreach (DataRow row in dt.Rows)
            {
                if (row["Result"].ToString().ToLower() == "fail")
                {
                    failCount++;
                }
            }
            return failCount;
        }
    }
}
