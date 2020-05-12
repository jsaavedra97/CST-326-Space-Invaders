using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    public GameObject bullet;
	private Rigidbody2D rb2D;

	public float playerSpeed;
    private float bulletDelay;
	public float rateOfFire;

    public Transform offset;

	public Text score;

	public AudioSource pew;
	public AudioSource explosion;

	void Start()
	{
		rb2D = GetComponent<Rigidbody2D>();
	}

	void Update()
    {
        // Delaying the bullets shot
		if (Input.GetButton("SpaceShip") && Time.time > bulletDelay)
        {
			pew.Play();

			bulletDelay = Time.time + rateOfFire;
			GameObject shot = Instantiate(bullet, offset.position, Quaternion.identity);
			Debug.Log("Bang!");

			//pew.Play();
			Destroy(shot, 3f);

		}

		transform.Translate(Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime, 0f, 0f);

	}

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Wall")
		{
			Debug.Log("Crash!");
		}


		if (collision.gameObject.tag == "EnemyBullet")
		{
			explosion.Play();
			Destroy(gameObject);

			Time.timeScale = 0;

			FindObjectOfType<GameManager>().updateHighScore(score.text);
			//FindObjectOfType<GameManager>().EndGame();
		}

	}

}
