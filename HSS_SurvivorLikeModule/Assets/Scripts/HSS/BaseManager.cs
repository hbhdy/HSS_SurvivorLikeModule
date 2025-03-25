//using Cysharp.Threading.Tasks;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace HSS
{
    public class BaseManager : MonoBehaviour
    {
        protected bool isReady = false;

        /// <summary>
        /// �Ŵ��� �ʱ�ȭ
        /// </summary>
        public virtual IEnumerator Co_Init()
        {
            yield return null;

            HSSLog.Log($"{gameObject.name} is Ready");
            isReady = true;
        }

        //public virtual async UniTask Task_Init()
        //{
        //    await UniTask.Yield();

        //    HSSLog.Log($"{gameObject.name} is Ready");
        //    isReady = true;
        //}

        /// <summary>
        /// �ʱ�ȭ
        /// </summary>
        public virtual void Init()
        {

        }
    }
}