# QuickRetryMod - ワンボタンリトライMod

フロアの途中で **F5** を押すと、保存してタイトルに戻ります。
「続ける」を選択するとそのフロアの最初から再プレイできます。

## 必要なもの

- Slay the Spire（Steam版）
- [ModTheSpire](https://github.com/kiooeht/ModTheSpire/releases) 3.30.0以上
- [BaseMod](https://github.com/daviscook477/BaseMod/releases)
- Java 8 (JDK)

## セットアップ（Windows）

### 1. STSのインストールパスを確認する

Steamの標準インストール先：
```
C:\Program Files (x86)\Steam\steamapps\common\SlayTheSpire
```

パスが異なる場合は `build.gradle` の以下の行を書き換えてください：

```groovy
def defaultStsHome = 'C:/Program Files (x86)/Steam/steamapps/common/SlayTheSpire'
```

> **注意:** Windowsのパスでもバックスラッシュ `\` ではなくスラッシュ `/` を使ってください。

### 2. ModTheSpire と BaseMod を導入する

1. [ModTheSpire](https://github.com/kiooeht/ModTheSpire/releases) の `ModTheSpire.jar` をダウンロード
2. [BaseMod](https://github.com/daviscook477/BaseMod/releases) の `BaseMod.jar` をダウンロード
3. 両方を `<STSフォルダ>\mods\` に置く（`mods` フォルダがなければ作成）

または Steam Workshop で導入しても可。

### 3. ビルド＆インストール

コマンドプロンプト or PowerShell で実行：

```powershell
cd QuickRetryMod
.\gradlew.bat deployMod
```

自動で `mods\QuickRetryMod-1.0.0.jar` にコピーされます。

> `gradlew.bat` がない場合は先に `gradle wrapper` を実行するか、
> `gradle jar` でビルドして生成された JAR を手動で `mods\` にコピーしてください。

## 使い方

1. ModTheSpireでゲームを起動し、`BaseMod` と `Quick Retry Mod` を有効化
2. ゲームプレイ中に **F5** を押す
3. 自動保存されてタイトルへ戻る
4. 「続ける」でそのフロアの最初（部屋選択画面）から再プレイ

## 注意

- このModはゲームの既存のセーブ機能を利用しています
- フロア途中のセーブデータをロードすると、STSの仕様によりそのフロアの最初（部屋選択前）から再開します
- 戦闘結果（HP消費など）はセーブ時点の状態に戻ります
