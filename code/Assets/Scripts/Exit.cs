using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button exit;
    // Start is called before the first frame update
    void Start()
    {
        exit.onClick.AddListener(ExitGame);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitGame()
    {
        Debug.LogError("Check");
        SceneManager.LoadScene("MainMenu");
    }
}
