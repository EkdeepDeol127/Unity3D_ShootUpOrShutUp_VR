using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuBehavior : MonoBehaviour {

    public Button Play;
    public Button HighScore;
    public Button Instructions;
    public Button Options;
    public Button Quit;

    public GameObject MainMenuBackGround;
    public GameObject HighScoreBackGround;
    public GameObject InstructionsBackGround;
    public GameObject OptionsBackGround;

    public Button[] Back;

    void Start ()
    {
        Back = new Button[3];
        Play.onClick.AddListener(playGame);
        HighScore.onClick.AddListener(HighScoreScreen);
        Instructions.onClick.AddListener(InstructionsScreen);
        Options.onClick.AddListener(OptionsScreen);
        Quit.onClick.AddListener(QuitGame);

        for (int i = 0; i < 2; i++)
        {
            Back[i].onClick.AddListener(BackToMain);
        }

        MainMenuBackGround.SetActive(true);
        HighScoreBackGround.SetActive(false);
        InstructionsBackGround.SetActive(false);
        OptionsBackGround.SetActive(false);
    }

    /*void Update ()
    {
		
	}*/

    void playGame()
    {
        SceneManager.LoadScene("MainGame");
    }

    void HighScoreScreen()
    {
        MainMenuBackGround.SetActive(false);
        HighScoreBackGround.SetActive(true);
    }

    void InstructionsScreen()
    {
        MainMenuBackGround.SetActive(false);
        InstructionsBackGround.SetActive(true);
    }

    void OptionsScreen()
    {
        MainMenuBackGround.SetActive(false);
        OptionsBackGround.SetActive(true);
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void BackToMain()
    {
        MainMenuBackGround.SetActive(true);
        HighScoreBackGround.SetActive(false);
        InstructionsBackGround.SetActive(false);
        OptionsBackGround.SetActive(false);
    }
}
