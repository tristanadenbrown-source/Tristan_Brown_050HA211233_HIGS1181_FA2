using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    float moveSpeed = 10f; //This is a variable that will be referenced for movement speed//
    
    public float delayTimeModifier = 10f;//I chose 10 becasue it is the lowest number where that causes the camera not to wander off from the player when repeatedlly moving into walls//

    public Vector2 camerOffset;
    public Vector3 offset;
    public Vector2 startPosition;

    public GameManager targetedScript;

    public Transform playerCharacter;

    private bool movement = true;
    void Start()
    {
        offset = (Vector3)camerOffset;
        offset.z = transform.position.z - playerCharacter.position.z;
        startPosition = transform.position;

    }
    void Update()
    {
        if (targetedScript.Win == false)
        {
            Move();
        }
        if (targetedScript.Win == true)
        { 
            Destroy(GetComponent<PlayerController>());        }
        if (targetedScript.Loss == true)
        {
            Destroy(GetComponent<PlayerController>());
        }

    }

    private void LateUpdate()
    {
        CameraFollow();
    }
    void Move()
    {

    if (movement == true)
            {
                float moveX = Input.GetAxis("Horizontal");
                float moveY = Input.GetAxis("Vertical");

                Vector2 move = new Vector2(moveX, moveY);
                transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
            }

    }
    // Sourced from: "Controlling Unity Camera Behaviour", Unity Learn(https://learn.unity.com/tutorial/controlling-unity-camera-behaviour) adapted by [Tristan Brown]
    void CameraFollow()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerCharacter.position + offset, delayTimeModifier * Time.deltaTime);
    }
    public void TakeDamage()
    {
        transform.position = startPosition;
        targetedScript.health -= 1;
        Debug.Log("You Took Damage");
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Hazard"))
        {
            TakeDamage();
        }

        else if(other.CompareTag("Collectible"))
        {
            targetedScript.AddScore();
            Destroy(other.gameObject);
        }
    }

}

