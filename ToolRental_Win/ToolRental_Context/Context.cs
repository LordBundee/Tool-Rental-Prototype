using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRental_Controller
{
    public class Context
    {
        #region Variable Declarations 

        static SQL _sql = new SQL();

        #endregion

        #region Accessors 

        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            }
        }

        /// <summary>
        /// This Method
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(string tableName)
        {
            return _sql.GetDataTable(ConnectionString, tableName);
        }

        public static DataTable GetDataTable(string sqlQuery, string tableName)
        {
            return _sql.GetDataTable(ConnectionString, sqlQuery, tableName);
        }

        public static DataTable GetDataTable(string sqlQuery, string tableName, bool isReadOnly)
        {
            return _sql.GetDataTable(ConnectionString, sqlQuery, tableName, isReadOnly);
        }

        #endregion

        #region Mutators 

        public static void SaveDatabaseTable(DataTable datatable)
        {
            _sql.SaveDatabaseTable(ConnectionString, datatable);
        }

        public static int InsertParentTable(string tableName, string columnNames, string columnValues)
        {
            return _sql.InsertParentRecord(ConnectionString, tableName, columnNames, columnValues);
        }

        public static void DeleteRecord(string tableName, string PKName, string PKID)
        {
            _sql.DeleteRecord(ConnectionString, tableName, PKName, PKID);
        }

        public static void UpdateRecord(string tableName, string columnNamesAndValues, string criteria)
        {
            _sql.UpdateRecord(ConnectionString, tableName, columnNamesAndValues, criteria);
        }


        #endregion

    }


}
