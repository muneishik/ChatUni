using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LoginSceneController : MonoBehaviour 
{
	[SerializeField] InputField inputField;
	// Use this for initialization
	void Start () {
	
	}
	
	public void OnClickLoginButton()
	{
		if(inputField.text.Length == 0) return;

		GameController.Instance.SetPlayerName(inputField.text);
		Application.LoadLevel(SceneName.ChatUni);
	}
}
