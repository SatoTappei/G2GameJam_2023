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
        // �Q�[���J�n�̃J�E���g�_�E��
        yield return _countDown.Execute();
        // �Q�[���X�^�[�g�̃R�[���o�b�N
        OnGameStart?.Invoke();
        
        // �Q�[����
        while (_timer <= Params.TimeLimit)
        {
            // �^�C�}�[�X�V
            _gameTimer.Tick(_timer);

            // ���߂��ׂ�
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
        // �Q�[���N���A�̃R�[���o�b�N
        OnGameClear?.Invoke();

        // 1�b��Ƀ��U���g��
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