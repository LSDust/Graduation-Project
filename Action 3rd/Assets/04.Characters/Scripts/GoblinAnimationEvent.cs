using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Action3rd
{
    public class GoblinAnimationEvent : MonoBehaviour
    {
        public GameObject prefabStone;
        public Transform throwPoint;

        public void Throw()
        {
            Vector3 initialVelocity = CalculateLaunchData(throwPoint.position,
                GameObject.FindGameObjectWithTag("Player").transform.position, 1f);
            GameObject stone = GameObject.Instantiate(prefabStone, throwPoint.position, Quaternion.identity);
            stone.GetComponent<Rigidbody>().velocity = initialVelocity;
        }

        public static Vector3 CalculateLaunchData(Vector3 start, Vector3 target, float flightTime)
        {
            // 计算位移
            Vector3 displacement = target - start;

            // 重力加速度 (Unity中Physics.gravity是负值)
            Vector3 gravity = Physics.gravity;

            // 计算初始速度
            Vector3 initialVelocity = (displacement - 0.5f * gravity * flightTime * flightTime) / flightTime;

            return initialVelocity;
        }
    }
}