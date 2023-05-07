using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
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

        public DataTable getResultStudent(int semester)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "DECLARE @columns AS NVARCHAR(MAX), @sql AS NVARCHAR(MAX); " +
                "SET @columns = N''; " +
                "SELECT @columns += N', [' + label + ']' " +
                "FROM (SELECT DISTINCT label FROM dbo.course WHERE semester = @sem) AS CourseName; " +
                "SET @sql = N' " +
                "SELECT * " +
                "FROM ( " +
                "  SELECT std.Id, fname, lname, label, student_score " +
                "  FROM dbo.std " +
                "JOIN dbo.score ON std.Id = score.student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                ") AS SourceTable " +
                "PIVOT ( " +
                "  SUM(student_score) " +
                "  FOR label IN (' + STUFF(@columns, 1, 2, '') + ') " +
                ") AS PivotTable " +
                "'; " +
                "EXEC sp_executesql @sql;";
            cmd.Parameters.Add("sem", SqlDbType.Int).Value = semester;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            //
            table.Columns.Add(new DataColumn("Average Score", typeof(double)));
            table.Columns.Add(new DataColumn("Result", typeof(string)));
            double sum = 0; int count = 0;
            // Lặp qua tất cả các hàng trong DataTable
            foreach (DataRow row in table.Rows)
            {
                // Lặp qua tất cả các cột trong hàng hiện tại
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "Id") continue;
                    // Truy cập giá trị ô hiện tại bằng cách sử dụng index của hàng và cột
                    object cellValue = row[col];

                    // Kiểm tra xem giá trị của ô có phải là một số hay không bằng cách sử dụng phương thức TryParse của lớp số
                    if (double.TryParse(cellValue.ToString(), out double result))
                    {
                        // Nếu giá trị của ô là một số, thực hiện các xử lý khác với giá trị ô ở đây
                        // ...
                        sum += result;
                        count++;
                    }
                }
                if (count > 0)
                {
                    row["Average Score"] = Math.Round(sum / count, 2);
                    if (sum / count >= 5)
                        row["Result"] = "Pass";
                    else
                        row["Result"] = "Fail";
                    sum = 0; count = 0;
                }
            }
            //
            return table;
        }
        public DataTable getResultStudent(int semester, int studentId = -1, string fname = "")
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "DECLARE @columns AS NVARCHAR(MAX), @sql AS NVARCHAR(MAX); " +
                "SET @columns = N''; " +
                "SELECT @columns += N', [' + label + ']' " +
                "FROM (SELECT DISTINCT label FROM dbo.course WHERE semester = @sem) AS CourseName; " +
                "SET @sql = N' " +
                "SELECT * " +
                "FROM ( " +
                "  SELECT std.Id, fname, lname, label, student_score " +
                "  FROM dbo.std " +
                "JOIN dbo.score ON std.Id = score.student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                "WHERE std.fname = @fnameParam OR std.Id = @idParam " +
                ") AS SourceTable " +
                "PIVOT ( " +
                "  SUM(student_score) " +
                "  FOR label IN (' + STUFF(@columns, 1, 2, '') + ') " +
                ") AS PivotTable " +
                "'; " +
                "EXEC sp_executesql @sql, N'@idParam int, @fnameParam nvarchar(50)', @idParam = @id, @fnameParam = @fname;";
            cmd.Parameters.Add("sem", SqlDbType.Int).Value = semester;
            cmd.Parameters.Add("id", SqlDbType.Int).Value = studentId;
            cmd.Parameters.Add("fname", SqlDbType.NVarChar, 50).Value = fname;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);

            //
            table.Columns.Add(new DataColumn("Average Score", typeof(double)));
            table.Columns.Add(new DataColumn("Result", typeof(string)));
            double sum = 0; int count = 0;
            // Lặp qua tất cả các hàng trong DataTable
            foreach (DataRow row in table.Rows)
            {
                // Lặp qua tất cả các cột trong hàng hiện tại
                foreach (DataColumn col in table.Columns)
                {
                    if (col.ColumnName == "Id") continue;
                    // Truy cập giá trị ô hiện tại bằng cách sử dụng index của hàng và cột
                    object cellValue = row[col];

                    // Kiểm tra xem giá trị của ô có phải là một số hay không bằng cách sử dụng phương thức TryParse của lớp số
                    if (double.TryParse(cellValue.ToString(), out double result))
                    {
                        // Nếu giá trị của ô là một số, thực hiện các xử lý khác với giá trị ô ở đây
                        // ...
                        sum += result;
                        count++;
                    }
                }
                if (count > 0)
                {
                    row["Average Score"] = Math.Round(sum / count, 2);
                    if (sum / count >= 5)
                        row["Result"] = "Pass";
                    else
                        row["Result"] = "Fail";
                    sum = 0; count = 0;
                }
            }
            //
            return table;
        }
        

        public DataTable getStudentResultDetail(int id, int semester)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT course_id, label, student_score, " +
                "  CASE " +
                "    WHEN student_score >= 5 THEN 'Pass' " +
                "    ELSE 'Fail' " +
                "  END AS 'Kết quả' " +
                "FROM dbo.score " +
                "JOIN dbo.course ON dbo.score.course_id = dbo.course.id " +
                "JOIN dbo.std ON dbo.score.student_id = dbo.std.Id " +
                "WHERE dbo.std.Id = @id and semester = @sem";
            cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
            cmd.Parameters.Add("sem", SqlDbType.Int).Value = semester;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public DataTable getCourseStdList(int id)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = mydb.getConnection;
            cmd.CommandText = "SELECT ROW_NUMBER() OVER (ORDER BY std.Id) AS STT, std.Id, fname, lname, bdate " +
                "FROM std JOIN dbo.score ON std.Id = student_id " +
                "JOIN dbo.course ON course.id = score.course_id " +
                "WHERE course.id = @cid ";
            cmd.Parameters.Add("@cid", SqlDbType.Int).Value = id;

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public int getNumPass(int semester)
        {
            DataTable dt = getResultStudent(semester);
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

        public int getNumFail(int semester)
        {
            DataTable dt = getResultStudent(semester);
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
