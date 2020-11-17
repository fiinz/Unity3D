using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perspetive : MonoBehaviour
{
    public class Perspective : Sense
    {
        public int fieldOfView = 45;
        public int viewDistance = 100;

        private Transform playerTransform;
        private Vector3 rayDirection;

        protected override void Initialize()
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }

        protected override void UpdateSense()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= detectionRate)
            {
                DetectAspect();
            }
        }

        //Detect perspective field of view for the AI Character
        void DetectAspect()
        {
            RaycastHit hit;
            rayDirection = playerTransform.position - transform.position;

            if ((Vector3.Angle(rayDirection, transform.up)) < fieldOfView)
            {
                // Detect if player is within the field of view
                if (Physics.Raycast(transform.position, rayDirection, out hit, viewDistance))
                {
                    Aspect aspect = hit.collider.GetComponent<Aspect>();
                    if (aspect != null)
                    {
                        //Check the aspect
                        if (aspect.aspectType != aspectName)
                        {
                            print("Enemy Detected");
                        }
                    }
                }
            }
        }
    }
}
