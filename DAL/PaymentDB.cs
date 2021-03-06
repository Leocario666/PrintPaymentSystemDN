﻿using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PaymentDB
    {


        

        public static decimal GetQuotaByID(int userID)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = PrinterDN; Persist Security Info = True; User ID = 6231db; Password = Pwd46231.; Pooling = False";

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM [Payment] WHERE  " +
                        " userId = @userID";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@userID", userID);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return (decimal)dr["quota"];
                        }
                        else
                        {
                            return -1;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static void CreatePayment(int userID)
        {
            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = PrinterDN; Persist Security Info = True; User ID = 6231db; Password = Pwd46231.; Pooling = False";

            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "INSERT INTO Payment(quota,userId) values(@quota,@userID); SELECT SCOPE_IDENTITY()";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);


                    cmd.Parameters.AddWithValue("@quota", 0.00);
                    cmd.Parameters.AddWithValue("@userID", userID);



                    // Open the command
                    cn.Open();

                    // Execute the command
                    cmd.ExecuteScalar();


                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void ModifyQuotaById(int userID, decimal quota)
        {

            string connectionString = "Data Source = 153.109.124.35; Initial Catalog = PrinterDN; Persist Security Info = True; User ID = 6231db; Password = Pwd46231.; Pooling = False";
            try
            {
                // Connexion to the Database
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    // The query
                    string query = "UPDATE Payment Set quota=@quota WHERE userId = @userID";

                    // Save the command
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cmd.Parameters.AddWithValue("@quota", quota);
                    cmd.Parameters.AddWithValue("@userID", userID);



                    // Open the command
                    cn.Open();

                    // Execute the command
                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                throw e;
            }
           
            
        }
    }
}
