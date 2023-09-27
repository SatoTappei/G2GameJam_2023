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
        //�w�i�X�N���[���̑��x�ɍ��킹�Ĉړ�
        transform.Translate(0f, -_backGroundScroll.ScrollSpeed * Time.deltaTime, 0f);
        if (transform.position.y < -30f)
        {
            Destroy(gameObject);
        }
    }
}
