using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty switchScenes;
    static int currentIndex = 0 ;
    void Start()
    {
        switchScenes.action.performed += ctx => SwitchScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwitchScene(){
        if (currentIndex == 4){
            SceneManager.LoadScene(0);
            currentIndex = 0;
        }
        else{
            SceneManager.LoadScene(currentIndex+1);
            currentIndex += 1 ;
        }
    }
}
