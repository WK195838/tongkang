# ARBANK 檔案規格書

## 基本資料
* **程式編號**：ARBANK
* **程式類型**：PF (實體檔案)
* **功能說明**：應收帳款承購 - 銀行基本資料檔

## 檔案功能說明
此檔案用於記錄應收帳款承購作業相關的銀行基本資料，包含銀行編號、名稱、帳號資訊、利率等資料。

## 紀錄格式

### 主檔紀錄 (RARBANK)
| 欄位代號 | 欄位名稱 | 位置 | 長度 | 型態 | 小數位 | 說明 |
|----------|----------|------|------|------|--------|------|
| ABFLAG | 處理註記 | - | 1 | A | - | 處理註記碼 |
| ABBKID | 銀行編號 | - | 3 | A | - | 銀行編號 |
| ABBKNM | 銀行名稱 | - | 10 | O | - | 銀行名稱 |
| ABACN1 | 支號 | - | 4 | A | - | 支號 |
| ABACN2 | 本行帳戶號碼 | - | 10 | A | - | 本行帳戶號碼 |
| ABSRTP | 手續費計算方式 | - | 1 | A | - | 手續費計算方式（1:依比例 2:固定金額） |
| ABSRCG | 手續費率 | - | 6 | S | 5 | 手續費率 |
| ABINRT | 貼現利率 | - | 6 | S | 5 | 貼現利率 |
| ABDAT1 | 合約起日 | - | 8 | S | 0 | 合約起日 |
| ABDAT2 | 合約迄日 | - | 8 | S | 0 | 合約迄日 |
| ABUPDM | 異動人員 | - | 10 | A | - | 異動人員 |
| ABUPDD | 異動日期 | - | 8 | S | 0 | 異動日期 |
| ABUPDT | 異動時間 | - | 6 | S | 0 | 異動時間 |

## 主鍵欄位
* ABBKID (銀行編號)

## 索引資料
* 唯一索引：ABBKID (銀行編號)

## 備註
* 手續費計算方式(ABSRTP)說明：
  - 1：依比例
  - 2：固定金額 