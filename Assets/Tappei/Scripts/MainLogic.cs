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
        // �Q�[���J�n�̃J�E���g�_�E��
        yield return _countDown.Execute();
        // �Q�[���X�^�[�g�̃R�[���o�b�N
        OnGameStart?.Invoke();
        
        // �Q�[����
        while (_timer <= Params.TimeLimit)
        {
            // �^�C�}�[�X�V
            _gameTimer.Tick(_timer);

            // �v���C���[�̎��S
            if (_car.IsDead) break;

            // �e�L�X�g�ɔ��f
            _scoreText.text = _scroll.Score.ToString("F2"); ;

            _timer += Time.deltaTime;
            yield return null;
        }

        // BGM
        _audio.Stop();

        // �v���C���[�����S���Ă����ꍇ�͂��߂��ׂ�A����ȊO�̓Q�[���N���A
        if (_car.IsDead)
        {
            // ���߂��ׂ珈��
            GameOver();
            OnGameOver?.Invoke();
            Score(ResultType.GameOver);
        }
        else
        {
            // �Q�[���N���A����
            GameClear();
            OnGameClear?.Invoke();
            Score(ResultType.GameClear);
        }

        // 1.5�b��Ƀ��U���g��
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

// ��C�̒e�ɓ����� ok
//  ���������ꍇ�̓M�A�̕ύX�Ɖ�ʂ̉��o���ς��B ok
// �Ԃ��ʂ̃N���X�̃M�A�̕ύX�������Ă� ok
// ��ʂɊG�̋�\������鉉�o(1�i�K,2�i�K,���߂��ׂ�) ok
// ��C�̒e�̉��o(��� ok
// UI�Ɏ��Ԃ�\�� ok
// UI�Ɍ��ݐi��ł��鋗����\�� 
// UI�ɃM�A��\�� ok
// �^�C�g�� -> �Q�[���X�^�[�g�܂ł̉��o ok
// �^�C���A�b�v -> ���U���g��ʂւ̑J��
// ���U���g�ւ̕\�� -> �^�C�g���ɖ߂� <- DDOL�ɃX�R�A����������K�v������