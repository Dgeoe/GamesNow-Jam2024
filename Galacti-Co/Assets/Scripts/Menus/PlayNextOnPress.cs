using UnityEngine;
using UnityEngine.SceneManagement;  
using UnityEngine.UI;              



public class PlayNextOnPress : MonoBehaviour
{
    public Button yourButton;  

    void Start()

    {
        if (yourButton != null)

        {

            yourButton.onClick.AddListener(OnButtonClick);

        }
    }
    void OnButtonClick()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {

            SceneManager.LoadScene(nextSceneIndex);  // Load the next scene

        }
        else
        {

            Debug.Log("No more scenes to load!");  
        }
    }

}