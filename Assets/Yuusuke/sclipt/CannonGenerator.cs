using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannnonGenerator : MonoBehaviour
{
    float _timer;
    [SerializeField] GameObject _cannonObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if ( _timer % 3 == 0)
        {
            Instantiate(_cannonObject);
        }
        else
        {
            _timer += Time.deltaTime;
        }
    }
}
