/** Author's Name:          Han Bi
 *  Modified By:       Han Bi
 *  Date Last Modified:     November 17, 2023
 *  Program Description:    A manager that manages minigames
 *  Revision History:       November 17, 2023 (Han Bi): Initial script
 *  
 *  Last Modified By:       Laura Amangeldiyeva
 *  Date Last Modified:     November 27, 2023
 *  Program Description:    A manager that manages minigames
 *  Revision History:       November 27, 2023 (Laura Amangeldiyeva): Changed the script to spawn CaptureTheHill mini game for game testing
 */


using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// A manager that handles events relating to minigames
/// </summary>
public class MinigameManager : MonoBehaviour
{
    [SerializeField]
    GameObject captureTheHillPrefab;

    [SerializeField]
    GameObject trapPrefab;

    [SerializeField]
    GameObject player;

    [SerializeField]
    [Tooltip("Minimum distance minigames can spawn from the player")]
    int minDistance;

    [SerializeField]
    [Tooltip("Maximum distance minigames can spawn from the player")]
    int maxDistance;

    //used to spawn the correct minigame based on enum
    Dictionary<MinigameType, GameObject> minigamePrefabs = new Dictionary<MinigameType, GameObject>();


    //list of weapons minigames has been spawned for
    List<Weapon> minigamesSpawned = new();

    int enumCount;

    public enum MinigameType
    {
        CaptureTheHill,
        Trap,
    }

    private void Start()
    {
        minigamePrefabs.Clear();

        //manually registering these, might need to automate later
        minigamePrefabs.Add(MinigameType.CaptureTheHill, captureTheHillPrefab);
        minigamePrefabs.Add(MinigameType.Trap, trapPrefab);
        
        enumCount = Enum.GetValues(typeof(MinigameType)).Length;

        if(player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }

        StartCoroutine(nameof(SubscribeEvents));
    }

    IEnumerator SubscribeEvents()
    {
        while (SkillManager.Instance == null)
        {
            print("null");
            yield return new WaitForSeconds(0.1f);
        }
        
        SkillManager.Instance.OnNewWeaponAdded += HandleNewWeaponSelected;

        //when initially subscribing, check if there are any weapons that are non empowered
        List<Weapon> unempoweredWeapons = SkillManager.Instance.GetUnEmpoweredWeapons();
        if (unempoweredWeapons != null)
        {
            foreach (Weapon weapon in unempoweredWeapons)
            {
                HandleNewWeaponSelected(weapon);
            }
        }

    }


    private void OnDestroy()
    {
        if(SkillManager.Instance != null)
        {
            SkillManager.Instance.OnNewWeaponAdded -= HandleNewWeaponSelected;
        }
    }

    void HandleNewWeaponSelected(Weapon weapon)
    {
        if(!minigamesSpawned.Contains(weapon))
        {
            minigamesSpawned.Add(weapon);
            //SpawnMinigame(RandomMinigame(), weapon);
            SpawnMinigame(MinigameType.CaptureTheHill, weapon);
        }
        
    }

    void HandleMiniGameCompleted(Minigame game)
    {
        game.EmpowerType.EmpowerWeapon();
        game.OnMinigameComplete -= HandleMiniGameCompleted;
    }

    public void SpawnMinigame(MinigameType gameType, Weapon weapon)
    {
        print($"Spawining {gameType} for {weapon}");

        if (minigamePrefabs.ContainsKey(gameType))
        {
            var _obj = Instantiate(minigamePrefabs[gameType], GenerateSpawnLocation(), Quaternion.identity);
            _obj.GetComponent<Minigame>().Initalize(weapon);
            _obj.GetComponent<Minigame>().OnMinigameComplete += HandleMiniGameCompleted;
            _obj.transform.SetParent(transform);
        }
        else
        {
            Debug.LogError($"Error: No prefab register for: {gameType}");
        }
    }


    MinigameType RandomMinigame()
    {
        return (MinigameType)UnityEngine.Random.Range(0, enumCount);
    }


    private Vector3 GenerateSpawnLocation()
    {
        Vector3 ans = new(0, 0, 0);
        int xSign = UnityEngine.Random.Range(-1, 1);
        int ySign = UnityEngine.Random.Range(-1, 1);


        int x = UnityEngine.Random.Range(minDistance, maxDistance);
        int y = UnityEngine.Random.Range(minDistance, maxDistance);

        if (xSign < 0)
        {
            ans.x = x;
        }
        else
        {
            ans.x = -x;
        }

        if(ySign < 0) 
        {
            ans.y = y;
        }
        else
        {
            ans.y = -y;
        }

        ans += player.transform.position;
        return ans;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(player.transform.position, minDistance);
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireSphere(player.transform.position, maxDistance);
    //}



}
