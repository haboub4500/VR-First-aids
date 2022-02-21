using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTimer : MonoBehaviour
{
    private float timeToAppear = 10f;
    private float timeWhenDisappear;
    // Start is called before the first frame update
    void Start()
    {
        timeWhenDisappear = Time.time + timeToAppear;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > timeWhenDisappear){
            SceneManager.LoadScene("menu");
        }
    }
}
