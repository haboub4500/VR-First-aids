using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasController : MonoBehaviour
{
    public Text field;
    public GameObject canvas;
    public GameObject audio;

    public GameObject cprCube;
    private float timeToAppear = 3f;
    private float timeWhenDisappear;

    private AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = audio.GetComponent<AudioSource>();
        MissionManager.current.OnAmbulanceCalled += AmbulanceNotification ;
        MissionManager.current.OnVictimMoved += VictimNotification;
        MissionManager.current.OnHeartChecked += CheckHeart;
        MissionManager.current.OnCprPerformed += PerformCpr;
        MissionManager.current.OnHeartChecked2 += CheckHeart2;
        MissionManager.current.OnMissionSuccess += MissionSuccessfull;
             
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeWhenDisappear){
            canvas.SetActive(false);
            source.Pause();
        }
    }

    void AmbulanceNotification(Boolean bol){
        if (bol==true){
            canvas.SetActive(true);
            field.text="You called the ambulance, well done";
            timeWhenDisappear = Time.time + timeToAppear;
        }
    }

    void VictimNotification(Boolean bol){
        if (bol==true){
            canvas.SetActive(true);
            field.text="You moved the victiom away, well done";
            timeWhenDisappear = Time.time + timeToAppear;
        }
    }

    void CheckHeart(Boolean bol){
        if (bol==true){
            canvas.SetActive(true);
            field.text="The victim is not breathing, act quick";
            timeWhenDisappear = Time.time + timeToAppear;
            cprCube.SetActive(true);
        }
    }

    void PerformCpr(Boolean bol){
        if (bol==true){
            canvas.SetActive(true);
            field.text="You have performed Cpr, well done";
            timeWhenDisappear = Time.time + timeToAppear;
        }
    }

    void CheckHeart2(Boolean bol){
        if (bol==true){
            source.Play();
            canvas.SetActive(true);
            field.text="The victim is breathing, well done";
            timeWhenDisappear = Time.time + timeToAppear;
        }
    }

    void MissionSuccessfull(int number){
        if( number == 5){
            canvas.SetActive(true);
            field.text="Well done, you did what you could. Now, you are going with the victim to the hospital";
            timeWhenDisappear = Time.time + timeToAppear;
            SceneManager.LoadScene("severe injury");

        }
    }
}
