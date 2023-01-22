using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    public GameObject rover;
    Vector3[] vertices;
    Vector2[] newUV;
    int[] triangles;
    private int xSize = 100;
    private int zSize = 100;
    public Vector3 roverPos;
    public Vector3 offset;
    public Mesh mesh;
    
    void Start()
    {
        mesh = new Mesh();
        rover = GameObject.FindWithTag("rover");
        roverPos = new Vector3 (Mathf.Round(rover.transform.position.x),0,Mathf.Round(rover.transform.position.z));
        offset = roverPos;
        CreateShape();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = newUV;
        mesh.triangles = triangles;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
    // Start is called before the first frame update

    void CreateShape(){
        Debug.Log("CreateShape!");
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        for (int i = 0, z = (int)offset.z; z <= zSize+offset.z; z++){
            for (int x = (int)offset.x; x <= xSize+offset.x; x++){
                float y = (Mathf.PerlinNoise(x*.1f,z*.05f)-.5f) *10f+(Mathf.PerlinNoise(x*.01f,z*.01f)-.5f) *50f;
                vertices[i] = new Vector3(x,y,z);
                i++;
            }
        }
        triangles = new int[xSize*zSize*6];

        int vert = 0;
        int tris = 0;
        for (int z = (int)offset.z; z < zSize +  offset.z; z++){
            for (int x = (int)offset.x; x < xSize + offset.x; x++){
                triangles[tris + 0] = vert +0;
                triangles[tris + 1] = vert + xSize +1;
                triangles[tris + 2] = vert +1;
                triangles[tris + 3] = vert +1;
                triangles[tris + 4] = vert + xSize +1;
                triangles[tris + 5] = vert + xSize +2;

                vert++;
                tris += 6;
            }
            vert++;
        }
    }
    void Update(){
        roverPos = new Vector3 (Mathf.Round(rover.transform.position.x),0,Mathf.Round(rover.transform.position.z));
        if(Vector3.Distance(roverPos,offset)>10){
            offset = roverPos;
            CreateShape();
            mesh.vertices = vertices;
            mesh.uv = newUV;
            mesh.triangles = triangles;
            GetComponent<MeshCollider>().sharedMesh = mesh;
            mesh.RecalculateBounds();
        }
        
    }
}
