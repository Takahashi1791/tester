using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadMainScene()
    {
        // ���C���V�[���ɑJ��
        SceneManager.LoadScene("MainScene");
    }
}

