using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] Text _text;

    void Awake()
    {
        _text.text = string.Empty;
    }

    public IEnumerator Execute()
    {
        _text.text = "3";
        yield return new WaitForSeconds(1.0f);
        _text.text = "2";
        yield return new WaitForSeconds(1.0f);
        _text.text = "1";
        yield return new WaitForSeconds(1.0f);
        
        // 適当な演出
        _text.text = "スタート！";
        Invoke(nameof(Delete), 1.0f);
    }

    void Delete() => _text.text = string.Empty;
}
