namespace HybridView.UWP
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            //SetIoC();
            InitializeComponent();

            LoadApplication(new global::HybridView.App());
        }

        //private void SetIoC()
        //{
        //    var resolverContainer = new SimpleContainer();

        //    resolverContainer.Register(t => WindowsDevice.CurrentDevice);
        //    resolverContainer.Register<IJsonSerializer, XLabs.Serialization.JsonNET.JsonSerializer>();
        //    resolverContainer.Register<IDependencyContainer>(resolverContainer);
        //    resolverContainer.Register<IFilePath>(t => new FilePath());

        //    Resolver.SetResolver(resolverContainer.GetResolver());
        //}
    }
}