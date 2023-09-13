using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;

namespace Utte.Code
{

    /// <summary>
    /// Produces database support code for datasets
    /// </summary>
    public class DataBaseSupport : CodeGeneratorBase
    {

        #region Private/protected members

        protected DataSet _dataset;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes with a DataSet
        /// </summary>
        /// <param name="dataset"></param>
        public DataBaseSupport(DataSet dataset)
        {
            _dataset = dataset;
        }

        #endregion

        #region Public methods

        /// <summary>
        /// Produces code for creating stored procedures
        /// </summary>
        /// <param name="filename"></param>
        public void ProduceStoredProcedures(string filename)
        {
            _streamwriter = new StreamWriter(filename);
            _indentspaces = 0;
            foreach (DataTable table in _dataset.Tables)
            {
                WriteSelectStoredProcedure(table);
                WriteInsertStoredProcedure(table);
                WriteUpdateStoredProcedure(table);
                WriteDeleteStoredProcedure(table);
            }
        }

        /// <summary>
        /// Produces code for dataset
        /// </summary>
        /// <param name="filename"></param>
        public void ProduceDataSetCode(string filename)
        {
            List<TableAdapter> tableadapters = SetTableAdapters();
            _streamwriter = new StreamWriter(filename);
            _indentspaces = 0;
            WriteLine("using System;",true);
            WriteLine("using System.Collections.Generic;",true);
            WriteLine("using System.Data;",true);
            WriteLine("using System.Data.SqlClient;",true);
            WriteLine("using Utte.Controls;",true);
            WriteLine("using Utte.Controls.Input;", true);
            WriteLine("");
            WriteLine("namespace Utte", true);
            WriteLine("{", true);
            _indentspaces += 4;
            WriteLine("");
            ProduceDescription("Class for managing ...");
            Write("partial class ", true);
            WriteLine(_dataset.DataSetName);
            WriteLine("{", true);
            _indentspaces += 4;
            ProduceAdapterParameters(tableadapters);
            WriteLine("#region Public methods", true);
            WriteLine("");
            ProduceInitializeMethod(tableadapters);
            WriteLine("#region Update methods", true);
            WriteLine("");
            ProduceUpdateMethod(tableadapters);
            AddDialogBoxesSupport(tableadapters);
            WriteLine("#endregion", true);
            WriteLine("");
            WriteLine("#endregion", true);
            WriteLine("");
            _indentspaces -= 4;
            WriteLine("}", true);
            _indentspaces -= 4;
            WriteLine("}", true);
        }

        #endregion

        #region Private/protected methods

        #region DataSet update methods

