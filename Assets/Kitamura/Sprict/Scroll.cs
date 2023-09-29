using UnityEngine;

public class Scroll : MonoBehaviour
{
    [SerializeField] GearStep _gear = GearStep.One;
    [Header("下にあるものから順に割り当てる")]
    [SerializeField] SpriteRenderer[] _backgrounds;
    [Header("消す位置の設定")]
    [SerializeField] float _thresholdHeight = -10.43f;

    Transform[] _transforms;
    int _endIndex;

    int ScrollSpeed
    {
        get
        {
            if (_gear == GearStep.One) return Params.GearOneSpeed;
            else if (_gear == GearStep.Two) return Params.GearTwoSpeed;
            else return Params.GearThreeSpeed;
        }
    }

    public float Score { get; private set; }

    void Awake()
    {
        GetTransforms();
        _endIndex = _backgrounds.Length - 1;
    }

    void OnEnable()
    {
        Car.OnGearChanged += gear => _gear = gear;
    }

    void OnDisable()
    {
        Car.OnGearChanged -= gear => _gear = gear;
    }

    void Update()
    {
#if UNITY_EDITOR
        DebugControl();
#endif
        Move();
    }

    void GetTransforms()
    {
        _transforms = new Transform[_backgrounds.Length];
        for (int i = 0; i < _transforms.Length; i++)
        {
            _transforms[i] = _backgrounds[i].transform;
        }
    }

    void Move()
    {
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            if (_transforms[i].position.y <= _thresholdHeight)
            {
                // 背景の配列の末尾の位置+サイズ分オフセットの位置に再配置する
                Vector3 relocationPos = _transforms[_endIndex].position;
                relocationPos.y += _backgrounds[i].bounds.size.y;
                _transforms[i].position = relocationPos;

                _endIndex = i;
            }

            _transforms[i].Translate(Vector3.down * ScrollSpeed * Time.deltaTime);
        }

        // 走行距離をスコアとして保持する
        Score += ScrollSpeed * Time.deltaTime;
    }

    void DebugControl()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            _gear = GearView.Increment(_gear);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            _gear = GearView.Decrement(_gear);
        }
    }
}
