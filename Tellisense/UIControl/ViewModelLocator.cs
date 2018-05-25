using Tellisense.Core;

namespace Tellisense
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel AppVM => IOC.Get<ApplicationViewModel>();
    }
}
