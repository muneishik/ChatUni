using UnityEngine;
using System.Collections;
using System;

public class GameController : SingletonMonoBehaviour<GameController>
{
	public string playerName;

	// unix epochをDateTimeで表した定数(+日本時間).
	public readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 9, 0, 0, DateTimeKind.Utc);
	
	public void SetPlayerName(string name)
	{
		playerName = name;
	} 
}
