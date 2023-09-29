using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Car : MonoBehaviour, IDamageable
{
    // �M�A���ύX���ꂽ�ۂɌĂ΂��R�[���o�b�N
    public static event UnityAction<GearStep> OnGearChanged;

    [SerializeField] GearView _gearView;
    [SerializeField] DamageView _damageView;
    // 0:�� 1:�^�� 2:�E
    [SerializeField] Transform[] _lanes;

    Transform _transform;
    int _currentLaneIndex;
    int _nextLaneIndex;
    float _lerpProgress = 1;
    GearStep _gear = GearStep.One;
    DamageStep _damage = DamageStep.One;
    bool _isValid;

    bool ArrivalLane => _lerpProgress >= 1;

    public bool IsDead => _damage == DamageStep.Dead;

    void OnEnable()
    {
        MainLogic.OnGameStart += () => _isValid = true;
        MainLogic.OnGameClear += () => _isValid = false;
        MainLogic.OnGameOver += Dead;
    }

    void OnDisable()
    {
        MainLogic.OnGameStart -= () => _isValid = true;
        MainLogic.OnGameClear -= () => _isValid = false;
        MainLogic.OnGameOver -= Dead;
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
            AudioPlayer.Instance.PlaySE(AudioType.SE_Slide);
            return true;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            _nextLaneIndex = Mathf.Clamp(++_nextLaneIndex, 0, _lanes.Length - 1);
            _lerpProgress = 0;
            AudioPlayer.Instance.PlaySE(AudioType.SE_Slide);
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
        if (IsDead) return;

        // �l�̕ύX
        if (item.CompareTag("Color"))
        {
            _gear = GearView.Decrement(_gear);
            _damage = DamageView.Increment(_damage);
            _gearView.Change(_gear);
            _damageView.Condition(_damage);
            OnGearChanged?.Invoke(_gear);
        }
        else if (item.CompareTag("Rainbow"))
        {
            _gear = GearView.Increment(_gear);
            _gearView.Change(_gear);
            OnGearChanged?.Invoke(_gear);
        }
        else if (item.CompareTag("Rainbow"))
        {
            _damage = DamageView.Decrement(_damage);
            _damageView.Condition(_damage);
        }

        AudioPlayer.Instance.PlaySE(AudioType.SE_Damage);
    }
}