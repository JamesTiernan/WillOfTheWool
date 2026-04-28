using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private GameObject Pausetxt;
    [SerializeField] private GameObject Sliders;

    GameObject text;
    GameObject PauseScreen;
    private bool active = false;

    private void Start()
    {
        PauseScreen = PausePanel;
        text = Pausetxt;
        PauseScreen.SetActive(false);
        text.SetActive(false);
        Sliders.SetActive(false);
        active = false;
        
    }
    public void Pause(InputAction.CallbackContext context)
    {
        if (active == false)
        {
            PauseScreen.SetActive(true);
            text.SetActive(true);
            Sliders.SetActive(true);
            active = true;
            Time.timeScale = 0f;
            
        }

        else
        {
            PauseScreen.SetActive(false);
            text.SetActive(false);
            Sliders.SetActive(false);
            active = false;
            Time.timeScale = 1.0f;
        }

    }
}
