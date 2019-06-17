using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class MoveCircular : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField]
        private ThirdPersonCharacter m_Character;
        [SerializeField]
        private float radius = 5;
        private Transform tr;
        private float Horizontal;
        void Start()
        {
            tr = transform;
        }

        // Update is called once per frame
        void Update()
        {
            Horizontal = Input.GetAxis("Horizontal");
            Vector3 character_distance_to_center = m_Character.transform.position - tr.position;
            Vector3 stay_radius_force = (radius - character_distance_to_center.magnitude) * character_distance_to_center.normalized;
            Vector3 move_in_circle_force = Horizontal * Vector3.Cross(Vector3.up, character_distance_to_center);
            Vector3 final_direction = stay_radius_force + move_in_circle_force;
            m_Character.Move(final_direction, false, false);
            Debug.DrawRay(m_Character.transform.position, final_direction, Color.red);
        }
        private void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}

