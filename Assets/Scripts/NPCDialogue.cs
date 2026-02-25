using UnityEngine;

[CreateAssetMenu(fileName = "NewNPCDialogue", menuName = "NPC Dialogue")]

public class NPCDialogue : ScriptableObject
{
    public string npcName;
    public Sprite npcImage;
    public string[] dialogue;
    public bool[] autoProgressLines;
    public float autoProgressDelay = 1.5f;
    public float typeSpeed;
    public AudioClip voice;
    public float voicePitch = 1f;

}
