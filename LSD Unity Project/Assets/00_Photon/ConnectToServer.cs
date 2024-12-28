using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;
    public TextMeshProUGUI buttonText;
    [SerializeField] private GameObject lobbyPanel;

    public void OnClickConnect()
    {
        //PhotonNetwork.NickName = usernameInput.text;
        buttonText.text = "Connecting...";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        //SceneManager.LoadScene("Lobby");
        lobbyPanel.SetActive(true);
    }
}

