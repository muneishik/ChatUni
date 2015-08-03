using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NameText : MonoBehaviour 
{
	public Transform playerTransform;
	public Camera mainCamera;

	[SerializeField] RectTransform thisRectTransform;
	[SerializeField] Text nameText;
	
	public string nameStr = string.Empty;

	// Use this for initialization
	public void Initialize (string name) 
	{
		nameText.text = name;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (nameText.text.Length == 0) return;
		thisRectTransform.anchoredPosition3D = mainCamera.WorldToScreenPoint(playerTransform.position);
	}
}
