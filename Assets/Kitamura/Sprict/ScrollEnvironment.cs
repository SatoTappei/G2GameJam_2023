using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollEnvironment : MonoBehaviour
{
    [SerializeField] GearStep _gear = GearStep.One;
    [SerializeField] float _destroyHeight = -10.0f;

    Transform _transform;

    protected int ScrollSpeed
    {
        get
        {
            if (_gear == GearStep.One) return Params.GearOneSpeed;
            else if (_gear == GearStep.Two) return Params.GearTwoSpeed;
            else return Params.GearThreeSpeed;
        }
    }

    void OnEnable()
    {
        Car.OnGearChanged += gear => _gear = gear;
    }

    void OnDisable()
    {
        Car.OnGearChanged -= gear => _gear = gear;
    }

    void Start()
    {
        _transform = transform;
        OnStart();
    }

    void Update()
    {
        // w’è‚µ‚½‚‚³‚Åíœ
        if (_transform.position.y < _destroyHeight)
        {
            Destroy(gameObject);
        }
        else
        {
            _transform.Translate(Vector3.down * ScrollSpeed * Time.deltaTime);
        }

        OnUpdate();
    }

    protected virtual void OnStart() { }
    protected virtual void OnUpdate() { }
}
