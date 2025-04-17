using BehaviorDesigner.Runtime;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

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
            if (camp1.MonsterList.Count < camp1.monsterCount)
            {
                camp1.spawnTimer += Time.deltaTime;
                if (camp1.spawnTimer >= camp1.RefreshTime)
                {
                    camp1.spawnTimer = 0;
                    Refresh(camp1Position);
                }
            }
        }


        private void Refresh(List<Transform> waypoints)
        {
            for (int i = camp1.MonsterList.Count; i < camp1.monsterCount; i++)
            {
                GameObject monster =
                    GameObject.Instantiate(prefabGoblin1); //, camp1.campPoint.position, Quaternion.identity
                BehaviorTree bt = monster.GetComponent<BehaviorTree>();
                ((SharedGameObject)bt.GetVariable("Player")).Value = player;
                ((SharedTransformList)bt.GetVariable("WayPoints")).Value = waypoints;
                WithHp wh = monster.GetComponent<WithHp>();
                wh.OnDeath += () =>
                {
                    Destroy(wh.gameObject);
                    GameObject.Instantiate(this.prefabDeathVFX, wh.transform.position, Quaternion.identity);
                    GameObject.Instantiate(this.booty, wh.transform.position + Vector3.up, Quaternion.identity);
                    camp1.MonsterList.Remove(monster);
                };
                camp1.MonsterList.Add(monster);
            }
        }

        [SerializeField] private List<Camp> campList = new List<Camp>();
    }

    [Serializable]
    public class Camp
    {
        public Camp(int monsterCount, float refreshTime = 3f)
        {
            this.monsterCount = monsterCount;
            RefreshTime = refreshTime;
        }

        public Transform campPoints;
        public int monsterCount;
        [HideInInspector] public List<GameObject> MonsterList { get; private set; } = new List<GameObject>();
        [HideInInspector] public readonly float RefreshTime;
        [HideInInspector] public float spawnTimer = 0f;
    }
}