using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ssm.ui
{
    public interface IUIAnimationInterface
    {
        public void OnAnimationStart(int index);
        public void OnAnimationFinish(int index);
        public void OnAnimationUpdate(int index, float progress);
    }
}