using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum ResultType
{
    None,
    GameClear,
    GameOver,
}

public class GameManager : MonoBehaviour
{
    static GameManager _instance;

    [Header("�t�F�[�h�̐ݒ�")]
    [SerializeField] RawImage _fadeImage;
    [SerializeField] float _fadeSpeed = 1.0f;

    // �C���Q�[���ł̃X�R�A�����U���g�ŕ\������
    float _score;
    ResultType _resultType;

    public static float Score
    {
        get => _instance._score;
        set => _instance._score = value;
    }

    public static ResultType ResultType
    {
        get => _instance._resultType;
        set => _instance._resultType = value;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            // �l�̏�����
            Score = 0;
            ResultType = ResultType.None;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // �N�����̃^�C�g���V�[���Ńt�F�[�h�C������
        _instance.StartCoroutine(_instance.FadeIn());
    }

    /// <summary>
    /// �t�F�[�h�A�E�g��A�V�[���J�ځA�t�F�[�h�C������
    /// </summary>
    /// <param name="name">���̃V�[����</param>
    public static void SceneChange(string name)
    {
        _instance.StartCoroutine(_instance.Execute(name));
    }

    IEnumerator Execute(string name)
    {
        yield return FadeOut();
        SceneManager.LoadScene(name);
        yield return FadeIn();
    }

    IEnumerator FadeIn()
    {
        while (_instance._fadeImage.color.a > 0)
        {
            Color color = _instance._fadeImage.color;
            color.a -= Time.deltaTime;
            _instance._fadeImage.color = color;
            yield return null;
        }

        _fadeImage.enabled = false;
    }

    IEnumerator FadeOut()
    {
        _fadeImage.enabled = true;

        while (_instance._fadeImage.color.a < 1)
        {
            Color color = _instance._fadeImage.color;
            color.a += Time.deltaTime;
            _instance._fadeImage.color = color;
            yield return null;
        }
    }
}
