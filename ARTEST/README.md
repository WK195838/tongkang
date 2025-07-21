# ARTEST - 應收帳款登錄系統

## 專案概述

ARTEST是一個基於ASP.NET Web Forms (.NET Framework 4.8) 建置的應收帳款登錄系統，提供會計人員透過Web瀏覽器進行應收帳款資料的登錄、驗證和管理功能。

## 系統架構

### 技術規格
- **開發平台**: ASP.NET Web Application (.NET Framework 4.8)
- **資料庫**: Microsoft SQL Server 2019
- **前端技術**: HTML5, CSS3, JavaScript, ASP.NET Web Forms
- **後端技術**: C#.NET, ADO.NET

### 架構圖
```
[ Web UI (ASPX) ] 
       ↓
[ Controller Layer (ASPX.CS) ]
       ↓
[ Business Logic Layer (BLL) ]
       ↓
[ Data Access Layer (DAL) ]
       ↓
[ SQL Server Database ]
```

## 專案結構

```
ARTEST/
├── Models/                 # 實體類別
│   ├── ARInvoice.cs       # 應收帳款發票實體
│   └── Result.cs          # 操作結果類別
├── DAL/                   # 資料存取層
│   └── ARInvoiceDAL.cs    # 應收帳款資料存取
├── BLL/                   # 業務邏輯層
│   └── ARInvoiceBLL.cs    # 應收帳款業務邏輯
├── Web/                   # 前端頁面
│   ├── ARInvoiceEntry.aspx    # 登錄頁面
│   └── ARInvoiceEntry.aspx.cs # 頁面程式碼後置
├── SQL/                   # 資料庫腳本
│   └── CreateTable.sql    # 建立資料表腳本
├── Properties/            # 專案屬性
│   └── AssemblyInfo.cs    # 組件資訊
├── Web.config            # 應用程式設定
├── ARTEST.csproj         # 專案檔案
└── README.md             # 專案說明
```

## 功能特色

### 核心功能
- ✅ 應收帳款資料登錄
- ✅ 輸入資料驗證
- ✅ 發票號碼唯一性檢查
- ✅ 金額格式驗證
- ✅ 日期邏輯驗證
- ✅ 錯誤訊息顯示
- ✅ 表單清除功能

### 資料驗證規則
- 客戶代號：必填，最大20字元
- 發票號碼：必填，唯一值，最大30字元
- 發票日期：必填
- 到期日：必填，不可早於發票日期
- 應收金額：必填，必須大於0
- 科目代號：必填，從下拉選單選擇
- 備註：選填，最大200字元

## 安裝與設定

### 1. 環境需求
- Windows Server 2016 或以上
- IIS 10.0 或以上
- .NET Framework 4.8
- SQL Server 2016 或以上
- Visual Studio 2017 或以上（開發環境）

### 2. 資料庫設定
```sql
-- 1. 執行SQL腳本建立資料庫
sqlcmd -S localhost -i "SQL\CreateTable.sql"

-- 2. 確認資料表建立成功
USE ERP_DB
SELECT * FROM AR_Invoice
SELECT * FROM AccountCodes
```

### 3. 應用程式設定
1. 修改 `Web.config` 中的連線字串：
```xml
<connectionStrings>
  <add name="ERPConn" 
       connectionString="Data Source=YOUR_SERVER;Initial Catalog=ERP_DB;Integrated Security=true;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

2. 在IIS中建立網站：
   - 應用程式集區：.NET Framework v4.0
   - 託管管線模式：整合式
   - 身分識別：ApplicationPoolIdentity

### 4. 編譯與部署
```bash
# 使用Visual Studio
1. 開啟 ARTEST.csproj
2. 建置方案 (Ctrl+Shift+B)
3. 發行至IIS

# 使用MSBuild
msbuild ARTEST.csproj /p:Configuration=Release
```

## 使用方式

### 登錄應收帳款
1. 開啟瀏覽器，導航至 `http://yourserver/ARInvoiceEntry.aspx`
2. 填寫必要欄位：
   - 客戶代號
   - 發票號碼
   - 發票日期
   - 到期日
   - 應收金額
   - 科目代號
3. 填寫選填欄位：
   - 備註
4. 點擊「儲存」按鈕
5. 系統顯示成功或錯誤訊息

### 表單操作
- **儲存**：驗證並儲存資料
- **清除**：清空所有輸入欄位
- **自動驗證**：即時檢查輸入格式

## 資料庫設計

### AR_Invoice 表格
| 欄位名稱 | 資料型別 | 說明 | 約束 |
|---------|----------|------|------|
| InvoiceID | INT | 主鍵 | IDENTITY(1,1) |
| CustomerCode | VARCHAR(20) | 客戶代號 | NOT NULL |
| InvoiceNumber | VARCHAR(30) | 發票號碼 | NOT NULL, UNIQUE |
| InvoiceDate | DATE | 發票日期 | NOT NULL |
| DueDate | DATE | 到期日 | NOT NULL |
| Amount | DECIMAL(18,2) | 應收金額 | NOT NULL, >0 |
| AccountCode | VARCHAR(10) | 科目代號 | NOT NULL |
| Remark | NVARCHAR(200) | 備註 | NULL |
| CreateUser | VARCHAR(20) | 建立者 | NOT NULL |
| CreateDate | DATETIME | 建立時間 | NOT NULL |

### 索引設計
- PK_AR_Invoice (主鍵)
- UK_AR_Invoice_InvoiceNumber (唯一索引)
- IX_AR_Invoice_CustomerCode
- IX_AR_Invoice_InvoiceDate
- IX_AR_Invoice_DueDate
- IX_AR_Invoice_AccountCode

## 錯誤處理

### 常見錯誤及解決方案
1. **發票號碼重複**
   - 錯誤：「發票號碼已存在，請使用不同的發票號碼」
   - 解決：更換發票號碼

2. **金額格式錯誤**
   - 錯誤：「應收金額必須大於零」
   - 解決：輸入正確的數值

3. **日期邏輯錯誤**
   - 錯誤：「到期日不可早於發票日期」
   - 解決：調整日期設定

4. **連線失敗**
   - 錯誤：「資料庫錯誤」
   - 解決：檢查連線字串和資料庫狀態

## 測試案例

### 正常流程測試
```
客戶代號：C001
發票號碼：INV20240001
發票日期：2024-01-15
到期日：2024-02-14
金額：50000.00
科目：1103
備註：測試資料
```

### 異常情境測試
- 空白必填欄位
- 重複發票號碼
- 負數金額
- 到期日早於發票日期

## 後續擴充功能

### 已規劃功能
- [ ] 應收帳款查詢功能
- [ ] 批次資料匯入 (Excel)
- [ ] 應收帳款報表
- [ ] 客戶主檔維護
- [ ] 權限管理系統
- [ ] 操作記錄追蹤

### API化支援
- [ ] RESTful API設計
- [ ] JSON資料格式
- [ ] 跨平台前端支援

## 支援與維護

### 開發團隊聯絡資訊
- 專案負責人：ERP開發團隊
- 技術支援：請透過內部工單系統
- 文件更新：隨版本發布更新

### 版本歷史
- v1.0.0 (2024) - 初始版本
  - 應收帳款登錄功能
  - 基本資料驗證
  - 資料庫整合

---

**注意事項**：
1. 部署前請確認資料庫連線設定
2. 建議在測試環境先行驗證
3. 定期備份資料庫資料
4. 遵循公司資安政策進行部署 