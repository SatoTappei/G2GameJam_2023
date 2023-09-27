using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 車に対してダメージを与えるためのインターフェース
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// 引数で渡されたGameObjectを判定して汚れやギアの変更の処理を呼び出す
    /// </summary>
    /// <param name="item">このメソッドを呼び出すGameObject自身</param>
    void Damage(GameObject item);
}
