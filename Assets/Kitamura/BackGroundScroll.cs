using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll : MonoBehaviour
{
    /// <summary>�w�i</summary>
    [SerializeField] SpriteRenderer _backGroundSprite = null;
    /// <summary>�X�N���[�����x</summary>
    [SerializeField] float _scrollSpeed = 10f;
    /// <summary>�w�i�N���[��</summary>
    SpriteRenderer _backGroundSpriteClone;
    SpriteRenderer _backGroundSpriteCloneClone;
    /// <summary>�������W</summary>
    float _startPosition;
    void Start()
    {
        //�ŏ��̈ʒu
        _startPosition = _backGroundSprite.transform.position.y;
        //�w�i�̃X�v���C�g�𕡐�
        _backGroundSpriteClone = Instantiate(_backGroundSprite);
        _backGroundSpriteCloneClone = Instantiate(_backGroundSprite);
        //�㉺�ɕ\��
        _backGroundSpriteClone.transform.Translate(0f, -_backGroundSprite.size.y, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, _backGroundSprite.size.y, 0f);
    }

    void Update()
    {
        // �w�i�摜���X�N���[������
        _backGroundSprite.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);
        _backGroundSpriteCloneClone.transform.Translate(0f, -_scrollSpeed * Time.deltaTime, 0f);

        // �w�i�摜�����ɂ��������ɖ߂�
        if (_backGroundSprite.transform.position.y < _startPosition - _backGroundSprite.bounds.size.y * 2)
        {
            _backGroundSprite.transform.Translate(0, _backGroundSprite.bounds.size.y * 3, 0f);
        }

        //// �w�i�摜�̃N���[�������ɂ��������ɖ߂�
        if (_backGroundSpriteClone.transform.position.y < _startPosition - _backGroundSpriteClone.bounds.size.y * 2)
        {
            _backGroundSpriteClone.transform.Translate(0, _backGroundSpriteClone.bounds.size.y * 3, 0f);
        }
        //// �w�i�摜�̃N���[�������ɂ��������ɖ߂�
        if (_backGroundSpriteCloneClone.transform.position.y < _startPosition - _backGroundSpriteCloneClone.bounds.size.y * 2)
        {
            _backGroundSpriteCloneClone.transform.Translate(0, _backGroundSpriteCloneClone.bounds.size.y * 3, 0f);
        }
    }
}
