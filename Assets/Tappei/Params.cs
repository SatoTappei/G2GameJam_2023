using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Params : MonoBehaviour
{
    static Params _instance;

    [Header("���H�̈ړ����x")]
    [SerializeField] float _roadMoveSpeed = 1.0f;
    [Header("�Ԃ̃��[���Ԃ̈ړ����x")]
    [SerializeField] float _laneStepSpeed = 1.0f;
    [Header("�G����y���͈�")]
    [SerializeField] float _paintExplosionRange = 3.0f;
    [Header("�X�^������")]
    [SerializeField] float _stunTime = 1.5f;

    public static float RoadMoveSpeed => _instance._roadMoveSpeed;
    public static float LaneStepSpeed => _instance._laneStepSpeed;
    public static float PaintExplosionRange => _instance._paintExplosionRange;
    public static float StunTime => _instance._stunTime;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
            Debug.LogWarning("Planner���d�����Ă���");
        }
    }
}
