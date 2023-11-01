/*  Author's Name:          Marcus Ngooi
 *  Last Modified By:       Marcus Ngooi
 *  Date Last Modified:     October 25, 2023
 *  Program Description:    Parent class implementing Singleton pattern. 
 *                          If a class needs to be a Singleton, just inherit this class.
 *  Revision History:       October 25, 2023 (Marcus Ngooi): Initial Singleton script.
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
        if (instance == null)
        {
            instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
