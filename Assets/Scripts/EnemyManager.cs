using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    private GameObject[] enemyObjects;

    void Update()
    {
        // 「Enemy」タグのついたオブジェクトを検索
        enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        // 敵の数が0になったらクリアシーンに遷移
        if (enemyObjects.Length == 0)
        {
            SceneManager.LoadScene("GameclearScene");
        }
    }
}

