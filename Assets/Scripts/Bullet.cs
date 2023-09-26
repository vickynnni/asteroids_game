using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float maxLifeTime = 3f;
    public Vector3 targetVector;
    
    void Start()
    {
        Destroy(gameObject, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetVector * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            IncreaseScore();
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    private void IncreaseScore()
    {
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score: " + Player.SCORE;
    }
}
