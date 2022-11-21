using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RankManager : MonoBehaviour
{
    public static RankManager instance;

    public Text[] txtRanks;

    Dictionary<string, Runner> players;
    Dictionary<string, Runner> sortedPlayers;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {
        players = new Dictionary<string, Runner>();
    }

    // Set player rank in UI text
    public void SetRank(Runner player)
    {
        players[player.name] = player;
        IOrderedEnumerable<KeyValuePair<string, Runner>> sortedPlayer = players.OrderBy(x => x.Value.distanceToWaypoint).OrderByDescending(x => x.Value.activeWaypointIndex);
        int i = 0;
        foreach (KeyValuePair<string, Runner> item in sortedPlayer)
        {
            txtRanks[i].text = (i + 1) + " . " + item.Value.name;
            i++;
        }
    }
}