        /// <summary>
        /// Adds code for showing dialog boxes for dataset update
        /// </summary>
        /// <param name="list"></param>
        protected void AddDialogBoxesSupport(List<TableAdapter> list)
        {
            foreach (TableAdapter ta in list)
            {
                string description = "Shows dialog for adding a new " + ta.DataTable.TableName.ToLower();
                ProduceDescription(description);
                Write("public void Add", true);
                Write(ta.DataTable.TableName);
                WriteLine("()");
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("DataTableRowAdd addform = new DataTableRowAdd();", true);
                WriteLine("Dictionary<string, NameAttribute> attributemap = new Dictionary<string, NameAttribute>();", true);
                WriteLine("Dictionary<string,string> parentmap=new Dictionary<string,string>();", true);
                WriteLine("Dictionary<string,object> defaultvaluemap=new Dictionary<string,object>();", true);
                WriteLine("Dictionary<string,object> givenvaluemap=new Dictionary<string,object>();", true);
                foreach (DataColumn datacolumn in ta.DataTable.Columns)
                    if (datacolumn.Unique)
                    {
                        Write("givenvaluemap.Add(\"", true);
                        Write(datacolumn.ColumnName);
                        WriteLine("\", -1);");
                    }
                    else
                    {
                        Write("attributemap.Add(\"", true);
                        Write(datacolumn.ColumnName);
                        Write("\", new NameAttribute(\"");
                        Write(datacolumn.ColumnName);
                        WriteLine("\"));");
                    }
                Write("addform.InitializeForm(\"Add ", true);
                Write(ta.DataTable.TableName.ToLower());
                Write("\", this.");
                Write(ta.DataTable.TableName);
                WriteLine(", attributemap, defaultvaluemap, givenvaluemap, parentmap);");
                WriteLine("addform.ShowDialog();", true);
                WriteLine("addform.Dispose();", true);
                WriteLine("UpdateDataSet();", true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("", true);

                description = "Shows dialog for updating an existing " + ta.DataTable.TableName.ToLower();
                ProduceDescription(description);
                Write("public void Update", true);
                Write(ta.DataTable.TableName);
                WriteLine("()");
                WriteLine("{", true);
                _indentspaces += 4;
                WriteLine("DataTableRowUpdate updateform = new DataTableRowUpdate();", true);
                WriteLine("List<string> searchcolumns = new List<string>();", true);
                WriteLine("Dictionary<string, NameAttribute> attributemap = new Dictionary<string, NameAttribute>();", true);
                WriteLine("Dictionary<string,string> parentmap=new Dictionary<string,string>();", true);
                WriteLine("Dictionary<string,object> defaultvaluemap=new Dictionary<string,object>();", true);
                WriteLine("Dictionary<string,object> givenvaluemap=new Dictionary<string,object>();", true);
                foreach (DataColumn datacolumn in ta.DataTable.Columns)
                {
                    Write("attributemap.Add(\"", true);
                    Write(datacolumn.ColumnName);
                    Write("\", new NameAttribute(\"");
                    Write(datacolumn.ColumnName);
                    WriteLine("\"));");
                }
                Write("updateform.InitializeForm(\"Update ", true);
                Write(ta.DataTable.TableName.ToLower());
                Write("\", this.");
                Write(ta.DataTable.TableName);
                WriteLine(",searchcolumns, attributemap, defaultvaluemap, givenvaluemap, parentmap, true, true);");
                WriteLine("updateform.ShowDialog();", true);
                WriteLine("updateform.Dispose();", true);
                WriteLine("UpdateDataSet();", true);
                _indentspaces -= 4;
                WriteLine("}", true);
                WriteLine("", true);
            }
        }

        /// <summary>
        /// Adds code for updating dataset to database
        /// </summary>
        /// <param name="list"></param>
        protected void ProduceUpdateMethod(List<TableAdapter> list)
        {
            ProduceDescription("Updates the database with DataAdapters");
            WriteLine("public void UpdateDataSet()", true);
            WriteLine("{", true);
            _indentspaces += 4;
            foreach (TableAdapter ta in list)
            {
                Write(ta.AdapterName, true);
                Write(".Update(this,\"");
                Write(ta.DataTable.TableName);
                WriteLine("\");");
            }
            _indentspaces -= 4;
            WriteLine("}", true);
            WriteLine("");
        }

        /// <summary>
        /// Adds code for initializing the dataadapters for the dataset
        /// </summary>
        /// <param name="list"></param>
        protected void ProduceInitializeMethod(List<TableAdapter> list)
        {
            WriteLine("#region Initialize method", true);
            WriteLine("", true);
            ProduceDescription("Initializes dataadapters within the dataset");
            WriteLine("public void Initialize()", true);
            WriteLine("{", true);
            _indentspaces += 4;
            WriteLine("SqlCommand command;", true);
            foreach (TableAdapter ta in list)
            {
                Write(ta.AdapterName, true);
                WriteLine("=new SqlDataAdapter();");
                WriteLine("");

                try
                {
                    InitialCommandData("Select", ta);
                    Write(ta.AdapterName, true);
                    Write(".Fill(this, \"");
                    Write(ta.DataTable.TableName);
                    WriteLine("\");");
                }
                catch
                {
                }
                WriteLine("");

                try
                {
                    InitialCommandData("Insert", ta);
                    for (int i = 0; i < ta.DataTable.Columns.Count; i++)
                    {
                        DataColumn datacolumn = ta.DataTable.Columns[i];
                        if (datacolumn.Unique)
                        {
                            Write("command.Parameters.Add(new SqlParameter(\"@", true);
                            Write(datacolumn.ColumnName);
                            Write("\", SqlDbType.Int, 0, ParameterDirection.Output, false, 0, 0, \"");
                            Write(datacolumn.ColumnName);
                            WriteLine("\",DataRowVersion.Default,null));");
                        }
                        else
                            AddParameter(datacolumn);
                    }
                    WriteLine("command.UpdatedRowSource = UpdateRowSource.OutputParameters;", true);
                }
                catch
                {
                }
                WriteLine("");

                try
                {
                    InitialCommandData("Update", ta);
                    for (int i = 0; i < ta.DataTable.Columns.Count; i++)
                        AddParameter(ta.DataTable.Columns[i]);
                    WriteLine("");

                    InitialCommandData("Delete", ta);
                    DataColumn idcolumn = null;
                    foreach (DataColumn dc in ta.DataTable.Columns)
                        if (dc.Unique)
                            idcolumn = dc;
                    AddParameter(idcolumn);
                }
                catch
                {
                }
                WriteLine("");
            }
            _indentspaces -= 4;
            WriteLine("}", true);
            WriteLine("", true);
            WriteLine("#endregion", true);
            WriteLine("", true);
        }

        /// <summary>
        /// Adds code for a parameter for a certain datacolumn
        /// </summary>
        /// <param name="datacolumn"></param>
        protected void AddParameter(DataColumn datacolumn)
        {
            Write("command.Parameters.Add(new SqlParameter(\"@", true);
            Write(datacolumn.ColumnName);
            if (datacolumn.DataType == typeof(int))
                Write("\", SqlDbType.Int, 0, \"");
            else if (datacolumn.DataType == typeof(double))
                Write("\", SqlDbType.Float, 0, \"");
            else if (datacolumn.DataType == typeof(string))
                Write("\", SqlDbType.VarChar, 50, \"");
            else if (datacolumn.DataType == typeof(DateTime))
                Write("\", SqlDbType.SmallDateTime, 0, \"");
            else if (datacolumn.DataType == typeof(bool))
                Write("\", SqlDbType.Bit, 0, \"");
            Write(datacolumn.ColumnName);
            WriteLine("\"));");
        }

        /// <summary>
        /// Adds code for the generic data needed for a SqlCommand
        /// </summary>
        /// <param name="commandtype"></param>
        /// <param name="ta"></param>
        protected void InitialCommandData(string commandtype, TableAdapter ta)
        {
            WriteLine("command = new SqlCommand();", true);
            Write("command.CommandText = \"", true);
            Write(ta.DataTable.TableName);
            Write(commandtype);
            WriteLine("\";");
            WriteLine("command.CommandType = CommandType.StoredProcedure;", true);
            WriteLine("command.Connection = DataBase.Connection;", true);
            Write(ta.AdapterName, true);
            Write(".");
            Write(commandtype);
            WriteLine("Command = command;");
        }

        /// <summary>
        /// Adds code for the dataadapter parameters
        /// </summary>
        /// <param name="list"></param>
        protected void ProduceAdapterParameters(List<TableAdapter> list)
        {
            WriteLine("", true);
            WriteLine("#region Private/protected members", true);
            WriteLine("", true);
            foreach (TableAdapter ta in list)
            {
                Write("protected SqlDataAdapter ", true);
                Write(ta.AdapterName);
                WriteLine(";");
            }
            WriteLine("", true);
            WriteLine("#endregion", true);
            WriteLine("", true);
        }

        /// <summary>
        /// Constructs a list of dataadapternames coupled with its table
        /// </summary>
        /// <returns></returns>
        protected List<TableAdapter> SetTableAdapters()
        {
            List<TableAdapter> list = new List<TableAdapter>();
            foreach (DataTable datatable in _dataset.Tables)
            {
                TableAdapter ta = new TableAdapter();
                ta.AdapterName = "_" + datatable.TableName.ToLower() + "adapter";
                ta.DataTable = datatable;
                list.Add(ta);
            }
            return list;
        }

        #endregion

        #region Produce stored procedures methods

        /// <summary>
        /// Produces a select stored procedure for a DataTable
        /// </summary>
        /// <param name="table"></param>
        protected void WriteSelectStoredProcedure(DataTable table)
        {
            Write("CREATE PROCEDURE dbo.", true);
            Write(table.TableName);
            WriteLine("Select");
            WriteLine("AS",true);
            _indentspaces += 4;
            Write("SELECT ", true);
            StringBuilder columns = new StringBuilder();
            foreach (DataColumn datacolumn in table.Columns)
            {
                columns.Append(datacolumn.ColumnName);
                columns.Append(", ");
            }
            columns.Remove(columns.Length - 2, 2);
            WriteLine(columns.ToString());
            Write("FROM ", true);
            WriteLine(table.TableName);
            WriteLine("");
            WriteLine("RETURN", true);
            _indentspaces -= 4;
            WriteLine("");
        }

        /// <summary>
        /// Produces an insert stored procedure for a DataTable
        /// </summary>
        /// <param name="table"></param>
        protected void WriteInsertStoredProcedure(DataTable table)
        {
            Write("CREATE PROCEDURE dbo.", true);
            Write(table.TableName);
            WriteLine("Insert");
            _indentspaces += 4;
            WriteLine("(",true);
            string idcolumnname="";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn datacolumn = table.Columns[i];
                Write("@", true);
                Write(datacolumn.ColumnName);
                if (datacolumn.DataType == typeof(int))
                    Write(" int");
                else if (datacolumn.DataType == typeof(double))
                    Write(" float");
                else if (datacolumn.DataType == typeof(string))
                    Write(" varchar(50)");
                else if (datacolumn.DataType == typeof(DateTime))
                    Write(" smalldatetime");
                else if (datacolumn.DataType == typeof(bool))
                    Write(" bit");
                if (datacolumn.Unique)
                {
                    Write(" output");
                    idcolumnname = datacolumn.ColumnName;
                }
                if (i < table.Columns.Count - 1)
                    WriteLine(",");
                else
                    WriteLine("");
            }
            WriteLine(")", true);
            _indentspaces -= 4;
            WriteLine("AS", true);
            _indentspaces += 4;
            Write("INSERT INTO ", true);
            Write(table.TableName);
            Write(" (");
            StringBuilder columns = new StringBuilder();
            StringBuilder parameters = new StringBuilder();
            foreach(DataColumn datacolumn in table.Columns)
                if (!datacolumn.Unique)
                {
                    columns.Append(datacolumn.ColumnName);
                    columns.Append(", ");
                    parameters.Append("@");
                    parameters.Append(datacolumn.ColumnName);
                    parameters.Append(", ");
                }
            columns.Remove(columns.Length - 2, 2);
            parameters.Remove(parameters.Length - 2, 2);
            Write(columns.ToString());
            WriteLine(")");
            Write("VALUES (", true);
            Write(parameters.ToString());
            WriteLine(")");
            WriteLine("");
            Write("SELECT @", true);
            Write(idcolumnname);
            Write("=MAX(");
            Write(idcolumnname);
            Write(") FROM ");
            WriteLine(table.TableName);
            WriteLine("");
            WriteLine("RETURN", true);
            _indentspaces -= 4;
            WriteLine("");
        }

