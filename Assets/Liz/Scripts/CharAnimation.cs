using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnimation : MonoBehaviour
{
    public SpriteRenderer CharSR;
    public Sprite rightFace;
    public Sprite leftFace;
    public Sprite jumping;
    public Sprite attack;
    public Sprite stand;

    // Start is called before the first frame update
    void Start()
    {
        CharSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CharSR.sprite = rightFace;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            CharSR.sprite = stand;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CharSR.sprite = leftFace;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            CharSR.sprite = stand;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            CharSR.sprite = jumping;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            CharSR.sprite = stand;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharSR.sprite = attack;
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            CharSR.sprite = stand;
        }
    }
}
