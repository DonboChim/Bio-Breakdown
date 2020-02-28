using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateWalls : MonoBehaviour
{
    public Camera camera;
    public GameObject start;
    public GameObject end;
    public bool creating;
    public GameObject wallPrefab;
    public GameObject wall;
    public GameObject centerPivot;
    public float timeBetweenWalls;
    public GameObject originalStartPoint;
    public Vector3 savedStartPoint;
    public Vector3 savedEndPoint;
    public bool buttonpressed;
    public List<GameObject> wallClones;
    public bool erase;
    public float distanceBetween;
    public bool revisado;
    WallManager wallManager;
    float totalX;
    float totalZ;
    [SerializeField] float centerX;
    [SerializeField] float centerZ;




    //Parte de bateria del muro

    private static float carga = 1000000f;
    private float cambio = 5f;
    private bool activo = false;

    public static float Carga { get => carga; set => carga = value; }
    public float CenterX { get => centerX; set => centerX = value; }
    public float CenterZ { get => centerZ; set => centerZ = value; }

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenWalls = 0.2f;
        wallManager = GameObject.Find("EnemyManager").GetComponent<WallManager>();
    }

    // Update is called once per frame
    void Update()
    {
        getInput();

        if (Input.GetKey("space"))
        {
            buttonpressed = true;
            timeBetweenWalls += Time.deltaTime;

            carga -= cambio * Time.deltaTime;


        }

        if (creating)
        {
            buildWall();

        }
        if (timeBetweenWalls <= 0.3f)
        {

            creating = false;


            setEnd();
        }
        else if (timeBetweenWalls > 0.3f)
        {
            creating = true;
            timeBetweenWalls = 0;
            setStart();
        }

        if (carga <= 0)
        {
            carga = 0;
        }


    }
    void getInput()
    {


        if (Input.GetKeyUp(KeyCode.Space) && carga > 0)
        {
            buttonpressed = false;
            revisado = true;
            StartCoroutine("Timer");
        }
        if (buttonpressed == false)
        {

            newStart();
            newEnd();
            setEnd();
            setStart();

            if (wallClones.Count != 0 && revisado ==true)
            {

                wallClones[0].gameObject.tag = "firstWall";

                wallClones[wallClones.Count - 1].gameObject.tag = "lastWall";

                distanceBetween = Vector3.Distance(wallClones[0].transform.GetChild(0).transform.position, wallClones[wallClones.Count - 1].transform.GetChild(1).transform.position);

                Debug.Log(distanceBetween);
                if (distanceBetween <= 3.5f)
                {
                    Vector3 CreatPosition = (wallClones[0].transform.GetChild(0).transform.position + (wallClones[wallClones.Count - 1].transform.GetChild(1).transform.position - wallClones[0].transform.GetChild(0).transform.position) /2);
                    
                    wall = Instantiate(wallPrefab, CreatPosition, new Quaternion(gameObject.transform.rotation.x, gameObject.transform.rotation.y, gameObject.transform.rotation.z,0));
                    wall.transform.LookAt(wallClones[0].transform.GetChild(0).transform);
                    wall.transform.localScale = new Vector3(0.15f, wall.transform.localScale.y, distanceBetween);
                    wall.gameObject.tag = "lastWall";
                    wallClones.Add(wall);
                    getCenter();
                }
                revisado = false;

            }
            wall = Resources.Load("clone") as GameObject;
        }
        if (creating && carga > 0)
        {
            adjust();
        }

    }
    void buildWall()
    {
        if (carga >= 0)
        {

            wall = Instantiate(wallPrefab, start.transform.position, Quaternion.identity);
            wallClones.Add(wall);
        }
        else if (carga <= 0)
        {
            Debug.Log("No");
            creating = false;
        }
    }
    void newStart()
    {
        start.transform.position = originalStartPoint.transform.position;

    }
    void newEnd()
    {
        savedStartPoint = originalStartPoint.transform.position;

    }
    void setStart()
    {

        savedStartPoint = start.transform.position;

    }
    void setEnd()
    {

        end.transform.position = savedStartPoint;
    }
    void adjust()
    {
        if (creating == true)
        {

            adjustWall();
        }
    }
    void adjustWall()
    {
        if (wall != null)
        {


            start.transform.LookAt(end.transform.position);
            end.transform.LookAt(start.transform.position);
            float distance = Vector3.Distance(start.transform.position, end.transform.position);
            wall.transform.position = start.transform.position + distance / 2 * start.transform.forward;
            wall.transform.rotation = start.transform.rotation;
            wall.transform.localScale = new Vector3(0.25f, wall.transform.localScale.y, distance);
        }
    }
    IEnumerator Timer()
    {

        yield return new WaitForSeconds(0.1f);
        
        erase = true;

    }
    IEnumerator Revision()
    {

        yield return new WaitForSeconds(0.05f);
        revisado = true;
        

    }
    void getCenter()
    {
        foreach (GameObject walls in wallClones)
        {
            totalX += walls.transform.position.x;
            totalZ += walls.transform.position.z;
        }
        CenterX = totalX / wallClones.Count;
        CenterZ = totalZ / wallClones.Count;
        wall = Instantiate(centerPivot, new Vector3(CenterX,-2, CenterZ), Quaternion.identity);
        totalX = 0;
        totalZ = 0;
        CenterX = 0;
        CenterZ = 0;
    }



}

