using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : MonoBehaviour
{
    public float speed = 2f;
    public int damage = 1;

    bool enemyHit = false;
    Vector3 dir;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void FlipDirection()
    {
        speed *= -1f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player") )
        {
            PlayerMovement playerMovement = collision.collider.GetComponent<PlayerMovement>();
            
            if (playerMovement)
            {
                //playerMovement.Damage(damage);  
            }

            gameManager.PlayerDamage(damage);
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(Vector3.zero, dir * 3f);
    }
}
