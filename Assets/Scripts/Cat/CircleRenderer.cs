using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class CircleRenderer : MonoBehaviour
{
    [SerializeField] private int segments = 50;
    [SerializeField] private Color color;
    [SerializeField] private float heightOffset = 0.1f;
    private float radius = 1f;
    public RayCastGun laserScript;
    public CatMovement catScript;



    private LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = false;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.startColor = color;
        lineRenderer.endColor = color;

    }

    private void Update()
    {
        if (laserScript.currentLaser == LasersTypes.laserRed)
        {
            radius = catScript.radius * 2f;
        }
        else if (laserScript.currentLaser == LasersTypes.laserBlue)
        {
           radius = catScript.radius * 2f;

        }

        CreatePoints();

    }

    private void CreatePoints()
    {
        float angle = 0f;
        float deltaAngle = 2f * Mathf.PI / segments;
        Vector3[] points = new Vector3[segments];

        for (int i = 0; i < segments; i++)
        {
            float x = Mathf.Sin(angle) * radius;
            float y = heightOffset; // Alterado para 0f
            float z = Mathf.Cos(angle) * radius;
            points[i] = new Vector3(x, y, z);
            angle += deltaAngle;
        }

        lineRenderer.positionCount = segments;
        lineRenderer.SetPositions(points);
    }
}

