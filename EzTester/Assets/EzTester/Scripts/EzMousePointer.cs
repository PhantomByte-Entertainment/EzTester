using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
namespace EzTester
{
    /// <summary>
    /// This class is used to show a mouse pointer in the game world, This is useful when you want test colliders in the game world,
    /// without using specific objects, just only the mouse pointer.
    /// The attached object will follow the mouse pointer in the game world, it should have a collider attached to it.
    /// </summary>
    public class EzMousePointer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("The pointer object that will be used to show the mouse pointer")]
        private Mesh m_pointerMesh;/**The pointer object that will be used to show the mouse pointer */
        private GameObject m_pointerObject;/**The pointer object that will be used to show the mouse pointer */
        [SerializeField]
        [Tooltip("Show the pointer object in the game world")]
        private bool m_showPointer = false;/**Show the pointer object in the game world */

        [SerializeField]
        [Tooltip("The color of the pointer object")]
        private Color m_pointerColor = Color.red;/**The color of the pointer object */

        [Header("Physics")]
        [SerializeField]
        [Tooltip("Use collider for the pointer object")]
        private bool m_useCollider = true;/**Use collider for the pointer object */
        [SerializeField]
        [Tooltip("Use rigidbody for the pointer object")]
        private bool m_useRigidbody = true;/**Use rigidbody for the pointer object */

        [Header("Instructions")]
        [SerializeField]
        [Tooltip("Show instructions on the screen")]
        private bool m_showInstructions = false;/**Show instructions on the screen */

        private float m_pointerZ = 0;/**The z position of the pointer object */
        void Start()
        {
            Cursor.visible = m_showPointer;
            if (m_pointerMesh == null)
            {
                Debug.LogWarning("Pointer Mesh is not set in the inspector");
                //create a sphere if the pointer object is not set
                m_pointerObject = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                m_pointerObject.transform.localScale = new Vector3(1f, 1f, 1f);

            }
            else
            {
                m_pointerObject = Instantiate(new GameObject());
                m_pointerObject.AddComponent<MeshFilter>().mesh = m_pointerMesh;
                m_pointerObject.AddComponent<MeshRenderer>();
                if (m_useCollider)
                {
                    m_pointerObject.AddComponent<MeshCollider>();
                }
            }
            m_pointerObject.name = "Test Pointer Object";
            m_pointerObject.GetComponent<Renderer>().material.color = m_pointerColor;


            if (m_useRigidbody)
            {
                AddRigidbody();
            }
            m_pointerZ = Camera.main.WorldToScreenPoint(m_pointerObject.transform.position).z + 1;
        }
        // Update is called once per frame
        void Update()
        {
            if (m_pointerObject == null)
            {
                return;
            }

            if (!m_useCollider)
            {
                m_pointerObject.GetComponent<Collider>().enabled = false;
            }
            else
            {
                m_pointerObject.GetComponent<Collider>().enabled = true;
            }

            if (!m_useRigidbody)
            {
                Destroy(m_pointerObject.GetComponent<Rigidbody>());
            }
            else
            {

                AddRigidbody();

            }


            Vector3 mousePosition = Input.mousePosition;
            m_pointerZ += Input.mouseScrollDelta.y;
            mousePosition.z = m_pointerZ;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            m_pointerObject.transform.position = worldPosition;

        }
        /// <summary>
        /// Add a rigidbody to the pointer object
        /// </summary>
        private void AddRigidbody()
        {
            if (m_pointerObject.GetComponent<Rigidbody>() == null)
            {
                Rigidbody rb = m_pointerObject.AddComponent<Rigidbody>();
                rb.isKinematic = true;

            }
        }

        /// <summary>
        /// Show the instructions on the screen
        /// </summary>
        void OnGUI()
        {
            if (m_showInstructions)
            {
                GUI.Box(new Rect(0, 0, 500, 65), "Instructions");
                GUI.Label(new Rect(10, 15, 500, 20), "Use the mouse scroll to move the pointer object in the z-axis", GUI.skin.label);
                GUI.Label(new Rect(10, 35, 500, 20), "Use the mouse to move the pointer object in the x and y axis", GUI.skin.label);
            }


        }
    }


}
