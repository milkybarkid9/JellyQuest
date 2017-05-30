using UnityEngine;
using System.Collections;

public class DungeonDisplay : MonoBehaviour {
	public GameObject[] shapes;
	public MapGenerator mapGenerator;
	public float minimumMazePercentage = 0.8f;

    [SerializeField]
    public int tileHeight;
    [SerializeField]
    public int tileWidth;
    public Vector2 startPos;

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
                        Instantiate(shapes[0], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[0].transform.rotation);
                        if (c == 0) {
                            startPos.x = -2*tileWidth/5;
                            startPos.y = (-tileHeight * r) /*+ (-tileHeight / 2)*/;
                        }
                        break;

                    case "│":
                        Instantiate(shapes[1], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[1].transform.rotation);
                        break;

                    case "┌":
                        Instantiate(shapes[2], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[2].transform.rotation);
                        break;

                    case "┐":
                        Instantiate(shapes[3], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[3].transform.rotation);
                        break;

                    case "└":
                        Instantiate(shapes[4], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[4].transform.rotation);
                        break;

                    case "┘":
                        Instantiate(shapes[5], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[5].transform.rotation);
                        break;

                    case "├":
                        Instantiate(shapes[6], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[6].transform.rotation);
                        break;

                    case "┤":
                        Instantiate(shapes[7], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[7].transform.rotation);
                        break;

                    case "┬":
                        Instantiate(shapes[8], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[8].transform.rotation);
                        break;

                    case "┴":
                        Instantiate(shapes[9], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[9].transform.rotation);
                        break;

                    case "┼":
                        Instantiate(shapes[10], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[10].transform.rotation);
                        break;

                    case "u":
                        Instantiate(shapes[11], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[11].transform.rotation);
                        break;

                    case "d":
                        Instantiate(shapes[12], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[12].transform.rotation);
                        break;

                    case "l":
                        Instantiate(shapes[13], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[13].transform.rotation);
                        break;

                    case "r":
                        Instantiate(shapes[14], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[14].transform.rotation);
                        break;

                    default:
                    case "X":
                    case "O":
                        Instantiate(shapes[15], new Vector3(c * tileWidth, -r * tileHeight, 0), shapes[15].transform.rotation);
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
