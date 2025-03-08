using UnityEngine;

namespace Action3rd
{
    /// <summary>
    ///     单例组件父类
    /// </summary>
    /// <typeparam name="T">单例子类</typeparam>
    public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
    {
        /// <summary>
        ///     唯一实例
        /// </summary>
        public static T Instance { get; protected set; }

        /// <summary>
        ///     检查唯一实例是否存在
        /// </summary>
        public static bool InstanceExists => Instance != null;

        /// <summary>
        ///     Awake(构造)函数将单例与实例关联
        /// </summary>
        protected virtual void Awake()
        {
            if (InstanceExists)
            {
                Destroy(gameObject);
            }
            else
            {
                Instance = (T)this;
            }
        }

        /// <summary>
        ///     将唯一实例清除
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
    }
}