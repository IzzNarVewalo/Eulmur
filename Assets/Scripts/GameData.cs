//wir wollen eine Klasse, die nur eine refernz hat; singleten oder so ähnlich


public class Gamedata
{

	private static Gamedata instance;
    private int score;
    //nur deklariert, noch nicht initialisiert

    //konstruktor

    private Gamedata ()
	{
		//sicher gehen, dass nur eine instanz erschaffen
		//aber redundand, weil private -> nur in script änderbar und hier * macht
		if (instance != null)
			return;
		instance = this;
		Paused = false; //damit zeit AssetModificationProcessor anfang nicht zurückgedreht wird
	}


	public static Gamedata Instance { //schreibgeschützt
		get { //da drauf zugreifen
			//*hier
			if (instance == null)
				instance = new Gamedata ();//neue Instanz erstellt
			return instance;
		}
	}

	//mit properties
	//sowie methode, aber von außen wie eine Variable zugreifen: Score = 10; (10 = value)
	public int Score {
		get{ return score; } //oder auch if(score <10) gebe nur dann zurück
		set{ score = value; } //value ist schon intern initialisiert, müssen nicht extra mit Übergabeparameter
		//statt setScore(10);
	}

	//=
	//public int getScore()
	//{
	//	return score;
	//}

	public int Lives {
		get;//wenn get weg, dann lesegeschützt
		set;//wenn set weg, dann schreibgeschützt
	}

	public int Food {
		get;//wenn get weg, dann lesegeschützt
		set;//wenn set weg, dann schreibgeschützt
	}

	//pausieren Variable
	public bool Paused {

		get;
		set;

	}
}
