using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Repositories
{
    public class CustomerRepositorySqlServer : ICustomerRepository
    {
        private readonly string _connectionString;

        public CustomerRepositorySqlServer(IConfiguration configuration)
        {
            //Todo connectionstring should be stored appsetting.json
            //this._connectionString = "Data source=EC2AMAZ-8RI616P;" +
            //"Initial Catalog=Northwind;" +
            // "Integrated Security=SSPI;" +
            // "TrustServerCertificate=true";

            _connectionString = configuration.GetConnectionString("NorthwindContext");
        }

        public CustomerRepositorySqlServer(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void DeleteById(string id)
        {
            using (SqlConnection sqlConnection =
                           new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    "DELETE FROM [dbo].[Customers]" +
                    " WHERE CustomerID=@CustomerID";

                sqlCommand.Parameters.AddWithValue("@CustomerID", id);
                sqlCommand.ExecuteNonQuery();




            }

        }

        public List<DtoCustomer> GetAll()
        {
            using (SqlConnection sqlConnection =
                            new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    "SELECT *  FROM [dbo].[Customers]";

                SqlDataReader sqlDataReader =
                        sqlCommand.ExecuteReader();

                List<DtoCustomer> customers =
                    new List<DtoCustomer>();
                //foreach (SqlDataReader reader in sqlDataReader)
                while (sqlDataReader.Read() == true)
                {
                    //fieldnames from db > DtoCustomer
                    customers.Add(
                        new DtoCustomer
                        (sqlDataReader["CustomerID"].ToString(),
                        sqlDataReader["CompanyName"].ToString(),
                        sqlDataReader["ContactName"].ToString(),
                        sqlDataReader["ContactTitle"].ToString(),
                        sqlDataReader["Address"].ToString(),
                        sqlDataReader["City"].ToString(),
                        sqlDataReader["Region"].ToString(),
                        sqlDataReader["Phone"].ToString()
                        )
                    );
                }

                return customers;
            }//closing and dispose of the object



        }

        public List<DtoCustomer> GetByCompany(string name)
        {
            //ADO.net connection, command, sqldatareader
            using (SqlConnection sqlConnection =
                new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.CommandText = "p_GetAllCustomersByCoName";
                sqlCommand.Parameters.AddWithValue("@CompanyName", name);
                //todo refactor 
                SqlDataReader sqlDataReader =
                        sqlCommand.ExecuteReader();

                List<DtoCustomer> customers =
                    new List<DtoCustomer>();

                while (sqlDataReader.Read() == true)
                {
                    //fieldnames from db > DtoCustomer
                    customers.Add(
                        new DtoCustomer
                        (sqlDataReader["CustomerID"].ToString(),
                        sqlDataReader["CompanyName"].ToString(),
                        sqlDataReader["ContactName"].ToString(),
                        sqlDataReader["ContactTitle"].ToString(),
                        sqlDataReader["Address"].ToString(),
                        sqlDataReader["City"].ToString(),
                        sqlDataReader["Region"].ToString(),
                        sqlDataReader["Phone"].ToString()
                        )
                    );
                }//end of while
                return customers;
            }//end of using

        }//end of method

        public DtoCustomer GetByCompany()
        {
            throw new NotImplementedException();
        }

        public DtoCustomer? GetById(string id)
        {

            using (SqlConnection sqlConnection =
                new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "SELECT * FROM Customers Where CustomerID=@ID";
                sqlCommand.Parameters.AddWithValue("@ID", id);
                //execute the query
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read() == true)
                {
                    DtoCustomer dtoCustomer = new DtoCustomer(
                        sqlDataReader["CustomerID"].ToString(),
                            sqlDataReader["CompanyName"].ToString(),
                            sqlDataReader["ContactName"].ToString(),
                            sqlDataReader["ContactTitle"].ToString(),
                            sqlDataReader["Address"].ToString(),
                            sqlDataReader["City"].ToString(),
                            sqlDataReader["Region"].ToString(),
                            sqlDataReader["Phone"].ToString()

                        );
                    return dtoCustomer;
                }
                else
                {
                    return null;
                }

            }//end of using
        }//end of method

        public int GetCount()
        {
            //SELECT count(*)  FROM [dbo].[Customers]
            //ado.net
            using (SqlConnection sqlConnection =
                 new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText =
                    "SELECT count(*)  FROM [dbo].[Customers]";

                int RowCount =
                    (int)sqlCommand.ExecuteScalar();

                return RowCount;
            }//closing and dispose of the object

        }

        public void Save(DtoCustomer customer)
        {
            using (SqlConnection sqlConnection =
            new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.Connection = sqlConnection;
                sqlCommand.CommandText = "Insert into Customers(CustomerID, CompanyName," +
                    "ContactName, ContactTitle, Address,City, Region, Phone)" +
                    "Values(@CustomerID, @CompanyName," +
                    "@ContactName, @ContactTitle, @Address,@City, @Region, @Phone)";
                sqlCommand.Parameters.AddWithValue("@CustomerID", customer.CustomerId);
                sqlCommand.Parameters.AddWithValue("@CompanyName", customer.Company);
                sqlCommand.Parameters.AddWithValue("@ContactName", customer.ContactName);
                sqlCommand.Parameters.AddWithValue("@ContactTitle", customer.ContactTitle);
                sqlCommand.Parameters.AddWithValue("@Address", customer.Address);
                sqlCommand.Parameters.AddWithValue("@City", customer.City);
                sqlCommand.Parameters.AddWithValue("@Region", customer.Region);
                sqlCommand.Parameters.AddWithValue("@Phone", customer.Phone);

                sqlCommand.ExecuteNonQuery();
            }//end of using
        }//end of save

        public void Update(DtoCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}