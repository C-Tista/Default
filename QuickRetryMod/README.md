# QuickRetryMod - ワンボタンリトライMod

フロアの途中で **F5** を押すと、保存してタイトルに戻ります。
「続ける」を選択するとそのフロアの最初から再プレイできます。

## 必要なもの

- Slay the Spire（Steam版）
- [ModTheSpire](https://github.com/kiooeht/ModTheSpire/releases) 3.30.0以上
- [BaseMod](https://github.com/daviscook477/BaseMod/releases)

## ビルド方法

### 1. 環境変数を設定

```bash
# Linux / Mac
export STS_HOME="$HOME/.steam/steam/steamapps/common/SlayTheSpire"

# Windows (PowerShell)
$env:STS_HOME="C:\Program Files (x86)\Steam\steamapps\common\SlayTheSpire"
```

### 2. ビルド

```bash
./gradlew jar
```

### 3. インストール（ビルド&コピー）

```bash
./gradlew deployMod
```

生成された `QuickRetryMod-1.0.0.jar` を `<STS_HOME>/mods/` フォルダに置いてください。

## 使い方

1. ModTheSpireでゲームを起動し、`BaseMod` と `Quick Retry Mod` を有効化
2. ゲームプレイ中に **F5** を押す
3. 保存されてタイトルへ戻る
4. 「続ける」でそのフロアの最初から再プレイ

## 注意

- このModはゲームの既存のセーブ機能を利用しています
- フロア途中のセーブデータをロードすると、STSの仕様によりそのフロアの最初（部屋選択前）から再開します
- 戦闘結果（HP消費など）はセーブ時点の状態に戻ります
