using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    [SerializeField] Transform _cursor;

    public void Tick(float value)
    {
        float p = value / Params.TimeLimit;
        _cursor.transform.eulerAngles = new Vector3(0, 0, p * -360.0f);
    }
}
