using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    /// <summary>背景</summary>
    [SerializeField] SpriteRenderer _backGroundSprite = null;
    /// <summary>スクロール速度</summary>
    float _scrollSpeed = 10f;
    /// <summary>背景クローン</summary>
    SpriteRenderer _backGroundSpriteClone;
    SpriteRenderer _backGroundSpriteCloneClone;
    /// <summary>初期座標</summary>
    float _startPosition;
    [Header("以下調整用")]
    [SerializeField][Range(1, 3)]
    int _gear;
    [Header("ギア別速度調整")]
    [SerializeField] int _gearOne;
    [SerializeField] int _gearTwo;
    [SerializeField] int _gearThree;

    public float ScrollSpeed => _scrollSpeed;
    public int Gear { set => _gear = value; }

    void Start()
    {
        //最初の位置
        _startPosition = _backGroundSprite.transform.position.y;
        //背景のスプライトを複製
        _backGroundSpriteClone = Instantiate(_backGroundSprite);
        _backGroundSpriteCloneClone = Instantiate(_backGroundSprite);
        //上下に表示
        _backGroundSpriteClone.transform.Translate(0f, -_backGroundSprite.size.y, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, _backGroundSprite.size.y, 0f);
    }

    void Update()
    {
        _scrollSpeed = GearChange(_gear);
        // 背景画像をスクロールする
        _backGroundSprite.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);

        // 背景画像が下にいったら上に戻す
        if (_backGroundSprite.transform.position.y < _startPosition - _backGroundSprite.bounds.size.y * 2)
        {
            _backGroundSprite.transform.Translate(0, _backGroundSprite.bounds.size.y * 3, 0f);
        }
        //// 背景画像のクローンが下にいったら上に戻す
        if (_backGroundSpriteClone.transform.position.y < _startPosition - _backGroundSpriteClone.bounds.size.y * 2)
        {
            _backGroundSpriteClone.transform.Translate(0, _backGroundSpriteClone.bounds.size.y * 3, 0f);
        }
        //// 背景画像のクローンが下にいったら上に戻す
        if (_backGroundSpriteCloneClone.transform.position.y < _startPosition - _backGroundSpriteCloneClone.bounds.size.y * 2)
        {
            _backGroundSpriteCloneClone.transform.Translate(0, _backGroundSpriteCloneClone.bounds.size.y * 3, 0f);
        }
    }

    float GearChange(int gear)
    {
        if (gear == 1)
            return _gearOne;
        if (gear == 2)
            return _gearTwo;
        if (gear == 3)
            return _gearThree;
        else
            Debug.Log("ギアが判別出来ません");
            return 1;
    }
}
