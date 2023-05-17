using UnityEngine;

public class EnemyCreat : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnPanel;
    public float enemySpawnSecondSet;
    private float enemySpawnSecond;
    public int enemySpawnCount;
    private bool isStart;

    private void Update()
    {
        if (Time.time > enemySpawnSecond && enemySpawnCount > 0 && (isStart || Input.GetKey(KeyCode.C)))
        {
            GameObject obj = Instantiate(enemyPrefab, spawnPanel.transform.position, spawnPanel.transform.rotation);
            obj.transform.SetParent(spawnPanel.transform);
            obj.transform.localScale = new Vector3(1, 1, 0);
            enemySpawnCount--;
            isStart = true;
            enemySpawnSecond = Time.time + enemySpawnSecondSet;
        }
    }
}