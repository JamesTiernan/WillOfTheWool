using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    [SerializeField]
    private LevelConnection _connection;


    [SerializeField]
    private string _targetSceneName;

    [SerializeField]
    private Transform Spawnpoint;

    GameObject player;

    private void Start()
    {
        if (_connection == LevelConnection.ActiveConnection)
        {
            player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = Spawnpoint.position;
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }
    }
}
