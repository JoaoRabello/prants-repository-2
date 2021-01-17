using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public interface IDamageable
{
    /// <summary>
    /// Call this method to inflict damage to any IDamageable
    /// </summary>
    /// <param name="damageAmount">The amount of damage to inflict</param>
    void TakeDamage(float damageAmount);
}
