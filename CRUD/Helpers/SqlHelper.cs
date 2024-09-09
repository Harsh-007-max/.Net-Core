using System.Data;
using System.Data.SqlClient;
namespace CRUD.Helpers;


public class SqlHelper
{
    private readonly string _connectionString;

    public SqlHelper(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataTable? ExecuteStoredProcedure(string procedureName, Dictionary<string,object> parameters=null)
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        SqlCommand command=command = new SqlCommand(procedureName, connection);
        if (parameters != null)
        {
            foreach (KeyValuePair<string, object> parameter in parameters)
            {
                command.Parameters.Add(parameter.Key,SqlDbType.Int).Value = parameter.Value;
            }
        }
        command.CommandType = CommandType.StoredProcedure;
        connection.Open();
        if (parameters == null)
        {
            SqlDataReader reader = command.ExecuteReader();
            DataTable dataTable = new DataTable();
            dataTable.Load(reader);
            connection.Close();
            return dataTable;
        }
        else
        {
            command.ExecuteNonQuery();
            return null;
        }
    }
}