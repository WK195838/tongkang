# ARCUDT 檔案規格書

## 基本資料
* **程式編號**：ARCUDT
* **程式類型**：PF (實體檔案)
* **功能說明**：應收帳款承購 - 客戶基本資料檔

## 檔案功能說明
此檔案用於儲存應收帳款承購業務的客戶基本資料，包含客戶名稱、地址、聯絡資訊、往來條件等，作為承購業務執行的基礎資料。系統使用此檔案進行承購銷貨資料驗證、客戶資料查詢及報表列印。

## 紀錄格式

### 主檔紀錄

| 欄位代號 | 欄位名稱 | 位置 | 長度 | 型態 | 小數位 | 說明 |
|----------|----------|------|------|------|--------|------|
| CDCUNO | 客戶編號 | - | 6 | A | - | 客戶編號，主鍵 |
| CDCUNM | 客戶名稱 | - | 30 | A | - | 客戶中文名稱 |
| CDCUNME | 英文名稱 | - | 30 | A | - | 客戶英文名稱 |
| CDCUAD1 | 客戶地址1 | - | 30 | A | - | 客戶地址第1行 |
| CDCUAD2 | 客戶地址2 | - | 30 | A | - | 客戶地址第2行 |
| CDCUAD3 | 客戶地址3 | - | 30 | A | - | 客戶地址第3行 |
| CDCUADE | 英文地址 | - | 60 | A | - | 客戶英文地址 |
| CDTELNO | 電話號碼 | - | 15 | A | - | 客戶電話號碼 |
| CDFAXNO | 傳真號碼 | - | 15 | A | - | 客戶傳真號碼 |
| CDCONTC | 聯絡人 | - | 20 | A | - | 客戶聯絡人姓名 |
| CDTAXID | 統一編號 | - | 8 | A | - | 客戶統一編號 |
| CDREGID | 登記證號 | - | 12 | A | - | 客戶營業登記證號 |
| CDBANK | 往來銀行 | - | 3 | A | - | 往來銀行代號 |
| CDBKBR | 分行代號 | - | 4 | A | - | 往來銀行分行代號 |
| CDBKNM | 分行名稱 | - | 20 | A | - | 往來銀行分行名稱 |
| CDBKAC | 銀行帳號 | - | 20 | A | - | 往來銀行帳號 |
| CDCRCD | 信用等級 | - | 1 | A | - | 客戶信用等級 |
| CDSTATUS | 狀態代碼 | - | 1 | A | - | 客戶狀態代碼 (A-使用/S-暫停/D-停用) |
| CDMARK | 客戶註記 | - | 40 | A | - | 客戶特殊狀況註記 |
| CDCDT | 建檔日期 | - | 8 | A | - | 建檔日期 (YYYYMMDD) |
| CDUSR | 建檔人員 | - | 10 | A | - | 建檔人員代號 |
| CDUPUS | 修改人員 | - | 10 | A | - | 最後修改人員代號 |
| CDUPDT | 修改日期 | - | 8 | A | - | 最後修改日期 (YYYYMMDD) |
| CDUPTM | 修改時間 | - | 6 | A | - | 最後修改時間 (HHMMSS) |

## 主鍵欄位
* CDCUNO (客戶編號)

## 索引資料
* 主索引：CDCUNO (客戶編號)
* 次索引：CDCUNM (客戶名稱)
* 次索引：CDTAXID (統一編號)

## 備註
* 此檔案為應收帳款承購業務的客戶基本資料主檔
* 與客戶管制檔(ARCUCT)搭配使用，共同構成完整的客戶資訊
* 客戶基本資料用於系統中各項交易的客戶資訊確認和顯示
* 客戶狀態代碼(CDSTATUS)控制客戶是否可以進行承購交易
* 英文名稱和地址用於產生英文報表和文件
* 系統會根據客戶的信用等級(CDCRCD)進行不同的承購處理流程
* 修改客戶資料時會自動記錄異動人員、日期和時間，便於追蹤管理 