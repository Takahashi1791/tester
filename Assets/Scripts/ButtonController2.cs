using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController2 : MonoBehaviour
{
    public void LoadTitleScene()
    {
        // メインシーンに遷移
        SceneManager.LoadScene("TitleScene");
    }
}

