using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Web;

public static class SessionManager
{
    private static string connectionString = "Data Source=MCP-TI3-2\\SQLEXPRESS;Initial Catalog=aspnetdb;Integrated Security=True";

    public static Guid GetOrCreateSessionId(HttpRequestBase request, HttpResponseBase response)
    {
        HttpCookie cookie = request.Cookies["CustomSessionId"];
        Guid sessionId;

        if (cookie == null || !Guid.TryParse(cookie.Value, out sessionId))
        {
            sessionId = Guid.NewGuid();
            response.Cookies.Add(new HttpCookie("CustomSessionId", sessionId.ToString()));
            CreateSession(sessionId);
        }

        return sessionId;
    }

    public static void CreateSession(Guid sessionId)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string sql = "INSERT INTO SessionServer (SessionId, UserData, ExpiresAt) VALUES (@id, '', @expires)";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", sessionId);
            cmd.Parameters.AddWithValue("@expires", DateTime.Now.AddMinutes(20));

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }

    public static string GetSessionData(Guid sessionId)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string sql = "SELECT UserData FROM SessionServer WHERE SessionId = @id AND ExpiresAt > GETDATE()";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@id", sessionId);

            conn.Open();
            var result = cmd.ExecuteScalar();
            return result?.ToString();
        }
    }

    public static void SetSessionData(Guid sessionId, string data)
    {
        using (var conn = new SqlConnection(connectionString))
        {
            string sql = "UPDATE SessionServer SET UserData = @data, ExpiresAt = @expires WHERE SessionId = @id";
            var cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@data", data);
            cmd.Parameters.AddWithValue("@expires", DateTime.Now.AddMinutes(20));
            cmd.Parameters.AddWithValue("@id", sessionId);

            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
}

