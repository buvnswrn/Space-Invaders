using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{

	public GameObject explosion;
	public GameObject playerExplosion;
	public int ScoreValue;
	private GameController gamecontroller;
	void Start()
	{
		GameObject gameControllerobject = GameObject.FindWithTag ("GameController");
		if (gameControllerobject != null) 
		{
			gamecontroller = gameControllerobject.GetComponent<GameController> ();
		}
		if (gameControllerobject == null) 
		{
			Debug.Log ("Cannot Find Game Controller Script");
		}
	}
	void OnTriggerEnter(Collider other){
	if(other.tag=="Boundary")
	{
	return;
	}
	Instantiate(explosion,transform.position,transform.rotation);
	if(other.tag=="Player")
	{
	Instantiate(playerExplosion,other.transform.position,other.transform.rotation);
			gamecontroller.GameOver ();
	}
	gamecontroller.AddScore (ScoreValue);
	Destroy(other.gameObject);
	Destroy(gameObject);
	}
}
