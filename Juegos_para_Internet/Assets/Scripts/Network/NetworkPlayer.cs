using UnityEngine;
using System.Collections;


public class NetworkPlayer : Photon.MonoBehaviour{

	public GameObject myCamera;
	private bool isAlive = true;
	private Vector3 position;
	private Quaternion rotation;
	private float lerpSmothing = 5f;

	void Start ()
	{
		
		if (photonView.isMine) {

			gameObject.name = "Me";

			myCamera.SetActive (true);
			GetComponent<CarController> ().enabled = true;
			GetComponent<CarUserControl> ().enabled = true;
			GetComponent<CarAudio> ().enabled = true;
		   
		}
		else 
		{
			gameObject.name = "Network Player";
			StartCoroutine ("Alive");
		} 
	}


	void OnPhotonSerializeView(PhotonStream stream , PhotonMessageInfo info)
	{
		if (stream.isWriting) 
		{
			stream.SendNext (transform.position);
			stream.SendNext (transform.rotation);

		} 
		else 
		{
			position = (Vector3)stream.ReceiveNext ();
			rotation = (Quaternion)stream.ReceiveNext ();
		}

	}


	IEnumerator Alive()
	{
		while (isAlive) 
		{

			transform.position = Vector3.Lerp (transform.position, position, Time.deltaTime * lerpSmothing);
			transform.rotation = Quaternion.Lerp (transform.rotation, rotation, Time.deltaTime * lerpSmothing);

			yield return null;
		}


	}
	

}