        /// <summary>
        /// Produces an update stored procedure for a DataTable
        /// </summary>
        /// <param name="table"></param>
        protected void WriteUpdateStoredProcedure(DataTable table)
        {
            Write("CREATE PROCEDURE dbo.", true);
            Write(table.TableName);
            WriteLine("Update");
            _indentspaces += 4;
            WriteLine("(", true);
            string idcolumnname="";
            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn datacolumn = table.Columns[i];
                Write("@", true);
                Write(datacolumn.ColumnName);
                if (datacolumn.DataType == typeof(int))
                    Write(" int");
                else if (datacolumn.DataType == typeof(double))
                    Write(" float");
                else if (datacolumn.DataType == typeof(string))
                    Write(" varchar(50)");
                else if (datacolumn.DataType == typeof(DateTime))
                    Write(" smalldatetime");
                else if (datacolumn.DataType == typeof(bool))
                    Write(" bit");
                if (datacolumn.Unique)
                    idcolumnname = datacolumn.ColumnName;
                if (i < table.Columns.Count - 1)
                    WriteLine(",");
                else
                    WriteLine("");
            }
            WriteLine(")", true);
            _indentspaces -= 4;
            WriteLine("AS", true);
            _indentspaces += 4;
            Write("UPDATE ", true);
            WriteLine(table.TableName);
            Write("SET ", true);
            bool firstrow = true;
            for (int i = 0; i < table.Columns.Count; i++)
            {
                DataColumn datacolumn = table.Columns[i];
                if (datacolumn.ColumnName != idcolumnname)
                {
                    if (firstrow)
                        Write(datacolumn.ColumnName);
                    else
                        Write(datacolumn.ColumnName,true);
                    Write("=@");
                    Write(datacolumn.ColumnName);
                    if (i == table.Columns.Count - 1)
                        WriteLine("");
                    else
                        WriteLine(",");
                    if (firstrow)
                    {
                        _indentspaces += 4;
                        firstrow = false;
                    }
                }
            }
            _indentspaces -= 4;
            Write("WHERE ", true);
            Write(idcolumnname);
            Write("=@");
            WriteLine(idcolumnname);
            WriteLine("");
            WriteLine("RETURN");
            _indentspaces -= 4;
            WriteLine("");
        }

