using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Transform _t;
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private bool isJumping = false;

    [SerializeField]
    private float Speed = 4f;

    [SerializeField]
    private float Jump = 10f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(new Vector2(-Speed * 15, transform.localPosition.y));
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.AddForce(new Vector2(transform.localPosition.x, Jump * 130), ForceMode2D.Force);
                isJumping = true;
                rb.AddForce(new Vector2(transform.position.x, Jump * 60));
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(new Vector2(Speed * 15, transform.localPosition.y));
            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.AddForce(new Vector2(transform.localPosition.x, Jump * 130), ForceMode2D.Force);
                isJumping = true;
                rb.AddForce(new Vector2(transform.position.x, Jump * 60));
            }
        }
        else if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            rb.AddForce(new Vector2(transform.position.x, Jump * 130), ForceMode2D.Force);
            isJumping = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("ground"))
        {
            isJumping = false;
        }
        if (c.gameObject.CompareTag("Lava"))
        {
            Debug.Log("Colisao");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}