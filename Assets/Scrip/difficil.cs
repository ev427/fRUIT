using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class difficil : MonoBehaviour
{
    private Button _button;
    private GameManager _gameManager;
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("Game Minwage employee").GetComponent<GameManager>();
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDificil);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void SetDificil()
    {
        Debug.Log(gameObject.name + "was clicked");
    }
}