        /// <summary>
        /// Produces a delete stored procedure for a DataTable
        /// </summary>
        /// <param name="table"></param>
        protected void WriteDeleteStoredProcedure(DataTable table)
        {
            Write("CREATE PROCEDURE dbo.", true);
            Write(table.TableName);
            WriteLine("Delete");
            _indentspaces += 4;
            WriteLine("(", true);
            string idcolumnname="";
            foreach (DataColumn datacolumn in table.Columns)
                if (datacolumn.Unique)
                {
                    idcolumnname = datacolumn.ColumnName;
                    Write("@", true);
                    Write(datacolumn.ColumnName);
                    WriteLine(" int");
                }
            WriteLine(")", true);
            _indentspaces -= 4;
            WriteLine("AS", true);
            _indentspaces += 4;
            Write("DELETE FROM ", true);
            WriteLine(table.TableName);
            Write("WHERE ", true);
            Write(idcolumnname);
            Write("=@");
            WriteLine(idcolumnname);
            WriteLine("");
            WriteLine("RETURN");
            _indentspaces -= 4;
            WriteLine("");
        }

        #endregion

        #endregion

        #region Private/protected structs/classes

        /// <summary>
        /// Struct for storing dataadaptername with it's datatable
        /// </summary>
        protected struct TableAdapter
        {

            #region Public members

            public string AdapterName;
            public DataTable DataTable;

            #endregion

        }

        #endregion

    }
}
