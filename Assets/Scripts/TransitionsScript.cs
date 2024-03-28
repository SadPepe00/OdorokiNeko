using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionsScript : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;


    

    public void ButtonPressed(string sceneName)
    {
        LoadNextScene(sceneName);
    }

    public void LoadNextScene(string sceneName)
    {
        //StartCoroutine(LoadScene(SceneManager.GetActiveScene().buildIndex + 1));
        SceneManager.LoadScene(sceneName);
        
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        // Load scene
        SceneManager.LoadScene(sceneIndex);
    }
}
