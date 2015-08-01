using UnityEngine;
using System.Collections;
using System;
[System.Serializable]
public class Prefab
{
	[SerializeField] GameObject _view;
	public GameObject viewObject{
		get{return _view;}
	}
}