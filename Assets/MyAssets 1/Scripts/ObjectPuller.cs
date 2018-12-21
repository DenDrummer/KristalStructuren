using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPuller : MonoBehaviour 
    {
        public float pullRadius = 20;
        public float pullForce = 50;
        private Transform cylinderRef;

        public void Start()
        {
            
        }

        public void FixedUpdate()
        {
            foreach (Collider collider in Physics.OverlapSphere(transform.position, pullRadius))
            {
            /*cylinderRef = GameObject.CreatePrimitive(PrimitiveType.Cylinder).transform;
            cylinderRef.localScale = new Vector3(-2,0,-2);
            GameObject gameObject = GameObject.Instantiate(cylinderRef.gameObject, transform.position, Quaternion.identity);
                gameObject.transform.localScale = Vector3.up * Vector3.Distance(transform.position, collider.transform.position);
                cylinderRef.position = transform.position; 
           cylinderRef.LookAt(collider.transform);*/

            // calculate direction from target to me
            Vector3 forceDirection = transform.position - collider.transform.position;

                // apply force on target towards me
                collider.GetComponent<Rigidbody>().AddForce(forceDirection.normalized*pullForce*Time.fixedDeltaTime*-50);
            }
        }
}
