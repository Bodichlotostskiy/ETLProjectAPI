using System.Data;
using System.Data.SqlClient;

namespace ETLProjectAPI.Infrastructure.Database
{

    public class DataContext
    {

        #region Fields: Private

        private readonly string _processingConnectionString;

        #endregion

        #region Constructors: Public

        public DataContext(string connectionString)
        {
            _processingConnectionString = connectionString;
        }

        #endregion

        #region Methods: Public

        public IDbConnection CreateConnection()
        {
            var connection = new SqlConnection(_processingConnectionString);
            connection.Open();
            return connection;
        }

        public void Release()
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
