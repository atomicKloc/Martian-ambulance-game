using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(MeshFilter))]
public class TerrainGenerator : MonoBehaviour
{
    public GameObject rover;
    public GameObject marsBase;
    public const float E = 2.71828175F;
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
        //defining variables
        mesh = new Mesh();
        rover = GameObject.FindWithTag("rover");
        marsBase = GameObject.FindWithTag("base");
        roverPos = new Vector3 (Mathf.Round(rover.transform.position.x),0,Mathf.Round(rover.transform.position.z));
        offset = roverPos;
        //creating shape
        CreateShape();
        GetComponent<MeshFilter>().mesh = mesh;
        mesh.vertices = vertices;
        mesh.uv = newUV;
        mesh.triangles = triangles;
        GetComponent<MeshCollider>().sharedMesh = mesh;
        mesh.RecalculateNormals();
    }
    // Start is called before the first frame update

    void CreateShape(){
        //specifying vertex positions
        vertices = new Vector3[(xSize+1)*(zSize+1)];
        for (int i = 0, z = (int)offset.z; z <= zSize+offset.z; z++){
            for (int x = (int)offset.x; x <= xSize+offset.x; x++){
                //deciting height based on perlin noise, making terain flat near points of inerest
                float y = 1f/(1f+Mathf.Pow(E,(-.5f*(Vector3.Distance(new Vector3(0,0,0), new Vector3(x-50,0,z-50))-80f))))*1f/(1f+Mathf.Pow(E,(-.5f*(Vector3.Distance(marsBase.transform.position, new Vector3(x-50,0,z-50))-80f))))*((Mathf.PerlinNoise(x*.1f-2000f,z*.05f-2000f)-.5f) *10f+(Mathf.PerlinNoise(x*.01f+2000f,z*.01f+2000f)-.5f) *50f);
                vertices[i] = new Vector3(x,y,z);
                i++;
            }
        }
        //creates triangles
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
        //reloads mesh in new position as player moves
        roverPos = new Vector3 (Mathf.Round(rover.transform.position.x),0,Mathf.Round(rover.transform.position.z));
        if(Vector3.Distance(roverPos,offset)>10){
            offset = roverPos;
            CreateShape();
            mesh.vertices = vertices;
            mesh.uv = newUV;
            mesh.triangles = triangles;
            GetComponent<MeshCollider>().sharedMesh = mesh;
            mesh.RecalculateBounds();
            mesh.RecalculateNormals();
        }
        
    }
}
