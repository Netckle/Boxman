using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 포탈에 박스가 충돌하면 연결된 포탈의 발사지점으로 워프시킨다.
/// </summary>
public class Portal : MonoBehaviour
{
    public Transform shootPoint; 
    public Portal pairPortal;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Box")
        {          
            collision.gameObject.transform.position = pairPortal.shootPoint.position;            
        }
    }
}
