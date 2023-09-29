using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DamageStep
{
    One = 1,
    Two = 2,
    Three = 3,
    Dead = 4, // ‚ª‚ß‚¨‚×‚ç
}

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

    public void Condition(DamageStep damage)
    {
        InvalidAll();

        if (damage == DamageStep.One)   _condition1.SetActive(true);
        if (damage == DamageStep.Two)   _condition2.SetActive(true);
        if (damage == DamageStep.Three) _condition3.SetActive(true);
    }

    public static DamageStep Increment(DamageStep step)
    {
        int value = (int)step;
        return (DamageStep)Mathf.Clamp(++value, 1, 4);
    }

    public static DamageStep Decrement(DamageStep step)
    {
        int value = (int)step;
        return (DamageStep)Mathf.Clamp(--value, 1, 4);
    }
}
