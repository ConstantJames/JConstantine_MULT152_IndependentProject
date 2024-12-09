using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackToTitleButton : MonoBehaviour
{
    private Button button;
    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnMouseDown);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        gameManager.TitleScreen();
        gameManager.ResetGame();
        print("BACKING UP!");
    }

    public void SecondStart()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnMouseDown);
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }
}
