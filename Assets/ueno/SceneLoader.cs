using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour            //�V�[���̐؂�ւ�
{
    public void changeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
