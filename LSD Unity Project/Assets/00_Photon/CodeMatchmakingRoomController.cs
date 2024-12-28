using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using TMPro;

public class CodeMatchmakingRoomController : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject joinButton;
    [SerializeField] private TMP_Text playerCount;
    [SerializeField] private TMP_Text playerCount2;

    public override void OnJoinedRoom()
    {
        joinButton.SetActive(false);
        playerCount.text = PhotonNetwork.PlayerList.Length + "Players";
        playerCount2.text = PhotonNetwork.PlayerList.Length + "Players";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        playerCount.text = PhotonNetwork.PlayerList.Length + "Players";
        playerCount2.text = PhotonNetwork.PlayerList.Length + "Players";
    }

    public override void OnPlayerEnteredRoom(Player otherPlayer)
    {
        playerCount.text = PhotonNetwork.PlayerList.Length + "Players";
        playerCount2.text = PhotonNetwork.PlayerList.Length + "Players";
    }

    public override void OnLeftRoom()
    {
        base.OnLeftRoom();
        playerCount.text = "O Players";
        playerCount2.text = "O Players";
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);
        Debug.Log(message);
    }

    public void StartGameOnClick()
    {
        PhotonNetwork.LoadLevel();
    }
}
