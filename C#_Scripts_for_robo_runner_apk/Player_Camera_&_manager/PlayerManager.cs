using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;


    public static int numberOfCells;
    public Text EnergyCells;
    void Start()
    {
        Time.timeScale = 1;
        gameOver = false;
        isGameStarted = false;
        numberOfCells = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        
        }

        EnergyCells.text = "Cells:" + numberOfCells;
        if (Swipe_Controller.tap)
        {
          
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}
