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
    public class Contact
    {
        MY_DB db = new MY_DB();

        // Insert contact
        public bool InsertContact(string fname, string lname, string phone, string address, string email, int userId, int groupId, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("INSERT INTO [Contact] (fname, lname, groupid, phone, email, address, pic, userid) VALUES (@fn, @ln,@grp,@phn,@mail,@adrs,@pic, @uid)", db.GetConnection);
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@grp", SqlDbType.Int).Value = groupId;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@uid", SqlDbType.Int).Value = userId;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            db.openConnection();
            if (command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        // Update contact
        public bool UpdateContact(int contactId, string fname, string lname, string phone, string address, string email, int groupid, MemoryStream picture)
        {
            SqlCommand command = new SqlCommand("UPDATE [Contact] SET  fname = @fn, lname = @ln, groupid = @gid, phone = @phn, email = @mail, address = @adrs, pic=@pic WHERE Id=@id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            command.Parameters.Add("@fn", SqlDbType.VarChar).Value = fname;
            command.Parameters.Add("@ln", SqlDbType.VarChar).Value = lname;
            command.Parameters.Add("@gid", SqlDbType.Int).Value = groupid;
            command.Parameters.Add("@phn", SqlDbType.VarChar).Value = phone;
            command.Parameters.Add("@mail", SqlDbType.VarChar).Value = email;
            command.Parameters.Add("@adrs", SqlDbType.VarChar).Value = address;
            command.Parameters.Add("@pic", SqlDbType.Image).Value = picture.ToArray();
            db.openConnection();
            if(command.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }
        // Delete contact by id
        public bool DeleteContact(int contactId)
        {
            SqlCommand c = new SqlCommand("DELETE FROM [Contact] WHERE Id=@id", db.GetConnection);
            c.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            db.openConnection();
            if(c.ExecuteNonQuery() == 1)
            {
                db.closeConnection();
                return true;
            }
            db.closeConnection();
            return false;
        }

        // Get all contacts
        public DataTable SelectContactList(SqlCommand command)
        {
            //command = new SqlCommand("SELECT * FROM [Contact]", db.GetConnection);
            command.Connection = db.GetConnection;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            //DataSet ds = new DataSet();
            adapter.Fill(table);
            return table;
        }
        // Get contact by ID
        public DataTable GetContactById(int contactId)
        {
            SqlCommand command = new SqlCommand("SELECT Id, fname, lname, groupid, phone, email, address, pic, userid FROM [Contact] WHERE Id=@id", db.GetConnection);
            command.Parameters.Add("@id", SqlDbType.Int).Value = contactId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            //DataSet ds = new DataSet();
            adapter.Fill(table);
            return table;
        }
        public bool checkID(int contactId)
        {
            SqlCommand command = new SqlCommand("SELECT Id FROM [User] WHERE Id=@id", db.GetConnection);
            command.Parameters.Add("@Id", SqlDbType.Int).Value = contactId;
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable table = new DataTable();
            adapter.Fill(table);
            if ((table.Rows.Count > 0))
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
