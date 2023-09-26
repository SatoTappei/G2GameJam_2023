using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // 0:�� 1:�^�� 2:�E
    [SerializeField] Transform[] _lanes;

    Transform _transform;
    int _currentLaneIndex;
    int _nextLaneIndex;
    float _lerpProgress = 1;
    bool _isValid = true; // TODO:�{���̓Q�[���J�n����true�ɂȂ�
    bool _isGoal;

    bool ArrivalLane => _lerpProgress >= 1;
    public bool IsGoal => _isGoal;

    void Start()
    {
        _transform = transform;
        _currentLaneIndex = 1;
        _nextLaneIndex = 1;
        // �ړ����ɏ㉺�ړ����Ȃ��悤�ɁA�J�n���[���̈ʒu�ɍ��������킹��
        _transform.position = _lanes[_currentLaneIndex].position;
    }

    void Update()
    {
        if (!_isValid) return;

        if (ArrivalLane)
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
        _transform.position = Vector3.Slerp(from, to, _lerpProgress);

        // ���̃��[���ɓ��B�����ꍇ�͌��݂̃��[���̏㏑��
        if (ArrivalLane) _currentLaneIndex = _nextLaneIndex;
        return ArrivalLane;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // �S�[�������t���O�𗧂Ă�
        if (collision.CompareTag("Finish")) _isGoal = true;
    }
}
