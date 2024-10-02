using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 10; // �G�̍ő�̗�
    public int currentHealth = 10; // ���݂̗̑�

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // �_���[�W���󂯂��������̗͂����炷

        if (currentHealth <= 0)
        {
            // �̗͂�0�ȉ��ɂȂ�����G��j�󂷂�
            Destroy(gameObject);
        }
    }
}
