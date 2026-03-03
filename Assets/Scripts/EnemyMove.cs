using Mono.Cecil;
using NUnit.Framework;
using UnityEngine;

public class EnemySideways : MonoBehaviour
{
    [SerializeField] private float movementDistance;
    [SerializeField] private float speed;
    private bool movingLeft;
    private float leftEdge;
    private float rightEdge;

    [SerializeField] private bool IsSwooping;
    [SerializeField] private bool IsReturning;
    private Vector3 startPosition;
    private Vector3 target;
    private Transform player;

    private void Start()
    {
        startPosition = transform.position;
        

    }
    private void Awake()
    {
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;

    }


    private void Update()
    {
        if (IsSwooping)
        {
            Swoop();
        }
        else if(IsReturning)
        {
            ReturnToStart();
            
         }
        else
        {
            Patroling(); 
        }
    }


    public void StartSwoop(Transform PlayerTransform)
    {
        if (!IsSwooping && !IsReturning)
        {
            player = PlayerTransform;
            target = new Vector3(player.position.x, player.position.y, player.position.z);
            IsSwooping = true;
        }

    }


    private void Swoop()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);


        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            IsSwooping = false;
            IsReturning = true;

        }
    }


    private void ReturnToStart()
    {

        transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
        
            if (Vector3.Distance(transform.position, startPosition) < 0.1f)
        {
            transform.position = startPosition;
            Debug.Log("Einius");
            IsReturning = false;
        }
    }

    private void Patroling()
    {

        if (movingLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }

            else
            {
                movingLeft = true;
            }
        }
    }

}
