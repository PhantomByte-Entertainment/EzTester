using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Utility namespace for performing raycasts in Unity.
/// </summary>
/// namespace EzUtility{
/// <summary>
/// Utility class for performing raycasts in Unity.
/// </summary>
public class EzRaycastHitter : MonoBehaviour
{
    /// <summary>
    /// Performs a raycast from the specified origin in the specified direction with the given distance.
    /// </summary>
    /// <param name="origin">The starting point of the raycast.</param>
    /// <param name="direction">The direction of the raycast.</param>
    /// <param name="distance">The maximum distance the raycast can travel.</param>
    /// <returns>The RaycastHit result of the raycast.</returns>
    public static RaycastHit ShootRaycast(Vector3 origin, Vector3 direction, float distance)
    {
        RaycastHit hit;
        Physics.Raycast(origin, direction, out hit, distance);
        return hit;
    }

    /// <summary>
    /// Performs a raycast from the specified origin in the specified direction with the given distance.
    /// </summary>
    /// <param name="origin">The starting point of the raycast.</param>
    /// <param name="direction">The direction of the raycast.</param>
    /// <param name="distance">The maximum distance the raycast can travel.</param>
    /// <param name="layerMask">A LayerMask that is used to selectively ignore colliders when performing a raycast.</param>
    /// <returns>The RaycastHit result of the raycast.</returns>

    public static RaycastHit ShootRaycast(Vector3 origin, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.Raycast(origin, direction, out hit, distance, layerMask);
        return hit;
    }

    /// <summary>
    /// Performs a raycast passed as parameter and returns the RaycastHit result.
    /// </summary>
    /// <param name="ray">The Ray object representing the raycast.</param>
    /// <returns>The RaycastHit result of the raycast.</returns>
    public static RaycastHit ShootRaycast(Ray ray)
    {
        RaycastHit hit;
        Physics.Raycast(ray, out hit);
        return hit;
    }

