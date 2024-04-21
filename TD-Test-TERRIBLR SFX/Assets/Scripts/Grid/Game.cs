using UnityEngine;

public class Game : MonoBehaviour {

	[SerializeField]
	Vector2Int boardSize = new Vector2Int(11, 11);

	[SerializeField]
	GameBoard board = default;

	void Start() {
		board.Initialize(boardSize);
	}
}
