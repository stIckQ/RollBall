using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameOverBoardManager : MonoBehaviour {

    public GameObject gameOverUIController;
    public Text winText;
    public Text scoreText;
    public Image IsChampion;

    public void GameStart()
    {
        gameOverUIController.SetActive(false);
    }

    public void GameOver(float scoreNum)
    {
        Sprite sprite=new Sprite();  

        if (scoreNum==8)
        { 
            winText.text="You Win!";
            sprite = Resources.Load("UI/UI_Icon_Crown",sprite.GetType()) as Sprite;
        }
        else
        {
            winText.text = "You Lose!";
            sprite = Resources.Load("UI/UI_Icon_SmileyUnhappy",sprite.GetType()) as Sprite;
        }

        IsChampion.GetComponent<Image>().sprite = sprite;
        scoreText.text = scoreNum.ToString();

        gameOverUIController.SetActive(true);
    }
}
