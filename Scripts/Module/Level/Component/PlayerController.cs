using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <summary>
/// 选关界面人物简单的控制器脚本
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 2.5f;
    public Animator ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = GetComponent<Animator>();
        GameApp.CameraManager.SetPos(transform.position);//设置摄像机位置
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if(h == 0f)
        {
            ani.Play("idle");
        }
        else
        {
            if ((h > 0f && transform.localScale.x < 0) || (h < 0 && transform.localScale.x > 0))
            {
                Filp();
            }

            //-32 24 
            Vector3 pos = transform.position + Vector3.right * h * moveSpeed * Time.deltaTime;
            //限制    
            pos.x = Mathf.Clamp(pos.x, -32.0f, 24.0f);
            transform.position = pos;

            GameApp.CameraManager.SetPos(transform.position);//设置摄像机位置
            ani.Play("move");
        }
    }

    //转向
    public void Filp()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
