using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;

public class PhotonCommsManager : Photon.PunBehaviour
{
    #region Public Variables
    public PhotonLogLevel logLevel = PhotonLogLevel.Informational;
    #endregion

    #region Private Behaviour
    private GameObject currentPlayer;
    #endregion

    #region MonoBehaviours
    private void Awake()
    {
        PhotonNetwork.autoJoinLobby = false;
    }
    void Start ()
    {
        PhotonNetwork.logLevel = logLevel;
        PhotonNetwork.ConnectUsingSettings("0.1");
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    #endregion

    #region Public Methods
    public override void OnConnectedToMaster()
    {
        Debug.Log("Trying to enter random room.");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnPhotonRandomJoinFailed(object[] codeAndMsg)
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
        currentPlayer = PhotonNetwork.Instantiate("DaydreamPlayer", new Vector3(0f, 1.6f, 0f), Quaternion.identity, 0);
        currentPlayer.GetComponent<PlayerController>().isControllable = true;
    }
    #endregion

    #region GUI
    private void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
    #endregion
}
