using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileRandomizer : MonoBehaviour {

	public new SpriteRenderer renderer;
	Sprite[] tileSprites;

	// Use this for initialization
	void Start () {
		tileSprites = Resources.LoadAll<Sprite>("Tiles/tileset_desert");
		int randomNumber = Random.Range(0, 31);
		renderer.sprite = tileSprites[randomNumber];
	}
}
