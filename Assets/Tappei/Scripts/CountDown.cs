using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour
{
    [SerializeField] GameObject _three;
    [SerializeField] GameObject _two;
    [SerializeField] GameObject _one;
    [SerializeField] GameObject _go;


    void Awake()
    {
        _three.SetActive(false);
        _two.SetActive(false);
        _one.SetActive(false);
        _go.SetActive(false);
    }

    public IEnumerator Execute()
    {
        _three.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _three.SetActive(false);
        _two.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _two.SetActive(false);
        _one.SetActive(true);
        yield return new WaitForSeconds(1.0f);
        _one.SetActive(false);
        // “K“–‚È‰‰o
        _go.SetActive(true);
        Invoke(nameof(Delete), 1.0f);
    }

    void Delete() => _go.SetActive(false);
}
