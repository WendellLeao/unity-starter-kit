using UnityEngine;

namespace WendellLeao.StarterKit.Extensions
{
    public static class GameObjectExtensions
    {
        public static string GetRootName(this GameObject gameObject)
        {
            Transform gameObjectTransform = gameObject.transform;

            return gameObjectTransform.GetRootName();
        }
    }
}
