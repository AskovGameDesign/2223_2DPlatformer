using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DirectionFlipper : MonoBehaviour
{

    BoxCollider2D collider2D; 

    // Start is called before the first frame update
    void Start()
    {
        collider2D = GetComponent<BoxCollider2D>();
        collider2D.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            collision.GetComponent<SimpleEnemy>().FlipDirection();
            Vector3 enemyScale = collision.transform.localScale;
            enemyScale.x *= -1;
            collision.transform.localScale = enemyScale;
        }
    }

    private void OnDrawGizmos()
    {
        
    }

}
