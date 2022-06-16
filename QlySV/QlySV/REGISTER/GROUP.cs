using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlySV
{
    class GROUP
    {
        MY_DB mydb = new MY_DB();
        public bool insertGroup( string gname, int userid)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Group] ( Name, Userid)" +
                "VALUES ( @gn, @uid)", mydb.GetConnection);

            //command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.Parameters.Add("@gn", SqlDbType.VarChar).Value = gname;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;

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
        public bool updateGroup(int gid, string gname)
        {
            SqlCommand command = new SqlCommand("UPDATE [Group] SET Name=@name WHERE Id=@id", mydb.GetConnection);

            command.Parameters.Add("@name", SqlDbType.VarChar).Value = gname;
            command.Parameters.Add("@id", SqlDbType.Int).Value = gid;
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
        public bool deleteGroup(int groupid)
        {
            SqlCommand command = new SqlCommand("DELETE FROM [Group] WHERE Id=@id", mydb.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = groupid;

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

        public DataTable getGroups(int userid)
        {
            SqlCommand command = new SqlCommand("SELECT * FROM [Group] WHERE UserId=@uid", mydb.GetConnection);
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            //DataSet ds = new DataSet();
            adapter.Fill(table);
            return table;
        }
        public bool GroupExit(string name, string operation, int userid = 0, int groupid = 0)
        {
            string query = "";
            SqlCommand command = new SqlCommand();
            if (operation == "add")
            {
                query = "SELECT * FROM [Group] WHERE Name = @name OR Userid = @uid ";    
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
            }
            else if (operation == "edit")
            {
                query = "SELECT * FROM [Group] WHERE Name = @name AND Userid = @uid "; //AND Id <>@gid";
                command.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
                command.Parameters.Add("@uid", SqlDbType.Int).Value = userid;
                command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            }
            command.Connection = mydb.GetConnection;
            command.CommandText = query;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            //adapter.SelectCommand = command;
            adapter.Fill(table);
            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
