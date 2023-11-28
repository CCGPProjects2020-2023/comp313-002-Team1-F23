/** Author's Name:          Marcus Ngooi
 *  Last Modified By:       Han Bi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Parent class implementing Singleton pattern. 
 *                          If a class needs to be a Singleton, just inherit this class.
 *  Revision History:       October 25, 2023: Initial Singleton script.
 *                          November 2, 2023 (Han Bi): updated code in RemoveDuplicates()
 */

using UnityEngine;

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
}
