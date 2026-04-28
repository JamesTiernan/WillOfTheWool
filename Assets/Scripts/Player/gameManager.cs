using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class gameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    public void ReloadScene()
    {
       string currentSceneName = SceneManager.GetActiveScene().name;
       Debug.Log($"{currentSceneName}  -- reloaded");
       SceneManager.LoadScene(currentSceneName);
       
       player.GetComponent<healthManager>().health = player.GetComponent<healthManager>().maxHealth;
       player.GetComponent<healthManager>().gameoverScreen.SetActive(false);
       player.GetComponent<healthManager>().isDead = false;
       player.GetComponent<conveyorEffect>().onConveyor = false;
       player.GetComponent<playerController>().FixH();
       player.GetComponent<conveyorEffect>().speed = 0;
       player.GetComponent<conveyorEffect>().origin = false;
       player.GetComponent<woolInventoryManager>().RespawnWool();
       Invoke("Respawn",0.1f);
       
    }

    void Respawn()
    {
        player.transform.position = GetComponent<lastCheckpoint>().checkpointPosition;
    }
}