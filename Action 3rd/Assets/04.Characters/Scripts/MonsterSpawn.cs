using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Action3rd
{
    public class MonsterSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject prefabGoblin1;
        [SerializeField] private GameObject prefabDeathVFX;
        [SerializeField] private GameObject booty;
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            this.player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            for (int i = 0; i < campList.Count; i++)
            {
                if (campList[i].MonsterList.Count < campList[i].monsterCount)
                {
                    this.spawnTimer += Time.deltaTime;
                    if (this.spawnTimer >= RefreshTime)
                    {
                        this.spawnTimer = 0;
                        Refresh(campList[i]);
                    }
                }
            }
        }


        private void Refresh(Camp camp)
        {
            for (int i = camp.MonsterList.Count; i < camp.monsterCount; i++)
            {
                GameObject monster =
                    GameObject.Instantiate(prefabGoblin1,
                        camp.waypoints[0].transform.position + GetRandomPositionInCircle(2f),
                        Quaternion.identity);
                BehaviorTree bt = monster.GetComponent<BehaviorTree>();
                ((SharedGameObject)bt.GetVariable("Player")).Value = player;
                ((SharedGameObjectList)bt.GetVariable("WayPoints")).Value = camp.waypoints;
                WithHp wh = monster.GetComponent<WithHp>();
                wh.OnDeath += () =>
                {
                    Destroy(wh.gameObject);
                    GameObject.Instantiate(this.prefabDeathVFX, wh.transform.position, Quaternion.identity);
                    GameObject.Instantiate(this.booty, wh.transform.position + Vector3.up, Quaternion.identity);
                    camp.MonsterList.Remove(monster);
                };
                camp.MonsterList.Add(monster);
            }
        }

        [SerializeField] private List<Camp> campList = new List<Camp>();
        private const float RefreshTime = 10f;
        [HideInInspector] public float spawnTimer = 0f;

        Vector3 GetRandomPositionInCircle(float radius)
        {
            // 获取圆内的随机点
            Vector2 randomPoint = Random.insideUnitCircle * radius;

            // 转换为Vector3（y=0）
            return new Vector3(randomPoint.x, 0f, randomPoint.y);
        }
    }

    [Serializable]
    public class Camp
    {
        public List<GameObject> waypoints;
        public int monsterCount;
        [HideInInspector] public List<GameObject> MonsterList { get; private set; } = new List<GameObject>();
    }
}