using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    [SerializeField] AudioClip[] sounds;
    AudioSource soundPlayer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(int sfx,float pitchRange)
    {
        if(soundPlayer != null)
        {
            soundPlayer.resource = sounds[sfx];
            soundPlayer.pitch = 1;
            if(pitchRange != 0)
            {
                soundPlayer.pitch -= Random.Range(-pitchRange,pitchRange);
            }
            soundPlayer.Play();
        }
        
    }
}
