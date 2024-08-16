using Dapper;
using RestaurantBack.Domain.Entities.Product;
using RestaurantBack.Domain.RepositoryPattern;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantBack.Infrastructure.DapperRepository
{
    public class ProductRepository : IProductRepository
    {
        private string _connectionString;
        public ProductRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IEnumerable<ProductResponseEntity> GetProduct(ProductRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option", parameter.option, DbType.Int64, ParameterDirection.Input);

                    var response = con.Query<ProductResponseEntity>("sp_get_product", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response.Count() > 0)
                    {
                        return response;
                    }
                    else
                    {
                        return new List<ProductResponseEntity>() {
                            new ProductResponseEntity()
                            {
                                codSystem = 204,
                                msgSystem = "No se encontraron registros"
                            }
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new List<ProductResponseEntity>() {
                    new ProductResponseEntity()
                    {
                        codSystem = 204,
                        msgSystem = ex.Message
                    }
                };
            }
        }

        public ProductResponseEntity SetProduct(ProductRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option",              parameter.option,           DbType.Int64, ParameterDirection.Input);
                    sp_parameters.Add("@p_product_name",        parameter.productName,      DbType.String, ParameterDirection.Input);
                    sp_parameters.Add("@p_product_price",       parameter.productPrice,     DbType.Double, ParameterDirection.Input);

                    var response = con.QuerySingleOrDefault<ProductResponseEntity>("sp_set_product", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response != null)
                    {
                        return response;
                    }
                    else
                    {
                        return new ProductResponseEntity()
                        {
                            codSystem = 204,
                            msgSystem = "Ocurió un error en SetSales"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProductResponseEntity()
                {
                    codSystem = 204,
                    msgSystem = ex.Message
                };
            }
        }
    }
}
