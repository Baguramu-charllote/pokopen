using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GM_PlayerController : CharactorBaseController
{
    public override void Start()
    {
        base.Start();
    }
    
    public override void Update()
    {
        IsJump = false;
        base.Update();
    }
}
