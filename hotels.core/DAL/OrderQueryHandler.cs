using System.Collections.Generic;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Dapper;
using System.Linq;

public interface IOrderQueryHandler
{
    List<OrderData> GetOrders();
}
public class OrderQueryHandler : IOrderQueryHandler{
    private readonly IConfiguration config;

    public OrderQueryHandler(IConfiguration config){
        this.config = config;
    }


    public List<OrderData> GetOrders(){
        var result = new List<OrderData>();
        var connectionString = GetConnection();
        using(var connection = new SqlConnection(connectionString)){
            connection.Open();
            var orders = connection.Query<OrderData>(@"SELECT [ID]
                                                        ,[UserId]
                                                        ,[ItemId]
                                                        ,[Units]
                                                    FROM [dbo].[Order]");
            if(orders != null){
                result = orders.ToList();
            }
        }
        return result;
    }

    private string GetConnection(){
        var connectionString = config.GetSection("ConnectionStrings").GetSection("DashDbAzure").Value;
        return connectionString;
    }
}

