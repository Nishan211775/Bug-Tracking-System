﻿using Bug_Tracker.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker.DAO
{
    class FixerDAO : GenericDAO<Fixer>
    {
        private SqlConnection conn = new DBConnection().GetConnection();
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Fixer> GetAll()
        {
            throw new NotImplementedException();
        }

        public Fixer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Fixer t)
        {
            conn.Open();
            SqlTransaction trans = conn.BeginTransaction();

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.Transaction = trans;
                sql.CommandText = "INSERT INTO tbl_fixer VALUES(@fixed_by, @bug_id, @fixed_date)";
                sql.Prepare();
                sql.Parameters.AddWithValue("@fixed_by", t.FixedBy);
                sql.Parameters.AddWithValue("@bug_id", t.BugId);
                sql.Parameters.AddWithValue("@fixed_date", DateTime.Now);

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

        public void Update(Fixer t)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// returns a name of bug fixer
        /// </summary>
        /// <returns></returns>
        public List<Fixer> GetBugFixers()
        {
            conn.Open();
            List<Fixer> list = new List<Fixer>();
            Fixer fixer = null;
            Programmer programmer = null;

            try
            {
                SqlCommand sql = new SqlCommand(null, conn);
                sql.CommandText = "SELECT f.bug_id, f.fixed_date, p.full_name FROM tbl_programmer p JOIN tbl_fixer f ON p.programmer_id = f.fixed_by;";
                sql.Prepare();

                using (SqlDataReader reader = sql.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fixer = new Fixer();
                        programmer = new Programmer();

                        fixer.BugId = Convert.ToInt32(reader["bug_id"]);
                        fixer.FixedDate = Convert.ToDateTime(reader["fixed_date"]);
                        programmer.FullName = reader["full_name"].ToString();

                        fixer.programmer = programmer;

                        list.Add(fixer);
                    }
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }

            return list;
        }
     }
}
