using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Sample : MonoBehaviourPunCallbacks{

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        var v = new Vector3(Random.Range(-3f, 3f), Random.Range(-3f, 3f));
        PhotonNetwork.Instantiate("GamePlayer", v, Quaternion.identity);
    }
}
