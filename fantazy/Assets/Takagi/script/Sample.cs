using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Sample : MonoBehaviourPunCallbacks{
    //メインカメラを取得する用
    Camera Main;
	// Use this for initialization
	void Start () {
        //メインカメラ取得
        Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        //PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する…らしい
        PhotonNetwork.ConnectUsingSettings();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    // // マスターサーバーへの接続が成功した時に呼ばれるコールバック…らしい
    public override void OnConnectedToMaster()
    {
        //"room"という名前のルームに参加する（ルームが無ければ作成してから参加する)…らしい
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }
    // マッチングが成功した時に呼ばれるコールバック…らしい
    public override void OnJoinedRoom()
    {
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する…らしい
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(10f, 15f));
        // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
        GameObject Obj = PhotonNetwork.Instantiate("Oreg", v, Quaternion.identity);
        //メインカメラの親を生成したゲームオブジェクトに指定してあげる
        Main.transform.parent = Obj.transform;
        //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
        Main.transform.position = Obj.transform.position;
    }
}
