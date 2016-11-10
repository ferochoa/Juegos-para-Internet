using UnityEngine;
using System.Collections;


public class NetworkPlayer : Photon.MonoBehaviour{

	public GameObject myCamera;


	void Start () {
		
		if (photonView.isMine) 
		{
			myCamera.SetActive (true);
			GetComponent<CarController> ().enabled = true;
			GetComponent<CarUserControl> ().enabled = true;
			GetComponent<CarAudio> ().enabled = true;
		   
		}
	}
	

}
