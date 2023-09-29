using System.Collections;
using UnityEngine;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameObject _three;
    [SerializeField] GameObject _two;
    [SerializeField] GameObject _one;
    [SerializeField] GameObject _go;


    void Awake()
    {
        InvalidAll();
    }

    void InvalidAll()
    {
        _three.SetActive(false);
        _two.SetActive(false);
        _one.SetActive(false);
        _go.SetActive(false);
    }

    public IEnumerator Execute()
    {
        AudioPlayer.Instance.PlaySE(AudioType.SE_RaceStart);

        _three.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _three.SetActive(false);
        _two.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _two.SetActive(false);
        _one.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _one.SetActive(false);
        _go.SetActive(true);

        // 1•bŒã‚É”ñ•\Ž¦‚É‚·‚é‚ªA‘Ò‚½‚È‚¢
        Invoke(nameof(Invalid), 1.0f);
    }

    void Invalid() => _go.SetActive(false);
}
