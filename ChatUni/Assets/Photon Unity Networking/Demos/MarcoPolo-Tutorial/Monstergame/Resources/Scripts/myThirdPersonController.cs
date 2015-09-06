using UnityEngine;
using System.Collections;

public class myThirdPersonController : ThirdPersonController
{	
	public string playerName = "TempName";
	public Camera mainCamera = null;

	GUIStyle style;
	Vector2 offset;

	void Start()
	{
		mainCamera = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera>();
		SetOffset ();
	}

	public void SetOffset()
	{
		style = new GUIStyle();
		style.normal.textColor = Color.white;
		style.fontSize = Screen.width/38;
		offset = style.CalcSize(new GUIContent(playerName));
		offset = new Vector3(offset.x,Screen.height / 7);
	}

	void OnGUI()
	{
		Vector3 screenPos = mainCamera.WorldToScreenPoint(transform.position);
		if (screenPos.z > 0)
		{
			GUI.Label(new Rect(screenPos.x - offset.x / 2 , Screen.height - screenPos.y - offset.y, 220, 30), playerName, style);
		}
	}

}
