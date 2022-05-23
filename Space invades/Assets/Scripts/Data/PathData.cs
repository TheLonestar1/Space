using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Path", menuName ="GameSO/Path")]
public class PathData : ScriptableObject
{
    public List<Vector2> Points = new List<Vector2>();
#if UNITY_EDITOR
    [ContextMenu("Save path")]
    private void GetPoints()
    {
        var enemyPath = FindObjectOfType<EnemyPath>();
        if(enemyPath != null)
        {
            Points = enemyPath.GetPathPoints();
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.SceneManagement.EditorSceneManager.MarkSceneDirty(UnityEngine.SceneManagement.SceneManager.GetActiveScene());
        }
    }
    [ContextMenu("Load path")]
    private void LoadPoints()
    {
        GameObject path = new GameObject("Path");
        EnemyPath enemyPath = path.AddComponent<EnemyPath>();
        for (int i = 0; i < Points.Count; i++)
        {
            GameObject point = new GameObject($"Point{i}");
            point.transform.SetParent(path.transform);
            point.transform.position = Points[i];
            enemyPath.AddPoints(point.transform);
        }
    }
#endif
}
