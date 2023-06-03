using UnityEngine;

namespace Scripts
{
    public class FollowPlayer : MonoBehaviour
    {
        void Update()
        {
            var cameraTransform = Camera.current?.transform?.position;
            if (cameraTransform.HasValue)
            {
                transform.LookAt(cameraTransform.Value);
            }
        }
    }
}
