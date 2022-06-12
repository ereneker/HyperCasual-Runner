using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// Started but not finished :1
/// </summary>
public class RankingSystem : MonoBehaviour
{
    public Rigidbody[] players;
    public Transform endPoint;
    private List<float> dist = new List<float>();
    [SerializeField] Text[] names = new Text[11];

    private void Update()
    {
        for (int i = 0; i < players.Length; i++)
        {
            this.dist[i] = endPoint.position.x - this.players[i].transform.position.x;
            if (this.dist[i] > this.dist[i+1])
            {
                names[i].text = players[i].name.ToString();
            }
        }
    }
}
