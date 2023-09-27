using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : MonoBehaviour
{
    [SerializeField] string _tag = "Player";

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(_tag))
        {
            collision.GetComponent<IDamageable>().Damage(gameObject);
        }
    }
}
