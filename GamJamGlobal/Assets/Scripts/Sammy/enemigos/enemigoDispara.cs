using UnityEngine;

public class enemigoDispara : MonoBehaviour
{
    public Transform player;
    public float detectionRange = 5.0f;
    public float speed = 2.0f;
    private Rigidbody2D rb2D;
    private Vector2 movement;
    void Start()
    {
       rb2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < detectionRange)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            movement = new Vector2(direction.x, 0);

        }

        else
        {
            movement = Vector2.zero;
        }

        rb2D.MovePosition(rb2D.position + movement * speed * Time.deltaTime);
    }
}
