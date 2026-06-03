# 實作完成說明 (Walkthrough)

我們已成功將專案擴充，新增了關於 **單一職責原則 (Single Responsibility Principle - SRP)** 的實作示範！

此專案目前已完成《大話設計模式》第一章 **「簡單工廠模式」**、第二章 **「策略模式」** 與第三章 **「單一職責原則」** 的核心實作，並附帶了彩色互動式命令列 (CLI) 選單，讓您能夠輕鬆以 `dotnet run` 進行測試與觀摩！

---

## 目錄與檔案結構

專案結構非常清爽，您可以直接點擊以下連結查看檔案內容：

```
DesignPatternsEverrich/
│
├── [DesignPatterns.slnx](file:///c:/SideProjects/DesignPatternsEverrich/DesignPatterns.slnx) (新版 .NET 9 方案檔)
│
└── src/
    └── DesignPatterns.CLI/
        ├── [DesignPatterns.CLI.csproj](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/DesignPatterns.CLI.csproj)
        ├── [Program.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/Program.cs) (主要進入點，包含 Demo 選單)
        │
        ├── 01_SimpleFactory/ (簡單工廠模式)
        │   ├── [Operation.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/Operation.cs) (運算基底類別)
        │   ├── [OperationAdd.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/OperationAdd.cs) (加法實作)
        │   ├── [OperationSub.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/OperationSub.cs) (減法實作)
        │   ├── [OperationMul.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/OperationMul.cs) (乘法實作)
        │   ├── [OperationDiv.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/OperationDiv.cs) (除法實作，含除以 0 防呆)
        │   ├── [OperationFactory.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/OperationFactory.cs) (運算工廠)
        │   └── [SimpleFactoryDemo.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/01_SimpleFactory/SimpleFactoryDemo.cs) (計算機 Demo 執行邏輯)
        │
        ├── 02_Strategy/ (策略模式)
        │   ├── [CashSuper.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/CashSuper.cs) (收費抽象類別)
        │   ├── [CashNormal.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/CashNormal.cs) (正常收費)
        │   ├── [CashRebate.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/CashRebate.cs) (打折收費)
        │   ├── [CashReturn.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/CashReturn.cs) (滿減返利)
        │   ├── [CashContext.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/CashContext.cs) (結合簡單工廠的策略上下文)
        │   └── [StrategyDemo.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/02_Strategy/StrategyDemo.cs) (收銀系統 Demo 執行邏輯)
        │
        └── 03_SingleResponsibility/ (單一職責原則)
            ├── [ViolatedInvoice.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/03_SingleResponsibility/ViolatedInvoice.cs) (違反 SRP：一個類別兼顧計算、列印、存檔)
            ├── [Invoice.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/03_SingleResponsibility/Invoice.cs) (符合 SRP：僅負責資料與計算)
            ├── [InvoicePrinter.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/03_SingleResponsibility/InvoicePrinter.cs) (符合 SRP：僅負責 Console 輸出)
            ├── [InvoiceSaver.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/03_SingleResponsibility/InvoiceSaver.cs) (符合 SRP：僅負責檔案儲存)
            └── [SingleResponsibilityDemo.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/03_SingleResponsibility/SingleResponsibilityDemo.cs) (SRP 觀念對比與說明 Demo)
```

---

## 核心設計亮點

### 1. 簡單工廠模式 (第一章)
在 `OperationFactory` 中，使用 C# 8.0+ 的 **Switch Expressions (切換表達式)** 進行重構，讓工廠建立邏輯更簡潔易讀。

### 2. 策略模式與簡單工廠結合 (第二章)
在 `CashContext` 中，我們實現了書中 2.6 節的精髓。將「判斷要使用哪種折扣演算法」的邏輯，直接移入到 `CashContext` 的建構子中。

### 3. 單一職責原則 (SRP - 第三章)
我們在 `03_SingleResponsibility` 中設計了對照組：
* **違反 SRP 的 `ViolatedInvoice`**：
  同一個類別內混雜了：
  1. 計算總價與稅額的 **業務邏輯**
  2. 格式化後輸出至畫面的 **呈現邏輯** (`PrintInvoice` 方法)
  3. 寫入 TXT 檔案的 **持久化邏輯** (`SaveToFile` 方法)
  *缺點*：未來若輸出格式要換成 HTML、PDF，或者要改存至資料庫、甚至稅率算法改變，都必須修改同一個檔案，極易引入 Bug。
* **符合 SRP 的設計**：
  我們將它拆分為三個只專注於單一目標的類別：
  1. **`Invoice.cs`**：專注於發票項目儲存與稅金計算（**引起變化的唯一原因：發票計算規則改變**）。
  2. **`InvoicePrinter.cs`**：專注於如何把發票輸出到螢幕上（**引起變化的唯一原因：顯示格式/排版改變**）。
  3. **`InvoiceSaver.cs`**：專注於如何備份到外部媒體（**引起變化的唯一原因：儲存媒介/目的地改變**）。

---

## 如何執行專案

請在您的命令提示字元 (CMD) 或 PowerShell 中，切換到方案目錄下，輸入以下指令：

```bash
dotnet run --project src/DesignPatterns.CLI
```

啟動後，您將會看到精美的終端選單：
1. **輸入 `1`**：即可測試簡單工廠計算機。
2. **輸入 `2`**：即可測試商場收銀系統。
3. **輸入 `3`**：即可測試單一職責原則對照組示範，並在畫面上顯示 SRP 原則的精髓解析。
4. **輸入 `q`**：退出程式。

---

## 後續如何擴充 (以裝飾模式為例)

當您閱讀到後面章節（例如「裝飾模式 Decorator」）時，擴充非常容易：

1. **建立新目錄**：在 `src/DesignPatterns.CLI/` 下建立名為 `04_Decorator/` 的資料夾。
2. **實作類別**：在其中新增您的 C# 檔案（如 `Person.cs`、`Finery.cs` 等）。
3. **建立示範器**：建立 `DecoratorDemo.cs` 並實作一個靜態的 `Run()` 方法。
4. **加入主選單**：
   在 [Program.cs](file:///c:/SideProjects/DesignPatternsEverrich/src/DesignPatterns.CLI/Program.cs) 中：
   - 增加選單列印：`Console.WriteLine("  [4] 裝飾模式 (裝飾者模式)");`
   - 在 `switch (choice)` 區塊中增加分支並呼叫對應的 `Run()` 方法。
