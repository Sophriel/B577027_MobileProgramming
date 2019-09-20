using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Transform closestZombie;

    float searchRadius = 0.3f;
    int layerMask;

    void Start()
    {
        closestZombie = transform;

        //  좀비만 탐색
        layerMask = 1 << LayerMask.NameToLayer("Zombie");
    }

    void Update()
    {
        ZombieRador();
    }

    //  SphereCast를 이용하여 
    //  가장 가까운 좀비를 탐색
    public void ZombieRador()
    {
        //  구형 탐색
        RaycastHit[] hit = Physics.SphereCastAll(transform.position, searchRadius, Vector3.up, 0.0f, layerMask);

        if (hit.Length > 0)
        {
            //  탐지시, 기존의 좀비를 흰색으로 변경하고
            closestZombie.GetComponent<MeshRenderer>().material.color = Color.white;

            closestZombie = hit[0].transform;

            //  더 가까운 좀비를 빨간색으로 변경
            closestZombie.GetComponent<MeshRenderer>().material.color = Color.red;

            searchRadius = 0.3f;
        }

        else
        {
            //  탐색 반경이 늘어남
            searchRadius += 0.1f;
        }
    }

    void OnDrawGizmos()
    {
        //  SphereCast를 시각화
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, searchRadius);
    }
}
