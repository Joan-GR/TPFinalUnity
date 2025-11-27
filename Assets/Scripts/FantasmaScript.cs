using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;


public class FantasmaScript : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform objetivo;
    // Start is called before the first frame update 
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = objetivo.position;

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = objetivo.position;
        if (agent.remainingDistance < 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}