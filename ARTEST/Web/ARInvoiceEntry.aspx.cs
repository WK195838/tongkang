using System;
using System.Web.UI;
using ARTEST.Models;
using ARTEST.BLL;

namespace ARTEST.Web
{
    /// <summary>
    /// 應收帳款登錄頁面
    /// </summary>
    public partial class ARInvoiceEntry : System.Web.UI.Page
    {
        /// <summary>
        /// 頁面載入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializePage();
            }
        }

        /// <summary>
        /// 初始化頁面
        /// </summary>
        private void InitializePage()
        {
            // 設定預設日期為今天
            txtInvoiceDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtDueDate.Text = DateTime.Today.AddDays(30).ToString("yyyy-MM-dd");
            
            // 清除訊息
            lblMessage.Visible = false;
        }

        /// <summary>
        /// 儲存按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                // 取得使用者輸入資料
                var arData = GetFormData();
                if (arData == null)
                {
                    return;
                }

                // 呼叫業務邏輯層儲存資料
                var result = ARInvoiceBLL.SaveARInvoice(arData);

                // 顯示結果訊息
                DisplayMessage(result);

                // 如果成功，清除表單
                if (result.IsSuccess)
                {
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                DisplayMessage(Result.Failure($"系統錯誤：{ex.Message}"));
            }
        }

        /// <summary>
        /// 清除按鈕點擊事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            lblMessage.Visible = false;
        }

        /// <summary>
        /// 取得表單資料
        /// </summary>
        /// <returns>應收帳款發票物件</returns>
        private ARInvoice GetFormData()
        {
            try
            {
                var invoice = new ARInvoice
                {
                    CustomerCode = txtCustomerCode.Text.Trim(),
                    InvoiceNumber = txtInvoiceNumber.Text.Trim(),
                    InvoiceDate = Convert.ToDateTime(txtInvoiceDate.Text),
                    DueDate = Convert.ToDateTime(txtDueDate.Text),
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    AccountCode = ddlAccountCode.SelectedValue,
                    Remark = txtRemark.Text.Trim(),
                    CreateUser = GetCurrentUser(),
                    CreateDate = DateTime.Now
                };

                return invoice;
            }
            catch (FormatException)
            {
                DisplayMessage(Result.Failure("輸入格式錯誤，請檢查日期和金額格式"));
                return null;
            }
            catch (Exception ex)
            {
                DisplayMessage(Result.Failure($"資料處理錯誤：{ex.Message}"));
                return null;
            }
        }

        /// <summary>
        /// 取得目前使用者
        /// </summary>
        /// <returns>使用者ID</returns>
        private string GetCurrentUser()
        {
            // 從Session取得使用者資訊
            if (Session["UserID"] != null)
            {
                return Session["UserID"].ToString();
            }

            // 如果沒有登入資訊，使用預設值
            return "SYSTEM";
        }

        /// <summary>
        /// 顯示訊息
        /// </summary>
        /// <param name="result">操作結果</param>
        private void DisplayMessage(Result result)
        {
            lblMessage.Visible = true;
            
            if (result.IsSuccess)
            {
                lblMessage.Text = "資料儲存成功！";
                lblMessage.CssClass = "message success";
            }
            else
            {
                lblMessage.Text = result.ErrorMessage;
                lblMessage.CssClass = "message error";
            }
        }

        /// <summary>
        /// 清除表單
        /// </summary>
        private void ClearForm()
        {
            txtCustomerCode.Text = string.Empty;
            txtInvoiceNumber.Text = string.Empty;
            txtInvoiceDate.Text = DateTime.Today.ToString("yyyy-MM-dd");
            txtDueDate.Text = DateTime.Today.AddDays(30).ToString("yyyy-MM-dd");
            txtAmount.Text = string.Empty;
            ddlAccountCode.SelectedIndex = 0;
            txtRemark.Text = string.Empty;

            // 將焦點設回第一個欄位
            txtCustomerCode.Focus();
        }

        /// <summary>
        /// 頁面預先渲染事件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            // 註冊用戶端腳本
            string script = @"
                // 數字格式化
                function formatNumber(input) {
                    var value = input.value.replace(/[^0-9.]/g, '');
                    if (value) {
                        input.value = parseFloat(value).toFixed(2);
                    }
                }

                // 綁定金額欄位失焦事件
                document.getElementById('" + txtAmount.ClientID + @"').addEventListener('blur', function() {
                    formatNumber(this);
                });

                // AJAX檢查發票號碼是否重複
                function checkInvoiceNumber() {
                    var invoiceNumber = document.getElementById('" + txtInvoiceNumber.ClientID + @"').value;
                    if (invoiceNumber) {
                        // 這裡可以實作AJAX檢查邏輯
                        console.log('檢查發票號碼：' + invoiceNumber);
                    }
                }

                // 綁定發票號碼失焦事件
                document.getElementById('" + txtInvoiceNumber.ClientID + @"').addEventListener('blur', checkInvoiceNumber);
            ";

            ClientScript.RegisterStartupScript(this.GetType(), "FormEnhancements", script, true);
        }
    }
} 