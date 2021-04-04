using UnityEngine;

namespace Assets.Scripts.TrashGame
{
    public class TrashObject : MonoBehaviour
    {
        private new Camera camera;
        private void Start()
        {
            camera = Camera.main;
        }

        // The plane the object is currently being dragged on
        private Plane dragPlane;

        // The difference between where the mouse is on the drag plane and 
        // where the origin of the object is on the drag plane
        private Vector3 offset;
        private void OnMouseDown()
        {
            dragPlane = new Plane(camera.transform.forward, transform.position);
            Ray camRay = camera.ScreenPointToRay(Input.mousePosition);

            dragPlane.Raycast(camRay, out float planeDist);
            offset = transform.position - camRay.GetPoint(planeDist);
        }

        private void OnMouseDrag()
        {
            var camRay = camera.ScreenPointToRay(Input.mousePosition);
            dragPlane.Raycast(camRay, out float planeDist);
            transform.position = camRay.GetPoint(planeDist) + offset;
        }
    }
}
