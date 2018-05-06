using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bug_Tracker.Model;

namespace Bug_Tracker.DAO
{
    class ProgrammerDAO : GenericDAO<Programmer>
    {
        private SqlConnection conn = new DBConnection().GetConnection();

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Programmer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Programmer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Programmer t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();
            
            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_programmer VALUES(@fullName, @username, @password)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@fullName", t.FullName);
                sql.Parameters.AddWithValue("@username", t.Username);
                sql.Parameters.AddWithValue("@password", t.Password);
                
                sql.ExecuteNonQuery();

                trans.Commit();
            }
            catch (SqlException ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public void Update(Programmer t)
        {
            throw new NotImplementedException();
        }

        public bool IsLogin(string username, string password)
        {
            conn.Open();
            SqlTransaction trans = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "SELECT * FROM tbl_programmer WHERE username=@username AND password=@password";
                sql.Prepare();
                sql.Parameters.AddWithValue("@username", username);
                sql.Parameters.AddWithValue("@password", password);

                SqlDataReader reader = sql.ExecuteReader();

                while(reader.Read())
                {
                    return true;
                }
                //trans.Commit();
            } catch(SqlException ex)
            {
                trans.Rollback();
                throw ex;
            } finally
            {
                conn.Close();
            }

            return false;
        }
    }
}
