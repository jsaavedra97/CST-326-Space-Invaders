using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyMovement : MonoBehaviour
{
    private Transform enemies;
    public float enemySpeed;

    public Text score;

    public AudioSource movement;
    public AudioSource win;

    void Start()
    {
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemies = GetComponent<Transform>();
        Debug.Log(enemies.position);
    }

    void MoveEnemy()
    {
        enemies.position += Vector3.right * enemySpeed;

        movement.Play();

        foreach (Transform enemy in enemies)
        {
            // Enemy Movement
            if (enemy.position.x < -10 || enemy.position.x > 10)
            {

                enemySpeed = -enemySpeed;
                enemies.position += Vector3.down * 0.5f;
                return;
            }

            if (enemy.position.y <= -1.5)
            {
                //Game Over Stuff
                Time.timeScale = 0;

                FindObjectOfType<GameManager>().updateHighScore(score.text);
                FindObjectOfType<GameManager>().EndGame();

				//StartCoroutine(gameOverDelay());

			}
        }

        if (enemies.childCount == 0)
        {
            // Win!
            win.Play();

			Time.timeScale = 0;

			FindObjectOfType<GameManager>().updateHighScore(score.text);
			FindObjectOfType<GameManager>().WinGame();

			//StartCoroutine(winDelay());
		}

        else if (enemies.childCount == 1)
        {
			CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.025f, 0.15f);
        }

        else if (enemies.childCount > 1 && enemies.childCount <= 4)
		{
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.05f, 0.15f);
        }

        else if (enemies.childCount > 4 && enemies.childCount <= 10)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.075f, 0.15f);
        }

        else if (enemies.childCount > 10 && enemies.childCount < 15)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.085f, 0.15f);
        }
    }

    IEnumerator gameOverDelay()
	{
		yield return new WaitForSeconds(2);
        FindObjectOfType<GameManager>().EndGame();
    }

    IEnumerator winDelay()
    {
        yield return new WaitForSeconds(2);
        FindObjectOfType<GameManager>().WinGame();
    }

}
