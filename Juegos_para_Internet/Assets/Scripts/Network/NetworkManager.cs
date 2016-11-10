using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {

	private const string VERSION = "V0.0.1";
	public string roomName = "OurRoom";
	public string playerPrefabName = "Car";
	public Transform spawnPoint;

	void Start () {
		PhotonNetwork.ConnectUsingSettings (VERSION);
		PhotonNetwork.autoJoinLobby = true;
	
	}
	
	void OnJoinedLobby()
	{
		RoomOptions roomOptions = new RoomOptions() { isVisible = false, maxPlayers = 4 };
		PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
	}

	void OnJoinedRoom()
	{
		PhotonNetwork.Instantiate (playerPrefabName,spawnPoint.position, spawnPoint.rotation,0);
	}
}
