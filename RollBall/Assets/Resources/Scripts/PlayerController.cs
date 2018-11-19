using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    public float speed;
	public Text countText;
    public Text timeText;
    public GameObject gameOverUIControllerObject;

	private Rigidbody rb;
	private int count;
    private float countdown;
    private string dateTime;
    private GameOverBoardManager gameOverBoardManager;

    private bool isGameOver;

	void Start(){
		rb = GetComponent<Rigidbody> ();
        
		count = 0;
		SetCountText ();
        countdown = 20.0f;
        isGameOver = false;

        gameOverBoardManager=gameOverUIControllerObject.GetComponent<GameOverBoardManager>();
        gameOverBoardManager.GameStart();
	}

    void Update()
    {
        
        if(count<8&&countdown>=0.0f)
        {
            countdown = countdown - Time.deltaTime;
            countdown = Mathf.Round(countdown * 100) / 100;
            timeText.text = countdown.ToString();
        }
        else if (!isGameOver && countdown <= 0.0f && count<8)
        {
            timeText.text = "";

            GameOver();
        }
    }

    // FixedUpdate
    void FixedUpdate () {
		float xMove = Input.GetAxis ("Horizontal");
		float zMove = Input.GetAxis ("Vertical");

		Vector3 move = new Vector3 (xMove,0.0f,zMove);

		rb.AddForce(move*Time.deltaTime*speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "PickUp") {
			other.gameObject.SetActive (false);
			count++;
			SetCountText ();
			//Debug.Log ("+1");
		}
    }

	void SetCountText()
	{
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) 
		{
            timeText.text = "";

            GameOver();
		}
        
	}


    void GameOverSaveScore()
    {
        isGameOver = true;
        dateTime = System.DateTime.Now.ToString();
        if (ScoreManager.SaveScoreDate(count, dateTime))
        {
           
        }
        for (int i = 0; i < ScoreManager.maxScoreNum; i++)
        {
            Debug.Log(PlayerPrefs.GetInt("score" + i.ToString()));
        }
        Debug.Log("wwwwwwwwwwwwww");
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameOverBoardManager.GameOver(count);
        GameOverSaveScore();
    }
   
}