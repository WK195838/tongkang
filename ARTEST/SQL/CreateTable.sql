-- ===============================================
-- 應收帳款登錄系統 - 資料庫建立腳本
-- 建立日期：2024
-- 說明：建立AR_Invoice資料表及相關索引
-- ===============================================

-- 檢查資料庫是否存在，如不存在則建立
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'ERP_DB')
BEGIN
    CREATE DATABASE ERP_DB
    PRINT '資料庫 ERP_DB 建立成功'
END
ELSE
BEGIN
    PRINT '資料庫 ERP_DB 已存在'
END
GO

-- 使用ERP_DB資料庫
USE ERP_DB
GO

-- 檢查AR_Invoice表格是否存在，如存在則刪除
IF OBJECT_ID('dbo.AR_Invoice', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.AR_Invoice
    PRINT 'AR_Invoice表格已刪除'
END
GO

-- 建立AR_Invoice表格
CREATE TABLE dbo.AR_Invoice (
    InvoiceID       INT IDENTITY(1,1) NOT NULL,    -- 唯一識別碼（主鍵、自動編號）
    CustomerCode    VARCHAR(20) NOT NULL,          -- 客戶代號
    InvoiceNumber   VARCHAR(30) NOT NULL,          -- 發票號碼（唯一）
    InvoiceDate     DATE NOT NULL,                 -- 發票日期
    DueDate         DATE NOT NULL,                 -- 到期日
    Amount          DECIMAL(18,2) NOT NULL,        -- 應收金額
    AccountCode     VARCHAR(10) NOT NULL,          -- 科目代號
    Remark          NVARCHAR(200) NULL,            -- 備註
    CreateUser      VARCHAR(20) NOT NULL,          -- 建立者
    CreateDate      DATETIME NOT NULL,             -- 建立時間

    -- 設定主鍵
    CONSTRAINT PK_AR_Invoice PRIMARY KEY CLUSTERED (InvoiceID),
    
    -- 設定唯一索引（發票號碼不可重複）
    CONSTRAINT UK_AR_Invoice_InvoiceNumber UNIQUE NONCLUSTERED (InvoiceNumber),
    
    -- 設定檢查約束
    CONSTRAINT CK_AR_Invoice_Amount CHECK (Amount > 0),                    -- 金額必須大於0
    CONSTRAINT CK_AR_Invoice_DueDate CHECK (DueDate >= InvoiceDate),       -- 到期日不可早於發票日期
    CONSTRAINT CK_AR_Invoice_CustomerCode CHECK (LEN(CustomerCode) > 0),   -- 客戶代號不可空白
    CONSTRAINT CK_AR_Invoice_InvoiceNumber CHECK (LEN(InvoiceNumber) > 0), -- 發票號碼不可空白
    CONSTRAINT CK_AR_Invoice_AccountCode CHECK (LEN(AccountCode) > 0),     -- 科目代號不可空白
    CONSTRAINT CK_AR_Invoice_CreateUser CHECK (LEN(CreateUser) > 0)        -- 建立者不可空白
)
GO

-- 建立非叢集索引以提升查詢效能
-- 客戶代號索引
CREATE NONCLUSTERED INDEX IX_AR_Invoice_CustomerCode 
ON dbo.AR_Invoice (CustomerCode)
GO

-- 發票日期索引
CREATE NONCLUSTERED INDEX IX_AR_Invoice_InvoiceDate 
ON dbo.AR_Invoice (InvoiceDate)
GO

-- 到期日索引
CREATE NONCLUSTERED INDEX IX_AR_Invoice_DueDate 
ON dbo.AR_Invoice (DueDate)
GO

-- 科目代號索引
CREATE NONCLUSTERED INDEX IX_AR_Invoice_AccountCode 
ON dbo.AR_Invoice (AccountCode)
GO

-- 建立者和建立時間複合索引
CREATE NONCLUSTERED INDEX IX_AR_Invoice_CreateUserDate 
ON dbo.AR_Invoice (CreateUser, CreateDate)
GO

-- 插入測試資料
INSERT INTO dbo.AR_Invoice (
    CustomerCode, 
    InvoiceNumber, 
    InvoiceDate, 
    DueDate, 
    Amount, 
    AccountCode, 
    Remark, 
    CreateUser, 
    CreateDate
) VALUES 
    ('C001', 'INV20240001', '2024-01-15', '2024-02-14', 50000.00, '1103', '第一筆測試資料', 'ADMIN', GETDATE()),
    ('C002', 'INV20240002', '2024-01-16', '2024-02-15', 75000.00, '1103', '第二筆測試資料', 'ADMIN', GETDATE()),
    ('C003', 'INV20240003', '2024-01-17', '2024-02-16', 120000.00, '1103', '第三筆測試資料', 'ADMIN', GETDATE())
GO

-- 建立科目代號參考表格（可選）
IF OBJECT_ID('dbo.AccountCodes', 'U') IS NOT NULL
BEGIN
    DROP TABLE dbo.AccountCodes
END
GO

CREATE TABLE dbo.AccountCodes (
    AccountCode VARCHAR(10) NOT NULL,
    AccountName NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    
    CONSTRAINT PK_AccountCodes PRIMARY KEY (AccountCode)
)
GO

-- 插入科目代號資料
INSERT INTO dbo.AccountCodes (AccountCode, AccountName, IsActive) VALUES
    ('1101', '現金', 1),
    ('1102', '銀行存款', 1),
    ('1103', '應收帳款', 1),
    ('1104', '票據', 1),
    ('1105', '其他應收款', 1)
GO

-- 建立外鍵約束（連結科目代號表格）
ALTER TABLE dbo.AR_Invoice 
ADD CONSTRAINT FK_AR_Invoice_AccountCode 
FOREIGN KEY (AccountCode) REFERENCES dbo.AccountCodes(AccountCode)
GO

-- 檢視表格資訊
SELECT 
    TABLE_NAME,
    COLUMN_NAME,
    DATA_TYPE,
    CHARACTER_MAXIMUM_LENGTH,
    IS_NULLABLE,
    COLUMN_DEFAULT
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_NAME = 'AR_Invoice'
ORDER BY ORDINAL_POSITION
GO

-- 檢視建立的索引
SELECT 
    i.name AS IndexName,
    i.type_desc AS IndexType,
    c.name AS ColumnName
FROM sys.indexes i
    INNER JOIN sys.index_columns ic ON i.object_id = ic.object_id AND i.index_id = ic.index_id
    INNER JOIN sys.columns c ON ic.object_id = c.object_id AND ic.column_id = c.column_id
    INNER JOIN sys.tables t ON i.object_id = t.object_id
WHERE t.name = 'AR_Invoice'
ORDER BY i.name, ic.key_ordinal
GO

-- 驗證資料
SELECT 
    COUNT(*) AS TotalRecords,
    MIN(InvoiceDate) AS EarliestInvoice,
    MAX(InvoiceDate) AS LatestInvoice,
    SUM(Amount) AS TotalAmount
FROM dbo.AR_Invoice
GO

PRINT '資料庫建立完成！'
PRINT '表格：AR_Invoice、AccountCodes'
PRINT '索引：已建立所需的索引以提升查詢效能'
PRINT '測試資料：已插入3筆範例資料' 