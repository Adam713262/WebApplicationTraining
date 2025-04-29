using Microsoft.Data.SqlClient;
using WebApplicationTraining.Dtos;

namespace WebApplicationTraining.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
            private readonly string _connectionString;

            public ProductRepository()
            {
                //Todo connectionstring should be stored appsetting.json
                this._connectionString = "Data source=EC2AMAZ-8RI616P;" +
                    "Initial Catalog=Northwind;" +
                    "Integrated Security=SSPI;" +
                    "TrustServerCertificate=true";
            }

            public ProductRepository(string connectionString)
            {
                this._connectionString = connectionString;
            }



            public void CreateProduct(DtoProduct product)
            {
                throw new NotImplementedException();
            }

            public void DeleteProduct(int productId)
            {
                throw new NotImplementedException();
            }

            public List<DtoProduct> GetAllProducts()
            {
                using (SqlConnection sqlConnection =
                           new SqlConnection(this._connectionString))
                {
                    sqlConnection.Open();

                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandText =
                        "SELECT *  FROM [dbo].[Products]";

                    SqlDataReader sqlDataReader =
                            sqlCommand.ExecuteReader();

                    List<DtoProduct> products = new List<DtoProduct>();
                    //foreach (SqlDataReader reader in sqlDataReader)
                    while (sqlDataReader.Read() == true)
                    {
                        //fieldnames from db > DtoProduct
                        products.Add(
                            new DtoProduct
                            ((int)sqlDataReader["ProductID"],
                            sqlDataReader["ProductName"].ToString(),
                            (int)sqlDataReader["SupplierID"],
                            (int)sqlDataReader["CategoryID"],
                            sqlDataReader["QuantityPerUnit"].ToString(),
                           (decimal)sqlDataReader["UnitPrice"],
                             (short)sqlDataReader["UnitsinStock"],
                             (short)sqlDataReader["UnitsonOrder"],
                             (short)sqlDataReader["ReorderLevel"],
                              (bool)sqlDataReader["Discontinued"]
                            )
                        );
                    }

                    return products;
                }//closing and dispose of the object

            }

            public DtoProduct GetProductById(int productId)
            {
                throw new NotImplementedException();
            }

            public void UpdateProduct(DtoProduct product)
            {
                throw new NotImplementedException();
            }
        }


    }
       
