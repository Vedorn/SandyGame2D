using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricTools : MonoBehaviour {

	public GameObject tile;
	GameObject[,] world = new GameObject[4, 4];

	public Vector3 cartesianToIsometric(Vector3 cartesianPoint) {
		float isometricX = cartesianPoint.x - cartesianPoint.y;
		float isometricY = (cartesianPoint.x + cartesianPoint.y) / 2;
		Vector3 isometricPoint = new Vector3(isometricX, isometricY, 0);
		return isometricPoint;
	}

	public Vector3 isometricToCartesian(Vector3 isometricPoint) {
		float cartesianX = (2 * isometricPoint.y + isometricPoint.x) / 2;
		float cartesianY = (2 * isometricPoint.y - isometricPoint.x) / 2;
		Vector3 cartesianPoint = new Vector3(cartesianX, cartesianY, 0);
		return cartesianPoint;
	}

	public void BuildWorld(GameObject[,] worldLayout) {
		Vector3 start = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 10));
		int width = (int)Camera.main.ScreenToWorldPoint(Vector3.right).x;
		Debug.Log("Width: " + width);
		int height = (int)Camera.main.ScreenToWorldPoint(Vector3.up).y;
		Debug.Log(height);
		for (int i = 0; i < worldLayout.GetLength(0); i++) {
			for (int j = 0; j < worldLayout.GetLength(1); j++) {
				Vector3 isometricCoordinates = cartesianToIsometric(new Vector3(i, j, 0));
				worldLayout[i,j] = Instantiate(tile, start + isometricCoordinates, Quaternion.identity);
				worldLayout[i,j].transform.SetParent(transform);
			}
		}
	}

	void Start() {
		BuildWorld(world);
	}
}

//		Vector2[] testArray = { new Vector2(4,3), new Vector2(4,3), new Vector2(4,3), new Vector2(4,3), new Vector2(4,3) };
//		for (int i = 0; i < testArray.Length; i++) {
//			Debug.Log(testArray[i]);
//		}

//		int [,] test2DArray = new int[3,4];
//		Debug.Log(test2DArray[0,3]);
//		for (int i = 0; i < test2DArray.GetLength(0); i++) {
//			for(int j = 0; j < test2DArray.GetLength(1); j++) {
//				Debug.Log(test2DArray[i, j]);
//			}
//		}