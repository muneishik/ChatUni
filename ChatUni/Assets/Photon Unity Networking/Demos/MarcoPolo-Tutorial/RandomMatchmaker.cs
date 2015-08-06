using UnityEngine;

public class RandomMatchmaker : Photon.PunBehaviour
{
    private PhotonView myPhotonView;
	public myThirdPersonController charaController{get; private set;}
	[SerializeField] Prefab nameTextPrefab;
	[SerializeField] Transform textList;

	[SerializeField] Camera mainCamera;
	
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("0.1");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("JoinRandom");
        PhotonNetwork.JoinRandomRoom();
    }

    public void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
    }

    public override void OnJoinedRoom()
    {
		string[] avatar = new string[]{"uni_gen"};
		int i = Random.Range (0, avatar.Length);

        GameObject monster = PhotonNetwork.Instantiate(avatar[i], Vector3.zero, Quaternion.identity, 0);
		charaController = monster.GetComponent<myThirdPersonController> ();
		charaController.isControllable = true;
		charaController.playerName = GameController.Instance.playerName;
		charaController.mainCamera = mainCamera;
		charaController.SetOffset();
        myPhotonView = monster.GetComponent<PhotonView>();

    }

    public void OnGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());

        if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
        {
            bool shoutMarco = GameLogic.playerWhoIsIt == PhotonNetwork.player.ID;

            if (shoutMarco && GUILayout.Button("Marco!"))
            {
                myPhotonView.RPC("Marco", PhotonTargets.All);
            }
            if (!shoutMarco && GUILayout.Button("Polo!"))
            {
                myPhotonView.RPC("Polo", PhotonTargets.All);
            }
        }
    }
}
