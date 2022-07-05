using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight_CS : MonoBehaviour
{
    private bool isOn = true;

    [Header("Flashlight referencia"), SerializeField]
    private GameObject Flashlight_LightSource;


    [Header("Flashlight Clicking Sound")]
    private AudioSource clickSound;

    [Header("Flashlight Keycode"), SerializeField]
    public KeyCode Flashlight_keycode;


    

    private void Update()
    {

        

            if (Input.GetKeyDown(Flashlight_keycode)) // A Flashlight-ot triggeleli
            {
                if (isOn == false)
                {
                    Flashlight_LightSource.SetActive(true);

                    Debug.Log("Elovette");

                    //clickSound.play();

                    isOn = true;

                }
                else if (isOn)
                {
                    Flashlight_LightSource.SetActive(false);

                    Debug.Log("Elrakta");
                    //clickSound.play();

                    isOn = false;
                }
            }

        
    }
    
}



