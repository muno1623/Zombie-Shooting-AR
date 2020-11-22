using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
    public Button newGame;
    // Start is called before the first frame update
    void Start()
    {
        newGame.onClick.AddListener(loadGame);
    }

    // Update is called once per frame
    void loadGame()
    {
        SceneManager.LoadScene("GamePlayEasy");
    }
}
