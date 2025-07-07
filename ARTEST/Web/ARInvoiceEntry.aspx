<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ARInvoiceEntry.aspx.cs" Inherits="ARTEST.Web.ARInvoiceEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>應收帳款登錄</title>
    <style type="text/css">
        body {
            font-family: '微軟正黑體', Arial, sans-serif;
            margin: 0;
            padding: 20px;
            background-color: #f5f5f5;
        }
        .container {
            max-width: 800px;
            margin: 0 auto;
            background-color: white;
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 2px 10px rgba(0,0,0,0.1);
        }
        .header {
            text-align: center;
            color: #2c3e50;
            margin-bottom: 30px;
            border-bottom: 2px solid #3498db;
            padding-bottom: 15px;
        }
        .form-group {
            margin-bottom: 15px;
            display: flex;
            align-items: center;
        }
        .form-label {
            width: 120px;
            font-weight: bold;
            color: #34495e;
            margin-right: 10px;
        }
        .form-control {
            flex: 1;
            padding: 8px 12px;
            border: 1px solid #bdc3c7;
            border-radius: 4px;
            font-size: 14px;
        }
        .form-control:focus {
            border-color: #3498db;
            outline: none;
            box-shadow: 0 0 5px rgba(52, 152, 219, 0.3);
        }
        .required {
            color: red;
        }
        .btn {
            padding: 10px 30px;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            font-size: 16px;
            margin: 5px;
        }
        .btn-primary {
            background-color: #3498db;
            color: white;
        }
        .btn-primary:hover {
            background-color: #2980b9;
        }
        .btn-secondary {
            background-color: #95a5a6;
            color: white;
        }
        .btn-secondary:hover {
            background-color: #7f8c8d;
        }
        .button-group {
            text-align: center;
            margin-top: 30px;
            padding-top: 20px;
            border-top: 1px solid #ecf0f1;
        }
        .message {
            padding: 10px;
            margin: 15px 0;
            border-radius: 4px;
            text-align: center;
            font-weight: bold;
        }
        .message.success {
            background-color: #d4edda;
            color: #155724;
            border: 1px solid #c3e6cb;
        }
        .message.error {
            background-color: #f8d7da;
            color: #721c24;
            border: 1px solid #f5c6cb;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="header">
                <h2>應收帳款登錄系統</h2>
            </div>
            
            <asp:Label ID="lblMessage" runat="server" CssClass="message" Visible="false"></asp:Label>
            
            <div class="form-group">
                <label class="form-label">客戶代號 <span class="required">*</span>:</label>
                <asp:TextBox ID="txtCustomerCode" runat="server" CssClass="form-control" MaxLength="20" placeholder="請輸入客戶代號"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">發票號碼 <span class="required">*</span>:</label>
                <asp:TextBox ID="txtInvoiceNumber" runat="server" CssClass="form-control" MaxLength="30" placeholder="請輸入發票號碼"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">發票日期 <span class="required">*</span>:</label>
                <asp:TextBox ID="txtInvoiceDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">到期日 <span class="required">*</span>:</label>
                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">應收金額 <span class="required">*</span>:</label>
                <asp:TextBox ID="txtAmount" runat="server" CssClass="form-control" TextMode="Number" step="0.01" placeholder="請輸入金額"></asp:TextBox>
            </div>
            
            <div class="form-group">
                <label class="form-label">科目代號 <span class="required">*</span>:</label>
                <asp:DropDownList ID="ddlAccountCode" runat="server" CssClass="form-control">
                    <asp:ListItem Value="">請選擇科目</asp:ListItem>
                    <asp:ListItem Value="1101">1101-現金</asp:ListItem>
                    <asp:ListItem Value="1102">1102-銀行存款</asp:ListItem>
                    <asp:ListItem Value="1103">1103-應收帳款</asp:ListItem>
                    <asp:ListItem Value="1104">1104-票據</asp:ListItem>
                    <asp:ListItem Value="1105">1105-其他應收款</asp:ListItem>
                </asp:DropDownList>
            </div>
            
            <div class="form-group">
                <label class="form-label">備註:</label>
                <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" MaxLength="200" placeholder="請輸入備註（選填）"></asp:TextBox>
            </div>
            
            <div class="button-group">
                <asp:Button ID="btnSave" runat="server" Text="儲存" CssClass="btn btn-primary" OnClick="btnSave_Click" />
                <asp:Button ID="btnClear" runat="server" Text="清除" CssClass="btn btn-secondary" OnClick="btnClear_Click" />
            </div>
        </div>
    </form>
    
    <script type="text/javascript">
        // 表單驗證
        function validateForm() {
            var customerCode = document.getElementById('<%= txtCustomerCode.ClientID %>').value;
            var invoiceNumber = document.getElementById('<%= txtInvoiceNumber.ClientID %>').value;
            var invoiceDate = document.getElementById('<%= txtInvoiceDate.ClientID %>').value;
            var dueDate = document.getElementById('<%= txtDueDate.ClientID %>').value;
            var amount = document.getElementById('<%= txtAmount.ClientID %>').value;
            var accountCode = document.getElementById('<%= ddlAccountCode.ClientID %>').value;
            
            if (!customerCode) {
                alert('請輸入客戶代號');
                return false;
            }
            
            if (!invoiceNumber) {
                alert('請輸入發票號碼');
                return false;
            }
            
            if (!invoiceDate) {
                alert('請選擇發票日期');
                return false;
            }
            
            if (!dueDate) {
                alert('請選擇到期日');
                return false;
            }
            
            if (!amount || parseFloat(amount) <= 0) {
                alert('請輸入正確的金額');
                return false;
            }
            
            if (!accountCode) {
                alert('請選擇科目代號');
                return false;
            }
            
            if (new Date(dueDate) < new Date(invoiceDate)) {
                alert('到期日不可早於發票日期');
                return false;
            }
            
            return true;
        }
        
        // 綁定儲存按鈕點擊事件
        document.getElementById('<%= btnSave.ClientID %>').addEventListener('click', function(e) {
            if (!validateForm()) {
                e.preventDefault();
            }
        });
    </script>
</body>
</html> 