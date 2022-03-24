using System.Windows.Input;

namespace DemoProject.ViewModels;

public class XamlBoundViewModel : BaseViewModel
{
    private readonly INameService _nameService;

    public string Name { get; set; }

    public ICommand UpdateNameCommand => new Command(() => UpdateName());

    public static Type ViewModelType
    {
        get { return typeof(XamlBoundViewModel); }
    }

    public XamlBoundViewModel(INameService nameService)
    {
        _nameService = nameService;
    }

    void UpdateName()
    {
        Name = _nameService.GetName();

        OnPropertChanged(nameof(Name));
    }
}
