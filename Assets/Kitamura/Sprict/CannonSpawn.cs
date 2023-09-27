using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonSpawn : MonoBehaviour
{
    [SerializeField] SpriteRenderer _tree;
    [SerializeField] Transform[] _spawn;
    float timer;


    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.5f)
        {
            timer = 0;
            Instantiate(_tree, _spawn[Random.Range(0, 4)].position,transform.rotation);
        }
    }
}
