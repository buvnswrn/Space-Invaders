using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount;
	public float spawnWait;
	public float startWait;
	public float waveWait;
	public Text scoreText;
	public Text restartText;
	public Text gameoverText;
	private bool gameover;
	private bool restart;
	private int score;
	void Start()
	{
		gameover = false;
		restart = false;
		gameoverText.text="";
		restartText.text="";
		score = 0;
		UpdateScore ();
		StartCoroutine(SpawnWaves());
	}
	void Update()
	{
		if (restart) 
		{
			if (Input.GetKeyDown (KeyCode.R)) 
			{
				Application.LoadLevel (Application.loadedLevel);
			}
				
		}


	}

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
			
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (hazard, spawnPosition, spawnRotation);
				yield return new WaitForSeconds (spawnWait);
	
			}
			yield return new WaitForSeconds (waveWait);
			if (gameover) {
				restartText.text = "Press 'R' to Restart";
				restart = true;
				break;
			}
		}
	}
	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
	public void GameOver()
	{
		gameoverText.text = "Game Over!!!";
		gameover = true;
	}
}
