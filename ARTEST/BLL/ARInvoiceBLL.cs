using System;
using ARTEST.Models;
using ARTEST.DAL;

namespace ARTEST.BLL
{
    /// <summary>
    /// 應收帳款發票業務邏輯層
    /// </summary>
    public class ARInvoiceBLL
    {
        /// <summary>
        /// 儲存應收帳款發票資料
        /// </summary>
        /// <param name="invoice">發票資料</param>
        /// <returns>操作結果</returns>
        public static Result SaveARInvoice(ARInvoice invoice)
        {
            // 基本資料驗證
            var validationResult = ValidateInvoiceData(invoice);
            if (!validationResult.IsSuccess)
            {
                return validationResult;
            }

            // 檢查發票號碼是否重複
            if (ARInvoiceDAL.IsInvoiceNumberExists(invoice.InvoiceNumber))
            {
                return Result.Failure("發票號碼已存在，請使用不同的發票號碼");
            }

            // 呼叫資料存取層儲存資料
            return ARInvoiceDAL.Insert(invoice);
        }

        /// <summary>
        /// 驗證發票資料
        /// </summary>
        /// <param name="invoice">發票資料</param>
        /// <returns>驗證結果</returns>
        private static Result ValidateInvoiceData(ARInvoice invoice)
        {
            if (invoice == null)
            {
                return Result.Failure("發票資料不可為空");
            }

            // 客戶代號驗證
            if (string.IsNullOrWhiteSpace(invoice.CustomerCode))
            {
                return Result.Failure("客戶代號不可空白");
            }

            if (invoice.CustomerCode.Length > 20)
            {
                return Result.Failure("客戶代號長度不可超過20個字元");
            }

            // 發票號碼驗證
            if (string.IsNullOrWhiteSpace(invoice.InvoiceNumber))
            {
                return Result.Failure("發票號碼不可空白");
            }

            if (invoice.InvoiceNumber.Length > 30)
            {
                return Result.Failure("發票號碼長度不可超過30個字元");
            }

            // 金額驗證
            if (invoice.Amount <= 0)
            {
                return Result.Failure("應收金額必須大於零");
            }

            if (invoice.Amount > 999999999999.99m)
            {
                return Result.Failure("應收金額超過允許範圍");
            }

            // 日期驗證
            if (invoice.InvoiceDate == DateTime.MinValue)
            {
                return Result.Failure("發票日期不可為空");
            }

            if (invoice.DueDate == DateTime.MinValue)
            {
                return Result.Failure("到期日不可為空");
            }

            if (invoice.DueDate < invoice.InvoiceDate)
            {
                return Result.Failure("到期日不可早於發票日期");
            }

            // 科目代號驗證
            if (string.IsNullOrWhiteSpace(invoice.AccountCode))
            {
                return Result.Failure("科目代號不可空白");
            }

            if (invoice.AccountCode.Length > 10)
            {
                return Result.Failure("科目代號長度不可超過10個字元");
            }

            // 備註驗證
            if (!string.IsNullOrEmpty(invoice.Remark) && invoice.Remark.Length > 200)
            {
                return Result.Failure("備註長度不可超過200個字元");
            }

            // 建立者驗證
            if (string.IsNullOrWhiteSpace(invoice.CreateUser))
            {
                return Result.Failure("建立者不可空白");
            }

            if (invoice.CreateUser.Length > 20)
            {
                return Result.Failure("建立者長度不可超過20個字元");
            }

            return Result.Success();
        }

        /// <summary>
        /// 根據ID取得發票資料
        /// </summary>
        /// <param name="invoiceId">發票ID</param>
        /// <returns>發票資料</returns>
        public static ARInvoice GetInvoiceById(int invoiceId)
        {
            if (invoiceId <= 0)
            {
                return null;
            }

            return ARInvoiceDAL.GetById(invoiceId);
        }

        /// <summary>
        /// 檢查發票號碼是否存在
        /// </summary>
        /// <param name="invoiceNumber">發票號碼</param>
        /// <returns>是否存在</returns>
        public static bool CheckInvoiceNumberExists(string invoiceNumber)
        {
            if (string.IsNullOrWhiteSpace(invoiceNumber))
            {
                return false;
            }

            return ARInvoiceDAL.IsInvoiceNumberExists(invoiceNumber);
        }
    }
} 