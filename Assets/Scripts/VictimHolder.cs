using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using System;
using UnityEditor;

public class VictimHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject victim;
    Quaternion defaultRotation;
    Boolean isAdjusted = false;
   
    void Start()
    {
        defaultRotation=victim.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LateUpdate()
    {
      
    }

    public void AdjustRotation(){
        if(isAdjusted==false){
            victim.transform.rotation=defaultRotation;
            isAdjusted=true;

        }
        

    }

    public void ChangeBoolean(){
        isAdjusted=false;

    }
}
