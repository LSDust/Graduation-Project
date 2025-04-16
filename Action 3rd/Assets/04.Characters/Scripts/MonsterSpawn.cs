using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Action3rd
{
    public class MonsterSpawn : MonoBehaviour
    {
        [SerializeField] private GameObject prefabGoblin1;
        [SerializeField] private GameObject prefabDeathVFX;
        [SerializeField] private GameObject booty;
        [SerializeField] private List<Transform> camp1Position;
        private Camp camp1 = new Camp(4);
        private GameObject player;

        // Start is called before the first frame update
        void Start()
        {
            this.player = GameObject.FindGameObjectWithTag("Player");
        }

        // Update is called once per frame
        void Update()
        {
            if (camp1.MonsterList.Count < camp1.MonsterCount)
            {
                camp1.SpawnTimer += Time.deltaTime;
                if (camp1.SpawnTimer >= camp1.RefreshTime)
                {
                    camp1.SpawnTimer = 0;
                    Refresh(camp1Position);
                }
            }
        }


        private void Refresh(List<Transform> waypoints)
        {
            for (int i = camp1.MonsterList.Count; i < camp1.MonsterCount; i++)
            {
                GameObject monster = GameObject.Instantiate(prefabGoblin1);
                BehaviorTree bt = monster.GetComponent<BehaviorTree>();
                ((SharedGameObject)bt.GetVariable("Player")).Value = player;
                ((SharedTransformList)bt.GetVariable("WayPoints")).Value = waypoints;
                WithHp wh = monster.GetComponent<WithHp>();
                wh.OnDeath += () =>
                {
                    GameObject.Instantiate(this.prefabDeathVFX, wh.transform.position, Quaternion.identity);
                    GameObject.Instantiate(this.booty, wh.transform.position + Vector3.up, Quaternion.identity);
                };
                camp1.MonsterList.Add(monster);
            }
        }
    }

    public class Camp
    {
        public Camp(int monsterCount, float refreshTime = 3f)
        {
            MonsterCount = monsterCount;
            RefreshTime = refreshTime;
        }

        [SerializeField] private readonly GameObject campPoint;
        public readonly int MonsterCount;
        public List<GameObject> MonsterList { get; private set; } = new List<GameObject>();
        public readonly float RefreshTime;
        public float SpawnTimer = 0f;
    }
}