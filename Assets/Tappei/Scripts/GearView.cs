using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearView : MonoBehaviour
{
    [SerializeField] Transform _cursor;
    [SerializeField] float _angle1 = -66.0f;
    [SerializeField] float _angle2 = 0;
    [SerializeField] float _angle3 = 66.0f;

    public void Change(int value)
    {
        if (value == 1) _cursor.transform.eulerAngles = new Vector3(0, 0, _angle1);
        if (value == 2) _cursor.transform.eulerAngles = new Vector3(0, 0, _angle2);
        if (value == 3) _cursor.transform.eulerAngles = new Vector3(0, 0, _angle3);
    }
}
