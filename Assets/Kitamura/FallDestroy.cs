using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDestroy : MonoBehaviour
{
    BackGroundScroll _backGroundScroll;
    void Start()
    {
        _backGroundScroll = GameObject.Find("System").GetComponent<BackGroundScroll>();
        //n�b��Ƀf�X�g���C
        Destroy(gameObject ,3f);
    }
    void Update()
    {
        //�w�i�X�N���[���̑��x�ɍ��킹�Ĉړ�
        transform.Translate(0f, -_backGroundScroll.ScrollSpeed * Time.deltaTime, 0f);
    }
}
