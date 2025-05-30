# ARCUCTG 檔案規格書

## 基本資料
* **程式編號**：ARCUCTG
* **程式類型**：PF (實體檔案)
* **功能說明**：客戶管制檔 (LOG檔案)
* **變更記錄**：2013HS227 1021114 S00WCJ

## 檔案功能說明
此檔案為客戶管制檔(ARCUCT)的LOG檔案，用於記錄客戶管制資訊的所有變更歷史，包含信用額度、付款條件等資料的異動紀錄。系統透過此檔案追蹤客戶管制設定的變更軌跡，作為稽核與歷史查詢之用。

## 紀錄格式

### LOG紀錄

| 欄位代號 | 欄位名稱 | 位置 | 長度 | 型態 | 小數位 | 說明 |
|----------|----------|------|------|------|--------|------|
| GCUSNO | 客戶編號 | - | 6 | A | - | 客戶編號 |
| GCNM | 客戶名稱 | - | 30 | A | - | 客戶名稱 |
| GCCRLT | 信用額度 | - | 11 | P | 2 | 信用額度金額 |
| GCARAG | 帳齡分類 | - | 1 | A | - | 帳齡分類代碼 |
| GCCRTP | 信用類別 | - | 1 | A | - | 信用等級分類 |
| GCPTY | 付款方式 | - | 1 | A | - | 付款方式代碼 |
| GCPTDT | 付款條件 | - | 2 | A | - | 付款條件代碼 |
| GCMAN | 負責業務 | - | 6 | A | - | 負責業務人員代號 |
| GCAREA | 客戶區域 | - | 3 | A | - | 客戶所在區域代碼 |
| GCCTST | 管制狀態 | - | 1 | A | - | 帳款管制狀態 |
| GCCLDT | 關帳日期 | - | 8 | A | - | 最後關帳日期 (YYYYMMDD) |
| GCOVTP | 超額處理 | - | 1 | A | - | 信用超額處理方式 |
| GCUSTP | 客戶類型 | - | 1 | A | - | 客戶類型代碼 |
| GCBKTP | 銀行往來 | - | 1 | A | - | 銀行往來評等 |
| GCNOTE | 備註說明 | - | 50 | A | - | 客戶管制備註說明 |
| GCSTDT | 停用日期 | - | 8 | A | - | 客戶停用日期 (YYYYMMDD) |
| GCFGDT | 凍結日期 | - | 8 | A | - | 帳款凍結日期 (YYYYMMDD) |
| GCLOGD | 記錄日期 | - | 8 | A | - | 記錄日期 (YYYYMMDD) |
| GCLOGT | 記錄時間 | - | 6 | A | - | 記錄時間 (HHMMSS) |
| GCTYPE | 異動類型 | - | 1 | A | - | 異動類型 (A-新增/C-修改/D-刪除) |
| GCUSR | 異動人員 | - | 10 | A | - | 異動人員代號 |
| GCPGM | 程式代號 | - | 10 | A | - | 異動程式代號 |
| GCMSG | 異動說明 | - | 50 | A | - | 異動原因說明 |

## 主鍵欄位
* GCUSNO (客戶編號)
* GCLOGD (記錄日期)
* GCLOGT (記錄時間)

## 索引資料
* 主索引：GCUSNO + GCLOGD + GCLOGT (客戶編號 + 記錄日期 + 記錄時間)
* 次索引：GCLOGD + GCLOGT (記錄日期 + 記錄時間)
* 次索引：GCUSR (異動人員)

## 備註
* 此檔案記錄客戶管制檔(ARCUCT)的所有異動歷史，保留完整的變更軌跡
* 每筆異動都會記錄異動前的完整資料內容，作為追蹤溯源使用
* 異動類型(GCTYPE)欄位區分為新增(A)、修改(C)、刪除(D)三種
* 系統會自動記錄異動時間、異動人員及異動程式等稽核資訊
* 此檔案通常用於解釋客戶信用額度或管制狀態的變動原因
* 使用此檔案可追蹤客戶管制設定的歷史變更，協助問題調查與稽核
* 於2013年10月11日進行系統更新 (專案編號：2013HS227) 