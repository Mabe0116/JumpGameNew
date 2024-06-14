using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScript : MonoBehaviour

{
    public GameObject hitKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //タイマーにより「Hit Space Key」が点滅
        timer++;
        if(timer %100>50)
        {
            hitKey.SetActive(false);
        }
        else
        {
            hitKey.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.Space) || UnityEngine.Input.GetButton("Jump"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }
    private int timer = 0;
}
