using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsMoveDestroy : MonoBehaviour
{
    BackGroundScroll _backGroundScroll;

    protected virtual void MoveDestroy(){}

    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
    }
    void Update()
    {
        //背景スクロールの速度に合わせて移動
        transform.Translate(0f, -_backGroundScroll.ScrollSpeed * Time.deltaTime, 0f);
        if (transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }
}
