using System.Collections;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce;

    bool isDead = false;
    Animator animator;
    Rigidbody2D body;
    AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!isDead)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                animator.SetTrigger("Flap");
                body.velocity = Vector2.zero;
                body.AddForce(new Vector2(0, upForce));
                audioSource.Play();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetTrigger("Die");
        body.velocity = Vector2.zero;
        isDead = true;
        StartCoroutine(ResetGame());
    }

    IEnumerator ResetGame()
    {
        yield return new WaitForSeconds(3);
        GameController.Instance.ResetGame();
    }
}
