using UnityEngine;
using UnityEngine.SceneManagement;


public class gotoend : MonoBehaviour,IInteractable
{
    public void Interact()
    {
        Debug.Log("interact");
        Destroy(GameObject.FindGameObjectWithTag("Player"));
        Destroy(GameObject.FindGameObjectWithTag("UI"));
        Destroy(GameObject.FindGameObjectWithTag("MainCamera"));
        Destroy(GameObject.FindGameObjectWithTag("CoinManager"));
        SceneManager.LoadSceneAsync("endScene", LoadSceneMode.Single);
    }

    public bool IsInteractable()
    {
        return true;
    }
}
