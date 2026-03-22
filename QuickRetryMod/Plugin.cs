using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace QuickRetryMod;

/// <summary>
/// QuickRetryMod - F5でセーブしてタイトルに戻るBepInExプラグイン
///
/// 【クラス名の調べ方】
/// STS2の内部クラス名は逆コンパイラで確認が必要です。
/// 手順:
///   1. dnSpy または ILSpy をダウンロード
///   2. <STS2フォルダ>\SlayTheSpire2_Data\Managed\Assembly-CSharp.dll を開く
///   3. "save" "title" "quit" などで検索してセーブ・タイトル処理のクラス/メソッドを特定
///   4. 見つけたクラス名を SaveAndQuitPatch の TODO 部分に記述する
/// </summary>
[BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
public class QuickRetryPlugin : BaseUnityPlugin
{
    internal static new ManualLogSource Logger = null!;
    private static readonly Harmony Harmony = new(MyPluginInfo.PLUGIN_GUID);

    private void Awake()
    {
        Logger = base.Logger;
        Harmony.PatchAll();
        Logger.LogInfo($"{MyPluginInfo.PLUGIN_NAME} loaded. Press F5 to save and return to title.");
    }

    private void Update()
    {
        // F5キーが押されたらセーブしてタイトルへ
        if (Input.GetKeyDown(KeyCode.F5))
        {
            Logger.LogInfo("F5 pressed - triggering save and quit.");
            SaveAndQuit.Execute();
        }
    }
}

/// <summary>
/// セーブしてタイトルに戻る処理
///
/// Assembly-CSharp.dll を逆コンパイルして実際のクラス名・メソッド名を確認し、
/// TODO の部分を書き換えてください。
/// </summary>
internal static class SaveAndQuit
{
    public static void Execute()
    {
        try
        {
            // TODO: 逆コンパイルで確認したセーブ&タイトル復帰処理を呼ぶ
            //
            // STS1 相当のイメージ（STS2では異なる可能性が高い）:
            //   GameManager.instance.SaveAndReturnToTitle();
            //
            // 逆コンパイルで確認後、例えば以下のように記述する:
            //   var manager = GameManager.instance;
            //   manager.SaveGame();
            //   manager.ReturnToMainMenu();
            //
            // Harmony でメソッドをパッチする場合は SaveAndQuitPatch を参照。

            QuickRetryPlugin.Logger.LogWarning(
                "SaveAndQuit.Execute() が呼ばれましたが、まだ実装されていません。" +
                "Assembly-CSharp.dll を逆コンパイルしてセーブ処理のクラス名を確認してください。");
        }
        catch (System.Exception ex)
        {
            QuickRetryPlugin.Logger.LogError($"Save and quit failed: {ex}");
        }
    }
}

/// <summary>
/// Harmony パッチの例（セーブ処理をフックする場合に使用）
///
/// 逆コンパイルで実際のクラス名・メソッド名を確認してから使用してください。
/// クラス名が判明したら、コメントアウトを外して TargetType を修正する。
/// </summary>
// [HarmonyPatch]
// internal static class SaveAndQuitPatch
// {
//     // TODO: 逆コンパイルで確認した型とメソッド名に書き換える
//     [HarmonyTargetMethod]
//     static System.Reflection.MethodBase TargetMethod() =>
//         AccessTools.Method(typeof(/* ゲームのクラス名 */), "/* メソッド名 */");
//
//     [HarmonyPrefix]
//     static bool Prefix()
//     {
//         // セーブ処理の前後に処理を挿入できる
//         return true; // true = 元のメソッドも実行, false = スキップ
//     }
// }
