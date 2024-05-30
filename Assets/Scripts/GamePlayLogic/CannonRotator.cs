using UnityEngine;

namespace GamePlayLogic
{
    public class CannonRotator : MonoBehaviour
    {
        [SerializeField] private Transform m_cannonHub;
    
        public void RotateCannon(Vector3 direction, float rotationSpeed)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            m_cannonHub.rotation = Quaternion.Slerp(m_cannonHub.rotation,targetRotation,rotationSpeed*Time.deltaTime);
        }
    }
}


