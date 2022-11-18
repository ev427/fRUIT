using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class target : MonoBehaviour
{

    public int PointValue = 1;
    public float MinSpeed = 10;
    public float MaxSpeed = 20;
    public float MaxTorque = 10;
    public float XRange = 8;
    public float YRange = 4;
    private Rigidbody2D _targetRb;
    private GameManager _gameManager;
    void Start()
    {
        _targetRb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("Game Minwage employee").GetComponent<GameManager>();
        _targetRb.AddForce(Vector2.up * RandomizeForce(), ForceMode2D.Impulse);
        _targetRb.AddTorque(MaxTorque);
    }

    void Update()
    {
        
    }

    private float RandomizeForce()
    {
        return Random.Range(MinSpeed, MaxSpeed);
    }

    private float RandomizeTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    private float RandomPos()
    {
        return Random.Range(-XRange, XRange);
    }
    private void OnMouseDown()
    {
        _gameManager.UpdateScore(PointValue);
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(this.gameObject);

        if(!gameObject.CompareTag("Bad"))
        {
            //Debug.Log("Game Over");
            _gameManager.GameOver();
        }
    }
}
