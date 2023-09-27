using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageView : MonoBehaviour
{
    [SerializeField] GameObject _condition1;
    [SerializeField] GameObject _condition2;
    [SerializeField] GameObject _condition3;

    void Start()
    {
        InvalidAll();
    }

    void InvalidAll()
    {
        _condition1.SetActive(false);
        _condition2.SetActive(false);
        _condition3.SetActive(false);
    }

    public void Condition(int value)
    {
        InvalidAll();

        if (value == 1) _condition1.SetActive(true);
        if (value == 2) _condition2.SetActive(true);
        if (value == 3) _condition3.SetActive(true);
    }
}
