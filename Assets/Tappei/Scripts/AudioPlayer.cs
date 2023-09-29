using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Đ����鉹���w�肷�邽�߂̗񋓌^
/// ����ǉ������炱���ɂ��Ή�����l��ǉ�����
/// </summary>
public enum AudioType
{
    SE_GameOver,
    SE_RaceStart,
    SE_SubmitUI,
    SE_CountDown,
    SE_Finish,
    SE_Engine_1,
    SE_Engine_2,
    SE_Engine_3,
    SE_Slide,
    SE_Damage,
    SE_Explosion,
    SE_ResultGameOver,
    SE_ResultGameClear,
}

/// <summary>
/// ���̍Đ����s���N���X
/// </summary>
[System.Serializable]
public class AudioPlayer : MonoBehaviour
{
    public static AudioPlayer Instance;

    /// <summary>
    /// �C���X�y�N�^�[���犄�蓖�Ă邽�߂̉��̃f�[�^�̃N���X
    /// </summary>
    [System.Serializable]
    public class AudioData
    {
        [SerializeField] AudioType _key;
        [SerializeField] AudioClip _clip;
        [SerializeField] float _volume;

        public AudioType Key => _key;
        public AudioClip Clip => _clip;
        public float Volume => _volume;
    }

    [SerializeField] AudioData[] _audioDatas;
    [Header("�����ɍĐ��ł��鐔")]
    [SerializeField] int _playAtSame = 10;
    [Header("�A���ōĐ��ł���Ԋu")]
    [SerializeField] float _interval = 0.05f;

    AudioSource[] _audioSources;
    Dictionary<AudioType, AudioData> _audioDict = new();
    float _lastTime;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Init(gameObject);
        }
        else
        {
            Destroy(this);
        }
    }

    void OnDisable()
    {
        _audioDict.Clear();
    }

    void Init(GameObject go)
    {
        _audioSources = new AudioSource[_playAtSame];

        for (int i = 0; i < _audioSources.Length; i++)
        {
            _audioSources[i] = go.AddComponent<AudioSource>();
        }

        foreach (AudioData data in _audioDatas)
        {
            _audioDict.Add(data.Key, data);
        }
    }

    public void PlaySE(AudioType type)
    {
        if (IsInterval()) return;

        AudioData data = GetData(type);
        AudioSource source = GetSourceSE();
        if (data == null || source == null) return;

        source.clip = data.Clip;
        source.volume = data.Volume;
        source.Play();
    }

    public void PlayBGM()
    {
        // ������ǉ�����
    }

    bool IsInterval()
    {
        if (Time.realtimeSinceStartup - _lastTime > _interval)
        {
            _lastTime = Time.realtimeSinceStartup;
            return false;
        }
        else
        {
            return true;
        }
    }

    AudioSource GetSourceSE()
    {
        // ��Ԍ���AudioSource��BGM�Đ��p�Ȃ̂Ŏ���Ă���
        for (int i = 0; i < _audioSources.Length - 1; i++)
        {
            if (!_audioSources[i].isPlaying) return _audioSources[i];
        }

        Debug.LogWarning("AudioSource���s��");
        return null;
    }

    AudioData GetData(AudioType type)
    {
        if (_audioDict.TryGetValue(type, out AudioData data))
        {
            return data;
        }

        throw new KeyNotFoundException($"�����o�^����Ă��Ȃ�: {type}");
    }
}
