using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchCameraShake : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision){
    	if(collision.transform.CompareTag("Player")){
    		FirstPersonAIO fp = FindObjectOfType<FirstPersonAIO>();
    		fp.ActivateCameraShake(1, 0.02f);
    	}
    }

    /*void OnTriggerEnter(Collider collider){
    	if(collider.CompareTag("Player")){
    		Debug.Log("Test");
    		FirstPersonAIO fp = FindObjectOfType<FirstPersonAIO>();
    		fp.ActivateCameraShake(1, 0.02f);
    	}
    }*/
}
