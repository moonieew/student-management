using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Web.UI.MobileControls;
using System.IO;
using System.Data.Common;

namespace QlySV
{
    class STUDENT
    {
        MY_DB mydb = new MY_DB();
        //SqlDataAdapter adapter = new SqlDataAdapter();
        //DataTable table = new DataTable();
        public bool insertStudent(int Id, string fname, string lname, DateTime bdate,string gender,string phone,string address, System.IO.MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO std (id, fname, lname, bdate, gender, phone, address, picture)" + "VALUES (@id, @fn, @ln, @bdt, @gdr, @phn, @adrs, @pic)", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = Id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            mydb.openConnection();
            if ((command.ExecuteNonQuery()==1))
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

        public bool deleteStudent(int id)
        {
            SqlCommand command = new SqlCommand("DELETE FROM std WHERE id=@id",mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
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
        public int totalStudent()
        {
            SqlCommand command = new SqlCommand("SELECT count(id) as total FROM std", mydb.GetConnection);
           
            mydb.openConnection();
            int tong = 0;
            using (DbDataReader reader=command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tong = Convert.ToInt32(reader.GetValue(0));
                        return tong;
                    }
                    mydb.closeConnection();
                }
                else
                {
                    mydb.closeConnection();
                    return 0;
                }
            }
            return tong;
            
        }
        public int totalMaleStudent()
        {
            SqlCommand command = new SqlCommand("SELECT count(id) as total FROM std WHERE gender='Male'", mydb.GetConnection);
           
            mydb.openConnection();
            int tong = 0;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tong = Convert.ToInt32(reader.GetValue(0));
                        return tong;
                    }
                    mydb.closeConnection();
                }
                else
                {
                    mydb.closeConnection();
                    return 0;
                }
            }
            return tong;

        }
        public int totalFemaleStudent()
        {
            SqlCommand command = new SqlCommand("SELECT count(id) as total FROM std WHERE gender='Female'", mydb.GetConnection);
           
            mydb.openConnection();
            int tong = 0;
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        tong = Convert.ToInt32(reader.GetValue(0));
                        return tong;
                    }
                    mydb.closeConnection();
                }
                else
                {
                    mydb.closeConnection();
                    return 0;
                }
            }
            return tong;

        }
        public bool updateStudent(int id, string fname, string lname, DateTime bdate, string gender, string phone, string address, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE std SET fname=@fn,lname=@ln,bdate=@bdt,gender=@gdr,phone=@phn,ad" + "dress=@adrs,picture=@pic WHERE id=@ID", mydb.GetConnection);
            command.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("bdt", SqlDbType.DateTime).Value = bdate;
            command.Parameters.Add("@gdr", SqlDbType.VarChar).Value = gender;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
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
            command.Connection = mydb.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
