﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rigid;

    private bool gameStarted = false;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {        
        Invoke("StartGame", 5f);
    }

    void StartGame()
    {
        rigid.velocity = new Vector2(5f * GetRandomSign(), -5f);
        gameStarted = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStarted)
            return;

        //Loopback protection
        if (Mathf.Abs(rigid.velocity.x) <= 0.2f)
        {
            rigid.velocity = new Vector3(GetRandomSign(), rigid.velocity.y);
        }

        if (Mathf.Abs(rigid.velocity.y) <= 0.2f)
        {
            rigid.velocity = new Vector3(rigid.velocity.x, GetRandomSign());
        }
    }

    private int GetRandomSign()
    {
        return Random.Range(0, 1) * 2 - 1;
    }
}
