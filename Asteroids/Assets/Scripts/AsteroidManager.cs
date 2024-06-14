using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidManager : MonoBehaviour
{
    //variables
    public float spawnRate = 1.0f;
    public int maxSpawn = 1;
    public float spawnEdge;
    public float trajectoryVariance;
    public float minSize;
    public float maxSize;

    //refrences
    public AsteroidLogic asteroidPrefab;

    //spawn asteroids on a set timer
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate);
    }

    private void Spawn()
    {
        for(int i = 0; i < maxSpawn; i++)
        {
            //location of where it spawns on the edge of the screen
            Vector3 dir = Random.insideUnitCircle.normalized * spawnEdge;
            dir += this.transform.position;

            //random rotation and direction
            Quaternion rotation = Quaternion.AngleAxis(Random.Range(-trajectoryVariance, trajectoryVariance), Vector3.forward);

            //spawning asteroid
            AsteroidLogic astro = Instantiate(asteroidPrefab, dir, rotation);
            astro.size = Random.Range(minSize, maxSize);
            astro.Move(rotation * -(dir - this.transform.position));
        }
    }
}
