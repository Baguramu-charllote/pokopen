using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_PlayerController : CharactorBaseController
{
    //Rayを使うときに当たったオブジェクトを取っておくためのもの
    RaycastHit Hit;
    public override void Start()
    {
        base.Start();
    }
    
    public override void Update()
    {
        //常にRayは飛ぶ
        Ray();
        IsJump = false;
        base.Update();
    }
    public virtual void Ray()
    {
        //Rayを飛ばすものと場所を指定している
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0.0f));
        //ifのなかは当たったら中のプログラムが回る。Hitに当たったオブジェクトの情報が入っている
        if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //入っているオブジェクトのレイヤーがinspector上で指定されたレイヤーだったら＊9っていうのがレイヤー番号
                if (Hit.collider.gameObject.layer == (int)LayerMaskNo.Enemy)
                {
                    Hit.collider.gameObject.GetComponent<CharactorBaseController>().IsMove = !Hit.collider.gameObject.GetComponent<CharactorBaseController>().IsMove;
                }
            }
        }
    }
}
