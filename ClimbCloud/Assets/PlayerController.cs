using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private Animator animator;
    private float jumpForce = 880.0f;
    private float walkForce = 30.0f;
    private float maxWalkSpeed = 2.0f;

    // Use this for initialization
    void Start()
    {
        this.rigid2D = GetComponent<Rigidbody2D>();
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // jump
        if (Input.GetKeyDown(KeyCode.Space) &&
            this.rigid2D.velocity.y == 0) // Y方向の速度が0 => ジャンプ中でない時
        {
            this.rigid2D.AddForce(transform.up * this.jumpForce);
        }

        // move right/left
        int key = 0;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            key = 1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            key = -1;
        }

        // speed of player
        float speedx = Mathf.Abs(this.rigid2D.velocity.x);
        // speed limit 
        if (speedx < this.maxWalkSpeed)
        {
            this.rigid2D.AddForce(transform.right * key * this.walkForce);
        }

        // 振り向く
        if (key != 0)
        {
            transform.localScale = new Vector3(key, 1, 1);
        }

        // プレイヤの速度に応じてアニメーション速度を変える
        this.animator.speed = speedx / 2.0f;
        
        // 落下したら最初から
        if (transform.position.y < -10)
        {
            SceneManager.LoadScene("GameScene");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("ゴール");
        SceneManager.LoadScene("ClearScene");
    }
}