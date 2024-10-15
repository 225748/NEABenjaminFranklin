
using System.Data.OleDb;
using System;

namespace NEABenjaminFranklin
{
    class clsDBConnector
    {
        OleDbConnection conn = new OleDbConnection();
        string dbProvider;
        string dbSource;
        string workingDirectory = Environment.CurrentDirectory;

        public void Connect()
        {
            dbProvider = "Provider=Microsoft.ACE.OLEDB.12.0;";
            dbSource = @"Data Source = " + workingDirectory + @"\NEADatabaseBenFranklin.accdb";
            conn.ConnectionString = dbProvider + dbSource;
            //conn.ConnectionString =  Properties.Settings.Default.dbStudentlatesConnectionString ;
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public void DoDML(string dmlString)
        {
            OleDbCommand cmd;
            cmd = new OleDbCommand(dmlString, conn);
            cmd.ExecuteNonQuery();
        }

        public OleDbDataReader DoSQL(string sqlString)
        {
            OleDbCommand cmd;
            cmd = new OleDbCommand(sqlString, conn);
            return cmd.ExecuteReader() ;
        }  
    }
}
