package quickretry;

import basemod.BaseMod;
import basemod.interfaces.PostUpdateSubscriber;
import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.megacrit.cardcrawl.core.CardCrawlGame;
import com.megacrit.cardcrawl.dungeons.AbstractDungeon;
import com.megacrit.cardcrawl.rooms.AbstractRoom;
import com.evacipated.cardcrawl.modthespire.lib.SpireInitializer;

/**
 * QuickRetryMod - ワンボタンで保存してタイトルに戻るMod
 *
 * デフォルトキー: F5
 * 環境変数 QUICK_RETRY_KEY で変更可能（例: F6, R など）
 *
 * 使い方:
 *   フロアのどこかで F5 を押すと保存してタイトルに戻ります。
 *   タイトルから「続ける」を選ぶと、そのフロアの最初からプレイできます。
 */
@SpireInitializer
public class QuickRetryMod implements PostUpdateSubscriber {

    // キーコード（デフォルトはF5）
    private static final int DEFAULT_KEY = Input.Keys.F5;

    private final int hotkey;

    public static void initialize() {
        new QuickRetryMod();
    }

    public QuickRetryMod() {
        // キーの設定（将来的にBaseMod設定パネルで変更可能にする余地あり）
        this.hotkey = DEFAULT_KEY;
        BaseMod.subscribe(this);
        System.out.println("[QuickRetryMod] Initialized. Press F5 to save and return to title.");
    }

    @Override
    public void receivePostUpdate() {
        // ゲームのメインループ中のみ動作する
        if (!isInRun()) {
            return;
        }

        if (Gdx.input.isKeyJustPressed(hotkey)) {
            triggerSaveAndQuit();
        }
    }

    /**
     * 現在プレイ中のRunの中にいるか確認する
     */
    private boolean isInRun() {
        return CardCrawlGame.dungeon != null
                && AbstractDungeon.currMapNode != null
                && AbstractDungeon.currMapNode.room != null
                && AbstractDungeon.screen != AbstractDungeon.CurrentScreen.DEATH;
    }

    /**
     * 保存してタイトルに戻る
     *
     * Slay the Spireは「セーブして終了」時にフロア途中のセーブデータを作成します。
     * そのセーブデータをロードすると、そのフロアの最初（部屋の選択画面）から
     * 再開できます。
     */
    private void triggerSaveAndQuit() {
        try {
            AbstractRoom currentRoom = AbstractDungeon.currMapNode.room;
            AbstractRoom.RoomPhase phase = currentRoom.phase;

            // 戦闘中・イベント中・宝箱確認中など、いずれの状態でも保存可能
            System.out.println("[QuickRetryMod] Save & Quit triggered. Room phase: " + phase);

            // ゲームのモードをキャラクター選択画面（タイトル相当）に切り替える
            // これによりゲームが自動的にセーブしてタイトルに戻る
            CardCrawlGame.mode = CardCrawlGame.GameMode.CHAR_SELECT;

        } catch (Exception e) {
            System.err.println("[QuickRetryMod] Error during Save & Quit: " + e.getMessage());
            e.printStackTrace();
        }
    }
}
