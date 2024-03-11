using System.Data;
using System.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace Data.Context.Dapper;

public class ApplicationReadDbConnection : IDisposable
{
    private readonly IDbConnection connection;

    public ApplicationReadDbConnection(IConfiguration configuration)
    {
        connection = new SqlConnection(AppSettings.MSSQLSettings.SQLConn);
    }

    public void Dispose()
    {
        connection.Dispose();
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(string sql, object param = null,
        IDbTransaction transaction = null, CancellationToken cancellationToken = default)
    {
        return (await connection.QueryAsync<T>(sql, param, transaction)).AsList();
    }

    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction);
    }

    public async Task<T> QuerySingleAsync<T>(string sql, object param = null, IDbTransaction transaction = null,
        CancellationToken cancellationToken = default)
    {
        return await connection.QuerySingleAsync<T>(sql, param, transaction);
    }
}