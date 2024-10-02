using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemyObjects;

    void Update()
    {
        // �uEnemy�v�^�O�̂����I�u�W�F�N�g������
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // �G�̐���0�ɂȂ�����N���A�V�[���ɑJ��
        if (enemyObjects.Length == 0)
        {
            SceneManager.LoadScene("GameclearScene");
        }
    }
}

