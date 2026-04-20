using UnityEngine;
using UnityEngine.SceneManagement;

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
        SceneManager.LoadSceneAsync("Demo Level");
        SceneManager.LoadSceneAsync("playerScene",LoadSceneMode.Additive);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-14,5,0);
        SceneManager.UnloadSceneAsync("mainMenu");
    }
}
