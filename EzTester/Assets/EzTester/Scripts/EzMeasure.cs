using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace EzTester
{
    /// <summary>
    /// Enum representing the display type of the distance indicator.
    /// </summary>
    public enum EzIndicatorDisplayType
    {
        DebugLine,
        TextInGame,
        Both
    }

    public class EzMeasure : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The first object to calculate the distance")]
        protected Transform m_object1;/**The first object to calculate the distance */

        [SerializeField]
        [Tooltip("The second object to calculate the distance")]
        protected Transform m_object2;/**The second object to calculate the distance */

        [Header("Distance Drawer")]
        [SerializeField]
        [Tooltip("Show the distance between the two objects")]
        protected bool m_showDistance = false;/**Show the distance between the two objects */

        [SerializeField]
        [Tooltip("The display type of the distance indicator")]
        protected EzIndicatorDisplayType m_displayType = EzIndicatorDisplayType.Both;/**The display type of the distance indicator */

        [Header("Text")]
        [SerializeField]
        [Tooltip("The font size of the distance text")]
        protected int m_distanceFontSize = 30;/**The font size of the distance text */

        [SerializeField]
        [Tooltip("The character size of the distance text")]
        protected float m_distanceCharacterSize = 0.1f;/**The character size of the distance text */

        [SerializeField]
        [Tooltip("The anchor of the distance text")]
        protected TextAnchor m_distanceAnchor = TextAnchor.MiddleCenter;/**The anchor of the distance text */

        [SerializeField]
        [Tooltip("The alignment of the distance text")]
        protected TextAlignment m_distanceAlignment = TextAlignment.Center;/**The alignment of the distance text */

        [SerializeField]
        [Tooltip("The font style of the distance text")]
        protected FontStyle m_distanceFontStyle = FontStyle.Bold;/**The font style of the distance text */

        [SerializeField]
        [Tooltip("Font of the distance text")]
        protected Font m_distanceFont;/**Font of the distance text */

        [Header("Colors")]
        [SerializeField]
        [Tooltip("The color of the distance line")]
        protected Color m_distanceColor = Color.red;/**The color of the distance line */

        [SerializeField]
        [Tooltip("The color of the distance text")]
        protected Color m_distanceTextColor = Color.white;/**The color of the distance text */

        protected GameObject m_distanceTextObject;/**The distance text object */
        protected virtual void Start()
        {
            if (m_object1 == null || m_object2 == null)
            {
                Debug.LogWarning("Object1 or Object2 is not set in the inspector");
            }
        }
        /// <summary>
        /// Calculates the distance between the two objects.
        /// </summary>
        /// <returns></returns>
        protected virtual float Calculate()
        {
            return 0;
        }
        /// <summary>
        /// Calculates the distance between the two objects.
        /// </summary>
        /// <param name="object1"></param>
        /// <param name="object2"></param>
        /// <returns></returns>
        public virtual float Calculate(Transform object1, Transform object2)
        {
            return 0;
        }

        protected void ShowDistanceText()
        {
            Vector3 middlePoint = (m_object1.position + m_object2.position) / 2;

            if (m_distanceTextObject == null)
            {
                m_distanceTextObject = new GameObject("DistanceText");
                m_distanceTextObject.AddComponent<TextMesh>();
            }
            else
            {
                m_distanceTextObject.transform.position = middlePoint;
            }

            TextMesh textMesh = m_distanceTextObject.GetComponent<TextMesh>();
            textMesh.color = m_distanceTextColor;
            textMesh.fontSize = m_distanceFontSize;
            textMesh.characterSize = m_distanceCharacterSize;
            textMesh.anchor = m_distanceAnchor;
            textMesh.alignment = m_distanceAlignment;
            textMesh.fontStyle = m_distanceFontStyle;
            textMesh.font = m_distanceFont;
            textMesh.text = Calculate().ToString("F2");
        }



        public virtual void ShowIndicators()
        {
            ShowDistanceText();

        }
        private void DebugLine()
        {
            Debug.Log("Calculation: " + Calculate().ToString("F2") + " units");
            Debug.DrawLine(m_object1.position, m_object2.position, m_distanceColor);
        }
        private void Update()
        {
            if (m_showDistance)
            {
                switch (m_displayType)
                {
                    case EzIndicatorDisplayType.DebugLine:
                        if (m_distanceTextObject != null)
                        {
                            Destroy(m_distanceTextObject);
                        }
                        DebugLine();
                        break;
                    case EzIndicatorDisplayType.TextInGame:
                        ShowIndicators();
                        break;
                    case EzIndicatorDisplayType.Both:
                        DebugLine();
                        ShowIndicators();
                        break;
                }
            }
        }
    }

}
