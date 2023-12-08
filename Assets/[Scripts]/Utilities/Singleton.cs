/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Parent class implementing Singleton pattern. 
 *                          If a class needs to be a Singleton, just inherit this class.
 *  Revision History:       October 25, 2023: Initial Singleton script.
 *                          November 2, 2023 (Han Bi): updated code in RemoveDuplicates()
 *                          December 7, 2023 (Ikamjot Hundal): Added OnSceneLoaded where I'll destroy singleton objects in gameover scene
 */

using UnityEngine;
using UnityEngine.SceneManagement;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    public static T Instance { get => instance; }
    public virtual void Awake()
    {
        RemoveDuplicates();
    }
    private void RemoveDuplicates()
    {

        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "GameOver")
        {
            Destroy(gameObject);
        }
    }
}
