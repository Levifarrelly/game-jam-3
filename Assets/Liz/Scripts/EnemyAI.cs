using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState
{
    Float,
    Follow,
    Attack,
    Die,
}

public class EnemyAI : MonoBehaviour
{
    GameObject player;
    public EnemyState currState = EnemyState.Float;

    public Transform target;

    Rigidbody2D Erb;

    public float speed;
    public float range = 2f;

    public Vector3[] positions;

    private int index;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Erb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        switch (currState)
        {
            case (EnemyState.Float):
                Float();
                break;
            case (EnemyState.Follow):
                Follow();
                break;
            case (EnemyState.Die):
                //Die():
                break;
        }

        if (IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Follow;
        }
        else if (!IsPlayerInRange(range) && currState != EnemyState.Die)
        {
            currState = EnemyState.Float;
        }


    }

    private bool IsPlayerInRange(float range)
    {
        return Vector3.Distance(transform.position, player.transform.position) <= range;
    }

    void Float()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[index], Time.deltaTime * speed);

        if (transform.position == positions[index])
        {
            if (index == positions.Length - 1)
            {
                index = 0;
            }
            else
            {
                index++;
            }
        }
    }

    void Follow()
    {
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 0);
            Erb.velocity = new Vector3(-speed, 0f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
        if (transform.position.x > target.position.x)
        {
            transform.localScale = new Vector3(1, 1, 0);
            Erb.velocity = new Vector3(-speed, 0f);
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(target.position.x, transform.position.y, transform.position.z), speed * Time.deltaTime);
        }
    }
}
