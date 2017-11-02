using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnIslands : MonoBehaviour {

	public GameObject[] islands;
	public string[] islandNames;

	public int startX = -100;
	public int startZ = -100; 
	public int zoneWidth = 10; 
	public int width = 200;
	public int height = 200; 
	public int column;
	public int row;

    void Start () {
		                 //OLD SPAWN
		//for(int maxIslands = 0; maxIslands < numberOfIslands ; maxIslands++)
		//{
		//	Vector2 pos = new Vector2 (Random.Range (xMin, xMax), Random.Range (yMin, yMax));
		//	Instantiate (ArcticIsland, pos, transform.rotation);
		//}

    

		column = width / zoneWidth;
		row = height / zoneWidth;
        CreateIsland();
       
}
    public void CreateIsland()
        {
		for (int z = 0; z<row; z++) {  
			for (int x = 0; x<column; x++)     {   
				int pointX = startX + x * zoneWidth + Random.Range(2, zoneWidth);
    int pointZ = startZ + z * zoneWidth + Random.Range(2, zoneWidth);
    Vector2 pos = new Vector2(pointX, pointZ);
    Instantiate(islands[Random.Range(0, islands.Length)], pos, transform.rotation);
			} 
		}
	}
	

	void Update () {
		
	}
}
