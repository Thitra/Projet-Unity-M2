using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class LaunchCameraShake : MonoBehaviour
{
	public PlayableDirector playableDirector;
	FirstPersonAIO fp;

    // Start is called before the first frame update
    void Start()
    {
        fp = FindObjectOfType<FirstPersonAIO>();
    }

    // Update is called once per frame
    void Update()
    {
    	
    }

    public void OnCollisionEnter(Collision collision){
    	if(collision.transform.CompareTag("Player")){
			/*Debug.Log("Test collision cameraShake");    	
    		FirstPersonAIO fp = FindObjectOfType<FirstPersonAIO>();
    		fp.ActivateCameraShake(1, 0.02f);*/
    		fp.DesactivateMovement();
    		playableDirector.Play();
    	}
    }
}
