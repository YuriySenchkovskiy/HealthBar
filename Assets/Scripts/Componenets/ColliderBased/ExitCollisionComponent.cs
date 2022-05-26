using UnityEngine;

namespace Scriptes.Components.ColliderBased
{
    public class ExitCollisionComponent : MonoBehaviour
    {
        [SerializeField] private string _tag;
        [SerializeField] private EnterEventComponent _action; 
        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.gameObject.CompareTag(_tag)) 
            {
                _action?.Invoke(other.gameObject); 
            }
        }
    }
}