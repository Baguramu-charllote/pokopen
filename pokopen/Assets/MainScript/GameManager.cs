using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public static class Data
{
    public static bool[] Charactor_state = new bool[4];
    public static string CharactorName ;
}
 public class GameManager : MonoBehaviourPunCallbacks
{
    Camera Main;
    Text ResultText;
    bool IsPause;
    void Start()
    {
        //メインカメラ取得
        Main = GameObject.Find("Main Camera").GetComponent<Camera>();
        //PhotonServerSettingsに設定した内容を使ってマスターサーバーへ接続する…らしい
        PhotonNetwork.ConnectUsingSettings();
        //
        ResultText = GameObject.Find("ResultText").GetComponent<Text>();
        ResultText.text = "";
        IsPause = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!IsPause)
            {
                IsPause = true;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
            }
            else if (IsPause)
            {
                IsPause = false;
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        int State_No = 0;
        for (int i = 0; i < 4; i++)
        {
            if (Data.Charactor_state[i]) State_No++;
        }
        if (State_No == 4) ResultText.text = "Victory";
    }

    public void PlayerInstans()
    {
        //// マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する…らしい
        //var v = new Vector3(Random.Range(-5f, 5f), Random.Range(10f, 15f));
        //if (Data.CharactorName == "oni")
        //{
        //    // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
        //    GameObject Obj = PhotonNetwork.Instantiate("Oreg_Player", v, Quaternion.identity);
        //    //メインカメラの親を生成したゲームオブジェクトに指定してあげる
        //    Main.transform.parent = Obj.transform;
        //    //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
        //    Main.transform.position = Obj.transform.position;
        //}
        //else if(Data.CharactorName == "GM")
        //{
        //    // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
        //    GameObject Obj = PhotonNetwork.Instantiate("GM_Player", v, Quaternion.identity);
        //    //メインカメラの親を生成したゲームオブジェクトに指定してあげる
        //    Main.transform.parent = Obj.transform;
        //    //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
        //    Main.transform.position = Obj.transform.position;
        //}
        //else
        //{
        //    // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
        //    GameObject Obj = PhotonNetwork.Instantiate("Runaway_Player", v, Quaternion.identity);
        //    //メインカメラの親を生成したゲームオブジェクトに指定してあげる
        //    Main.transform.parent = Obj.transform;
        //    //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
        //    Main.transform.position = Obj.transform.position;
        //}
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
        var v = new Vector3(Random.Range(-5f, 5f), Random.Range(10f, 15f));
        if (Data.CharactorName == "oni")
        {
            // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
            GameObject Obj = PhotonNetwork.Instantiate("Oreg_Player", v, Quaternion.identity);
            //メインカメラの親を生成したゲームオブジェクトに指定してあげる
            Main.transform.parent = Obj.transform;
            //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
            Main.transform.position = Obj.transform.position;
        }
        else if (Data.CharactorName == "GM")
        {
            // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
            GameObject Obj = PhotonNetwork.Instantiate("GM_Player", v, Quaternion.identity);
            //メインカメラの親を生成したゲームオブジェクトに指定してあげる
            Main.transform.parent = Obj.transform;
            //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
            Main.transform.position = Obj.transform.position;
        }
        else
        {
            // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
            GameObject Obj = PhotonNetwork.Instantiate("Runaway_Player", v, Quaternion.identity);
            //メインカメラの親を生成したゲームオブジェクトに指定してあげる
            Main.transform.parent = Obj.transform;
            //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
            Main.transform.position = Obj.transform.position;
        }
        // マッチング後、ランダムな位置に自分自身のネットワークオブジェクトを生成する…らしい
        //var v = new Vector3(Random.Range(-3f, 3f), Random.Range(10f, 15f));
        // PhotonNetwork.InstantiateはResorcesというファイルに入っているprefabを名前を直接指定して生成する
        //GameObject Obj = PhotonNetwork.Instantiate("Oreg_Player", v, Quaternion.identity);
        //メインカメラの親を生成したゲームオブジェクトに指定してあげる
        //Main.transform.parent = Obj.transform;
        //メインカメラの座標をObjに合わせてあげてFPS視点にしてあげている
        //Main.transform.position = Obj.transform.position;
    }
}
