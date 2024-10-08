using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // 敵の最大体力
    public int currentHealth = 10; // 現在の体力

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ダメージを受けた分だけ体力を減らす

        if (currentHealth <= 0)
        {
            // 体力が0以下になったら敵を破壊する
            Destroy(gameObject);
        }
    }
}
