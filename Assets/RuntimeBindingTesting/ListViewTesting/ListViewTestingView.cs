using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace RuntimeBindingTesting.ListViewTesting
{
    public class ListViewTestingView : MonoBehaviour
    {
        private UIDocument _uiDocument;
        private ListView _listView;
        private readonly ListViewTestingViewModel _viewModel = new();

        [SerializeField] private VisualTreeAsset templateAsset;

        private void Awake()
        {
            _uiDocument = GetComponent<UIDocument>();
        }

        private void Start()
        {
            _listView = _uiDocument.rootVisualElement.Q<ListView>();
            _listView.dataSource = _viewModel;
            _listView.bindItem += (element, index) => { element.Q<Label>().text = _viewModel.DataList[index].Label; };
            _listView.itemTemplate = templateAsset;

            _listView.SetBinding(
                bindingId: nameof(ListView.itemsSource),
                binding: new DataBinding()
                {
                    dataSourcePath = PropertyPath.FromName(nameof(ListViewTestingViewModel.DataList))
                }
            );
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                _viewModel.Add();
            }
        }
    }
}