using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon;
//スクリプトを張ったオブジェクトに、自動的に指定したコンポーネントを張り付ける
[RequireComponent(typeof(BoxCollider), typeof(Rigidbody), typeof(Animator))]
public class CharactorBaseController : MonoBehaviourPunCallbacks
{   
    //速度を指定する。
    public float _MoveSpeed;
    //移動速度の上限を指定する。
    public float _MaxSpeed;
    //ジャンプの強さを指定する。
    public float _JumpForce;
    //ジャンプの制限。
    public bool IsJump;
    //ダッシュ用のブースト数値。
    public float DashBoost;
    float Boost;
    //回転速度
    public float smooth;
    Vector3 Player_pos;
    //プレイヤーの行動を確認するための変数。enum：NowMoveNameの中身を使って入れてください。
    int Status;
    [HideInInspector] public float _dx = 0, _dy = 0, _dz = 0;
    [HideInInspector] public Rigidbody _Rb;
    [HideInInspector] public Animator _Ani;

    public enum NowMoveName
    {
        //停止状態
        Idle,
        //歩行状態
        Walk,
        //走行状態
        Run,
        //ジャンプ状態
        Jump,
        //屈み状態
        crouch,
    }
    public enum LayerMaskNo
    {
        Player = 8,
        Enemy,
        Item,
        Parts,
        Wall,
        Ground,
        Base
    }
    public virtual void Start()
    {
        //スタートは確実に停止状態で始めてください
        Status = 0;
        Boost = 1;
        IsJump = false;
        Player_pos = transform.position;
        _Rb = GetComponent<Rigidbody>();
        _Ani = GetComponent<Animator>();
    }

    public virtual void Update()
    {
        if (photonView.IsMine)
        {
            //移動
            Moving();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Jumping();
            }
        }
    }
    public virtual void Jumping()
    {
        if (!IsJump)
        {
            Vector3 JumpVec = new Vector3(0, 10, 0);
            IsJump = true;
            _Rb.AddForce(JumpVec * _JumpForce);
        }
    }
    public virtual void Moving()
    {
        Vector3 _MoveVec = new Vector3(0, 0, 0);
        //入力によりx、zに1または-1が入る。
        _dx = Input.GetAxis("Horizontal");
        _dz = Input.GetAxis("Vertical");
        if (_dz > 0)
        {
            _MoveVec = transform.forward;
        }
        else if (_dz < 0)
        {
            _MoveVec = -transform.forward;
        }
        if (_dx > 0)
        {
            _MoveVec += transform.right;
        }
        if (_dx < 0)
        {
            _MoveVec += -transform.right;
        }
        Vector3 Rotation = new Vector3(transform.position.x - Player_pos.x, 0, transform.position.z - Player_pos.z);
        //左shiftでダッシュができます
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            Boost = DashBoost;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Boost /= DashBoost;
        }
        //速度が_MaxSpeed以内であれば加速させます
        if (_Rb.velocity.magnitude < _MaxSpeed * Boost)
        {            
            _Rb.AddForce(_MoveVec.normalized * _MoveSpeed * _MoveSpeed * Boost * Time.deltaTime);
        }
        Player_pos = transform.position;
        Debug.Log(_MoveVec);
    }
    //センサーから接地判定をとるときに干渉させるプログラム
    public virtual void OnGround()
    {
        IsJump = false;
    }
}
