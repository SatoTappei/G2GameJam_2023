using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour
{
    static SceneChanger _instance;

    [SerializeField] RawImage _image;
    [SerializeField] float _speed = 1.0f;

    // TODO:シーンChangerにスコアを保持しているDDOL。名前を変える
    int _score;
    bool _isGameOver;

    public static int Score
    {
        get => _instance._score;
        set => _instance._score = value;
    }

    public static bool IsGameOver
    {
        get => _instance._isGameOver;
        set => _instance._isGameOver = value;
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 起動時のタイトルシーンでフェードインする
        _instance.StartCoroutine(_instance.FadeIn());
    }

    // 外部から呼ぶことでシーンを遷移する
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
        while (_instance._image.color.a > 0)
        {
            Color color = _instance._image.color;
            color.a -= Time.deltaTime;
            _instance._image.color = color;
            yield return null;
        }

        _image.enabled = false;
    }

    IEnumerator FadeOut()
    {
        _image.enabled = true;

        while (_instance._image.color.a < 1)
        {
            Color color = _instance._image.color;
            color.a += Time.deltaTime;
            _instance._image.color = color;
            yield return null;
        }
    }
}