    /// <summary>
    /// Shoots a raycast from the specified origin with the given direction and distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootSphereCast(Vector3 origin, float radius, Vector3 direction, float distance)
    {
        RaycastHit hit;
        Physics.SphereCast(origin, radius, direction, out hit, distance);
        return hit;
    }
    /// <summary>
    /// Shoots a sphere cast from the specified origin with the given radius, direction, distance, and layer mask.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit ShootSphereCast(Vector3 origin, float radius, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.SphereCast(origin, radius, direction, out hit, distance, layerMask);
        return hit;
    }
    /// <summary>
    /// Shoots a sphere cast from the specified ray with the given radius and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="radius"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootSphereCast(Ray ray, float radius, float distance)
    {
        RaycastHit hit;
        Physics.SphereCast(ray, radius, out hit, distance);
        return hit;
    }

    /// <summary>
    /// Shoots a box cast from the specified origin with the given half extents, direction, orientation, and distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="halfExtents"></param>
    /// <param name="direction"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootBoxCast(Vector3 origin, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance)
    {
        RaycastHit hit;
        Physics.BoxCast(origin, halfExtents, direction, out hit, orientation, distance);
        return hit;
    }
    /// <summary>
    /// Shoots a box cast from the specified origin with the given half extents, direction, orientation, and distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="halfExtents"></param>
    /// <param name="direction"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit ShootBoxCast(Vector3 origin, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.BoxCast(origin, halfExtents, direction, out hit, orientation, distance, layerMask);
        return hit;
    }
    /// <summary>
    /// Shoots a box cast from the specified ray with the given half extents, orientation, and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="halfExtents"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootBoxCast(Ray ray, Vector3 halfExtents, Quaternion orientation, float distance)
    {
        RaycastHit hit;
        Physics.BoxCast(ray.origin, halfExtents, ray.direction, out hit, orientation, distance);
        return hit;
    }

    /// <summary>
    /// Shoots a capsule cast from the specified points with the given radius, direction, distance.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootCapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance)
    {
        RaycastHit hit;
        Physics.CapsuleCast(point1, point2, radius, direction, out hit, distance);
        return hit;
    }
    /// <summary>
    /// Shoots a capsule cast from the specified points with the given radius, direction, distance, and layer mask.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit ShootCapsuleCast(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit hit;
        Physics.CapsuleCast(point1, point2, radius, direction, out hit, distance, layerMask);
        return hit;
    }
    /// <summary>
    /// Shoots a capsule cast from the specified ray with the given radius and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="radius"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit ShootCapsuleCast(Ray ray, float radius, float distance)
    {
        RaycastHit hit;
        Physics.CapsuleCast(ray.origin, ray.origin, radius, ray.direction, out hit, distance);
        return hit;
    }

    /// <summary>
    /// Shoots a raycast from the specified origin with the given direction and distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootRaycastAll(Vector3 origin, Vector3 direction, float distance)
    {
        RaycastHit[] hits = Physics.RaycastAll(origin, direction, distance);
        return hits;
    }
    /// <summary>
    ///     
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootRaycastAll(Vector3 origin, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit[] hits = Physics.RaycastAll(origin, direction, distance, layerMask);
        return hits;
    }
    /// <summary>
    /// Shoots a raycast from the specified ray with the given distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootRaycastAll(Ray ray, float distance)
    {
        RaycastHit[] hits = Physics.RaycastAll(ray, distance);
        return hits;
    }

    /// <summary>
    /// Shoots a sphere cast from the specified origin with the given radius, direction, distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootSphereCastAll(Vector3 origin, float radius, Vector3 direction, float distance)
    {
        RaycastHit[] hits = Physics.SphereCastAll(origin, radius, direction, distance);
        return hits;
    }
    /// <summary>
    /// Shoots a sphere cast from the specified origin with the given radius, direction, distance, and layer mask.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootSphereCastAll(Vector3 origin, float radius, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit[] hits = Physics.SphereCastAll(origin, radius, direction, distance, layerMask);
        return hits;
    }
    /// <summary>
    /// Shoots a sphere cast from the specified ray with the given radius and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="radius"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootSphereCastAll(Ray ray, float radius, float distance)
    {
        RaycastHit[] hits = Physics.SphereCastAll(ray, radius, distance);
        return hits;
    }

    /// <summary>
    /// Shoots a box cast from the specified origin with the given half extents, direction, orientation, and distance.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="halfExtents"></param>
    /// <param name="direction"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootBoxCastAll(Vector3 origin, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance)
    {
        RaycastHit[] hits = Physics.BoxCastAll(origin, halfExtents, direction, orientation, distance);
        return hits;
    }
    /// <summary>
    /// Shoots a box cast from the specified origin with the given half extents, direction, orientation, distance, and layer mask.
    /// </summary>
    /// <param name="origin"></param>
    /// <param name="halfExtents"></param>
    /// <param name="direction"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootBoxCastAll(Vector3 origin, Vector3 halfExtents, Vector3 direction, Quaternion orientation, float distance, LayerMask layerMask)
    {
        RaycastHit[] hits = Physics.BoxCastAll(origin, halfExtents, direction, orientation, distance, layerMask);
        return hits;
    }
    /// <summary>
    /// Shoots a box cast from the specified ray with the given half extents, orientation, and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="halfExtents"></param>
    /// <param name="orientation"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootBoxCastAll(Ray ray, Vector3 halfExtents, Quaternion orientation, float distance)
    {
        RaycastHit[] hits = Physics.BoxCastAll(ray.origin, halfExtents, ray.direction, orientation, distance);
        return hits;
    }
    /// <summary>
    /// Shoots a capsule cast from the specified points with the given radius, direction, distance.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <returns></returns>

    public static RaycastHit[] ShootCapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance)
    {
        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, direction, distance);
        return hits;
    }
    /// <summary>
    /// Shoots a capsule cast from the specified points with the given radius, direction, distance, and layer mask.
    /// </summary>
    /// <param name="point1"></param>
    /// <param name="point2"></param>
    /// <param name="radius"></param>
    /// <param name="direction"></param>
    /// <param name="distance"></param>
    /// <param name="layerMask"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootCapsuleCastAll(Vector3 point1, Vector3 point2, float radius, Vector3 direction, float distance, LayerMask layerMask)
    {
        RaycastHit[] hits = Physics.CapsuleCastAll(point1, point2, radius, direction, distance, layerMask);
        return hits;
    }
    /// <summary>
    /// Shoots a capsule cast from the specified ray with the given radius and distance.
    /// </summary>
    /// <param name="ray"></param>
    /// <param name="radius"></param>
    /// <param name="distance"></param>
    /// <returns></returns>
    public static RaycastHit[] ShootCapsuleCastAll(Ray ray, float radius, float distance)
    {
        RaycastHit[] hits = Physics.CapsuleCastAll(ray.origin, ray.origin, radius, ray.direction, distance);
        return hits;
    }


}
