using UnityEngine;

public class Grid : MonoBehaviour
{
    public const float innerRadius = 3f;
    public const float outerRadius = 0.866025404f;
    public Vector3 offset;

    [SerializeField] private readonly float size = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {
        var xCount = Mathf.RoundToInt(position.x / size);
        var yCount = Mathf.RoundToInt(position.y / size);
        var zCount = Mathf.RoundToInt(position.z / size);

        var result = new Vector3(
            xCount * size,
            yCount * size,
            zCount * size);


        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 40; x += 1)
        for (float z = 0; z < 40; z += 1)
        {
            Vector3 point;
            if (z % 2 == 0)
                point = new Vector3(x * innerRadius, 0, z * outerRadius) * size + offset;
            else
                point = new Vector3(x * innerRadius + innerRadius / 2f, 0, z * outerRadius) * size + offset;
            Gizmos.DrawSphere(point, 0.1f);
        }


        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GetNearestPointOnGrid(transform.position), 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);
    }
}