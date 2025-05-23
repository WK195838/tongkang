# ARADJM 檔案規格書

## 基本資料
* **程式編號**：ARADJM
* **程式類型**：PF (實體檔案)
* **功能說明**：扣物調折扣紀錄檔

## 檔案功能說明
此檔案用於記錄客戶扣物調折扣的相關資訊，包含發票資訊、調整前後的數量與金額等詳細資料。

## 紀錄格式

### 主檔紀錄 (RARADJM)
| 欄位代號 | 欄位名稱 | 位置 | 長度 | 型態 | 小數位 | 說明 |
|----------|----------|------|------|------|--------|------|
| AMFLAG | 處理註記 | - | 1 | A | - | 處理註記碼 |
| AMCUNO | 客戶編號 | - | 6 | A | - | 客戶編號 |
| AMCUNM | 客戶名稱 | - | 10 | A | - | 客戶名稱 |
| AMORNO | 訂單編號 | - | 6 | A | - | 訂單編號 |
| AMSALE | 業務類別 | - | 2 | A | - | 業務類別 |
| AMAREA | 廠區別 | - | 1 | A | - | 廠區別 |
| AMINNO | 發票號碼 | - | 10 | A | - | 發票號碼 |
| AMACNT | 發票聯別 | - | 1 | A | - | 發票聯別 |
| AMITEM | 發票項次 | - | 2 | S | 0 | 發票項次 |
| AMINDT | 發票日期 | - | 8 | S | 0 | 發票日期 |
| AMDECD | 發票作廢碼 | - | 1 | A | - | 發票作廢碼 |
| AMDEDT | 發票作廢日期 | - | 8 | S | 0 | 發票作廢日期 |
| AMTXNO | 稅號編號 | - | 8 | A | - | 稅號編號 |
| AMDATE | 出貨日期 | - | 8 | S | 0 | 出貨日期 |
| AMPDNM | 品名 | - | 3 | A | - | 品名 |
| AMQTY1 | 原出貨數量 | - | 7 | P | 0 | 原出貨數量 |
| AMPRC1 | 原出貨單價 | - | 5 | P | 3 | 原出貨單價 |
| AMAMT1 | 原出貨金額 | - | 11 | P | 0 | 原出貨金額 |
| AMQTY2 | 調整數量 | - | 7 | P | 0 | 調整數量 |
| AMPRC2 | 調整單價 | - | 5 | P | 3 | 調整單價 |
| AMAMT2 | 調整金額 | - | 9 | P | 0 | 調整金額 |
| AMUPDM | 異動人員 | - | 10 | A | - | 異動人員 |
| AMUPDD | 異動日期 | - | 8 | S | 0 | 異動日期 |
| AMUPDT | 異動時間 | - | 6 | S | 0 | 異動時間 |
| AMRESV | 保留碼 | - | 10 | A | - | 保留碼 |

## 主鍵欄位
* AMINNO (發票號碼)
* AMACNT (發票聯別)
* AMITEM (發票項次)

## 索引資料
* 唯一索引：AMINNO + AMACNT + AMITEM

## 備註
* 此檔案主要用於記錄銷貨發票的調整折扣資訊 