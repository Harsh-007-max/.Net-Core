using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;

namespace CRUD.Helpers;


public class SqlHelper
{
    private readonly string _connectionString;

    public SqlHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }

    public SqlCommand GetCommand(SqlConnection connection)
    {
        SqlCommand command = connection.CreateCommand();
        command.CommandType = CommandType.StoredProcedure;
        return command;
    }

    public SqlCommand fillSqlCommandProperty<T>(T obj, SqlCommand command)
    {
        foreach (var prop in typeof(T).GetProperties())
        {
            var propertyValue = prop.GetValue(obj, null);
            if (propertyValue != null)
            {
                string propName = "@" + prop.Name;
                command.Parameters.AddWithValue(propName, propertyValue);
            }
        }
        return command;
    }
    public T PerformSqlOperation<T>(T obj,string procedureName,bool insert=false,Boolean update=false,Boolean delete=false,int id=0)
    {
        SqlConnection connection = GetConnection();
        connection.Open();
        SqlCommand command = GetCommand(connection);
        command.CommandText = procedureName;
        if (insert)
        {
            command = fillSqlCommandProperty(obj, command);
            command.ExecuteNonQuery();
        }else if(update)
        {
            command = fillSqlCommandProperty(obj, command);
            command.ExecuteNonQuery();
        }else if (delete)
        {
            command = fillSqlCommandProperty(obj, command);
            command.ExecuteNonQuery();
        }else if (id != 0)
        {
            // return GetByID<T>(command);
        }
        else
        {
            ExecuteStoredProcedure(procedureName);
        }
        connection.Close();
        return default(T);
    }

    public T GetByID<T>(string procedureName,string propName,int id) where T : new()
    {
        SqlConnection connection = GetConnection();
        connection.Open();
        SqlCommand command = GetCommand(connection);
        command.CommandText = procedureName;
        command.Parameters.AddWithValue(propName,id);
        T item = new T();
        SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            DataRow dr = dt.Rows[0];
            foreach (var prop in typeof(T).GetProperties())
            {
                if (dt.Columns.Contains(prop.Name) && dr[prop.Name] != DBNull.Value)
                {
                    var targetType= Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                    prop.SetValue(item,Convert.ChangeType(dr[prop.Name],targetType));
                }
            }
        }
        return item;
    }
    public DataTable? ExecuteStoredProcedure(string procedureName)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand command=command = new SqlCommand(procedureName, connection);
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();
        DataTable dataTable = new DataTable();
        dataTable.Load(reader);
        connection.Close();
        return dataTable;
    }
}
