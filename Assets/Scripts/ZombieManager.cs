using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieManager : MonoBehaviour
{
    public Transform PlayerCharacter;

    public GameObject ZombiePrafab;
    public List<Transform> ZombieTransforms;

    private Transform closestZombie;

    void Start()
    {
        //  플레이어 캐릭터 할당
        PlayerCharacter = GameObject.FindGameObjectWithTag("Player").transform;

        //  좀비 생성 후 리스트에 추가
        for (int i = 0; i < 10; i++)
        {
            float posX = Random.Range(-10.0f, 10.0f);
            float posZ = Random.Range(-10.0f, 10.0f);
            Transform zombie = Instantiate(ZombiePrafab, new Vector3(posX, 0.5f, posZ), Quaternion.identity).transform;

            ZombieTransforms.Add(zombie);
        }

        //  초기화
        closestZombie = ZombieTransforms[0];
    }

    void Update()
    {
        //CheckZombiesDistance();
    }

    //  리스트에 존재하는 좀비들과 플레이어 사이의 거리를 측정하여
    //  가장 가까운 좀비를 탐색
    public void CheckZombiesDistance()
    {
        //  기존 빨간 좀비의 색상 변경
        closestZombie.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;

        //  플레이어와 좀비들의 거리를 비교
        foreach (Transform z in ZombieTransforms)
        {
            if ((PlayerCharacter.position - z.position).sqrMagnitude <
                (PlayerCharacter.position - closestZombie.position).sqrMagnitude)
            {
                closestZombie = z;
            }
        }

        //  가장 가까운 좀비의 색상 변경
        closestZombie.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
    }
}
