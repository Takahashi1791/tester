using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // プレイヤーと接触したらゲームオーバーシーンに遷移
            SceneManager.LoadScene("GameoverScene");
        }
    }
}

