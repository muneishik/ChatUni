using UnityEngine;
using System.Collections;

public class GameController : SingletonMonoBehaviour<GameController>
{
	public string playerName;
	
	public void SetPlayerName(string name)
	{
		playerName = name;
	} 
}
