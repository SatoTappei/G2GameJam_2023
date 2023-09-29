using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSpawner : MonoBehaviour
{
    static Transform _parent;

    [SerializeField] GearStep _gear = GearStep.One;
    [SerializeField] GameObject[] _prefabs;
    [Header("¶¬ˆÊ’u")]
    [SerializeField] Transform[] _spawnPoints;
    [Header("¶¬ŠÔŠu(deltaTime * ƒMƒA‚Ì‘¬“x)")]
    [SerializeField] float _spawnRate = 20;
    float _timer;
    bool _isValid;

    int ScrollSpeed
    {
        get
        {
            if (_gear == GearStep.One) return Params.GearOneSpeed;
            else if (_gear == GearStep.Two) return Params.GearTwoSpeed;
            else return Params.GearThreeSpeed;
        }
    }

    public GearStep Gear { get => _gear; set => _gear = value; }

    void Awake()
    {
        if (_parent == null) _parent = new GameObject().transform;
    }

    void OnEnable()
    {
        MainLogic.OnGameStart += () => _isValid = true;
        MainLogic.OnGameClear += InValid;
        MainLogic.OnGameOver += InValid; 
    }

    private void OnDisable()
    {
        MainLogic.OnGameStart -= () => _isValid = true;
        MainLogic.OnGameClear -= InValid;
        MainLogic.OnGameOver -= InValid;
    }

    void Update()
    {
        if (!_isValid) return;

        _timer += Time.deltaTime * ScrollSpeed;
        if(_timer > _spawnRate)
        {
            _timer = 0;
            Spawn();
        }
    }

    void Spawn()
    {
        Vector3 spawnPos = _spawnPoints[Random.Range(0, _spawnPoints.Length)].position;
        GameObject prefab = _prefabs[Random.Range(0, _prefabs.Length)];
        GameObject environment = Instantiate(prefab, spawnPos, Quaternion.identity, _parent);
    }

    void InValid()
    {
        _isValid = false;
        if (_parent != null) Destroy(_parent.gameObject);
    }
}
