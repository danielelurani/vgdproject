using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuMusic : MonoBehaviour
{
    private void Awake(){

        GameObject [] musicObj = GameObject.FindGameObjectsWithTag("MenuMusic");

        if(musicObj.Length > 1){

            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
