using UnityEngine;
using UnityEngine.SceneManagement;
public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void ReloadScene()
    {
       string currentSceneName = SceneManager.GetActiveScene().name;
       Debug.Log($"{currentSceneName}  -- reloaded");
       SceneManager.LoadScene(currentSceneName);
       player.transform.position = GetComponent<lastCheckpoint>().checkpointPosition;
       player.GetComponent<healthManager>().health = player.GetComponent<healthManager>().maxHealth;
       player.GetComponent<healthManager>().gameoverScreen.SetActive(false);
       player.GetComponent<healthManager>().isDead = false;
       player.GetComponent<woolInventoryManager>().RespawnWool();
    }
}