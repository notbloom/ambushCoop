using UnityEngine;

public class Grid : MonoBehaviour
{
    public const float innerRadius = 3f;
    public const float outerRadius = 0.866025404f;
    [SerializeField]
    private float size = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position)
    {

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3(
            (float)xCount * size,
            (float)yCount * size,
            (float)zCount * size);


        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        for (float x = 0; x < 40; x += size)
        {
            for (float z = 0; z < 40; z += size)
            {
                Vector3 point;
                if (z % 2 == 0)
                {
                    point = new Vector3(x * innerRadius, 0, z * outerRadius);
                }
                else
                {
                    point = new Vector3(x * innerRadius + innerRadius / 2f, 0, z * outerRadius);
                }
                Gizmos.DrawSphere(point, 0.1f);
            }

        }



        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(GetNearestPointOnGrid(transform.position), 0.3f);

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, 0.1f);

    }
}