# RPA流程圖

```mermaid
graph TD
    A[RPA拉程式] --> B[SRC清單]
    A --> C[SRC]
    C --> E[同步Github]

    B --> D[篩選正式SRC]
    E --> F[Cursor拉至本地]
    F --> G[CURSOR分析SRC]
    G --> H[照正式SRC清單轉規格書清單<br>100筆1張]
    D --> I[轉CSV]
    I --> E[同步Github]
    H --> J[按清單生成規格書MD檔<hr>並更新清單<hr>DDS<hr>RPG<hr>CLP]