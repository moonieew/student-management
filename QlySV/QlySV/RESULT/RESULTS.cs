using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlySV
{
    class RESULTS
    {
        MY_DB db = new MY_DB();

        public DataTable GetListCourse()
        {
            db.openConnection();
            SqlCommand command = new SqlCommand("SELECT Id, label FROM [Course]", db.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            db.closeConnection();
            return ds.Tables[0];
        }
        public DataTable GetListStudent(string keyword)
        {
            DataTable dt = new DataTable();
            DataTable allCourse = GetListCourse();
            // Luu ma mon hoc va ten mon hoc tuong ung
            // Dictionary<courseId, courseName>
            Dictionary<int, string> courseID = new Dictionary<int, string>();
            dt.Columns.Add("Student ID");
            dt.Columns.Add("First Name");
            dt.Columns.Add("Last Name");
            // Them cac cot la ten cac mon hoc
            foreach (DataRow item in allCourse.Rows)
            {
                dt.Columns.Add(item[1].ToString());
                courseID.Add(Convert.ToInt32(item[0]), item[1].ToString());
            }
            dt.Columns.Add("Average Score");
            dt.Columns.Add("Result");
            // Sau khi add ta co table
            // |------------|-----------|----------|-----------|-----------|-----|---------------|--------|
            // | Student ID | FirstName | LastName | Mon hoc 1 | Mon hoc 2 |[...]| Average Score | Result |
            // |            |           |          |           |           |     |               |        |

            // Tao cau truy van de them tung dong vao bang
            // Su dung GROUP BY de lay diem TB theo student_id
            // sau do JOIN ket qua voi bang Student de lay info nhu fname, lname
            db.openConnection();
            string query = "SELECT s.student_id, fname, lname, s.average FROM std INNER JOIN " +
                "(SELECT student_id, AVG(student_score) as average FROM Score GROUP BY student_id) as s " +
                "ON std.Id = s.student_id";
            if (keyword != "")
            {
                query = "SELECT s.student_id, fname, lname, s.average FROM std INNER JOIN " +
                "(SELECT student_id, AVG(student_score) as average FROM Score GROUP BY student_id) as s " +
                "ON std.Id = s.student_id WHERE s.student_id LIKE '%" + keyword + "%' OR fname LIKE '%" + keyword + "%'";
            }
            SqlCommand command = new SqlCommand(query, db.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            db.closeConnection();
            // Tao new row va them gia tri cho cac row
            foreach (DataRow student in ds.Tables[0].Rows)
            {
                DataRow dataRow = dt.NewRow();
                // Them student_id, firstName, lastName, diemTB
                dataRow["Student ID"] = student["student_id"];
                dataRow["First Name"] = student["fname"];
                dataRow["Last Name"] = student["lname"];
                dataRow["Average Score"] = student["average"];
                if (Convert.ToDouble(student["average"]) > 0)
                {
                    if (Convert.ToDouble(student["average"]) > 5)
                    {
                        if (Convert.ToDouble(student["average"]) > 8)
                        {
                            dataRow["Result"] = "gioi";
                        }
                        else
                            dataRow["Result"] = "kha";
                    }
                    else
                        dataRow["Result"] = "yeu";

                }
                // Them diem so theo tung mon hoc
                // Lay id mon hoc tren Dictionary
                foreach (var id in courseID)
                {
                    db.openConnection();
                    // query lay diem theo studentId va courseID
                    SqlCommand c = new SqlCommand("select student_score from Score where course_id=@cID and student_id=@sID", db.GetConnection);
                    c.Parameters.Add("@cID", SqlDbType.Int).Value = id.Key;
                    c.Parameters.Add("@sID", SqlDbType.Int).Value = student["student_id"];
                    SqlDataAdapter a = new SqlDataAdapter(c);
                    DataSet set = new DataSet();
                    a.Fill(set);

                    // check mon hoc co diem hay chua
                    if (set.Tables[0].Rows.Count > 0)
                    {
                        DataRow score = set.Tables[0].Rows[0];
                        // lay diem so gan cho cot mon hoc tuong ung
                        dataRow[id.Value] = score[0].ToString();
                    }

                    db.closeConnection();
                }
                // them row vao table
                dt.Rows.Add(dataRow);
            }
            return dt;
        }
        public DataTable getResult(string keyword)
        {
            DataTable dt = new DataTable();
            DataTable allCourse = GetListCourse();
            dt.Columns.Add("Student Fail (%)");
            dt.Columns.Add("Student Pass (%)");
            db.openConnection();
            string query = "SELECT s.average FROM std INNER JOIN " +
                "(SELECT student_id, AVG(student_score) as average FROM Score GROUP BY student_id) as s " +
                "ON std.Id = s.student_id";
            if (keyword != "")
            {
                query = "SELECT s.average FROM std INNER JOIN " +
                "(SELECT student_id, AVG(student_score) as average FROM Score GROUP BY student_id) as s " +
                "ON std.Id = s.student_id WHERE s.student_id LIKE '%" + keyword + "%' OR fname LIKE '%" + keyword + "%'";
            }
            SqlCommand command = new SqlCommand(query, db.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            db.closeConnection();
            int p = 0;
            int f = 0;
            foreach (DataRow student in ds.Tables[0].Rows)
            {
                if (Convert.ToDouble(student["average"]) < 5)
                    f++;
                else
                    p++;
            }
            DataRow dataRow = dt.NewRow();
            dataRow["Pass"] = (p * 100 / (p + f)).ToString();
            dataRow["Fail"] = (f * 100 / (p + f)).ToString();

            dt.Rows.Add(dataRow);
            return dt;
        }
    }
}
