using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TW_Mission_Control
{
    class db
    {
        private SQLiteConnection sql_con;
        private SQLiteCommand sql_cmd;
        private SQLiteDataAdapter DB;
        private DataSet DS = new DataSet();
        private DataTable DT = new DataTable();

        // Create the connection with the DB
        private void SetConnection()
        {
            sql_con = new SQLiteConnection ("Data Source=data.db;Version=3;New=False;Compress=True;");
        }

        // Execute simple updates ( CREATE, INSERT, UPDATE, DELETE )
        private void ExecuteQuery(string txtQuery)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            sql_cmd.CommandText = txtQuery;
            sql_cmd.ExecuteNonQuery();
            sql_con.Close();
        }

        // Execute SELECT query's
        private DataTable LoadData(string[] data)
        {
            SetConnection();
            sql_con.Open();
            sql_cmd = sql_con.CreateCommand();
            string CommandText = "select id, desc from mains";
            DB = new SQLiteDataAdapter(CommandText, sql_con);
            DS.Reset();
            DB.Fill(DS);
            DT = DS.Tables[0];
            sql_con.Close();
            return DT;
        }

        // Prepare and execute INSERT query
        private void INSERT(string[] colloms, string[] values)
        {
            int collCount = 0;
            int vallCount = 0;

            string query = "INSERT INTO mains (";
            
            foreach (string coll in colloms)
            {
                if (collCount != 0)
                {
                    query += ", ";
                }
                query += coll;
                collCount++;
            }

            query += ") VALUES (";
            
            foreach (string vall in values)
            {
                if (vallCount != 0)
                {
                    query += ", ";
                }
                query += "'" + vall + "'";
                vallCount++;
            }
            query += ")";

            ExecuteQuery(query);
        }
    }
}
