/** Author's Name:          Mithul Koshy
 *  Last Modified By:       Mithul Koshy
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Arranges asteroids as props in the level.
 *  Revision History:       October 25, 2023 (Mithul Koshy): Initial AsteroidUI script.
 */

using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class AsteroidUI : MonoBehaviour
{
    public RectTransform spawnArea;
    public List<GameObject> asteroidPrefabs;
    public float spawnInterval = 2f;
    public float asteroidSpeed = 50f;

    private void Start()
    {
        // Start spawning asteroids
        InvokeRepeating("SpawnAsteroid", 0f, spawnInterval);
    }

    private void SpawnAsteroid()
    {
        // Select a random asteroid prefab from the list
        int randomIndex = Random.Range(0, asteroidPrefabs.Count);
        GameObject selectedAsteroidPrefab = asteroidPrefabs[randomIndex];

        // Create a new asteroid instance
        GameObject asteroid = Instantiate(selectedAsteroidPrefab, transform);

        // Set the asteroid's position randomly within the spawn area
        RectTransform asteroidTransform = asteroid.GetComponent<RectTransform>();
        float xPosition = Random.Range(spawnArea.rect.min.x, spawnArea.rect.max.x);
        float yPosition = Random.Range(spawnArea.rect.min.y, spawnArea.rect.max.y);
        asteroidTransform.anchoredPosition = new Vector2(xPosition, yPosition);

        // Add a rigidbody to the asteroid for movement
        Rigidbody2D asteroidRigidbody = asteroid.AddComponent<Rigidbody2D>();
        asteroidRigidbody.gravityScale = 0f; // Disable gravity for asteroids
        asteroidRigidbody.velocity = Random.insideUnitCircle.normalized * asteroidSpeed;

        // Destroy the asteroid when it's outside the defined rectangle
        Destroy(asteroid, 10f);
    }
}
