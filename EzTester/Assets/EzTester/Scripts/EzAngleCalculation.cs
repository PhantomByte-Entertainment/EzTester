using System;
using System.Collections;
using System.Collections.Generic;
using EzTester;
using UnityEngine;
namespace EzTester
{

    enum EzAxis
    {
        X,
        Y,

    }
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
        protected override float Calculate()
        {
            return ComputeAngle(m_object1, m_object2);

        }
        public override float Calculate(Transform object1, Transform object2)
        {
            return ComputeAngle(object1, object2);
        }

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
        protected override void Start()
        {
            base.Start();
            m_baseLineObject = new GameObject("BaseLine");
            m_angleLineObject = new GameObject("AngleLine");

        }
        private void ShowAngleAmplitude()
        {

            if (m_angleLineRenderer == null)
            {
                m_angleLineRenderer = m_angleLineObject.AddComponent<LineRenderer>();
                CreateLine(m_object1.position, m_object2.position, m_angleLineRenderer);
            }
            else
            {
                List<Vector3> anglePoints = new List<Vector3>();
                float objectsAngle = Calculate();
                if (objectsAngle < 0)
                {
                    objectsAngle = 360 + objectsAngle;
                }
                //get the point in front of object1 that follow the direction object1 to object2
                for (int i = 0; i < objectsAngle; i++)
                {
                    Vector3 direction = m_object2.position - m_object1.position;
                    
                    Vector3 point = m_object1.position + Quaternion.Euler(0, 0, i) * direction.normalized;
                    if(m_axis == EzAxis.X)
                    {
                        point = m_object1.position + Quaternion.Euler(0, i, 0) * direction.normalized;
                    }
                    anglePoints.Add(point);
                }
      
  
                m_angleLineRenderer.positionCount = anglePoints.Count;
                m_angleLineRenderer.SetPositions(anglePoints.ToArray());

            }



        }
        private void ShowAngleLine()
        {

            Vector3 object2Projected = new Vector3(m_object2.position.x, m_object1.position.y, m_object2.position.z);
            if (m_axis == EzAxis.X)
            {
                object2Projected = new Vector3(m_object1.position.x, m_object2.position.y, m_object1.position.z - 5);
            }

            if (m_baseLineRenderer == null)
            {
                m_baseLineRenderer = m_baseLineObject.AddComponent<LineRenderer>();

                CreateLine(m_object1.position, object2Projected, m_baseLineRenderer);
            }
            else
            {

                m_baseLineRenderer.SetPosition(0, m_object1.position);
                m_baseLineRenderer.SetPosition(1, object2Projected);
            }



            if (m_objectLineRenderer == null)
            {
                m_objectLineRenderer = m_distanceTextObject.AddComponent<LineRenderer>();
                CreateLine(m_object1.position, m_object2.position, m_objectLineRenderer);
            }
            else
            {
                m_objectLineRenderer.SetPosition(0, m_object1.position);
                m_objectLineRenderer.SetPosition(1, m_object2.position);
            }


        }
        public override void ShowIndicators()
        {
            base.ShowIndicators();
            ShowAngleLine();
            ShowAngleAmplitude();
        }
    }
}

