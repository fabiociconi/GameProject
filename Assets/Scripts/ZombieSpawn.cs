using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawn : MonoBehaviour {

    public GameObject[] Zombies;

    public int waveSize;
    public int maxZombies;
    public float spawnTime;

	// Use this for initialization
	void Start () {
        InvokeRepeating("SpawnZombiesWave", spawnTime, spawnTime);
	}

    void SpawnZombiesWave()
    {
        var zombies = GameObject.FindGameObjectsWithTag("Enemy");
        if (zombies.Length >= maxZombies)
        {
            return;
        }

        for (int i=0; i < waveSize; i++)
        {
            var zombie = Instantiate(Zombies[Mathf.RoundToInt(Random.Range(0, Zombies.Length))], transform.transform);

            float x = 0;
            float y = 0;

            while (Mathf.Abs(x) < 20 || Mathf.Abs(y) < 20)
            {
                x = Random.Range(-35, 35);
                y = Random.Range(-35, 35);
            }

            zombie.transform.position = new Vector3(x, y, 0) + GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        }
    }
}
