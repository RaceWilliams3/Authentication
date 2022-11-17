using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Transform playerTrans;
    private Transform trans;
    private bool atTarget;
    private Vector3 targetPos;

    public float speed;
    public int driftRange;
    public bool isPlaying;
    

    void Awake()
    {
        playerTrans = player.GetComponent<Transform>();
        trans = GetComponent<Transform>();
        atTarget = true;
        isPlaying = false;
    }

    void Start()
    {
        isPlaying = true;
    }

    void Update()
    {
        if (atTarget == false && Leaderboard.isPlaying == true)
        {
            trans.position = Vector3.MoveTowards(trans.position, targetPos, speed);
            if (Vector3.MoveTowards(trans.position, targetPos, speed) == targetPos)
                atTarget = true;
        }
        else
        {
            targetPos = new Vector3(Random.Range(-driftRange, driftRange), 0, Random.Range(-driftRange, driftRange)) + playerTrans.position;
            atTarget = false;
        }
    }
}
