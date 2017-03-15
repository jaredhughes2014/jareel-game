using Jareel;
using UnityEngine;

namespace JareelUnity
{
    /// <summary>
    /// State subscriber which is conveniently posed to allow controlling the rendering
    /// of a view script.
    /// 
    /// Having multiple renderers work on the same view is supported if a view needs data
    /// from more than one state for rendering. However, you should consider reorganizing
    /// your state before choosing that route.
    /// 
    /// </summary>
    /// <typeparam name="S">The state type this renderer subscribes to</typeparam>
    /// <typeparam name="V"></typeparam>
    public abstract class ViewRenderer<S, V> : MonoStateSubscriber<S> where S : State where V : MonoBehaviour
    {
        /// <summary>
        /// Accesssor for the view component. By default, this just calls GetComponent
        /// on this object.
        /// </summary>
        protected virtual V View { get { return GetComponent<V>(); } }

        /// <summary>
        /// Overriden to redirect to an abstract render function
        /// </summary>
        /// <param name="newState">The state after a recent update</param>
        protected sealed override void OnStateChanged(S newState)
        {
            Render(newState, View);
        }

        protected abstract void Render(S state, V view);
    }
}