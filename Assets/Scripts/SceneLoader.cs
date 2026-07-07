using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("GameScene");
    }
}