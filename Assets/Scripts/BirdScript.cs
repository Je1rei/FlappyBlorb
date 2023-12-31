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

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            logic.swingSFX.Play();
            myRigidbody.velocity = Vector2.up * flapStrength;
        }
    }

    public void ChangeCollider(int newRadius)
    {
        circleCollider.radius -= newRadius;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(birdIsAlive == true)
        {
            logic.GameOver();
            birdIsAlive = false;
        }
    }
}
