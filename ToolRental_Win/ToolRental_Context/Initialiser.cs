using DBConnection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolRental_Controller
{
    public class Initialiser
    {

        #region Variable Declarations 

        private static string _ConnectionString = string.Empty;
        static SQL _sql = new SQL();

        #endregion


        #region Mutators

        /// <summary>
        /// This  method creates a database on the specified SQL Server 
        /// </summary>
        public static void CreateDatabase()
        {
            _ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            //Call the SQL create database to build database in SQL Server -- Called in Program.cs Class
            _sql.CreateDatabase(_ConnectionString);

            CreateDatabaseTables();
            //SeedDatabaseTables();
        }

        public static void CreateDatabaseTables()
        {
            #region Database Table Templates

            //All schemas using SQL Query Language
            //Customer table schema
            string MemberSchema =   "MemberID int IDENTITY(1,1) PRIMARY KEY, " +
                                    "FirstName VARCHAR(70), " +
                                    "LastName VARCHAR(70), "+
                                    "PhoneNumber VARCHAR(20)";

            //Tool Table Schema
            string ToolSchema =     "ToolID int IDENTITY(1,1) PRIMARY KEY, " +
                                    "ToolType VARCHAR(70), " +
                                    "BrandID int NOT NULL, " +
                                    "StatusID int NOT NULL, " +                                
                                    "Comments VARCHAR(255)";

            //Workspace Table Schema
            string WorkspaceSchema =   "WorkspaceID int IDENTITY (1,1) PRIMARY KEY, " +
                                       "WorkspaceName VARCHAR(70)";

            //ToolBrands Table Schema
            string ToolBrandsSchema =   "BrandID int IDENTITY (1,1) PRIMARY KEY, " +
                                        "BrandName VARCHAR(70)";

            //Rental Table schema
            string RentalsSchema =  "RentalID int IDENTITY(1,1) PRIMARY KEY, " +
                                    "MemberID int NOT NULL, " +
                                    "WorkspaceID int NOT NULL, " +
                                    "ToolID int NOT NULL, " +
                                    "DateRented DATETIME NOT NULL, " +
                                    "DateReturned DATETIME NULL";

            string ToolStatusSchema = "StatusID int IDENTITY (1,1) PRIMARY KEY, " +
                                      "Status VARCHAR(50)";

            #endregion

            #region CreateDatabaseTables

            //Generate Members Table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "Members"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "Members", MemberSchema);
                SeedMembersTable();
            }

            //Generate Tools Table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "Tools"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "Tools", ToolSchema);
                SeedToolsTable();
            }

            //Generate Workspaces Table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "Workspaces"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "Workspaces", WorkspaceSchema);
                SeedWorkspacesTable();
            }

            //Generate ToolBrands Table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "Brands"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "Brands", ToolBrandsSchema);
                SeedBrandsTable();
            }

            //Generate Rentals Table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "Rentals"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "Rentals", RentalsSchema);
                SeedRentalsTable();
            }

            //Generate RentalItem table
            if (!_sql.IsDatabaseTableExists(_ConnectionString, "ToolStatusTypes"))
            {
                _sql.CreateDatabaseTable(_ConnectionString, "ToolStatusTypes", ToolStatusSchema);
                SeedToolStatusTable();
            }
            

            #endregion
        }

        /// <summary>
        /// This method will allow the alteration the schema of the specified tables
        /// </summary>
        public static void AlterDatabaseTables(string tableName, string tableSchema)
        {
            //To alter the database schema, call this method by
            //passing the table name and table schema you want to change
            //E.g if you want to add a new column in movie called Genre, 
            //do the following:
            //create schema for the new column
            //string newSchema = "ADD COLUMN Genre VARCHAR(20) NULL";
            //AlterDatabaseTables("Movie", newSchema);
            _sql.AlterDatabaseTable(_ConnectionString, tableName, tableSchema);
        }


        /// <summary>
        /// This method will run each of the sub-methods to seed each relevant table with dummy data
        /// </summary>
        private static void SeedDatabaseTables()
        {
            SeedMembersTable();
            SeedToolsTable();
            SeedWorkspacesTable();
            SeedBrandsTable();
            SeedRentalsTable();
            SeedToolStatusTable();
           
        }

        private static void SeedMembersTable()
        {
            //Create list of Members data
            List<String> Members = new List<string>
            {
                "1 , 'John', 'Smith', '0434256736'",
                "2, 'Mary', 'Parks', '0476489473' ",
                "3, 'John', 'Barry', '0452255223'",
                "4, 'Rebecca', 'Hagarty', '0423262900'",
                "5, 'Theodore', 'Jones', '0401671171'"
            };

            //ColumnNames must match the order of the test data
            string columnNames = "MemberID, FirstName, LastName, PhoneNumber ";

            //Push the data to the database
            foreach (var member in Members)
            {
                _sql.InsertRecord(_ConnectionString, "Members", columnNames, member);
            }
        }

        private static void SeedToolStatusTable()
        {
            List<String> ToolStatusTypes = new List<string>
                {
                    "1, 'Active'" ,
                    "2, 'OnRental'",
                    "3, 'Awaiting Repair'" ,
                    "4, 'On Repair'" ,
                    "5, 'Retired'"
                };

            string columnNames = "StatusID, Status";

            //Push the data to the database
            foreach (var statusItem in ToolStatusTypes)
            {
                _sql.InsertRecord(_ConnectionString, "ToolStatusTypes", columnNames, statusItem);
            }
        }

        private static void SeedToolsTable()
        {
            //Create list of Tools data
            List<String> Tools = new List<string>
            {
                "1,     'Hammer',           1,  1, ' '",
                "2,     'Screwdriver',      1,  2, 'Chipped handle' ",
                "3,     'Hammer Drill',     2,  5, 'Damaged power cord'",
                "4,     'Angle Grinder',    2,  2, 'Slight scuffing on handle'",
                "5,     'Socket Set',       3,  2, 'Slightly dented case'",
                "6,     'Hacksaw',          6,  1,  ' '",
                "7,     'Mouse Sander',     4,  1,  ' '",
                "8,     'Vernier Caliper',  3,  1,  'PLUS protective case'",
                "9,     'Torque Wrench',    3,  1,  ' '",
                "10,    'Cordless Drill',   5,  1,  ' '",
                "11,    'Angle Grinder',    7,  1,  ' '",
                "12,    'Orbital Sander',   7,  1,  ' '",
                "13,    'Soldering Iron',   3,  1,  ' '",
                "14,    'Shifting Spanner', 1,  1,  ' '",
                "15,    'Router',           8,  1,  ' '",
                "16,    'Mouse Sander',     4,  1,  ' '",
                "17,    'Mallet',           6,  1,  ' '",
                "18,    'Hammer',           1,  1,  ' '",
                "19,    'Screwdriver',      6,  1,  ' '",
                "20,    'Jigsaw',           8,  1,  ' '"
            };

            //ColumnNames must match the order of the test data
            string columnNames = "ToolID, ToolType, BrandID, StatusID, Comments";

            //Push the data to the database
            foreach (var tool in Tools)
            {
                _sql.InsertRecord(_ConnectionString, "Tools", columnNames, tool);
            }
        }

        private static void SeedWorkspacesTable()
        {
            //Create list of Workspaces data
            List<String> Workspaces = new List<string>
            {
                "1 , 'ToolRoom'",
                "2, 'LowerWorkshop1'",
                "3, 'LowerWorkShop2'",
                "4, 'UpstairsWorkshop1'",
                "5, 'UpstairsWorkshop2'",
                "6, 'MachineRoom'"
            };

            //ColumnNames must match the order of the test data
            string columnNames = "WorkspaceID, WorkspaceName ";

            //Push the data to the database
            foreach (var workspace in Workspaces)
            {
                _sql.InsertRecord(_ConnectionString, "Workspaces", columnNames, workspace);
            }
        }

        private static void SeedBrandsTable()
        {
            //Create list of Brands data
            List<String> Brands = new List<string>
            {
                "1, 'Stanley'",
                "2, 'Makita' ",
                "3, 'Repco'",
                "4, 'Black & Decker'",
                "5, 'Bosch'",
                "6, 'Other/Generic'",
                "7, 'Hitachi'",
                "8, 'AEG'"
            };

            //ColumnNames must match the order of the test data
            string columnNames = "BrandID, BrandName";

            //Push the data to the database
            foreach (var brand in Brands)
            {
                _sql.InsertRecord(_ConnectionString, "Brands", columnNames, brand);
            }
        }

        private static void SeedRentalsTable()
        {
            //Create list of Rentals data
            List<String> Rentals = new List<string>
            {
                "1, 1, 2, 1, '2019/01/12', '2019/02/01' ",
                "2, 1, 2, 3, '2019/01/12', '2019/03/23' ",
                "3, 2, 4, 2, '2019/02/19', '2019/05/05' ",
                "4, 3, 3, 1, '2019/07/30', '2019/08/10' ",
                "5, 3, 3, 4, '2019/07/30', '2019/08/12' ",
                "6, 3, 3, 5, '2019/07/30',  NULL ",
                "7, 5, 2, 1, '2019/08/15', '2019/08/18' ",
                "8, 5, 2, 4, '2019/08/15', '2019/08/23' ",
                "9, 4, 1, 2, '2019/08/17',  NULL ",
                "10, 1, 2, 4, '2019/09/01', NULL "
            };

            //ColumnNames must match the order of the test data
            string columnNames = "RentalID, MemberID, WorkspaceID, ToolID, DateRented, DateReturned";

            //Push the data to the database
            foreach (var rental in Rentals)
            {
                _sql.InsertRecord(_ConnectionString, "Rentals", columnNames, rental);
            }
        }

        #endregion

    }
}
