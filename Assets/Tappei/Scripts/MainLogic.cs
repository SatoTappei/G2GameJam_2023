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

    [SerializeField] Scroll _scroll;
    [SerializeField] CountDown _countDown;
    [SerializeField] GameTimer _gameTimer;
    [SerializeField] Car _car;
    [SerializeField] GameObject _gameClear;
    [SerializeField] GameObject _gameOver;
    [SerializeField] Text _scoreText;
    [SerializeField] AudioSource _audio;

    float _timer;

    void Start()
    {
        _gameClear.SetActive(false);
        _gameOver.SetActive(false);
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

            // プレイヤーの死亡
            if (_car.IsDead) break;

            // テキストに反映
            _scoreText.text = _scroll.Score.ToString("F2"); ;

            _timer += Time.deltaTime;
            yield return null;
        }

        // BGM
        _audio.Stop();

        // プレイヤーが死亡していた場合はがめおべら、それ以外はゲームクリア
        if (_car.IsDead)
        {
            // がめおべら処理
            GameOver();
            OnGameOver?.Invoke();
            Score(ResultType.GameOver);
        }
        else
        {
            // ゲームクリア処理
            GameClear();
            OnGameClear?.Invoke();
            Score(ResultType.GameClear);
        }

        // 1.5秒後にリザルトへ
        yield return new WaitForSeconds(1.5f);
        GameManager.SceneChange("Result");
    }

    void GameClear()
    {
        _gameClear.SetActive(true);
        AudioPlayer.Instance.PlaySE(AudioType.SE_Finish);
    }

    void GameOver()
    {
        _gameOver.SetActive(true);
        AudioPlayer.Instance.PlaySE(AudioType.SE_GameOver);
    }

    void Score(ResultType type)
    {
        GameManager.Score = _scroll.Score;
        GameManager.ResultType = type;
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