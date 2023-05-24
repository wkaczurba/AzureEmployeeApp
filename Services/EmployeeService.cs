using EmployeeApp.Models;
using System.Data.SqlClient;

namespace EmployeeApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private static string db_source = "bestsqlserver.database.windows.net";
        private static string db_user = "best_admin";
        private static string db_password = "***";
        private static string db_database = "best_database";

        private readonly IConfiguration _configruation;

        public EmployeeService(IConfiguration configruation)
        {
            _configruation = configruation;
        }

        private SqlConnection GetConnection()
        {
            //var _builder = new SqlConnectionStringBuilder();
            //_builder.DataSource = db_source;
            //_builder.UserID = db_user;
            //_builder.Password = db_password;
            //_builder.InitialCatalog = db_database;

            //return new SqlConnection(_builder.ConnectionString);
            var connectionString = _configruation.GetConnectionString("SQLConnection");

            return new SqlConnection(connectionString);
        }

        public List<Employee> GetEmployees()
        {
            var conn = GetConnection();
            List<Employee> employeeList = new List<Employee>();

            string statement = "select EmployeeID, LastName, FirstName from Employees;";

            conn.Open();
            var cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var employee = new Employee()
                    {
                        EmployeeID = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2)
                    };
                    employeeList.Add(employee);
                }
            }
            conn.Close();
            return employeeList;
        }
    }
}
