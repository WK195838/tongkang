# 東鋼應收帳款系統規格書

## 專案概述
本專案旨在為東鋼應收帳款系統建立完整的系統規格書與程式規格書。東鋼應收帳款系統是以 IBM AS/400 傳統 RPG 固定格式開發的系統，主要負責應收帳款管理、電子發票狀態查詢及列印、報表產生等功能。為確保系統文件的完整性，所有程式檔案（包括各修訂版本）均需納入規格書撰寫範圍。

## 系統基本資訊
- **系統名稱**：東鋼應收帳款系統
- **開發平台**：IBM AS/400
- **程式語言**：傳統固定格式 RPG (OPM RPG)、DDS、CL
- **資料庫**：DB2 for AS/400
- **系統規模**：總計5912個程式檔案 (含各修訂版本)
- **規格書覆蓋範圍**：100% (所有5912個檔案均需撰寫規格書)
- **系統負責人**：TBD

## 規格書文件結構

### 1. 程式清單
- [RPG程式清單](./RPG程式清單.md) - RPG 程式的詳細資訊 (2962個檔案)
- [DDS檔案清單](./DDS檔案清單.md) - 所有 DDS 檔案的詳細資訊 (1606個檔案)
- [CL程式清單](./CL程式清單.md) - 所有 CL 程式的詳細資訊 (1344個檔案)
- [系統程式統計](./系統程式統計.md) - 系統程式數量統計與分析

### 2. 系統架構文件（待開發）
- 系統架構概述
- 子系統關係圖
- 資料流程圖
- 程式呼叫關係圖

### 3. 程式規格書（待開發）
- 各模組程式規格（含所有修訂版）
- 程式邏輯流程
- 檔案結構說明
- 畫面設計說明

### 4. 操作手冊（待開發）
- 系統操作流程
- 常見問題與解決方案
- 系統維護指南

## 規格書開發進度
- [x] 建立程式清單架構
- [x] 完成程式基本資訊統計
- [ ] 建立系統架構文件
- [ ] 開發主要程式的程式規格書
- [ ] 編寫系統操作手冊
- [ ] 建立系統維護指南

## 規格書開發規劃
面對近6000個需要撰寫規格書的程式檔案，專案將採用以下階段性策略：

### 階段一（基礎核心）
- 優先撰寫基本程式的規格書（約1876個檔案）
- 這些程式是各修訂版本的基礎，優先完成可建立系統基本框架

### 階段二（重要修訂版）
- 撰寫重要功能的修訂版規格書
- 包含已知在生產環境中使用的關鍵修訂版程式

### 階段三（完整覆蓋）
- 完成所有剩餘修訂版的規格書
- 確保整個系統的完整文件覆蓋

所有程式（含修訂版）的規格書將具備相同的詳細程度和文件標準。

## 系統規模統計
- **程式總數**：5912 個（含不同版本）
- **基本程式數**：約1876 個（不含修訂版）
- **RPG程式**：2962 個（含修訂版）
- **DDS檔案**：1606 個（含修訂版）
- **CL程式**：1344 個（含修訂版）
- **需撰寫規格書總數**：5912 個（所有檔案）

## 最主要程式類別
- **報表產生程式**：約2108個檔案，佔總數的35.7%
- **列印相關程式**：約1903個檔案，佔總數的32.2%
- **編輯處理程式**：約1224個檔案，佔總數的20.7%
- **其他功能程式**：約677個檔案，佔總數的11.4%

## 系統復雜度分析
- **高複雜度程式**：約1350個 (22.8%)
- **中複雜度程式**：約3800個 (64.3%)
- **低複雜度程式**：約762個 (12.9%)

## 專案時程
- **開始日期**：待定
- **預計完成日期**：待定
- **最後更新日期**：2025-05-12

## 備註
- 本專案規格書以當前系統實際狀態為基礎，主要目的是建立系統文件，便於系統維護與未來可能的系統升級。
- 系統程式數量統計顯示，此AS/400應用系統規模龐大，包含近6000個程式檔案，反映了長期的系統開發與維護歷史。
- 專案要求所有程式檔案（包括修訂版本）均需納入規格書撰寫範圍，共計5912個檔案。
- 由於程式數量巨大，各程式清單僅包含具代表性的樣本，完整清單可根據需要在後續階段建立。
- 修訂版程式（含@、#等標記）佔總檔案數的68.2%，顯示系統經過頻繁修改與持續演進。
- 修訂版程式可能包含特定業務邏輯與功能，因此完整記錄所有程式版本有助於系統維護與未來升級。 