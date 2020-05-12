using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public GameObject bullet;
    public Transform offset;
    public float rateOfFire;


    public Text score;
    public int points;

    public AudioSource bang;

    void FixedUpdate()
	{
        // Enemy Bullets
        if (Random.value > rateOfFire)
        {
            bang.Play();

            Debug.Log(bullet);
            GameObject shot = Instantiate(bullet, offset.position, Quaternion.identity);
            Destroy(shot, 3f);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        // Increments Score on Collision
        if (collider.tag == "Bullet")
		{
            int tempScore = int.Parse(score.text) + points;
            int numZeroes;
            string zeroes = "";

            if (tempScore < 100)
            {
                numZeroes = 2;
            }

            else if (tempScore < 1000)
			{
                numZeroes = 1;
			}

			else
			{
                numZeroes = 0;
			}

            for(int i = 0; i < numZeroes; i++)
			{
                zeroes += "0";
			}

            score.text = zeroes + (int.Parse(score.text) + points).ToString();
		}
    }

 
}
