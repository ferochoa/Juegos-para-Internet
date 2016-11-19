using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviour {

	private const string VERSION = "V0.0.1";
	public string playerPrefabName = "Car";
	
    private RoomInfo[] roomsList;
    public GameObject menu;
    public GameObject createButton;
    public GameObject joinButton;
    public GameObject lobbyPanel;
    public GameObject [] spawPoints;
    private int playersNumber ;
    public Text text; 

    void Start () {
		PhotonNetwork.ConnectUsingSettings (VERSION);
		//PhotonNetwork.autoJoinLobby = true;
	
	}
    void OnGUI()
    {

        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else 
        {
            GUILayout.Label("Connection Ready");
            lobbyPanel.gameObject.SetActive(true);
        }

        

    }

   

    void OnJoinedLobby()
    {
        if (PhotonNetwork.room == null)
        {
            createButton.SetActive(true);

        }
       
        
           
            joinButton.gameObject.SetActive(true);
        
        


    }

	void OnJoinedRoom()
	{
       playersNumber = PhotonNetwork.countOfPlayersInRooms;
        menu.gameObject.SetActive(false);      
        PhotonNetwork.Instantiate(playerPrefabName, spawPoints[playersNumber].transform.position, spawPoints[playersNumber].transform.rotation, 0);
         
       
    }

    void OnReceivedRoomListUpdate()
    {
        roomsList = PhotonNetwork.GetRoomList();
       
    }

    public void createRoom()
    {
        PhotonNetwork.CreateRoom("My room", new RoomOptions() { maxPlayers = 4 }, TypedLobby.Default);
        
    }


   public void joinRoom()
    {
        if (roomsList.Length == 0)
        {
            text.gameObject.SetActive(true);
            text.text = "No hay rooms disponibles";
        }
        else
        {
            for (int i = 0; i < roomsList.Length; i++)
            {

                PhotonNetwork.JoinRoom(roomsList[i].name);

            }
        }
    }
   
}
