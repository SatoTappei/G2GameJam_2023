using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    /// <summary>”wŒi</summary>
    [SerializeField] SpriteRenderer _backGroundSprite = null;
    /// <summary>ƒXƒNƒ[ƒ‹‘¬“x</summary>
    [SerializeField] float _scrollSpeed = 10f;
    /// <summary>”wŒiƒNƒ[ƒ“</summary>
    SpriteRenderer _backGroundSpriteClone;
    SpriteRenderer _backGroundSpriteCloneClone;
    /// <summary>‰ŠúÀ•W</summary>
    float _startPosition;
    void Start()
    {
        //Å‰‚ÌˆÊ’u
        _startPosition = _backGroundSprite.transform.position.y;
        //”wŒi‚ÌƒXƒvƒ‰ƒCƒg‚ğ•¡»
        _backGroundSpriteClone = Instantiate(_backGroundSprite);
        _backGroundSpriteCloneClone = Instantiate(_backGroundSprite);
        //ã‰º‚É•\¦
        _backGroundSpriteClone.transform.Translate(0f, -_backGroundSprite.size.y, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, _backGroundSprite.size.y, 0f);
    }

    void Update()
    {
        // ”wŒi‰æ‘œ‚ğƒXƒNƒ[ƒ‹‚·‚é
        _backGroundSprite.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);

        // ”wŒi‰æ‘œ‚ª‰º‚É‚¢‚Á‚½‚çã‚É–ß‚·
        if (_backGroundSprite.transform.position.y < _startPosition - _backGroundSprite.bounds.size.y * 2)
        {
            _backGroundSprite.transform.Translate(0, _backGroundSprite.bounds.size.y * 3, 0f);
        }

        //// ”wŒi‰æ‘œ‚ÌƒNƒ[ƒ“‚ª‰º‚É‚¢‚Á‚½‚çã‚É–ß‚·
        if (_backGroundSpriteClone.transform.position.y < _startPosition - _backGroundSpriteClone.bounds.size.y * 2)
        {
            _backGroundSpriteClone.transform.Translate(0, _backGroundSpriteClone.bounds.size.y * 3, 0f);
        }
        //// ”wŒi‰æ‘œ‚ÌƒNƒ[ƒ“‚ª‰º‚É‚¢‚Á‚½‚çã‚É–ß‚·
        if (_backGroundSpriteCloneClone.transform.position.y < _startPosition - _backGroundSpriteCloneClone.bounds.size.y * 2)
        {
            _backGroundSpriteCloneClone.transform.Translate(0, _backGroundSpriteCloneClone.bounds.size.y * 3, 0f);
        }
    }
}
