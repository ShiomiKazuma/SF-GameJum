using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour            //シーンの切り替え
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
