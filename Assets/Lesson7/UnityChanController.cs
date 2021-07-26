using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour
{
    //アニメーションするためのコンポーネントを入れる箱
    Animator animator;
    //Unityちゃんを移動させるためのコンポーネントを入れる箱
    Rigidbody2D rigid2d; 
    //地面の位置
    private float groundLevel = -3.0f;
    private float dump = 0.8f;
    float jumpVelocity = 20;
    // Start is called before the first frame update
    void Start()
    {
        //アニメーターのコンポーネントを取得
        this.animator = GetComponent<Animator>();
        this.rigid2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update(){
        this.animator.SetFloat("Horizontal",1);
        bool isGround = (transform.position.y > this.groundLevel) ? false : true;
        this.animator.SetBool("isGround", isGround);
        //着地した状態でクリックした時
        if(Input.GetMouseButtonDown(0) && isGround){
            //上向きの速度を与える
            this.rigid2d.velocity = new Vector2(0, this.jumpVelocity);
        }
        //クリックボタンが押されていない時
        if(Input.GetMouseButtonDown(0) == false){
            if(this.rigid2d.velocity.y > 0){
                this.rigid2d.velocity *= this.dump;
            }
        }
    }
}
