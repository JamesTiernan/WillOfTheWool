using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class mainMenuManager : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadGame()
    {
        StartCoroutine(LoadScenes());
    }
    IEnumerator LoadScenes()
    {
        AsyncOperation part1Load = SceneManager.LoadSceneAsync("Part1",LoadSceneMode.Additive);
        yield return part1Load;

        AsyncOperation playerLoad = SceneManager.LoadSceneAsync("playerScene", LoadSceneMode.Additive);
        yield return playerLoad;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            player.transform.position = new Vector3(-14, 5, 0);
        }

        yield return SceneManager.UnloadSceneAsync("mainMenu");
    }
}
