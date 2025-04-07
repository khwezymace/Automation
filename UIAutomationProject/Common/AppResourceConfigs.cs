using Microsoft.Data.SqlClient;
using System.Data;
using UIAutomation.Core.Abstration;

namespace UIAutomation.Core.Common
{
    public class AppResourceConfigs : IAppResourceConfigs
    {
        SqlConnection conn;
        string reportPath, logPath, downloadedFilePath;
        SqlCommand cmd;

        #region[Database connection]
        public void SetDatabaseConnection()
        {
            string connectionString = "Server=CAPWNDBUAT02.capfin.local;Database=AutomationData;Trusted_Connection=True;MultipleActiveResultSets=true; TrustServerCertificate=True";
            conn = new SqlConnection(connectionString);
            conn.Open();
        }
        #endregion

        #region [Bad debt management portal]
        public (string reportpath, string logPath, string downloadedFilepath) GetBDMExternalDir()
        {
            DataTable results = new DataTable();
            SetDatabaseConnection();
            cmd = new SqlCommand("sp_GetConsumerFiriendExternalPaths", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", 1);

            try
            {
                cmd.ExecuteNonQuery();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(results);
                foreach (DataRow row in results.Rows)
                {
                    reportPath += row["ReportPathValue"].ToString();
                    logPath = row["LogsPathValue"].ToString();
                    downloadedFilePath = row["DownloadedDocsPathValue"].ToString();
                }
            }
            catch (Exception ex)
            {
            }
            finally
            {
                conn.Close();
            }
            return (reportPath, logPath, downloadedFilePath);
        }
        #endregion
        #region [PPL Apps]
        #endregion

    }
}
