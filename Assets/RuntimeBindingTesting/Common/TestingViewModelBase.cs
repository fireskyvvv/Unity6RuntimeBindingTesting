namespace RuntimeBindingTesting.Common
{
    public abstract class TestingViewModelBase<T> where T : TestingViewModelBase<T>
    {
        protected void DebugLog(string log)
        {
            UnityEngine.Debug.Log($"[{typeof(T).Name}] {log}");
        }
    }
}