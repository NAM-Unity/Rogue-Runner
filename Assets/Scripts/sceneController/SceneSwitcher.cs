using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Назва сцени, на яку перемикаємо
    public string sceneName;

    public void SwitchScene()
    {
        SceneManager.LoadScene(sceneName);
    }
}
