using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState02
{
    Wander,
    Follow,
    Die,
};

public class Eneum : MonoBehaviour
{
    GameObject player;
    public EnemyState02 currState = EnemyState02.Wander;

    public Transform target;

    Rigidbody2D myRigidbody;

    public float range = 2f;
    public float moveSpeed = 2f;






    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        myRigidbody = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();



    }

    // Update is called once per frame
    void Update()
    {

        switch (currState)
        {
            case (EnemyState02.Wander):
                Wander();
                break;
            case (EnemyState02.Follow):
                Follow();
                break;
            case (EnemyState02.Die):
                // Die();
                break;
        }

        if (IsPlayerInRange(range) && currState != EnemyState02.Die)
        {
            currState = EnemyState02.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState02.Die)
        {
            currState = EnemyState02.Wander;
        }
    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    bool isFacingRight()
    {
        return transform.localScale.x > 0;
    }

    void Wander()
    {
        {
            if (isFacingRight())
            {
                myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            }
            else
            {
                myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            }
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)), 1f);

    }


    void Follow()
    {

        if (transform.position.x > target.position.x)
        {
            //target is left
            transform.localScale = new Vector2(-1, 1);
            myRigidbody.velocity = new Vector2(-moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }
        else if (transform.position.x < target.position.x)
        {
            //target is right
            transform.localScale = new Vector2(1, 1);
            myRigidbody.velocity = new Vector2(moveSpeed, 0f);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, transform.position.y), moveSpeed * Time.deltaTime);
        }

    }
}

