using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Configuration;
using System.Xml;
using System.Collections;
using System.IO;

namespace QBLC
{
    public class clsDBWork
    {

        private OdbcCommand mCmdODBC;
        private OdbcConnection mConnODBC;
        private OdbcDataAdapter objODBCDataAdapter;
        private string msConnODBCText;

        public clsDBWork()
        {
            msConnODBCText = ConfigurationManager.AppSettings["quickbookDSN"];
        }

        private bool ODBCConnect()
        {
            try
            {
                mConnODBC = new OdbcConnection(msConnODBCText);
                mConnODBC.Open();
                return true;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message + '\n' + Ex.StackTrace);
                return false;
            }
        }

        private void ODBCDisconnect()
        {
            try
            {
                mConnODBC.Close();
            }
            catch
            {
            }
        }

        private OdbcDataReader ODBCExecuteReader(string psQuery)
        {
            try
            {
                mCmdODBC = new OdbcCommand(psQuery, mConnODBC);
                return mCmdODBC.ExecuteReader();
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message + '\n' + Ex.StackTrace);
                return null;
            }
            finally
            {
                mCmdODBC.Dispose();
            }
        }
        private DataTable ODBCDataTable(string pstrQuery)
        {
            DataTable dtTableName ;
            try
            {
                dtTableName = new DataTable();
                objODBCDataAdapter = new OdbcDataAdapter(pstrQuery, mConnODBC);
                objODBCDataAdapter.Fill(dtTableName);
                return dtTableName;
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message + '\n' + Ex.StackTrace);
                return null;
            }
            finally
            {
                //objODBCDataAdapter.Dispose();
            }
        }
        private void ODBCExecuteCmd(string psQuery)
        {
            try
            {
                mCmdODBC = new OdbcCommand();
                mCmdODBC.CommandType = CommandType.StoredProcedure;
                mCmdODBC.CommandText = psQuery;
                mCmdODBC.Connection = mConnODBC;
                mCmdODBC.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message + '\n' + Ex.StackTrace);
            }
            finally
            {
                mCmdODBC.Dispose();
            }
        }
        public DataTable GetQBData(string pstrTableName,string pstrColumnNames,string pstrCrieteria)
        {
            try
            {
                ODBCConnect();
                //ODBCExecuteCmd("sp_optimizefullsync " + pstrTableName);
                string strQuery = "SELECT " + pstrColumnNames + " FROM " + pstrTableName + " WHERE " + pstrCrieteria;
                return ODBCDataTable(strQuery);
            }
            catch (Exception Ex)
            {
                WriteLog(Ex.Message + '\n' + Ex.StackTrace);
                return null;
            }
            finally
            {
                ODBCDisconnect();
            }
        }
        private void WriteLog(string pstrLog)
        {
            string lstrDebugFileName = @"C:\ITW_Log.txt";
            StreamWriter loDebugWriter;
            if (!File.Exists(lstrDebugFileName))
            {
                loDebugWriter = new StreamWriter(new FileStream(lstrDebugFileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite));
            }
            else
            {
                loDebugWriter = new StreamWriter(new FileStream(lstrDebugFileName, FileMode.Append, FileAccess.Write, FileShare.ReadWrite));
            }
            loDebugWriter.WriteLine(pstrLog);
            loDebugWriter.Flush();
            loDebugWriter.Close();
        }

            }
}
