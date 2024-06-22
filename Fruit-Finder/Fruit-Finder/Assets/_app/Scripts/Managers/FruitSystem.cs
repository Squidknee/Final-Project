using UnityEngine;

namespace _app.Scripts.Managers
{
    public class FruitSystem : MonoBehaviour
    {
        private int _amount;
        private int _wallet;
        private int _bank;

        private void OnEnable()
        {
            DelegateManager.fruitEvent += OnAmount;
        }

        private void OnDisable()
        {
            DelegateManager.fruitEvent -= OnAmount; 
        }

        public void OnAmount()
        {
            Debug.Log("something will happen here hopefully");
        }
    }
}