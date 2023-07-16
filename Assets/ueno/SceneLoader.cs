using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour            //ƒV[ƒ“‚ÌØ‚è‘Ö‚¦
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
