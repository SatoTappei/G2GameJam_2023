using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintBall : MonoBehaviour
{
    [SerializeField] Vector3[] _landingPoints;
    [Header("サイズ")]
    [SerializeField] float _max = 1.0f;
    [SerializeField] float _min = 0.5f;
    [Header("投射速度")]
    [Range(0, 1)]
    [SerializeField] float _speed = 0.33f;
    [Header("爆発")]
    [SerializeField] ParticleSystem _explosion;
    [SerializeField] LayerMask _layerMask;

    Transform _transform;
    Vector3 _spawnPos;
    Vector3 _landingPoint;
    float _easeProgress = 0;

    bool EaseCompleted => _easeProgress >= 1;

    void Start()
    {
        _transform = transform;
        _spawnPos = transform.position;
        _landingPoint = _landingPoints[Random.Range(0, _landingPoints.Length)];
    }

    void Update()
    {
        IncreaseProgress();
        LinerMove();
        EasingSize();

        if (EaseCompleted) Explosion();
    }

    void IncreaseProgress()
    {
        _easeProgress += Time.deltaTime * _speed;
        _easeProgress = Mathf.Clamp01(_easeProgress);
    }

    void LinerMove()
    {
        _transform.position = Vector3.Lerp(_spawnPos, _landingPoint, _easeProgress);
    }

    void EasingSize()
    {
        float easeValue = 1 - EaseOutBounce(_easeProgress);
        _transform.localScale = Vector3.one * _max * (easeValue + _min);
    }

    /// <summary>
    /// エフェクトを生成して自身は削除
    /// インターフェースを取得してダメージを与える
    /// </summary>
    void Explosion()
    {
        AudioPlayer.Instance.PlaySE(AudioType.SE_Explosion);

        Instantiate(_explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);

        // ダメージを与える
        Collider2D[] result = Physics2D.OverlapCircleAll(_transform.position, Params.PaintExplosionRange, _layerMask);
        foreach (Collider2D collider in result)
        {
            if (collider == null) break;
            if (collider.TryGetComponent(out IDamageable damageable)) damageable.Damage(gameObject);
        }
    }

    float EaseOutBounce(float t)
    {
        float bounce = 7.5625f;
        float split = 2.75f;
        if (t < 1 / split)
        {
            return bounce * t * t;
        }
        else if (t < 2 / split)
        {
            t -= 1.5f / split;
            return bounce * t * t + 0.75f;
        }
        else if (t < 2.5 / split)
        {
            t -= 2.25f / split;
            return bounce * t * t + 0.9375f;
        }
        else
        {
            t -= 2.625f / split;
            return bounce * t * t + 0.984375f;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_transform.position, Params.PaintExplosionRange);
    }
}
