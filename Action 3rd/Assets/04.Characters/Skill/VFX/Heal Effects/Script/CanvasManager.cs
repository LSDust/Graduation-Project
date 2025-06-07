using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CanvasManage
{ 
public class CanvasManager : MonoBehaviour
{
        int a=0;
        public int lastArray;
        public GameObject[] particles;
        public Text count;
        
        private void Start()
        {
            particles[0].SetActive(true);
        }
        public void Next()
        {
            a++;
            if (a >= lastArray)
            {
                a = 0;
            }
            count.text = a.ToString();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].SetActive(false);
            }
            if (a <= lastArray - 1 && a >= 0)
            {
                if (a == 0)
                { 
                    particles[a ].SetActive(true);
                }
                else
                {
                    particles[a - 1].SetActive(true);

                }
            }
           
    
        }

        public void Back()
        {
            a--;
            if (a <= 0)
            {
                a = 0;
            }
            count.text = a.ToString();
            for (int i = 0; i < particles.Length; i++)
            {
                particles[i].SetActive(false);
            }
            if (a <= lastArray - 1 && a >= 0)
            {
                if (a == 0)
                {
                    particles[a].SetActive(true);
                }
                else
                {
                    particles[a - 1].SetActive(true);

                }
            }
        }

        public void Particle_Play()
        {
            if (a == 0)
            {
                //particles[a].GetComponent<ParticleSystem>().Play();

                //particles[a].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

                particles[a].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                particles[a].transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
                particles[a].transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                //particles[a - 1].GetComponent<ParticleSystem>().Play();

                //particles[a - 1].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();

                particles[a - 1].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Play();
                particles[a - 1].transform.GetChild(1).gameObject.GetComponent<ParticleSystem>().Play();
                particles[a - 1].transform.GetChild(2).gameObject.GetComponent<ParticleSystem>().Play();

            }
        }
    }
}