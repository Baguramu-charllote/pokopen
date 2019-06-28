using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;          // 注視対象プレイヤー
    public Transform verRot;
    public Transform horRot;

    // Use this for initialization
    void Start()
    {
        horRot = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        player = transform.root.gameObject.GetComponent<Transform>();
        verRot = player;
        if (transform.parent.name != transform.name)
        {
            transform.position = player.position;
            float X_Rotation = -Input.GetAxis("Mouse X") * 3;
            float Y_Rotation = -Input.GetAxis("Mouse Y") * 2;
            verRot.transform.Rotate(0, -X_Rotation, 0);
            horRot.transform.Rotate(Y_Rotation, 0, 0);
        }
    }
}
