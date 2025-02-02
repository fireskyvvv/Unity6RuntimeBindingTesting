using System.Collections.Generic;
using System.Linq;
using RuntimeBindingTesting.Common;
using Unity.Properties;

namespace RuntimeBindingTesting.ListViewTesting
{
    public class ListViewTestingViewModel : TestingViewModelBase<ListViewTestingViewModel>
    {
        public class Data
        {
            [CreateProperty] public string Label { get; }

            public Data(string label)
            {
                Label = label;
            }
        }

        [CreateProperty] public List<Data> DataList { get; private set; }

        public ListViewTestingViewModel()
        {
            DataList = new();
            DataList.Add(new Data(System.Guid.NewGuid().ToString()));
            DataList.Add(new Data(System.Guid.NewGuid().ToString()));
            DataList.Add(new Data(System.Guid.NewGuid().ToString()));
        }

        public void Add()
        {
            DataList.Add(new Data(System.Guid.NewGuid().ToString()));
            DataList = DataList.ToList();

            DebugLog($"New data added to List. Current count:{DataList.Count}");
        }
    }
}