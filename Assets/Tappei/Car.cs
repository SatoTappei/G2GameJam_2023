using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    // 0:左 1:真ん中 2:右
    [SerializeField] Transform[] _lanes;

    Transform _transform;
    int _currentLaneIndex;
    int _nextLaneIndex;
    float _lerpProgress = 1;
    bool _isValid = true; // TODO:本来はゲーム開始時にtrueになる
    bool _isGoal;

    bool ArrivalLane => _lerpProgress >= 1;
    public bool IsGoal => _isGoal;

    void Start()
    {
        _transform = transform;
        _currentLaneIndex = 1;
        _nextLaneIndex = 1;
        // 移動時に上下移動しないように、開始レーンの位置に高さを合わせる
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
    /// 左右の入力で次のレーンを指定する
    /// </summary>
    /// <returns>左右の入力があった:true ない:false</returns>
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
    /// 次のレーンまで左右移動を行う
    /// </summary>
    /// <returns>次のレーンに到着:true 途中:false</returns>
    bool Move()
    {
        Vector3 from = _lanes[_currentLaneIndex].position;
        Vector3 to = _lanes[_nextLaneIndex].position;

        _lerpProgress += Time.deltaTime * Params.LaneStepSpeed;
        _lerpProgress = Mathf.Clamp01(_lerpProgress);
        _transform.position = Vector3.Slerp(from, to, _lerpProgress);

        // 次のレーンに到達した場合は現在のレーンの上書き
        if (ArrivalLane) _currentLaneIndex = _nextLaneIndex;
        return ArrivalLane;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // ゴールしたフラグを立てる
        if (collision.CompareTag("Finish")) _isGoal = true;
    }
}
