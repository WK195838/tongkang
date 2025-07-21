using System;
using System.Configuration;
using System.Data.SqlClient;
using ARTEST.Models;

namespace ARTEST.DAL
{
    /// <summary>
    /// 應收帳款發票資料存取層
    /// </summary>
    public class ARInvoiceDAL
    {
        /// <summary>
        /// 新增應收帳款發票資料
        /// </summary>
        /// <param name="data">發票資料</param>
        /// <returns>操作結果</returns>
        public static Result Insert(ARInvoice data)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConn"].ConnectionString))
            {
                string sql = @"INSERT INTO AR_Invoice (CustomerCode, InvoiceNumber, InvoiceDate, DueDate, Amount, 
                                AccountCode, Remark, CreateUser, CreateDate)
                               VALUES (@CustomerCode, @InvoiceNumber, @InvoiceDate, @DueDate, @Amount, 
                                @AccountCode, @Remark, @CreateUser, @CreateDate)";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@CustomerCode", data.CustomerCode);
                cmd.Parameters.AddWithValue("@InvoiceNumber", data.InvoiceNumber);
                cmd.Parameters.AddWithValue("@InvoiceDate", data.InvoiceDate);
                cmd.Parameters.AddWithValue("@DueDate", data.DueDate);
                cmd.Parameters.AddWithValue("@Amount", data.Amount);
                cmd.Parameters.AddWithValue("@AccountCode", data.AccountCode);
                cmd.Parameters.AddWithValue("@Remark", data.Remark ?? string.Empty);
                cmd.Parameters.AddWithValue("@CreateUser", data.CreateUser);
                cmd.Parameters.AddWithValue("@CreateDate", data.CreateDate);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return Result.Success();
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627) // 唯一索引違反
                    {
                        return Result.Failure("發票號碼已存在，請檢查輸入資料");
                    }
                    return Result.Failure($"資料庫錯誤：{ex.Message}");
                }
                catch (Exception ex)
                {
                    return Result.Failure($"系統錯誤：{ex.Message}");
                }
            }
        }

        /// <summary>
        /// 檢查發票號碼是否已存在
        /// </summary>
        /// <param name="invoiceNumber">發票號碼</param>
        /// <returns>是否存在</returns>
        public static bool IsInvoiceNumberExists(string invoiceNumber)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConn"].ConnectionString))
            {
                string sql = "SELECT COUNT(*) FROM AR_Invoice WHERE InvoiceNumber = @InvoiceNumber";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@InvoiceNumber", invoiceNumber);

                try
                {
                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// 根據ID查詢發票資料
        /// </summary>
        /// <param name="invoiceId">發票ID</param>
        /// <returns>發票資料</returns>
        public static ARInvoice GetById(int invoiceId)
        {
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConn"].ConnectionString))
            {
                string sql = @"SELECT InvoiceID, CustomerCode, InvoiceNumber, InvoiceDate, DueDate, 
                                Amount, AccountCode, Remark, CreateUser, CreateDate 
                               FROM AR_Invoice WHERE InvoiceID = @InvoiceID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@InvoiceID", invoiceId);

                try
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new ARInvoice
                            {
                                InvoiceID = reader.GetInt32("InvoiceID"),
                                CustomerCode = reader.GetString("CustomerCode"),
                                InvoiceNumber = reader.GetString("InvoiceNumber"),
                                InvoiceDate = reader.GetDateTime("InvoiceDate"),
                                DueDate = reader.GetDateTime("DueDate"),
                                Amount = reader.GetDecimal("Amount"),
                                AccountCode = reader.GetString("AccountCode"),
                                Remark = reader.IsDBNull("Remark") ? string.Empty : reader.GetString("Remark"),
                                CreateUser = reader.GetString("CreateUser"),
                                CreateDate = reader.GetDateTime("CreateDate")
                            };
                        }
                    }
                }
                catch
                {
                    // 記錄錯誤日誌
                }
            }
            return null;
        }
    }
} 