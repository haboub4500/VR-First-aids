using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
using UnityEditor;
public class PLayerActions : MonoBehaviour
{

    public InputAction callAmbulance;
    public GameObject victim;
    public GameObject car;
    public GameObject head;
    private float distance;

    private Boolean AmbulanceCalled = false;
    private Boolean VictimMoved = false;
    private Boolean heartCheked = false;
    private Boolean CprPerformed = false;

    private Boolean heartCheked2 = false;
    // Start is called before the first frame update
    void Start()
    {
        callAmbulance.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        callAmbulance.performed += ctx => calltheAmbulance() ;
        distance = Vector3.Distance(victim.transform.position,car.transform.position);
        if(distance>15 && VictimMoved == false && MissionManager.current.ProgressRate == 1){
            MissionManager.current.VictimMoved = true;
            VictimMoved = true;
            MissionManager.current.ProgressRate = 2;
        }
        float cprDistance = Vector3.Distance(victim.transform.position,head.transform.position);
        if(cprDistance < 2 && heartCheked == false && MissionManager.current.ProgressRate == 2){
            MissionManager.current.HeartChecked = true;
            heartCheked=true;
            MissionManager.current.ProgressRate = 3;
        }
        if(cprDistance < 2 && heartCheked2 == false && MissionManager.current.ProgressRate == 4){
            MissionManager.current.HeartChecked2 = true;
            heartCheked2=true;
            MissionManager.current.ProgressRate = 5;
        }


    }

    public void performCpr(){
        Debug.Log("true");
        if(CprPerformed == false && MissionManager.current.ProgressRate == 3){
            MissionManager.current.CprPerformed =true;
            CprPerformed=true;
            MissionManager.current.ProgressRate = 4;
        }
    }

    void calltheAmbulance(){
        if(AmbulanceCalled==false){
            MissionManager.current.AmbulanceCalled = true;
            AmbulanceCalled =true; 
            MissionManager.current.ProgressRate = 1;  
        }
    }
}
