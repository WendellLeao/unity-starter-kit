using UnityEngine;

namespace WendellLeao.StarterKit
{
    public sealed class PersistentObject : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
