using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MainLogic : MonoBehaviour
{
    public static UnityAction OnGameStart;
    public static UnityAction OnGameOver;
    public static UnityAction OnGameClear;

    [SerializeField] CountDown _countDown;
    [SerializeField] GameTimer _gameTimer;
    [SerializeField] GameEnd _gameEnd;
    [SerializeField] Car _car;
    
    float _timer;

    void Start()
    {
        StartCoroutine(GameLoop());
    }

    IEnumerator GameLoop()
    {
        // ゲーム開始のカウントダウン
        yield return _countDown.Execute();
        // ゲームスタートのコールバック
        OnGameStart?.Invoke();
        
        // ゲーム中
        while (_timer <= Params.TimeLimit)
        {
            // タイマー更新
            _gameTimer.Tick(_timer);

            // がめおべら
            if (_car.IsDead) 
            {
                _gameEnd.GameOver();
                OnGameOver?.Invoke();

                yield return new WaitForSeconds(1.0f);
                SceneChanger.SceneChange("Result");
                yield break; 
            }

            _timer += Time.deltaTime;
            yield return null;
        }

        _gameEnd.GameClear();
        // ゲームクリアのコールバック
        OnGameClear?.Invoke();

        // 1秒後にリザルトへ
        yield return new WaitForSeconds(1.0f);
        SceneChanger.SceneChange("Result");
    }

    IEnumerator GameClear()
    {
        yield return null;
    }

    IEnumerator GameOver()
    {
        yield return null;
    }
}

// 大砲の弾に当たる ok
//  当たった場合はギアの変更と画面の演出が変わる。 ok
// 車が別のクラスのギアの変更処理を呼ぶ ok
// 画面に絵の具が表示される演出(1段階,2段階,がめおべら) ok
// 大砲の弾の演出(飛ぶ ok
// UIに時間を表示 ok
// UIに現在進んでいる距離を表示 
// UIにギアを表示 ok
// タイトル -> ゲームスタートまでの演出 ok
// タイムアップ -> リザルト画面への遷移
// リザルトへの表示 -> タイトルに戻る <- DDOLにスコアを持たせる必要がある