using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCBOR.Data
{
    public class Notifications
    {
        public static String CreateNewsletterSubscriber(String EmailAddress)
        {
            String newId = String.Empty;
            SqlConnection sqlConnection = new SqlConnection(Utilities.GetConnectionString());
            String sqlText = String.Empty;
            sqlText = String.Format(@"
                INSERT INTO [dbo].[Newsletter]
                (   [EmailAddress]  )
                OUTPUT inserted.Id
                VALUES
                (   '{0}'   ) ",
                EmailAddress
                    );
            SqlCommand cmd = new SqlCommand(sqlText, sqlConnection);
            try
            {
                sqlConnection.Open();
                var newInsertedId = cmd.ExecuteScalar();
                sqlConnection.Close();
                newId = Convert.ToString(newInsertedId);
            }
            catch (Exception ex)
            {
                Core.Logger.AppendToErrors("ERROR - " +
                    String.Format("ex.Message-{0} ex.Inner-{1} ex.StackTrace{2}", ex.Message, ex.InnerException, ex.StackTrace));
            }
            finally
            { sqlConnection.Close(); }

            if (sqlConnection.State == ConnectionState.Open)
            { sqlConnection.Close(); }

            return newId;
        }

        public static Boolean DoesNewsletterSubscriberExist(String EmailAddress)
        {
            Boolean doesExist = false;
            SqlConnection sqlConnection = new SqlConnection(Utilities.GetConnectionString());
            DataTable dt = new DataTable();
            String sqlText = String.Empty;
            sqlText = String.Format(@"
                SELECT * FROM  [dbo].[Newsletter] WHERE EmailAddress= '{0}' ",
                EmailAddress);
            SqlCommand cmd = new SqlCommand(sqlText, sqlConnection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            try
            {
                sqlConnection.Open();
                da.Fill(dt);
                sqlConnection.Close();
                da.Dispose();
                if (dt.Rows.Count > 0)
                {
                    doesExist = true;
                }
            }
            catch (Exception ex)
            {
                Core.Logger.AppendToErrors("ERROR - " +
                    String.Format("ex.Message-{0} ex.Inner-{1} ex.StackTrace{2}", ex.Message, ex.InnerException, ex.StackTrace));
            }
            finally
            { sqlConnection.Close(); }

            if (sqlConnection.State == ConnectionState.Open)
            { sqlConnection.Close(); }

            return doesExist;
        }
    }
}
