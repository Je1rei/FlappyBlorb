using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    [SerializeField]
    private float faf;
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public CircleCollider2D circleCollider;
    private float _jump;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        _jump = Input.GetAxis("Jump");

        if (_jump > 0 && birdIsAlive)
        {
            logic.swingSFX.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        Debug.LogFormat("Jump:{0}", _jump);
    }

    public void ChangeCollider(int newRadius)
    {
        circleCollider.radius -= newRadius;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (birdIsAlive == true)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }
}
