using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public bool invincible;
	public float bumpSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnDeath()
	{
		gameObject.GetComponent<BoxCollider2D> ().enabled = false;
		gameObject.GetComponent<BoxCollider2D> ().isTrigger = true;
		gameObject.GetComponent<Rigidbody2D> ().isKinematic = false;
		Gamedata.Instance.Lives -= 1;
		//GameObject.FindGameObjectWithTag ("Owl").GetComponent<PlayerBehaiviour> ().Leben += 1;
	}
}
