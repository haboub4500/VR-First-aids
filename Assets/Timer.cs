using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIElements or just UI?
using UnityEngine.SceneManagement;
using System.Collections;


public class Timer : MonoBehaviour
{
    public GameObject textDisplay;
    public int secondsLeft ;
    public int minutesLeft;
    public bool takingAway = false;


    IEnumerator Timertake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft = secondsLeft - 1 ;

        if (secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":" + "0" + secondsLeft;
        }else
        {
            textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":" + secondsLeft;
        }

        if (secondsLeft == 0)
        {
            minutesLeft = minutesLeft - 1;
            secondsLeft = 60;
        }
        
        
        takingAway = false;

    }
        

    // Start is called before the first frame update
    void Start()
    {
        
textDisplay.GetComponent<Text>().text = "0" + minutesLeft + ":" + "0" + secondsLeft;    }

    // Update is called once per frame
    void Update()
    {
        if (takingAway == false && secondsLeft > 0 && minutesLeft >= 0 )
        {
            StartCoroutine(Timertake());
        }

        if (secondsLeft == 1 && minutesLeft == 0 )
        {
            if (SceneManager.GetActiveScene().name == "car accident")
            {
                SceneManager.LoadScene("game_over");
            }
            if (SceneManager.GetActiveScene().name == "severe injury")
            {
                SceneManager.LoadScene("game_over");
            }
            
            
        }
    }

    
}
