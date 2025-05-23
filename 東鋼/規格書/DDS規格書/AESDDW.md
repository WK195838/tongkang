# AESDDW 檔案規格書

## 基本資料
* **程式編號**：HSSPD
* **程式類型**：PF (實體檔案)
* **作者**：S02LTS
* **功能說明**：委送單異動記錄副檔 for SQL
* **建立日期**：90/08/18

## 檔案功能說明
此檔案用於記錄委送單的異動資訊，作為SQL查詢使用。

## 紀錄格式

### 主檔紀錄 (RHSSPD)
| 欄位代號 | 欄位名稱 | 位置 | 長度 | 型態 | 小數位 | 說明 |
|----------|----------|------|------|------|--------|------|
| A4TRFL | 狀態碼 | - | 1 | A | - | 狀態碼 |
| A4FLAG | 處理註記 | - | 1 | A | - | 處理註記 |
| A4TRCD | 作業代號 | - | 2 | A | - | 作業代號 |
| A4AREA | 廠區代號 | - | 1 | A | - | 廠區代號 |
| A4CUNO | 委送廠商客戶編號 | - | 6 | A | - | 委送廠商客戶編號 |
| A4ASNO | 委送單號 | - | 6 | S | 0 | 委送單號 |
| A4ITEM | 委送單項次號 | - | 3 | S | 0 | 委送單項次號 |
| A4DATE | 異動日 | - | 8 | S | 0 | 異動日期 |
| A4TIME | 異動時間 | - | 6 | S | 0 | 異動時間 |
| A4HBL | 鋼板規格種類 | - | 3 | A | - | 鋼板規格種類 (H X B & LENGTH) |
| A4GROP | 大類別 | - | 1 | A | - | 大類別 |
| A4PDN1 | 品名 | - | 3 | A | - | 品名 |
| A4PDN2 | 規格 | - | 1 | A | - | 規格 |
| A4PDN3 | 尺寸 | - | 8 | A | - | 尺寸 |
| A4PDN4 | H/T/D | - | 5 | A | - | H/T/D |
| A4PDN5 | B/W | - | 5 | A | - | B/W |
| A4PDN6 | T1 | - | 3 | A | - | T1 |
| A4PDN7 | T2 | - | 3 | A | - | T2 |
| A4PDN8 | 表面 | - | 4 | A | - | 表面 |
| A4PDN9 | 特殊註記 | - | 1 | A | - | 特殊註記 |
| A4LEVR | 等級A/B/C/E | - | 1 | A | - | 等級A/B/C/E |
| A4UPRC | 委送單價格 | - | 7 | S | 5 | 委送單價格 |
| A4QTY1 | 委送支數 | - | 5 | S | 0 | 委送支數 |
| A4OQT1 | 委送數量 | - | 9 | S | 0 | 委送數量 |
| A4AMT1 | 委送金額 | - | 12 | S | 0 | 委送金額 |
| A4QTY2 | 業務確認支數 | - | 5 | S | 0 | 業務確認支數 |
| A4OQT2 | 業務確認數量 | - | 9 | S | 0 | 業務確認數量 |
| A4AMT2 | 業務確認金額 | - | 12 | S | 0 | 業務確認金額 |
| A4QTY3 | 實收支數 | - | 5 | S | 0 | 實收支數 |
| A4OQT3 | 實收數量 | - | 9 | S | 0 | 實收數量 |
| A4AMT3 | 實收金額 | - | 12 | S | 0 | 實收金額 |
| A4TYPE | 客戶供料方式 | - | 1 | A | - | 客戶供料方式 |
| A4SKID | 條狀碼 | - | 1 | A | - | 條狀碼 |
| A4USE1 | 用途碼1 | - | 1 | A | - | 用途碼1 |
| A4USE2 | 用途碼2 | - | 1 | A | - | 用途碼2 |
| A4USE3 | 用途碼3 | - | 1 | A | - | 用途碼3 |
| A4USE4 | 用途碼4 | - | 1 | A | - | 用途碼4 |
| A4USE5 | 用途碼5 | - | 1 | A | - | 用途碼5 |
| A4OARE | 訂單編號廠區碼 | - | 1 | A | - | 訂單編號廠區碼 |
| A4OORN | 訂單編號序號碼 | - | 5 | S | 0 | 訂單編號序號碼 |
| A4OITM | 訂單編號項次號 | - | 3 | S | 0 | 訂單編號項次號 |
| A4DVNO | 出貨單號 | - | 6 | A | - | 出貨單號 |
| A4DVTM | 出貨單項次 | - | 3 | S | 0 | 出貨單項次 |
| A4CSCF | 客戶確認碼 | - | 1 | A | - | 客戶確認碼 |
| A4CFDD | 客戶確認日期 | - | 8 | S | 0 | 客戶確認日期 |
| A4CPDD | 客戶變更日期 | - | 8 | S | 0 | 客戶變更日期 |
| A4CPDT | 客戶變更時間 | - | 6 | S | 0 | 客戶變更時間 |
| A4CPDM | 客戶變更人員 | - | 10 | O | - | 客戶變更人員 |
| A4TDLV | 交運碼 | - | 1 | A | - | 交運碼 |
| A4CODE | 特請碼 | - | 1 | A | - | 特請碼 |
| A4SLCF | 業務確認碼 | - | 1 | A | - | 業務確認碼 |
| A4SFDD | 業務確認日期 | - | 8 | S | 0 | 業務確認日期 |
| A4UPDD | 業務變更日期 | - | 8 | S | 0 | 業務變更日期 |
| A4UPDT | 業務變更時間 | - | 6 | S | 0 | 業務變更時間 |
| A4UPDM | 業務變更人員 | - | 10 | O | - | 業務變更人員 |
| A4SRC | 資料來源 | - | 10 | A | - | 資料來源 |
| A4ENTD | 建檔日期 | - | 8 | S | 0 | 建檔日期 |
| A4ENTT | 建檔時間 | - | 6 | S | 0 | 建檔時間 |
| A4ENTM | 建檔人員 | - | 10 | O | - | 建檔人員 |

## 主鍵欄位
* A4CUNO (委送廠商客戶編號)
* A4ASNO (委送單號)
* A4ITEM (委送單項次號)

## 索引資料
* 唯一索引：A4CUNO + A4ASNO + A4ITEM

## 備註
* 此檔案在90/08/18建立
* 部分欄位於90/11新增 