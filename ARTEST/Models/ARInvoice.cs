using System;

namespace ARTEST.Models
{
    /// <summary>
    /// 應收帳款發票實體類別
    /// </summary>
    public class ARInvoice
    {
        /// <summary>
        /// 唯一識別碼
        /// </summary>
        public int InvoiceID { get; set; }

        /// <summary>
        /// 客戶代號
        /// </summary>
        public string CustomerCode { get; set; }

        /// <summary>
        /// 發票日期
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// 到期日
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 應收金額
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 發票號碼 (需唯一)
        /// </summary>
        public string InvoiceNumber { get; set; }

        /// <summary>
        /// 科目代號
        /// </summary>
        public string AccountCode { get; set; }

        /// <summary>
        /// 備註
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 建立者
        /// </summary>
        public string CreateUser { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
} 