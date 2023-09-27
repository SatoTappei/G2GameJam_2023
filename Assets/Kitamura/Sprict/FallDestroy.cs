using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    BackGroundScroll _backGroundScroll;
    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
    }
    void Update()
    {
        //背景スクロールの速度に合わせて移動
        transform.Translate(0f, -_backGroundScroll.ScrollSpeed * Time.deltaTime, 0f);
        if(transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }
}
