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

    private void Start()
    {
        if (_connection == LevelConnection.ActiveConnection)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            player.transform.position = Spawnpoint.position;
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.collider.CompareTag("Player"))
        {
            LevelConnection.ActiveConnection = _connection;
            SceneManager.LoadScene(_targetSceneName);
        }
    }
}
