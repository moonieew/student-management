using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlySV
{
    class User
    {
        MY_DB db = new MY_DB();
        public DataTable getUserById(Int32 userid)
        {
            SqlDataAdapter adapter=new SqlDataAdapter();
            DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM [User] WHERE Id=@uid", db.GetConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
        public bool insertUser(string fname, string lname, string username, string password, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [User] (f_name, l_name, uname, pwd, fig) VALUES (@fn, @ln, @un, @pass, @pic)", db.GetConnection);
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@pass", SqlDbType.Char).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();

            // Open connection to db
            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }

        public bool usernameExist(string username, string operation, int userId = 0)
        {
            string query = String.Empty;

            if(operation == "register")
            {
                query = "SELECT * FROM [User] WHERE uname=@un";
            }
            else if(operation == "edit")
            {
                query = "SELECT * FROM [User] WHERE uname = @un AND id <> @uid";
            }

            SqlCommand command = new SqlCommand(query, db.GetConnection);
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);

            if(table.Rows.Count > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateUser(int userId, string fName, string lName, string userName, string password, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand(
                "UPDATE [User] SET " +
                "f_name=@fn " +
                "l_name=@ln " +
                "uname=@un " +
                "pwd=@pass " +
                "fig=@pic " +
                "WHERE id=@uid", db.GetConnection);
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fName;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lName;
            command.Parameters.Add("@un", SqlDbType.VarChar).Value = userName;
            command.Parameters.Add("@pass", SqlDbType.VarChar).Value = password;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;

            db.openConnection();

            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
    }
}
