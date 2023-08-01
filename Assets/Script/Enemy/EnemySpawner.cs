using System.Collections;
using UnityEngine;

[System.Serializable]
public class Formation
{
    public GameObject enemyPrefab;
    public int enemyCount;
    public float enemyDelay;
    public float speed;
    public Route route;
    public float formationDelay;
}

public class EnemySpawner : MonoBehaviour
{
    public Formation[] formations;
    public GameObject bossPrefab;
    public float bossdelay;
    public Route bossRoute;
    public CheckWin checkWin;


    private void Start() {
        StartCoroutine(SpawnFormations());
        StartCoroutine(SpawnBoss());
    }

    private IEnumerator SpawnFormations()
    {
        for (int i = 0; i < formations.Length; i++)
        {
            yield return new WaitForSeconds(formations[i].formationDelay);
            SpawnEnemies(formations[i]);
        }
    }

    private void SpawnEnemies(Formation formation)
    {
        for (int i = 0; i < formation.enemyCount; i++)
        {
            GameObject enemy = Instantiate(formation.enemyPrefab,
                formation.route[0], Quaternion.identity);
            EnemyRouteAgent agent = enemy.GetComponent<EnemyRouteAgent>();
            agent.route = formation.route;
            agent.delay = i * formation.enemyDelay;
            formation.speed = agent.moveSpeed;
        }
        //CheckWin.AddCountEnemyFormation(1);
    }

    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(bossdelay);// set thoi gian delay 
        GameObject boss = Instantiate(bossPrefab);
        boss.GetComponent<EnemyRouteAgent>().route = bossRoute;
        boss.GetComponent<HealthEnemy>().onDie.AddListener(checkWin.GameWin);

    }
}

