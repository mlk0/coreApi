using System;

using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Linq;
using Microsoft.Extensions.Logging;

public class UserQueryHandler : IUserQueryHandler
{
    private IConfiguration _config;
    private readonly ILogger<UserQueryHandler> _logger;

    public  UserQueryHandler(IConfiguration config, ILogger<UserQueryHandler> logger)
    {
        _config = config;
        this._logger = logger;
    }

 
    public List<UserData> GetUsers()
    {


        List<UserData> result = null;


        //1. get the connection string 
        var connectionString = this.GetConnection();
        _logger.LogDebug($"connectionString : {connectionString}");

        //2. issue a Dapper query within an using block
        using(var connection = new SqlConnection(connectionString)){
            
            //Dapper.SqlMapper.ResetTypeHandlers();
            //3. open the connection
            connection.Open();
            
            //4. execute the queery and get the result into an IEnumerable<T>
            var users = connection.Query<UserData>("select * from dbo.[User]");
            //var users = connection.Query("select * from dbo.[User]");
            
            //5. finalize the result into a List<T>
            result = users.ToList();
        }


        return result;
    }

    private string GetConnection()
    {
        _logger.LogDebug("in GetConnection");
        var connection = _config.GetSection("ConnectionStrings").GetSection("DashDbAzure").Value;
        return connection;
    }
}

public interface IUserQueryHandler{
    List<UserData> GetUsers();
}