using UnityEngine;

namespace _app.Scripts.Managers
{
    public class DelegateManager : MonoBehaviour
    {
        public delegate void eventDelegate();

        public static eventDelegate fruitEvent;
    }
}