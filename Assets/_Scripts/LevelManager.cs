using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour 
{
    public void LoadLevel(string name)
	{
		Debug.Log("Load Level Requested For: " + name);
        SceneManager.LoadScene(name);
	}
	public void QuitRequest()
	{
		Debug.Log("I want to quit!");
        Application.Quit();
	}
	public void LoadNextLevel()
	{
        Scene activeScene = SceneManager.GetActiveScene();
        int activeSceneBuildIndex = activeScene.buildIndex;
        SceneManager.LoadScene(++activeSceneBuildIndex);
	}
    public void BrickDestroyed()
    {
        if (Brick.breakableCount <= 0)
        {
            LoadNextLevel();
        }
    }
}