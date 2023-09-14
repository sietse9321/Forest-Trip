
using UnityEngine.SceneManagement;
using UnityEngine;


public class SceneSwitcher : MonoBehaviour
{
    [SerializeField] Animator sceneSwitch;
    //temp int
    public void SwitchScene()
    {
        sceneSwitch.SetTrigger("Fade Out");
    }
    /// <summary>
    /// When the fade has finished to black, animationevent calls method to load next scene
    /// </summary>
    public void LoadScene()
    {
        SceneManager.LoadScene(1);
    }
}
