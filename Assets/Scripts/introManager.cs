using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class introManager : MonoBehaviour
{
    [SerializeField] InputAction pressAction;
    [SerializeField] int end;

    [SerializeField] GameObject[] textintro;
    [SerializeField] string SceneGoto;
    int progress = -1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NextText();
    }

    private void OnEnable()
    {
        // Enable the action
        pressAction.Enable();

        // Subscribe to events
        pressAction.started += OnPressStarted;     // Button down
    }

    private void OnDisable()
    {
        // Unsubscribe to avoid memory leaks
        pressAction.started -= OnPressStarted;

        pressAction.Disable();
    }

    private void OnPressStarted(InputAction.CallbackContext ctx)
    {
        Debug.Log("Button Pressed");
        NextText();
    }
    public void NextText()
    {
        if(progress == end)
        {
            return;
        }
        if(progress != -1)
        {
            textintro[progress].SetActive(false);
        }
        progress += 1;

        if(progress == end)
        {
            SceneManager.LoadSceneAsync(SceneGoto, LoadSceneMode.Single);
            return;

        }

        textintro[progress].SetActive(true);
        textintro[progress].GetComponent<Animator>().Play($"{progress}",0);

        StartCoroutine(Waiting());
    }

    IEnumerator Waiting()
    {
        Animator anim = textintro[progress].GetComponent<Animator>();
        
        yield return new WaitUntil(() => anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f);
        NextText();
    }
}
