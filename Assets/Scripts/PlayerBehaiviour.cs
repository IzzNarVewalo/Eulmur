using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerBehaiviour : MonoBehaviour, ITR
{
	public MoveSettings moveSettings;
	public InputSettings inputSettings;
	public Transform spawnPoint;
	public GameObject Owl, Lemur, Camera;
	private float p1SidewaysInput, p2SidewaysInput, p1JumpInput, p2JumpInput;
	public LayerMask Layers;

	public Sprite spriteOwlEin;
	public Sprite spriteOwlSchnurr;
	public Sprite spriteOwlKron;
	public Sprite spriteOwlnichts;
	public Sprite spriteLemurEin;
	public Sprite spriteLemurSchnurr;
	public Sprite spriteLemurKron;
	public Sprite spriteLemurnichts;

	private float scaleOwl;
	private float scaleLemur;

	//fuer Animation:
	public Animator anim; // Refrerence to the animator
	private float fangeanLaufen = -1f;
	private float Lemurlauf = -1f;
	//aus

	public enum Kostum {nichts, Einhornhorn, Schnurrbart, Krone};

	public static Kostum angezogen = Kostum.nichts;
	private TimeReverse trscript;

	public static Text playerStats;
	//speichert Text

	public bool timereverse;


	public void umziehen()
    {
        Owl.transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = PlayerData.unicornhorn;
        Owl.transform.GetChild(5).GetComponent<SpriteRenderer>().enabled = PlayerData.crown;
        Owl.transform.GetChild(6).GetComponent<SpriteRenderer>().enabled = PlayerData.moustache;
        Lemur.transform.GetChild(5).GetComponent<SpriteRenderer>().enabled = PlayerData.unicornhorn;
        Lemur.transform.GetChild(6).GetComponent<SpriteRenderer>().enabled = PlayerData.crown;
        Lemur.transform.GetChild(7).GetComponent<SpriteRenderer>().enabled = PlayerData.moustache;
        Debug.Log(Owl.transform.GetChild(4));
        Debug.Log(Lemur.transform.GetChild(5));
    }

    private void Awake ()
	{
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
		//Owl = Camera.GetComponent<cameraScript>().Owl;
		//Lemur = Camera.GetComponent<cameraScript>().Lemur;
		p1SidewaysInput = p1JumpInput = 0;
		p2SidewaysInput = p2JumpInput = 0;
        //Leben festlegen
		Gamedata.Instance.Lives = PlayerData.hp; 
		Gamedata.Instance.Food = 0;
	}

	//fuer Eule
	void GetPlayer1Input ()
	{ 
		p1SidewaysInput = Input.GetAxis (inputSettings.PLAYER1_SIDEWAYS_AXIS);
		if(p1SidewaysInput < 0){

		Owl.transform.localScale  =   new Vector3(scaleOwl*(1), Owl.transform.localScale.y, Owl.transform.localScale.z); 
			fangeanLaufen = 1;
		}
		if(p1SidewaysInput > 0){

			Owl.transform.localScale  =   new Vector3(scaleOwl*(-1), Owl.transform.localScale.y, Owl.transform.localScale.z); 
			fangeanLaufen = 1;
		}

		if(p1SidewaysInput == 0){

				fangeanLaufen = -1;
		}

		p1JumpInput = Input.GetAxis (inputSettings.PLAYER1_JUMP_AXIS);

		// Update the animator variables
		anim.SetFloat("fangeanLaufen", fangeanLaufen);
	}

	//fuer Lemur
	void GetPlayer2Input ()
	{
		p2SidewaysInput = Input.GetAxis (inputSettings.PLAYER2_SIDEWAYS_AXIS);

		if(p2SidewaysInput < 0){

			Lemur.transform.localScale  =   new Vector3(scaleLemur*(1), Lemur.transform.localScale.y, Lemur.transform.localScale.z); 
			Lemurlauf = 1;

		}
		if(p2SidewaysInput > 0){

			Lemur.transform.localScale  =   new Vector3(scaleLemur*(-1), Lemur.transform.localScale.y, Lemur.transform.localScale.z); 
			Lemurlauf = 1;
		
		}

		if(p2SidewaysInput == 0){

			Lemurlauf = -1;
		}

		p2JumpInput = Input.GetAxis(inputSettings.PLAYER2_JUMP_AXIS);
		// Update the animator variables
		anim.SetFloat("Lemurlauf", Lemurlauf);


	}

	void Run ()
	{
		if (Owl.transform.position.x < Camera.transform.position.x - 8)
			Owl.transform.position = new Vector2 (Camera.transform.position.x - 8, Owl.transform.position.y);
		else if (Owl.transform.position.x > Camera.transform.position.x + 8)
			Owl.transform.position = new Vector2 (Camera.transform.position.x + 8, Owl.transform.position.y);
		else
			Owl.transform.position += transform.right * p1SidewaysInput * Time.deltaTime * moveSettings.RunVelocity;


		if (Lemur.transform.position.x < Camera.transform.position.x - 8)
			Lemur.transform.position = new Vector2 (Camera.transform.position.x - 8, Lemur.transform.position.y);
		else if (Lemur.transform.position.x >= Camera.transform.position.x + 8)
			Lemur.transform.position = new Vector2 (Camera.transform.position.x + 8, Lemur.transform.position.y);
		else
			Lemur.transform.position += transform.right * p2SidewaysInput * Time.deltaTime * moveSettings.RunVelocity;
      
	}

    private void Jump()
    {
        //jump abhängig vom food
        if (p1JumpInput != 0)
        {
            if (OwlGrounded())
			{
                if (Gamedata.Instance.Food > 0)
                {
                    Owl.GetComponent<Rigidbody2D>().AddForce(Vector2.up*moveSettings.JumpVelocity * 6, ForceMode2D.Impulse);
                    Gamedata.Instance.Food -= 1;
                    UpdateStats();
                }
                else
                    Owl.GetComponent<Rigidbody2D>().AddForce(Vector2.up*moveSettings.JumpVelocity, ForceMode2D.Impulse);
            }
                           
            
        }
        if (p2JumpInput != 0 && LemurGrounded())
        {
            Lemur.GetComponent<Rigidbody2D>().AddForce(Vector2.up*moveSettings.JumpVelocity, ForceMode2D.Impulse);
        }
    }

    bool LemurGrounded ()
	{
		Debug.DrawRay(GameObject.FindGameObjectWithTag ("Lemur").transform.position, Vector3.down,Color.green);
		return Physics2D.Raycast (GameObject.FindGameObjectWithTag ("Lemur").transform.position, Vector2.down, moveSettings.DistanceToGround, moveSettings.Ground);
	}

	bool OwlGrounded ()
	{
		Debug.DrawRay(GameObject.FindGameObjectWithTag ("Owl").transform.position, Vector3.down,Color.green);
		return Physics2D.Raycast (GameObject.FindGameObjectWithTag ("Owl").transform.position, Vector2.down, moveSettings.DistanceToGround, moveSettings.Ground);
			}

	public void Spawn ()
	{
		GameObject.FindGameObjectWithTag ("Owl").transform.position = spawnPoint.position;
		GameObject.FindGameObjectWithTag ("Lemur").transform.position = spawnPoint.position;
		GameObject.FindGameObjectWithTag("MainCamera").transform.position = spawnPoint.position;

	}
	void Update ()
	{
		if (Gamedata.Instance.Paused && gameObject.GetComponent<TimeReverse> () != null)
			return;
		GetPlayer1Input ();
		GetPlayer2Input ();
	}

	void LateUpdate ()
	{
		if (Owl.transform.position.x < Camera.transform.position.x - 8)
			Owl.transform.position = new Vector2 (Camera.transform.position.x - 8, Owl.transform.position.y);
		else if (Owl.transform.position.x > Camera.transform.position.x + 8)
			Owl.transform.position = new Vector2 (Camera.transform.position.x + 8, Owl.transform.position.y);
	}


	void FixedUpdate ()
	{
		if (Gamedata.Instance.Paused && gameObject.GetComponent<TimeReverse> () != null)
			return;


		//hae?????
		if (!Owl.GetComponent<Rigidbody2D> ().isKinematic && !Lemur.GetComponent<Rigidbody2D> ().isKinematic) {
			Run ();
			Jump ();
		}

	}

	void Start ()
	{
		trscript = GetComponent<TimeReverse> ();
		playerStats = GameObject.Find ("PlayerStats").GetComponent<Text> ();
		UpdateStats ();
		timereverse = false;
		scaleOwl = -1 * Owl.transform.localScale.x;
		scaleLemur = -1 * Lemur.transform.localScale.x;
        umziehen();
	}

	//fuer TimeReverse

	#region ITR implementation

	public void SaveTRObject ()
	{
		MyStatus status = new MyStatus ();
		status.myPosition = transform.position;
		//status.myRotation = transform.rotation;, gibts doch nicht, oder?
		trscript.PushTRObject (status);
		Lemur.GetComponent<Rigidbody2D> ().isKinematic = false;
		Owl.GetComponent<Rigidbody2D> ().isKinematic = false;
	}

	public void LoadTRObject (TRObject trobject)
	{
		MyStatus newStatus = (MyStatus)trobject;
		transform.position = newStatus.myPosition;
		//transform.rotation = newStatus.myRotation;
		Owl.GetComponent<Rigidbody2D> ().isKinematic = true;
		Lemur.GetComponent<Rigidbody2D> ().isKinematic = true;
	}

	#endregion

	private class MyStatus: TRObject
	{
		public Vector2 myPosition;
		//evtl. brauche mehr
	}

	void OnDeath ()
	{
		Gamedata.Instance.Lives -= 1;
		UpdateStats ();

		//wenn schon verloren
		if (Gamedata.Instance.Lives == 0) {
			SceneManager.LoadScene("Verloren");

		}
		//sollte doch lieber das TimeReversal aufgerufen werden
		Spawn ();
	}

	void OnCollisionEnter2D (Collision2D	other)
	{

		if (other.gameObject.tag == "Platform") {  //tag von der sich bewegenden Plattform


			//aktuelles Objekt(this. wichtig wenn mehrere Player), weilnicht static kann ich mehrere Player haben

			//             werde Child von dem was ich grad berühre

			//this.transform.parent = collision.transform;

			this.transform.SetParent (other.transform);  
			//                        das mit was ich colliediere wird Elternteil
			//              ist eine Methode
		}


		if (other.gameObject.tag == "Fallenemy") {
			Gamedata.Instance.Lives -= 1;
			UpdateStats ();

			//wenn schon verloren
			if (Gamedata.Instance.Lives == 0) {
				SceneManager.LoadScene (6);

			}
		}

		if (other.gameObject.tag == "Enemy") {
			Enemy enemy = other.gameObject.GetComponent<Enemy> ();
			BoxCollider2D col = other.gameObject.GetComponent<BoxCollider2D> ();
			BoxCollider2D mycol = this.gameObject.GetComponent<BoxCollider2D> ();

			if (enemy.invincible) {
				OnDeath ();
			} else if (mycol.bounds.center.y - mycol.bounds.extents.y > col.bounds.center.y + 0.5f *
			    col.bounds.extents.y) {
				if (this.gameObject.tag == "Owl") {

					JumpedOnEnemy1 (enemy.bumpSpeed);
				}
				if (this.gameObject.tag == "Lemur") {
					JumpedOnEnemy2 (enemy.bumpSpeed);
				}

				enemy.OnDeath ();
			} else {
				OnDeath ();
			}
		}

	}


	void OnCollisionExit2D (Collision2D other)
	{
		// ich hab viele Infos, will aber nur die vom Object
		if (other.gameObject.tag	== "Platform") {
			this.transform.parent = null;
		}
	}



	void JumpedOnEnemy1 (float bumpSpeed)
	{
		
		Owl.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Owl.GetComponent<Rigidbody2D> ().velocity.x, bumpSpeed);

	}

	void JumpedOnEnemy2 (float bumpSpeed)
	{

		Lemur.GetComponent<Rigidbody2D> ().velocity = new Vector2 (Lemur.GetComponent<Rigidbody2D> ().velocity.x, bumpSpeed);
	}



	IEnumerator Nacheinander(GameObject Affe, float wartezeit){
		yield return new WaitForSeconds (wartezeit);
		Affe.GetComponent<fall_enemy> ().fallen();

	}

	void OnTriggerEnter2D (Collider2D other)
	{

		if (other.tag == "Tuer") {
			SceneManager.LoadScene ("Endszene");
		}


		if (other.tag == "Food") {
			Gamedata.Instance.Food += 1;
			Destroy (other.gameObject);
			UpdateStats ();
		}


		if (other.tag == "Button1") {

			GameObject.FindGameObjectWithTag ("Wand1").GetComponent<WandbewegeKnopf> ().bewegeHoch ();
		}


		if (other.tag == "Affengrenze") {
			float wartezeit = 2f;
			GameObject[] Affen;			
			Affen = GameObject.FindGameObjectsWithTag ("Fallenemy");
			//ruft alle gleichzeitig auf-> muessen immer um zwei erhoehen
			foreach(GameObject Affe in Affen){	
				wartezeit++; 
				StartCoroutine (Nacheinander (Affe, wartezeit));
			}
		}

		if (other.tag == "Deathzone") {
			
			OnDeathSpieler ();

		}

		if (other.tag == "Coin") {
			
			Gamedata.Instance.Score += 10;
			Destroy (other.gameObject);
			UpdateStats ();
		}

		if (other.tag == "Herz") {

			Gamedata.Instance.Lives += 1;
			Destroy (other.gameObject);
			UpdateStats ();
		}
	}

	void OnDeathSpieler ()
	{
		Gamedata.Instance.Lives -= 1;
		UpdateStats ();



		OnDeath ();

		Spawn ();
		//wenn schon verloren
		if (Gamedata.Instance.Lives == 0) {
			SceneManager.LoadScene(6);
		}

		//TimeReverse wird aktiviert -> soll für Gegner, Platformen und Spieler gelten

		/*timereverse = true;
		int variable = 0;
		while(variable < 20){

		//	gameObject.GetComponent<TimeReverse>().Laden());
			variable++;
	}*/
	}

	public static void UpdateStats ()
	{ 
		playerStats.text = "Score: " + Gamedata.Instance.Score.ToString ()
			 // ToString: zuerst ist e snur eine zahl, aber wir wollen einen string
		+ "\nLives: " + Gamedata.Instance.Lives.ToString ()
		+ "\nFood: " + Gamedata.Instance.Food.ToString (); 
		//playerStats.text = "Score: " + Gamedata.Instance.Score.ToString()
		//	+ "\nLives: " +Gamedata.Instance.Lives.ToString(); 

	}

    
}

[System.Serializable]
public class MoveSettings
{
	public float RunVelocity = 12;
	public float JumpVelocity = 2f;
	public float DistanceToGround = 0.5f;
	public LayerMask Ground;
}

[System.Serializable]
public class InputSettings
{
	public string PLAYER1_SIDEWAYS_AXIS = "Player1Horizontal";
	public string PLAYER1_JUMP_AXIS = "Player1Jump";
	public string PLAYER1_FLY_AXIS = "Player1Fly";
	public string PLAYER2_SIDEWAYS_AXIS = "Player2Horizontal";
	public string PLAYER2_JUMP_AXIS = "Player2Jump";
	public string PLAYER2_CROUCH_AXIS = "Player2Crouch";
}