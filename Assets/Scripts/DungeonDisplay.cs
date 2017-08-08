using UnityEngine;
using System.Collections;

public class DungeonDisplay : MonoBehaviour {
    [SerializeField]
    GameObject[] shapes0, shapes1, shapes2, shapes3, shapes4, shapes5, shapes6, shapes7, shapes8, 
                 shapes9, shapes10, shapes11, shapes12, shapes13, shapes14, shapes15;   

    [SerializeField]
	public GameObject[] shapes;
	public MapGenerator mapGenerator;
	public float minimumMazePercentage = 0.8f;
    

    [SerializeField]
    public int tileHeight;
    [SerializeField]
    public int tileWidth;
    public Vector2 startPos;
    private int rngTileChoice;

    public float getTileWidth() { return tileWidth; }
    public float getTileHeight() { return tileHeight; }
    public MapGenerator getMapGenerator() { return mapGenerator; }

    // Use this for initialization
    void Start () {

		mapGenerator = GetComponent<MapGenerator> ();

		int visitedCellCount = 0;
		bool[,] visitedCells = new bool[mapGenerator.mapRows, mapGenerator.mapColumns];
        
		int minimumMazeCells = Mathf.FloorToInt((mapGenerator.mapRows - 2) * (mapGenerator.mapColumns - 2) * minimumMazePercentage);

		while (visitedCellCount < minimumMazeCells)
        {
			//Debug.Log ("Current dungeon size = " + visitedCellCount + " which is less than the required " + minimumMazeCells + ". Retrying");
			mapGenerator.InitializeMap ();
			visitedCells = mapGenerator.TraverseMap ();            
            visitedCellCount = GetVisitedCellsCount (visitedCells);
			//Debug.Log ("visited cell count = " + visitedCellCount);
		}
        //mapGenerator.DisplayMap();
        mapGenerator.GetDeadEnds();
        //mapGenerator.DisplayMap();
        mapGenerator.GetGateway();
        //mapGenerator.DisplayMap ();

        for (int r = 0; r < mapGenerator.mapRows; r++)
        {
            for (int c = 0; c < mapGenerator.mapColumns; c++)
            {
                string ch = mapGenerator.map[r, c].ToString();

                switch (ch) //─│┌┐└┘├┤┬┴┼XO
                {
                    case "─":                              // x y z 
                        rngTileChoice = Random.Range(0, shapes0.Length - 1);
                        Instantiate(shapes0[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes0[rngTileChoice].transform.rotation);
                        if (c == 0) {
                            startPos.x = -2*tileWidth/5;
                            startPos.y = (-tileHeight * r) /*+ (-tileHeight / 2)*/;
                        }
                        break;

                    case "│":
                        rngTileChoice = Random.Range(0, shapes1.Length - 1);
                        Instantiate(shapes1[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes1[rngTileChoice].transform.rotation);
                        break;

                    case "┌":
                        rngTileChoice = Random.Range(0, shapes2.Length - 1);
                        Instantiate(shapes2[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes2[rngTileChoice].transform.rotation);
                        break;

                    case "┐":
                        rngTileChoice = Random.Range(0, shapes3.Length - 1);
                        Instantiate(shapes3[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes3[rngTileChoice].transform.rotation);
                        break;

                    case "└":
                        rngTileChoice = Random.Range(0, shapes4.Length - 1);
                        Instantiate(shapes4[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes4[rngTileChoice].transform.rotation);
                        break;

                    case "┘":
                        rngTileChoice = Random.Range(0, shapes5.Length - 1);
                        Instantiate(shapes5[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes5[rngTileChoice].transform.rotation);
                        break;

                    case "├":
                        rngTileChoice = Random.Range(0, shapes6.Length - 1);
                        Instantiate(shapes6[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes6[rngTileChoice].transform.rotation);
                        break;

                    case "┤":
                        rngTileChoice = Random.Range(0, shapes7.Length - 1);
                        Instantiate(shapes7[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes7[rngTileChoice].transform.rotation);
                        break;

                    case "┬":
                        rngTileChoice = Random.Range(0, shapes8.Length - 1);
                        Instantiate(shapes8[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes8[rngTileChoice].transform.rotation);
                        break;

                    case "┴":
                        rngTileChoice = Random.Range(0, shapes9.Length - 1);
                        Instantiate(shapes9[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes9[rngTileChoice].transform.rotation);
                        break;

                    case "┼":
                        rngTileChoice = Random.Range(0, shapes10.Length - 1);
                        Instantiate(shapes10[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes10[rngTileChoice].transform.rotation);
                        break;

                    case "u":
                        rngTileChoice = Random.Range(0, shapes11.Length - 1);
                        Instantiate(shapes11[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes11[rngTileChoice].transform.rotation);
                        break;

                    case "d":
                        rngTileChoice = Random.Range(0, shapes12.Length - 1);
                        Instantiate(shapes12[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes12[rngTileChoice].transform.rotation);
                        break;

                    case "l":
                        rngTileChoice = Random.Range(0, shapes13.Length - 1);
                        Instantiate(shapes13[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes13[rngTileChoice].transform.rotation);
                        break;

                    case "r":
                        rngTileChoice = Random.Range(0, shapes14.Length - 1);
                        Instantiate(shapes14[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes14[rngTileChoice].transform.rotation);
                        break;

                    default:
                    case "X":
                    case "O":
                        rngTileChoice = Random.Range(0, shapes15.Length - 1);
                        Instantiate(shapes15[rngTileChoice], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes15[rngTileChoice].transform.rotation);
                        break;
                }
                //}
            }
		}
        GameObject.Find("Sphere").transform.position = startPos;
	}

    private bool HasRightConnection(int r, int c)
    {
        if (mapGenerator.map[r, c + 1].ToString().Equals("─") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┐") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┘") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┤") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┬") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┴") ||
            mapGenerator.map[r, c + 1].ToString().Equals("┼"))
        {
            return true;
        }
        else
        {
            return false;
        }        
    }

    private bool HasLeftConnection(int r, int c)
    {
        if (mapGenerator.map[r, c - 1].ToString().Equals("─") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┐") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┘") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┤") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┬") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┴") ||
            mapGenerator.map[r, c - 1].ToString().Equals("┼"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

	private int GetVisitedCellsCount(bool[,] visitedCells) {
		int visitedCellsCount = 0;

		for (int r = 1; r < mapGenerator.mapRows - 1; r++) {
			for (int c = 1; c < mapGenerator.mapColumns - 1; c++) {
				if (visitedCells [r, c]) {
					visitedCellsCount++;
				}
			}
		}

		return visitedCellsCount;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
