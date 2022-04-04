using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))] //will auto add boxcollider when you attach this script to smth
public class OneWayPlatform : MonoBehaviour
{

    [SerializeField] private Vector3 entryDirection = Vector3.up; //direction the platform needs to be entered from
    [SerializeField] private bool localDirection = false; //want to know if this direction is a local or global direction
    [SerializeField, Range(1.0f, 2.0f)] private float triggerScale = 2f;
    //private new BoxCollider collider = null; //overrides old deprecated variable
    public GameObject parent;
    private BoxCollider parentCollider;
    private BoxCollider collider;
    public LayerMask ground;

    private BoxCollider collisionCheckTrigger = null;

    private Collider overlapping;

    private void Awake()
    {
        print(this.transform.parent.gameObject.name);
        parentCollider = this.transform.parent.gameObject.GetComponent<BoxCollider>();
        // collider = this.GetComponent<BoxCollider>();
        /*    collider.isTrigger = false;*/

        //this collider will detect if player is close to the object + direction player is coming from
        /* collisionCheckTrigger = gameObject.AddComponent<BoxCollider>(); //adds a new box collider
         collisionCheckTrigger.size = collider.size * triggerScale;
         collisionCheckTrigger.center = collider.center;
         collisionCheckTrigger.isTrigger = true;*/

        // Physics.IgnoreLayerCollision(ground, ground, true);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other);
        print(parentCollider);
        print("enter");
        Physics.IgnoreCollision(parentCollider, other, true);
        foreach (Collider coll in Controller.playerColliders)
        {
            Physics.IgnoreCollision(parentCollider, coll, true);
        }
        /* overlapping = other;
         print("just overlapped " + overlapping.gameObject.name);*/
    }

    private void OnTriggerExit(Collider other)
    {
        print("exit");
        Physics.IgnoreCollision(parentCollider, other, false);

        /*        if (other == overlapping)
                {
                    print("just exit " + overlapping.gameObject.name);

                    overlapping = null;

                }*/
    }

    private void Update()
    {
        /*  if (overlapping != null)
          {
              //print(transform.rotation + " " + overlapping.transform.rotation);
              if (true*//*Physics.ComputePenetration(
                  collisionCheckTrigger, transform.position, transform.rotation,
                  overlapping, overlapping.transform.position, overlapping.transform.rotation,
                  out Vector3 collisionDirection, out float penetrationDepth
                  )*//*) //will simulate the collision and will return true if collision happens
              {
                  Vector3 direction;
                  if (localDirection)
                  {
                      direction = transform.TransformDirection(entryDirection.normalized);
                  }
                  else
                  {
                      direction = entryDirection;
                  }

                  //if it happens, we want to check the diff between entryDirection and actual direction the player is coming from
                  float dot = Vector3.Dot(direction, overlapping.GetComponent<CharacterController>().velocity*//*collisionDirection*//*); //dot < 0, means they're facing opposite ways = coming from wrong directions

                  //Opposite direction, passing is not allowed
                  if (dot < 0)
                  {
                      Physics.IgnoreCollision(collider, overlapping, false);
                      //print("collision not ignored");
                  }
                  else //when dot > 0
                  {
                      Physics.IgnoreCollision(collider, overlapping, true);
                      // print("collision ignored");
                  }
              }
          }*/
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 direction;
        if (localDirection)
        {
            direction = transform.TransformDirection(entryDirection.normalized);
        }
        else
        {
            direction = entryDirection;
        }
        //so that when localDirection enabled, when you rotate the entry direction will change too!

        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, direction);
        //Gizmos.DrawRay(transform.position, entryDirection);

        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, -direction);
        //Gizmos.DrawRay(transform.position, -entryDirection);
    }

}
