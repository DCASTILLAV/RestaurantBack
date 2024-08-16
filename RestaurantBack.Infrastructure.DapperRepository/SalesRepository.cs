using Dapper;
using RestaurantBack.Domain.Entities.Person;
using RestaurantBack.Domain.Entities.Sales;
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
    public class SalesRepository : ISalesRespository
    {
        private string _connectionString;
        public SalesRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }
        public IEnumerable<SalesResponseEntity> getSales(SalesRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option",      parameter.option,   DbType.Int64,   ParameterDirection.Input);
                    sp_parameters.Add("@p_cod_user",    parameter.codUser,  DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_id_order",    parameter.idOrder,  DbType.Int64,   ParameterDirection.Input);

                    var response = con.Query<SalesResponseEntity>("sp_get_sales", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response.Count() > 0)
                    {
                        return response;
                    }
                    else
                    {
                        return new List<SalesResponseEntity>() {
                            new SalesResponseEntity()
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
                return new List<SalesResponseEntity>() {
                    new SalesResponseEntity()
                    {
                        codSystem = 204,
                        msgSystem = ex.Message
                    }
                };
            }
        }

        public SalesResponseEntity setSales(SalesRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option",      parameter.option,       DbType.Int64,   ParameterDirection.Input);
                    sp_parameters.Add("@p_cod_user",    parameter.codUser,      DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_format_json", parameter.formatJson,   DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_observation", parameter.observation,  DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_id_state",    parameter.idState,      DbType.Int64,   ParameterDirection.Input);
                    sp_parameters.Add("@p_id_person",   parameter.idPerson,     DbType.Int64,   ParameterDirection.Input);

                    var response = con.QuerySingleOrDefault<SalesResponseEntity>("sp_set_sales", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response != null)
                    {
                        return response;
                    }
                    else
                    {
                        return new SalesResponseEntity()
                        {
                            codSystem = 204,
                            msgSystem = "Ocurió un error en SetSales"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new SalesResponseEntity()
                {
                    codSystem = 204,
                    msgSystem = ex.Message
                };
            }
        }
    }
}
