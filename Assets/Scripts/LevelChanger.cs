using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelChanger : MonoBehaviour
{
    [SerializeField] private LevelConnection _connection;
    [SerializeField] private string _targetSceneName;
    [SerializeField] private Transform Spawnpoint;
    [SerializeField] private Animator fadeAnimator;

    private GameObject player;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = null;
        player = GameObject.FindGameObjectWithTag("Player");

        if (fadeAnimator == null)
            fadeAnimator = GameObject.Find("Fade").GetComponent<Animator>();

        if (_connection == LevelConnection.ActiveConnection && player != null)
            player.transform.position = Spawnpoint.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            StartCoroutine(FadeBlackoutTeleport());
    }

    private IEnumerator FadeBlackoutTeleport()
    {
        fadeAnimator.SetTrigger("FadeOut");
        yield return new WaitForSeconds(0.32f);

        fadeAnimator.SetTrigger("black");
        yield return new WaitForSeconds(0.1f);

        LevelConnection.ActiveConnection = _connection;

        if (_targetSceneName == SceneManager.GetActiveScene().name)
        {
            if (player == null)
                player = GameObject.FindGameObjectWithTag("Player");

            player.transform.position = Spawnpoint.position;
        }
        else
        {
            SceneManager.LoadScene(_targetSceneName);
        }
        
    }
}