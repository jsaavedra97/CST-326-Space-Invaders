using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] 
public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb2D;
    public bool isEnemy;
    
    public float speed = 5;

	//public int points; // Points assigned in inspector

	void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        Fire();
    }


    private void Fire()
    {
		Debug.Log(gameObject.tag);
		if (!isEnemy)
		{
            rb2D.velocity = Vector2.up * speed;
            Debug.Log("Wwweeeeee");
        }
		else
		{
            rb2D.velocity = Vector2.down * speed;
			Debug.Log("Grrrrrrrr");
		}
	}


	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Barricade" || collision.gameObject.tag == "Bullet" || collision.gameObject.tag == "EnemyBullet")
		{
			Destroy(gameObject);
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Player")
		{
			Destroy(gameObject);
		}

	}

    //  Made a Trigger for the Player's Bullets
	void OnTriggerEnter2D(Collider2D collider)
	{
        if (!isEnemy) 
		{
			Destroy(gameObject);
			Destroy(collider.gameObject);
		}
	}

}
