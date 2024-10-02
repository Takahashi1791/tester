using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // �v���C���[�ƐڐG������Q�[���I�[�o�[�V�[���ɑJ��
            SceneManager.LoadScene("GameoverScene");
        }
    }
}

