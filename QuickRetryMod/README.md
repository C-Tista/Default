# QuickRetryMod - ワンボタンリトライMod (STS2)

フロアの途中で **F5** を押すと、保存してタイトルに戻ります。
「続ける」を選択するとそのフロアの最初から再プレイできます。

## 必要なもの

- Slay the Spire 2（Steam版）
- [BepInEx 5.x](https://github.com/BepInEx/BepInEx/releases) (Unity Mono版)
- .NET SDK または Visual Studio（C#のビルド用）
- [dnSpy](https://github.com/dnSpyEx/dnSpy/releases) または [ILSpy](https://github.com/icsharpcode/ILSpy/releases)（逆コンパイル用）

## セットアップ手順

### 1. BepInEx を導入する

1. [BepInEx 5.x releases](https://github.com/BepInEx/BepInEx/releases) から `BepInEx_win_x64_5.x.x.x.zip` をダウンロード
2. STS2のインストールフォルダに展開する
   ```
   C:\Program Files (x86)\Steam\steamapps\common\Slay the Spire 2\
   ├── BepInEx\        ← ここに展開
   ├── SlayTheSpire2.exe
   └── ...
   ```
3. ゲームを一度起動して BepInEx の初期化を行い、終了する
4. `BepInEx\LogOutput.log` にログが出力されていれば成功

### 2. セーブ処理のクラス名を調べる（重要）

STS2の内部クラス名を確認する必要があります：

1. dnSpy を起動
2. `<STS2フォルダ>\SlayTheSpire2_Data\Managed\Assembly-CSharp.dll` を開く
3. 検索（Ctrl+F）で `save`, `quit`, `title`, `menu` などで検索
4. セーブ処理・タイトル復帰処理のクラス名・メソッド名を特定する
5. `Plugin.cs` の `SaveAndQuit.Execute()` 内の TODO 部分に記述する

### 3. ビルド＆インストール

環境変数を設定（またはcsprojのパスを直接書き換え）:

```powershell
$env:STS2_HOME = "C:\Program Files (x86)\Steam\steamapps\common\Slay the Spire 2"
```

ビルド（自動的に BepInEx\plugins にコピーされます）：

```powershell
dotnet build
```

## 使い方

1. BepInEx 導入済みの状態でゲームを起動
2. ゲームプレイ中に **F5** を押す
3. 保存されてタイトルへ戻る
4. 「続ける」でそのフロアの最初から再プレイ

## 開発の進め方

現状は `Plugin.cs` の `SaveAndQuit.Execute()` が未実装です。
dnSpyでクラス名を調べてから実装します。

```
Plugin.cs の TODO を埋める
    ↓
dotnet build でビルド
    ↓
BepInEx\LogOutput.log でログ確認
    ↓
動作確認
```
