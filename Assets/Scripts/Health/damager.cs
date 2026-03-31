using UnityEngine;

public class damager : MonoBehaviour
{
    [SerializeField] int damageAmount;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.GetComponent<healthManager>() != null)
        {
            other.GetComponent<healthManager>().Damage(damageAmount,true);
            playerController checkPlayer = other.GetComponent<playerController>();
            if(checkPlayer != null){other.GetComponent<playerController>().HitKnockback();}
        }
    }
}
