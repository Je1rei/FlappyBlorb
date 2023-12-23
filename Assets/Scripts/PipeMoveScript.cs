using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public LogicScript logic;
    public float moveSpeed = 5;
    public float deadZone = -45;

    public float moveSpeedMovablePipes = 1f;

    private float minY = -13f;
    private float maxY = 13f;
    private float targetY;
    private bool movingUp = true;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        if (logic != null)
        {
            moveSpeed *= logic.ratioSpeed;
        }

        SetRandomTargetY();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        MovePipes();
    }

    private void MovePipes()
    {
        if (logic.gameMode == 1)
        {
            float step = moveSpeed * Time.deltaTime;

            if (movingUp)
            {
                transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, targetY, step), 0);
                if (Mathf.Approximately(transform.position.y, targetY))
                {
                    movingUp = false;
                    SetRandomTargetY();
                }
            }
            else
            {
                transform.position = new Vector3(transform.position.x, Mathf.MoveTowards(transform.position.y, minY, step), 0);
                if (Mathf.Approximately(transform.position.y, minY))
                {
                    movingUp = true;
                    SetRandomTargetY();
                }
            }

            if (transform.position.x < deadZone)
            {
                Debug.Log("Pipe deleted");
                Destroy(gameObject);
            }
        }
    }

    private void SetRandomTargetY()
    {
        targetY = Random.Range(minY, maxY);
    }
}

