using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QlySV
{
    class COURSES
    {
        MY_DB mydb = new MY_DB();
        public bool insertCourse(int id, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Course (id, label, period, description) VALUES (@cid, @name, @hours, @des)", mydb.GetConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@hours", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@des", SqlDbType.VarChar).Value = description;
            mydb.openConnection();
            try
            {
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
            catch (SqlException)
            {
                MessageBox.Show("ID already exists");
                return false;
            }

        }
        public bool updateCourse(int id, string courseName, int hoursNumber, string description)
        {
            SqlCommand command = new SqlCommand("UPDATE Course SET label=@name, period=@hours, description=@des WHERE Id=@cid", mydb.GetConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = id;
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@hours", SqlDbType.Int).Value = hoursNumber;
            command.Parameters.Add("@des", SqlDbType.VarChar).Value = description;
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
        public bool deleteCourse(int courseId)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Course WHERE id=@cid", mydb.GetConnection);
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseId;
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
        public DataTable getAllCourses()
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course", mydb.GetConnection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public DataTable getCourseById(int courseID)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE Id=@cid", mydb.GetConnection);
            command.Parameters.Add("@cid", SqlDbType.VarChar).Value = courseID;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
        public bool checkCourseName(string courseName, int courseId = 0)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM Course WHERE label=@name And id<>@cid", mydb.GetConnection);
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = courseName;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = courseId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count > 0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
