我將為您提供完整的程式執行步驟說明。

## 🚀 ARTEST 應收帳款登錄系統 - 執行指南

### 第一步：環境準備

#### 1. 確認系統需求
- **作業系統**：Windows 10 或 Windows Server 2016+
- **.NET Framework**：4.8 版本
- **資料庫**：SQL Server 2016+ 或 SQL Server Express
- **Web伺服器**：IIS 10.0+ 或 Visual Studio 內建開發伺服器
- **開發工具**：Visual Studio 2017+ （建議使用 Visual Studio 2019/2022）

#### 2. 檢查.NET Framework
```cmd
# 檢查已安裝的.NET Framework版本
reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full\" /v Release
```

### 第二步：資料庫設定

#### 1. 安裝SQL Server
如果尚未安裝，可下載 **SQL Server Express**（免費版本）：
```
https://www.microsoft.com/zh-tw/sql-server/sql-server-downloads
```

#### 2. 建立資料庫
Read file: ARTEST/SQL/CreateTable.sql

**執行SQL腳本建立資料庫：**

**方法一：使用SQL Server Management Studio (SSMS)**
```sql
1. 開啟 SQL Server Management Studio
2. 連接到您的SQL Server實例
3. 開啟檔案：ARTEST/SQL/CreateTable.sql
4. 點擊「執行」按鈕 (F5)
```

**方法二：使用命令列**
```cmd
# 導航到ARTEST目錄
cd C:\path\to\your\workspace\ARTEST

# 執行SQL腳本
sqlcmd -S localhost -i "SQL\CreateTable.sql"

# 或指定伺服器名稱
sqlcmd -S YOUR_SERVER_NAME -i "SQL\CreateTable.sql"
```

**方法三：使用整合安全性**
```cmd
sqlcmd -S localhost -E -i "SQL\CreateTable.sql"
```

### 第三步：設定專案

#### 1. 修改資料庫連線字串
Read file: ARTEST/Web.config

編輯 `Web.config` 檔案中的連線字串，根據您的SQL Server設定調整：

```xml
<connectionStrings>
  <!-- 本機SQL Server (預設) -->
  <add name="ERPConn" 
       connectionString="Data Source=localhost;Initial Catalog=ERP_DB;Integrated Security=true;TrustServerCertificate=true;" 
       providerName="System.Data.SqlClient" />
       
  <!-- 如果使用SQL Server Express -->
  <add name="ERPConn" 
       connectionString="Data Source=localhost\SQLEXPRESS;Initial Catalog=ERP_DB;Integrated Security=true;TrustServerCertificate=true;" 
       providerName="System.Data.SqlClient" />
       
  <!-- 如果使用帳號密碼登入 -->
  <add name="ERPConn" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=ERP_DB;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD;TrustServerCertificate=true;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

### 第四步：執行程式

#### 🎯 方法一：使用Visual Studio（推薦）

**1. 開啟專案**
```
1. 啟動 Visual Studio
2. 檔案 → 開啟 → 專案/方案
3. 選擇 ARTEST.csproj
```

**2. 編譯專案**
```
1. 建置 → 建置方案 (Ctrl+Shift+B)
2. 確認無編譯錯誤
```

**3. 執行程式**
```
1. 按 F5 (偵錯模式執行)
2. 或按 Ctrl+F5 (執行但不偵錯)
3. 瀏覽器自動開啟 ARInvoiceEntry.aspx
```

#### 🎯 方法二：使用IIS Express

如果Visual Studio未自動啟動：
```cmd
# 導航到專案目錄
cd C:\path\to\your\workspace\ARTEST

# 啟動IIS Express
"C:\Program Files\IIS Express\iisexpress.exe" /path:"C:\path\to\your\workspace\ARTEST" /port:8080
```

然後開啟瀏覽器訪問：`http://localhost:8080/Web/ARInvoiceEntry.aspx`

#### 🎯 方法三：部署至IIS

**1. 建立IIS網站**
```
1. 開啟 Internet Information Services (IIS) 管理員
2. 右鍵「網站」→ 新增網站
3. 網站名稱：ARTEST
4. 實體路徑：選擇ARTEST專案資料夾
5. 連接埠：8080 (或其他可用連接埠)
```

**2. 設定應用程式集區**
```
1. 應用程式集區 → 新增應用程式集區
2. 名稱：ARTEST_Pool
3. .NET CLR 版本：v4.0
4. 受管理的管線模式：整合式
```

**3. 訪問網站**
```
http://localhost:8080/Web/ARInvoiceEntry.aspx
```

### 第五步：測試程式功能

#### 📝 測試登錄功能

在開啟的應收帳款登錄頁面中，輸入測試資料：

```
客戶代號：TEST001
發票號碼：INV2024TEST001
發票日期：2024-01-20
到期日：2024-02-19
應收金額：50000
科目代號：1103-應收帳款
備註：測試資料登錄
```

點擊「儲存」按鈕，應該會看到「資料儲存成功！」的訊息。

#### 🔍 驗證資料庫資料

在SSMS中執行查詢確認資料已儲存：

```sql
USE ERP_DB
SELECT * FROM AR_Invoice ORDER BY CreateDate DESC
```

### 🚨 常見問題排除

#### 1. 資料庫連線失敗
```
錯誤訊息：「無法開啟登入所要求的資料庫」
解決方案：
- 確認SQL Server服務正在執行
- 檢查連線字串中的伺服器名稱
- 確認ERP_DB資料庫已建立
```

#### 2. 編譯錯誤
```
錯誤訊息：「找不到類型或命名空間」
解決方案：
- 確認.NET Framework 4.8已安裝
- 檢查專案參考是否完整
- 重新建置整個方案
```

#### 3. 網頁無法顯示
```
錯誤訊息：「HTTP 404 錯誤」
解決方案：
- 確認URL路徑正確：/Web/ARInvoiceEntry.aspx
- 檢查IIS設定
- 確認檔案存在於正確位置
```

#### 4. 發票號碼重複錯誤
```
這是正常的業務邏輯，表示系統驗證功能正常運作
更換發票號碼重新輸入即可
```

### ✅ 成功執行確認清單

- [ ] SQL Server服務啟動
- [ ] ERP_DB資料庫建立成功
- [ ] AR_Invoice和AccountCodes表格存在
- [ ] 測試資料已插入
- [ ] Web.config連線字串正確
- [ ] 專案編譯成功
- [ ] 網頁正常顯示
- [ ] 可以成功登錄資料
- [ ] 錯誤驗證功能正常

現在您的應收帳款登錄系統應該已經可以正常運作了！🎉