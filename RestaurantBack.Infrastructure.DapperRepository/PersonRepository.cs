using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantBack.Domain.RepositoryPattern;
using RestaurantBack.Domain.Entities.Person;

namespace RestaurantBack.Infrastructure.DapperRepository
{
    public class PersonRepository : IPersonRepository
    {
        private string _connectionString;
        public PersonRepository(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public IEnumerable<PersonResponseEntity> GetPerson(PersonRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option", parameter.option, DbType.Int64, ParameterDirection.Input);

                    var response = con.Query<PersonResponseEntity>("sp_get_person", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response.Count() > 0)
                    {
                        return response;
                    }
                    else
                    {
                        return new List<PersonResponseEntity>() {
                            new PersonResponseEntity()
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
                return new List<PersonResponseEntity>() {
                    new PersonResponseEntity()
                    {
                        codSystem = 204,
                        msgSystem = ex.Message
                    }
                };
            }
        }

        public PersonResponseEntity SetPerson(PersonRequestEntity parameter)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    var sp_parameters = new DynamicParameters();
                    sp_parameters.Add("@p_option",      parameter.option,       DbType.Int64,   ParameterDirection.Input);
                    sp_parameters.Add("@p_names",       parameter.names,        DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_surnames",    parameter.surnames,     DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_cell_phone",  parameter.cellPhone,    DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_email",       parameter.email,        DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_cod_user",    parameter.codUser,      DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_password",    parameter.password,     DbType.String,  ParameterDirection.Input);
                    sp_parameters.Add("@p_id_person",   parameter.idPerson,     DbType.Int64,   ParameterDirection.Input);

                    var response = con.QuerySingleOrDefault<PersonResponseEntity>("sp_set_person", sp_parameters, commandType: CommandType.StoredProcedure);

                    if (response != null)
                    {
                        return response;
                    }
                    else
                    {
                        return new PersonResponseEntity()
                        {
                            codSystem = 204,
                            msgSystem = "Ocurió un error en SetSales"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                return new PersonResponseEntity()
                {
                    codSystem = 204,
                    msgSystem = ex.Message
                };
            }
        }
    }
}
