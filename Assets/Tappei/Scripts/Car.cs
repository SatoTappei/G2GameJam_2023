using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour, IDamageable
{
    [SerializeField] GearView _gearView;
    [SerializeField] DamageView _damageView;
    [SerializeField] BackGroundScroll _scroll;
    // 0:�� 1:�^�� 2:�E
    [SerializeField] Transform[] _lanes;

    Transform _transform;
    int _currentLaneIndex;
    int _nextLaneIndex;
    float _lerpProgress = 1;
    int _gear = 1;
    int _damage;
    bool _isValid;
    bool _isDead;

    bool ArrivalLane => _lerpProgress >= 1;

    public bool IsDead => _damage == 3;

    void OnEnable()
    {
        MainLogic.OnGameStart += () => _isValid = true;
        MainLogic.OnGameClear += () => _isValid = false;
        MainLogic.OnGameOver += () => _isValid = false;
    }

    void OnDisable()
    {
        MainLogic.OnGameStart -= () => _isValid = true;
        MainLogic.OnGameClear -= () => _isValid = false;
        MainLogic.OnGameOver += () => _isValid = false;
    }

    void Start()
    {
        _transform = transform;
        _currentLaneIndex = 1;
        _nextLaneIndex = 1;
        // �ړ����ɏ㉺�ړ����Ȃ��悤�ɁA�J�n���[���̈ʒu�ɍ��������킹��
        _transform.position = _lanes[_currentLaneIndex].position;

        _gearView.Change(_gear);
        _damageView.Condition(_damage);
    }

    void Update()
    {
        if (_isValid && ArrivalLane)
        {
            InputLaneIndex();
        }
        else
        {
            Move();
        }
    }

    /// <summary>
    /// ���E�̓��͂Ŏ��̃��[�����w�肷��
    /// </summary>
    /// <returns>���E�̓��͂�������:true �Ȃ�:false</returns>
    bool InputLaneIndex()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            _nextLaneIndex = Mathf.Clamp(--_nextLaneIndex, 0, _lanes.Length - 1);
            _lerpProgress = 0;
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _nextLaneIndex = Mathf.Clamp(++_nextLaneIndex, 0, _lanes.Length - 1);
            _lerpProgress = 0;
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ���̃��[���܂ō��E�ړ����s��
    /// </summary>
    /// <returns>���̃��[���ɓ���:true �r��:false</returns>
    bool Move()
    {
        Vector3 from = _lanes[_currentLaneIndex].position;
        Vector3 to = _lanes[_nextLaneIndex].position;

        _lerpProgress += Time.deltaTime * Params.LaneStepSpeed;
        _lerpProgress = Mathf.Clamp01(_lerpProgress);
        _transform.position = Vector3.Lerp(from, to, _lerpProgress);

        // ���̃��[���ɓ��B�����ꍇ�͌��݂̃��[���̏㏑��
        if (ArrivalLane) _currentLaneIndex = _nextLaneIndex;
        return ArrivalLane;
    }

    void Dead()
    {
        _isValid = false;
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }

    void IDamageable.Damage(GameObject item)
    {
        if (_isDead) return;

        // TODO:���Ԃ�����Εʂ̔��ʕ��@�ɒ���
        if (item.TryGetComponent(out ColorBall _))
        {
            _gear--;
            _damage++;
            _gear = Mathf.Clamp(_gear, 1, 3);
            _damage = Mathf.Clamp(_damage, 0, 3);
        }
        else if (item.TryGetComponent(out RainbowBall _))
        {
            _gear++;
            _gear = Mathf.Clamp(_gear, 1, 3);
        }
        else if (item.TryGetComponent(out WaterBall _))
        {
            _damage--;
            _damage = Mathf.Clamp(_damage, 0, 3);
        }

        _gearView.Change(_gear);
        _damageView.Condition(_damage);
        _scroll.Gear = _gear;
    }
}