using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool gameIsOver = false;

	public Text highScore;


	public void EndGame()
	{
		if (!gameIsOver)
		{
			gameIsOver = true;
			Debug.Log("Game Over!");
			//StartCoroutine(Credits());
			Credits();
		}
	}


    public void WinGame()
	{
		Debug.Log("You Win!");
		//StartCoroutine(Credits());
		Credits();
	}

	public void updateHighScore(string score)
	{
		highScore.text = score;
	}


    public void Credits()
	{
		Debug.Log("Credits Playing");
		Application.LoadLevel("Credits");
	}

 //   IEnumerator Credits()
	//{
	//	//Debug.Log("Credits Playing");
	//	yield return new WaitForSeconds(2);
	//	Debug.Log("Credits Playing");
	//	Application.LoadLevel("Credits");
	//}
}
