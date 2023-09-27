using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour
{
    static Params _instance;

    [Header("道路の移動速度")]
    [SerializeField] float _roadMoveSpeed = 1.0f;
    [Header("車のレーン間の移動速度")]
    [SerializeField] float _laneStepSpeed = 1.0f;
    [Header("ゲーム時間")]
    [SerializeField] float _timeLimit = 60.0f;
    [Header("イベントが起こる間隔")]
    [SerializeField] float _eventRate = 2.0f;
    [Header("絵具の炸裂範囲")]
    [SerializeField] float _paintExplosionRange = 3.0f;
    [Header("スタン時間")]
    [SerializeField] float _stunTime = 1.5f;

    public static float RoadMoveSpeed => _instance._roadMoveSpeed;
    public static float LaneStepSpeed => _instance._laneStepSpeed;
    public static float PaintExplosionRange => _instance._paintExplosionRange;
    public static float StunTime => _instance._stunTime;
    public static float TimeLimit => _instance._timeLimit;
    public static float EventRate => _instance._eventRate;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            Debug.LogWarning("Plannerが重複している");
        }
    }
}
