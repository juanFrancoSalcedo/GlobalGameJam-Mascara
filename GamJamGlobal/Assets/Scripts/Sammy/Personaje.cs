using UnityEngine;
using TMPro;


public class Personaje : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2d;
    private float move;

    private int nJumps;
    private int nJumpsValue;
    public float jumpForce = 5;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    private Animator animator;
    private int coins;
    public TMP_Text textCoin;

   
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = Input.GetAxis("Horizontal");
        rb2d.linearVelocity = new Vector2(move * speed, rb2d.linearVelocity.y);

        if (move != 0)

            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);


        if (Input.GetButtonDown("Jump") && nJumpsValue >=0)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            nJumpsValue --;
        }

        if (isGrounded)
        {
            nJumpsValue = nJumps;
        }

        animator.SetFloat("Speed",Mathf.Abs(move));
        animator.SetFloat("VerticalVelocity", rb2d.linearVelocity.y);
        animator.SetBool("isGrounded", isGrounded); 

    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            textCoin.text = coins.ToString();
        }

        if (collision.transform.CompareTag("enemigo"))
        {
            Destroy(gameObject);
            
        }
    }
    
}
