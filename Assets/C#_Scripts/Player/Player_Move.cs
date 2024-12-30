using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    private Rigidbody2D rb;
    private float X_Move;
    private float Y_Move;

    [Header("速度控制")]
    [SerializeField] public float moveSpeed;
    [SerializeField] public float jumpSpeed;

    [Header("状态控制,和动画有关")]
    
    [SerializeField] private float X_Move_Condition;
    [SerializeField] private float Y_Move_Condition;

    [SerializeField] public bool isRight;
    [SerializeField] public bool is_Ground;
    [SerializeField] public bool isJumping;
    [SerializeField] public bool isFalling;
    [SerializeField] public bool isRunning;
    [SerializeField] public bool is_static;
    [SerializeField] public bool isleeping;
    [SerializeField] public bool is_Button;
    //[Header("互动文本查看")]
    //[SerializeField] public bool is_Get_Button;//碰到宝箱enter键值变为true
    //[SerializeField] public bool is_SleepDream;
    //[SerializeField] public bool is_inTextShow;//按下enter键取反，在触发文本框是无法走动
    //[SerializeField] public bool is_GamejamEnd;//床上按enter表示游戏结束
    //[SerializeField] public bool is_Game_Round;
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 3.0f;
        jumpSpeed = 8.0f;
        is_Ground = true;

        X_Move_Condition = 0.1f;
        Y_Move_Condition = 0.1f;


    }

    void Update()
    {
        MoveX();
        MoveY();
       
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        //jiance
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        //jiance
    }

    private void MoveY()
    {
        Y_Move = rb.velocity.y;

        isJumping = !is_Ground && (Y_Move > +Y_Move_Condition);
        isFalling = !is_Ground && (Y_Move < -Y_Move_Condition);
        is_Ground = (Mathf.Abs(Y_Move) < Y_Move_Condition);

        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && is_Ground)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    private void MoveX()
    {
        X_Move = Input.GetAxis("Horizontal");
        isRunning = (X_Move != 0);
        if (isRunning)
        {
            isRight = (X_Move> X_Move_Condition) ? true : (X_Move < -X_Move_Condition ? false : isRight);
            rb.velocity = new Vector2(X_Move * moveSpeed, rb.velocity.y);
        }
    }

}