using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Helpers
{
    public class CoroutineHelper
    {
        public Coroutine coroutine { get; private set; }
        public object result;
        private IEnumerator target;

        public CoroutineHelper(MonoBehaviour owner, IEnumerator target)
        {
            this.target = target;
            this.coroutine = owner.StartCoroutine(Run());
        }

        private IEnumerator Run()
        {
            while (target.MoveNext())
            {
                result = target.Current;
                yield return result;
            }
        }
    }
}
