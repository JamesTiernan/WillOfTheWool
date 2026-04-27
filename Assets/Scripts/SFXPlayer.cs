using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource soundPlayer;
    private SFXManager sFXManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
        sFXManager = GameObject.FindGameObjectWithTag("SFXManager").GetComponent<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int sfx,float pitchRange)
    {
        if(soundPlayer != null)
        {
            if(sounds.GetLength(0) <= sfx)
            {
                Debug.LogWarning("SFX out of range.");
                return;
            }
            soundPlayer.resource = sounds[sfx];
            soundPlayer.pitch = 1;
            soundPlayer.volume = sFXManager.SFXValue();
            
            if(pitchRange != 0)
            {
                soundPlayer.pitch -= Random.Range(-pitchRange,pitchRange);
            }
            soundPlayer.Play();
        }
        
    }
}
