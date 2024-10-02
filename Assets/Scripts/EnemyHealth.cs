using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // “G‚ÌÅ‘å‘Ì—Í
    public int currentHealth = 10; // Œ»İ‚Ì‘Ì—Í

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ƒ_ƒ[ƒW‚ğó‚¯‚½•ª‚¾‚¯‘Ì—Í‚ğŒ¸‚ç‚·

        if (currentHealth <= 0)
        {
            // ‘Ì—Í‚ª0ˆÈ‰º‚É‚È‚Á‚½‚ç“G‚ğ”j‰ó‚·‚é
            Destroy(gameObject);
        }
    }
}
