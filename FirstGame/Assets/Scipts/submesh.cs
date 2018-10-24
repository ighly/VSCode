using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(MeshFilter), typeof(MeshRenderer))]

public class submesh : MonoBehaviour {

	Mesh mesh;
	Vector3[] vertices;
	int[] triangles;

	//Grid Settings
	public float cellsize;
	public Vector3 gridOffset;
	public int gridsize;

	 void Awake () {

		 mesh = GetComponent<MeshFilter>().mesh;
	 }

	 void Start () {

		 MakeContiguousProceduralGrid();
		 UpdateMesh();

	 }

	void MakeDiscreteProceduralGrid() {
		//set array sizes
		vertices = new Vector3[gridsize * gridsize * 4];
		triangles = new int[gridsize * gridsize * 6];

		//set tracker integers
		int v = 0;
		int t = 0;

		//set vertex offset
		float vertexOffset = cellsize * 0.5f;
		
		for (int x = 0; x <gridsize; x++){
			for (int y = 0; y <gridsize; y++){
				Vector3 cellOffset = new Vector3(x * cellsize, 0, y * cellsize);

				//populate the vertices and triangles arrays
				vertices[v] = new Vector3(-cellsize, 0, -cellsize) + cellOffset + gridOffset;
				vertices[v+1] = new Vector3(-cellsize, 0, cellsize) + cellOffset + gridOffset;
				vertices[v+2] = new Vector3(cellsize, 0, -cellsize) + cellOffset + gridOffset;
				vertices[v+3] = new Vector3(cellsize, 0, cellsize) + cellOffset + gridOffset;

				triangles[t] = v;
				triangles[t+1] = triangles[t+4] = v+1;
				triangles[t+2] = triangles [t+3] = v+2;
				triangles[t+5] = v+3;

				v += 4;
				t += 6;
			}
		}
	}
			
	void MakeContiguousProceduralGrid() {
		//set array sizes
		vertices = new Vector3[(gridsize+1)*(gridsize+1)];
		triangles = new int[gridsize*gridsize*6];

		//set tracker integers
		int v = 0;
		int t = 0;

		//set vertex offset
		float vertexOffset = cellsize * 0.5f;
		
		//create vertex grid
		for (int x = 0; x <=gridsize; x++){
			for (int y = 0; y <=gridsize; y++){
				vertices[v] = new Vector3 ((x*cellsize) - vertexOffset, x+y*0.2f, (y*cellsize) - vertexOffset);
				v++;
			}
		}

		//reset vertex tracker
		v = 0;

		//create each cell's triangles
		for (int x = 0; x <gridsize; x++){
			for (int y = 0; y <gridsize; y++){
				triangles[t] = v;
				triangles[t+1] = triangles[t+4] = v+1;
				triangles[t+2] = triangles [t+3] = v+(gridsize+1);
				triangles[t+5] = v+(gridsize+1) +1;
				v++;
				t += 6;
			}
			v++;
		}
	}

	void UpdateMesh() {
		
		mesh.Clear ();
		
		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.RecalculateNormals ();


	}
}