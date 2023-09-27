using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannnonGenerator : MonoBehaviour
{
    float _timer;
    [SerializeField] GameObject _cannonObject;
    [SerializeField] Transform[] _generatorPoint;
    int _cannonPosition;


    void Start()
    {
        
    }


    void Update()
    {
        
        if ( _timer  >= 3f)
        {
            _cannonPosition = Random.Range(0, _generatorPoint.Length);
            Instantiate(_cannonObject, _generatorPoint[_cannonPosition].position, _cannonObject.transform.rotation);
            _timer = 0;
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}
