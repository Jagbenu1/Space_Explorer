using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{

  [SerializeField] float invokeValue = 2f;
  void OnCollisionEnter(Collision other)
  {
    switch (other.gameObject.tag)
    {
      case "Friendly":
        Debug.Log("This thing is friendly");
        break;
      case "Finish":
        StartFinishSequence();
        break;
      default:
        StartCrashSequence();
        break;
    }
  }

  void StartCrashSequence()
  {
    // todo add sfx upon crash
    // todo add particle effect upon crash
    GetComponent<Movement>().enabled = false;
    Invoke("ReloadLevel", invokeValue);
  }

  void StartFinishSequence()
  {
    // todo add sfx upon crash
    // todo add particle effect upon crash
    GetComponent<Movement>().enabled = false;
    Invoke("LoadNextLevel", invokeValue);
  }

  void ReloadLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    SceneManager.LoadScene(currentSceneIndex);
  }

  void LoadNextLevel()
  {
    int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    int nextSceneIndex = currentSceneIndex + 1;
    if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
    {
      nextSceneIndex = 0;
    }
    SceneManager.LoadScene(nextSceneIndex);
  }
}


