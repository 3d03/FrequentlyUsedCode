using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using SimpleJSON;


public class BallController : MonoBehaviour
{
    public static float moveSpeed = 0.05f;

    [SerializeField] TextAsset ball_path_json;

    public Slider speedSlider; //этот слайдер запихал в паблик переменную, хотя конечно можно было сделать еще один контроллер-синглтон следящий  за всеми мячами.   

    public List<Vector3> pointPositions;         //лист спарсенных позиции траектории

    public GameObject trajectoryPointInstance;   //GO для отображения траектории
    public float trajectoryPointGapCoeff = 0.5f; //коэфициент промежутка между точками пройденной траектории   относительно Renderer.BoundingBox.size.x   (относительно размера мяча)
    float trajectoryPointGap;                    //расстояние между точками пройденной траектории   

    bool isMoving;
    bool needToMove;
    bool isFinishedMoving;

    int pathPointsCount;
    int curPathPointIndex=0;

    Vector3 lastTrajectoryPointPos = Vector3.zero;
    List<GameObject> generatedTrajectoryPoints;


    
    private void Start()
    {
        trajectoryPointGap = this.gameObject.GetComponent<Renderer>().bounds.size.x * trajectoryPointGapCoeff;
        AnalyzeBall_path_json();
        speedSlider.gameObject.SetActive(false);
        generatedTrajectoryPoints = new List<GameObject>();
        this.gameObject.transform.position = pointPositions[0];   //перенос на стартовую позицию
    }

    public void SetMoveSpeedBySlider()
    {
        moveSpeed = speedSlider.value;
    }

    void AnalyzeBall_path_json()
    {
        pointPositions = new List<Vector3>();
        pointPositions.Capacity = 0;

        var N = JSON.Parse(ball_path_json.text);
        pathPointsCount = N["x"].Count;

        for (int i=0; i<pathPointsCount;i++)
        {
            string xStr = N["x"][i].Value;
            string yStr = N["y"][i].Value;
            string zStr = N["z"][i].Value;

            float xPos = float.Parse(xStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            float yPos = float.Parse(yStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);
            float zPos = float.Parse(zStr, System.Globalization.CultureInfo.InvariantCulture.NumberFormat);

            pointPositions.Add(new Vector3(xPos, yPos, zPos));
        }
    }

    /// <summary>
    /// вызывается одинарным кликом в скрипте EnhancedButton
    /// </summary>
    public void Move()    
    {
        if (!isMoving  && !isFinishedMoving)
        {
            needToMove = true;
            curPathPointIndex=1;
            isMoving = true;
            speedSlider.gameObject.SetActive(true);
            CameraTargetController.Instance.ChangeCameraTarget(this.gameObject);
        }
    }

    public void GotoStartPoint()
    {
        this.transform.position = pointPositions[0];
        curPathPointIndex=0;
        needToMove = false;
        isMoving = false;
        speedSlider.gameObject.SetActive(false);

        generatedTrajectoryPoints.ForEach(l => GameObject.Destroy(l, 0.001f));
        generatedTrajectoryPoints.Clear();
        generatedTrajectoryPoints.Capacity = 0;
        isFinishedMoving = false;

    }
    

    private void Update()
    {
        if (needToMove)
        {
            //этот блок IF   отвечает за создание точек пройденной траектории
            if ((lastTrajectoryPointPos == Vector3.zero) || (Vector3.Distance(lastTrajectoryPointPos, this.transform.position) >= trajectoryPointGap))
            {
                lastTrajectoryPointPos = this.transform.position;
                GameObject trajectoryPoint = GameObject.Instantiate(trajectoryPointInstance);
                trajectoryPoint.transform.position = this.transform.position;
                trajectoryPoint.transform.localScale = this.transform.localScale * 0.5f;
                generatedTrajectoryPoints.Add(trajectoryPoint);
            }

            ///двигаем  к очередной точке - таргету
            Vector3 targetPos = new Vector3(pointPositions[curPathPointIndex].x, pointPositions[curPathPointIndex].y, pointPositions[curPathPointIndex].z);
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPos, moveSpeed);

     
            
            if (Vector3.Distance(this.transform.position, targetPos) ==0)      ///Если достигло очередной точки
            {
                curPathPointIndex++;
                if (curPathPointIndex == pointPositions.Count)  ///Если достигло финальной точки
                {
                    isMoving = false;
                    needToMove = false;
                    speedSlider.gameObject.SetActive(false);
                    isFinishedMoving = true;                    
                }

            }
        }
    }
}

