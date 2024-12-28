using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject lobbyConnectButton;
    [SerializeField] private GameObject lobbyPanel;
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private TMP_InputField playerNameInput;

    private string roomName;
    private int roomSize;

    [SerializeField] private GameObject CreatePanel;
    [SerializeField] private TMP_InputField codeDisplay;

    [SerializeField] private GameObject joinPanel;
    [SerializeField] private TMP_InputField codeInputField;
    private string joinCode;
    [SerializeField] GameObject joinButton;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        lobbyConnectButton.SetActive(true);

        if (PlayerPrefs.HasKey("Nickname"))
        {
            if (PlayerPrefs.GetString("Nickname") == "")
            {
                PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
            }
            else
            {
                PhotonNetwork.NickName = PlayerPrefs.GetString("Nickname");
            }
        }
        else
        {
            PhotonNetwork.NickName = "Player" + Random.Range(0, 1000);
        }
        playerNameInput.text = PhotonNetwork.NickName;
    }

    public void PlayerNameUpdateInputChanged(string nameInput)
    {
        PhotonNetwork.NickName = nameInput;
        PlayerPrefs.SetString("NickName", nameInput);
    }

    public void JoinLobbyOnClick()
    {
        mainPanel.SetActive(false);
        lobbyPanel.SetActive(true);
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoomOnClick()
    {
        CreatePanel.SetActive(true);

        Debug.Log("Creating Room");
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        int roomCode = Random.Range(1000, 10000);
        roomName = roomCode.ToString();
        PhotonNetwork.CreateRoom(roomName, roomOps);

        codeDisplay.name = roomName;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Create room failed");

        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        int roomCode = Random.Range(1000, 10000);
        roomName = roomCode.ToString();
        PhotonNetwork.CreateRoom(roomName, roomOps);

        codeDisplay.name = roomName;
    }

    public void CancelRoomOnClick()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
            {
                PhotonNetwork.CloseConnection(PhotonNetwork.PlayerList[i]);
            }
        }
        PhotonNetwork.LeaveRoom();
        CreatePanel.SetActive(false);
        joinButton.SetActive(true);
    }

    public void OpenJoinPanel()
    {
        joinPanel.SetActive(true);
    }

    public void CodeInput(string code)
    {
        joinCode = code;
    }

    public void JoinRoomOnClick()
    {
        PhotonNetwork.JoinRoom(joinCode);
    }

    public void LeaveRoomOnClick()
    {
        if (PhotonNetwork.InRoom)
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public void OnLeftRoom()
    {
        joinButton.SetActive(true);
        joinPanel.SetActive(false);
        codeInputField.text = "";
    }

    public void MatchmakingCancelOnClick()
    {
        mainPanel.SetActive(true);
        lobbyPanel.SetActive(false);
        PhotonNetwork.LeaveLobby();
    }
}
