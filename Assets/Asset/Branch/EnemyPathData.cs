using UnityEngine;

[CreateAssetMenu(fileName = "NewEnemyPath", menuName = "Scriptable Objects/EnemyPathData")]
public class EnemyPathData : ScriptableObject
{
    [Header("Path Settings")]
    [SerializeField] Vector3[] waypoints;

    public int WaypointCount => waypoints == null ? 0 : waypoints.Length;

    public Vector3 GetWaypoint(int index)
    {
        return waypoints[index]; 
    }
}
