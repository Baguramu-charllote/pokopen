using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorGroundSensor : MonoBehaviour
{
    void Start()
    {
        
    }
    
    void Update()
    {

    }
    public void OnTriggerEnter(Collider Col)
    {
        if (Col.gameObject.tag == "Ground")
        {
            transform.parent.GetComponent<CharactorBaseController>().OnGround();
        }
    }
}
