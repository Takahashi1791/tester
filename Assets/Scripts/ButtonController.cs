using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void LoadMainScene()
    {
        // メインシーンに遷移
        SceneManager.LoadScene("MainScene");
    }
}

