using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �Ԃɑ΂��ă_���[�W��^���邽�߂̃C���^�[�t�F�[�X
/// </summary>
public interface IDamageable
{
    /// <summary>
    /// �����œn���ꂽGameObject�𔻒肵�ĉ����M�A�̕ύX�̏������Ăяo��
    /// </summary>
    /// <param name="item">���̃��\�b�h���Ăяo��GameObject���g</param>
    void Damage(GameObject item);
}
