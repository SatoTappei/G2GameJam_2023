using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    BackGroundScroll _backGroundScroll;
    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
        //n秒後にデストロイ
        Destroy(gameObject ,3f);
    }
    void Update()
    {
        //背景スクロールの速度に合わせて移動
        transform.Translate(0f, -_backGroundScroll.ScrollSpeed * Time.deltaTime, 0f);
    }
}
