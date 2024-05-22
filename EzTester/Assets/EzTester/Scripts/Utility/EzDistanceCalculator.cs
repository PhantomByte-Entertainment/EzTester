using UnityEngine;

namespace EzUtility
{
    /// <summary>
    /// Namespace containing classes related to distance calculation in the game world.
    /// </summary>
    namespace DistanceCalculation
    {

        /// <summary>
        /// Class used to calculate the distance between two objects in the game world.
        /// </summary>
        public class EzDistanceCalculator : EzMeasure
        {
            /// <summary>
            /// Calculates the distance between the two objects. 
            /// </summary>
            /// <returns></returns>
            protected override float Calculate()
            {
                return Vector3.Distance(m_object1.position, m_object2.position);
            }
            /// <summary>
            /// Calculates the distance between the two objects provided as parameters.
            /// <param name="object1">The first object.</param>
            /// <param name="object2">The second object.</param>
            /// </summary>

            public override float Calculate(Transform object1, Transform object2)
            {
                return Vector3.Distance(object1.position, object2.position);
            }

            private void ShowDistanceLine()
            {
                Vector3 middlePoint = (m_object1.position + m_object2.position) / 2;

                if (m_distanceTextObject == null)
                {
                    m_distanceTextObject = new GameObject("DistanceLine");
                    m_distanceTextObject.AddComponent<LineRenderer>();
                }

                LineRenderer lineRenderer = m_distanceTextObject.GetComponent<LineRenderer>();

                if (lineRenderer == null)
                {
                    lineRenderer = m_distanceTextObject.AddComponent<LineRenderer>();
                }
                else
                {
                    m_distanceTextObject.transform.position = middlePoint;
                }

                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = m_distanceColor;
                lineRenderer.endColor = m_distanceColor;
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;
                lineRenderer.SetPosition(0, m_object1.position);
                lineRenderer.SetPosition(1, m_object2.position);
            }
            public override void ShowIndicators()
            {
                base.ShowIndicators();
                ShowDistanceLine();
            }
        }
    }
}
