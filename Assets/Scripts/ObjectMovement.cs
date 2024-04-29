using Unity.VisualScripting;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastVelocity;
    private float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = (Random.value < 0.5f) ? 3f : -3f;
        rb.velocity = new Vector2(speed, speed);
    }

    void Update()
    {
        lastVelocity = rb.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Barrier"))
        {
            speed = lastVelocity.magnitude;
            var direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            if(rb != null)
                rb.velocity = direction * Mathf.Max(speed, 0f);
            else
            {
                rb = GetComponent<Rigidbody2D>();
                rb.velocity = direction * Mathf.Max(speed, 0f);
            }
        }
        else
        {
            string thisTag = this.tag;
            
            string otherTag = collision.gameObject.tag;

            if ((thisTag == "Rock" && otherTag == "Scissors") ||
                (thisTag == "Paper" && otherTag == "Rock") ||
                (thisTag == "Scissors" && otherTag == "Paper"))
            {
                GameObject newPrefab = GetPrefabForTag(thisTag);
                InstantiateAndDestroy(newPrefab, collision.gameObject);
            }  
        }
    }


    private GameObject GetPrefabForTag(string tag)
    {
        switch (tag)
        {
            case "Rock":
                return Resources.Load<GameObject>("Rock");
            case "Paper":
                return Resources.Load<GameObject>("Paper");
            case "Scissors":
                return Resources.Load<GameObject>("Scissors");
            default:
                return null;
        }
    }

    private void InstantiateAndDestroy(GameObject newPrefab, GameObject toDestroy)
    {
        if (newPrefab != null)
        {
            Instantiate(newPrefab, toDestroy.transform.position, toDestroy.transform.rotation);
        }
        Destroy(toDestroy);
    }


}
