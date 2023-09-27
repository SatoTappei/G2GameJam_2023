using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipsLogic : MonoBehaviour
{
    [SerializeField] Button _button;

    void Start()
    {
        _button.onClick.AddListener(ToInGame);
    }

    void Update()
    {
        
    }

    void ToInGame()
    {

    }
}
