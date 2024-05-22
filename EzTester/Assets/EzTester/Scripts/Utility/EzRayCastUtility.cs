using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace EzUtility
{
    public enum RayCastType
    {
        Ray,
        Sphere,
        Box,
        Capsule
    }
    /// <summary>
    /// Class used to visualize a raycast in the game world.
    /// </summary>
    public class EzRayCastUtility : MonoBehaviour
    {

        [SerializeField]
        [Tooltip("Type of the raycast")]
        private RayCastType m_rayType = RayCastType.Ray;/**Type of the raycast */
        private Vector3 m_origin;/**Origin of the raycast */
        [SerializeField]
        [Tooltip("Direction of the raycast")]
        private Vector3 m_direction = Vector3.forward;/**Direction of the raycast */

        [SerializeField]
        [Tooltip("The distance of the raycast")]
        private float m_distance = 10;/**The distance of the raycast */

        [SerializeField]
        [Tooltip("The color of the raycast")]
        private Color m_rayColor = Color.red;/**The color of the raycast */

        [SerializeField]
        [Tooltip("Check hit on play mode")]
        private bool m_checkHit = false;/**Check hit on play mode */

        /// <summary>
        /// Draws a raycast from the origin to the direction provided.
        /// </summary>
        /// <param name="origin">The origin of the raycast.</param>
        /// <param name="direction">The direction of the raycast.</param>
        /// <param name="distance">The distance of the raycast.</param>
        public void DrawRayCast(Vector3 origin, Vector3 direction, float distance)
        {
            Debug.DrawRay(origin, direction * distance, m_rayColor);
        }

        /// <summary>
        /// Draws a raycast from the origin to the direction provided with the default distance.
        /// </summary>
        /// <param name="origin">The origin of the raycast.</param>
        /// <param name="direction">The direction of the raycast.</param>
        public void DrawRayCast(Vector3 origin, Vector3 direction)
        {
            DrawRayCast(origin, direction, m_distance);
        }

        /// <summary>
        /// Draws a raycast using the provided Ray object with the default distance.
        /// </summary>
        /// <param name="ray">The Ray object representing the raycast.</param>
        public void DrawRayCast(Ray ray)
        {
            DrawRayCast(ray.origin, ray.direction, m_distance);
        }

        /// <summary>
        /// Sets the direction of the raycast.
        /// </summary>
        /// <param name="direction"></param>
        public void SetDirection(Vector3 direction)
        {
            m_direction = direction;
        }
        /// <summary>
        /// Gets the direction of the raycast.
        /// </summary>
        /// <returns>The direction of the raycast.</returns>
        public Vector3 GetDirection()
        {
            return m_direction;
        }


        /// <summary>
        /// Draws a raycast from the current transform's position in the forward direction with the default distance.
        /// </summary>
        public void Update()
        {

            m_origin = transform.position;
            DrawRayCast(m_origin, m_direction, m_distance);
            if (m_checkHit)
            {
                RaycastHit hit = EzRaycastHitter.ShootRaycast(m_origin, m_direction, m_distance);
                if (hit.collider != null)
                {
                    Debug.LogFormat("EzRayCastViewer: Hitted: {0} , Source: {1}", hit.collider.gameObject.name, gameObject.name);
                }
            }
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = m_rayColor;
            switch (m_rayType)
            {
                case RayCastType.Ray:
                    Gizmos.DrawRay(m_origin, m_direction * m_distance);
                    break;
                case RayCastType.Sphere:
                    Gizmos.DrawWireSphere(m_origin + m_direction * m_distance, 0.1f);
                    break;
                case RayCastType.Box:
                    Gizmos.DrawWireCube(m_origin + m_direction * m_distance, Vector3.one * 0.1f);
                    break;
                case RayCastType.Capsule:
                    Gizmos.DrawWireSphere(m_origin, 0.1f);
                    Gizmos.DrawWireSphere(m_origin + m_direction * m_distance, 0.1f);
                    break;
            }
        }

   
    }

}
