using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BoxSpawner : MonoBehaviour 
{
    public GameObject boxPrefab;
    public Transform destination;
    public float moveTime;

    public List<GameObject> rails = new List<GameObject>();
    
    GameObject obj;
    Box box;

    private void Start()
    {
        obj = Instantiate(boxPrefab);
        box = obj.GetComponent<Box>();

        Spawn();
    }

    public void Spawn()
    {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        obj.transform.position = transform.position;
        obj.transform.DOMove(destination.position, moveTime);

        foreach(GameObject rail in rails)
        {
            Animator animator = rail.GetComponent<Animator>();
            animator.SetBool("isAction", true);
        }

        yield return new WaitForSeconds(moveTime);

        foreach (GameObject rail in rails)
        {
            Animator animator = rail.GetComponent<Animator>();
            animator.SetBool("isAction", false);
        }
    }
}
