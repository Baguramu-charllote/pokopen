using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OgreController : CharactorBaseController {
    //見つけたときに入れるlist
     public List<GameObject> Catch;
    //Rayを使うときに当たったオブジェクトを取っておくためのもの
    RaycastHit Hit;
    //檻のオブジェクトを保管しておくもの
    GameObject Jail;
    //捕まえれるオブジェクトを指定するため
    [SerializeField] LayerMask Layer;
    //檻からの半径の大きさ
    public float Radius;
    public override void Start () {
        base.Start();
        //檻を見つけている
        Jail = GameObject.Find("Jail");     
    }
	
	public override void Update () {
        //常にRayは飛ぶ
        Ray();        
        //檻の範囲内にいるかどうかの確認
        if (Radius > Vector3.Distance(Jail.transform.position, transform.position))
        {
            //Jが押されたら見つけた人を檻の座標にテレポート
            if (Input.GetKeyDown(KeyCode.J))
            {
                List<GameObject> ConfirmationObject = new List<GameObject> { };
                for (int i = 0; i < Catch.Count; i++)
                {
                    Catch[i].transform.position = Jail.transform.position;
                }
                //forで見つけた人全員をテレポートさせる
                for (int i = 0; i < Catch.Count; i++)
                {
                    Catch[i].transform.position = Jail.transform.position;
                }
                //Listをリセットする
                Catch.Clear();
            }
        }
        base.Update();
    }
    public virtual void Ray()
    {
        //Rayを飛ばすものと場所を指定している
        Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width/2,Screen.height/2,0.0f));
        //ifのなかは当たったら中のプログラムが回る。Hitに当たったオブジェクトの情報が入っている
        if (Physics.Raycast(ray, out Hit, Mathf.Infinity))
        {
            if (Input.GetMouseButtonDown(0))
            {
                //入っているオブジェクトのレイヤーがinspector上で指定されたレイヤーだったら＊9っていうのがレイヤー番号
                if (Hit.collider.gameObject.layer == (int)LayerMaskNo.Enemy)
                {
                    //Catchの中に当たったオブジェクトが追加される
                    Catch.Add(Hit.collider.gameObject);
                }
            }
        }
    }
}

//Ray を常に飛ばすことによってゲーム作ったあと鬼よわすぎーってなったら、スキルなどで＜逃げてる人にRayが当たると、UIが変わって発見しやすくなる＞とかの設定(変更？)ができるようにするためにこの仕様にしてます。