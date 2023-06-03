using System.Data;
using Npgsql;
using Microsoft.Extensions.Configuration;

public class DapperContext
{
private IConfiguration _configuration;
public DapperContext( IConfiguration configuration)
{
    _configuration=configuration;
}
public IDbConnection CreateConnection(){
    return new NpgsqlConnection(_configuration.GetConnectionString("DefaultConnection"));
}
}