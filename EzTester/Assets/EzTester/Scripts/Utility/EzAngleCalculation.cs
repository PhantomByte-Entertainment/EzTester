using System;
using System.Collections;
using System.Collections.Generic;
using EzTester;
using UnityEngine;

namespace EzUtility{
        enum EzAxis
        {
            X,
            Y,

        }
        /// <summary>
        /// Represents a class for calculating angles between two objects in a Unity scene.
        /// </summary>
        public class EzAngleCalculation : EzMeasure
        {
            private LineRenderer m_objectLineRenderer;
            private LineRenderer m_baseLineRenderer;
            private LineRenderer m_angleLineRenderer;
            private GameObject m_baseLineObject;
            private GameObject m_angleLineObject;
            [SerializeField]
            [Tooltip("Which axis to use for the angle calculation")]
            private EzAxis m_axis = EzAxis.Y;/**Which axis to use for the angle calculation */

            /// <summary>
            /// Gets the normal vector based on the specified base vector and object's transform.
            /// </summary>
            /// <param name="base1">The base vector.</param>
            /// <param name="obj1">The object's transform.</param>
            /// <returns>The normal vector.</returns>
            private Vector3 GetNormalVector(Vector3 base1, Transform obj1)
            {
                switch (m_axis)
                {
                    case EzAxis.X:
                        return Vector3.Cross(base1, obj1.up);
                    case EzAxis.Y:
                        return Vector3.Cross(base1, obj1.forward);
                }
                return Vector3.zero;
            }

            /// <summary>
            /// Computes the angle between two objects.
            /// </summary>
            /// <param name="obj1">The first object's transform.</param>
            /// <param name="obj2">The second object's transform.</param>
            /// <returns>The angle between the two objects.</returns>
            private float ComputeAngle(Transform obj1, Transform obj2)
            {
                Plane basePlane = new Plane(obj1.up, obj1.position);
                if (m_axis == EzAxis.X)
                {
                    basePlane = new Plane(obj1.right, obj1.position);
                }

                Vector3 object1Object2 = obj2.position - obj1.position;

                Vector3 inclinationNormal = GetNormalVector(object1Object2, obj1);
                if (inclinationNormal == Vector3.zero)
                {
                    Debug.LogWarning("The inclination normal is zero, the angle will be zero");
                    return 0;
                }
                Plane inclinatedPlane = new Plane(inclinationNormal, obj1.position);

                float angle = Vector3.Angle(basePlane.normal, inclinatedPlane.normal);
                switch (m_axis)
                {
                    case EzAxis.X:
                        if (obj2.position.x < obj1.position.x)
                        {
                            angle = -angle;
                        }
                        break;
                    case EzAxis.Y:
                        if (obj2.position.y < obj1.position.y)
                        {
                            angle = -angle;
                        }
                        break;
                }

                return angle;
            }

            /// <summary>
            /// Calculates the angle between the two objects.
            /// </summary>
            /// <returns>The calculated angle.</returns>
            protected override float Calculate()
            {
                return ComputeAngle(m_object1, m_object2);
            }

            /// <summary>
            /// Calculates the angle between the specified objects.
            /// </summary>
            /// <param name="object1">The first object's transform.</param>
            /// <param name="object2">The second object's transform.</param>
            /// <returns>The calculated angle.</returns>
            public override float Calculate(Transform object1, Transform object2)
            {
                return ComputeAngle(object1, object2);
            }

            /// <summary>
            /// Creates a line renderer with the specified positions.
            /// </summary>
            /// <param name="positionA">The starting position of the line.</param>
            /// <param name="positionB">The ending position of the line.</param>
            /// <param name="lineRenderer">The line renderer component.</param>
            private void CreateLine(Vector3 positionA, Vector3 positionB, LineRenderer lineRenderer)
            {
                lineRenderer.positionCount = 2;
                lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
                lineRenderer.startColor = m_distanceColor;
                lineRenderer.endColor = m_distanceColor;
                lineRenderer.startWidth = 0.1f;
                lineRenderer.endWidth = 0.1f;

                lineRenderer.SetPosition(0, positionA);
                lineRenderer.SetPosition(1, positionB);
            }

            /// <summary>
            /// Initializes the EzAngleCalculation component.
            /// </summary>
            protected override void Start()
            {
                base.Start();
                m_baseLineObject = new GameObject("BaseLine");
                m_angleLineObject = new GameObject("AngleLine");
                m_unit = "°";
            }
        }
    }

  

