namespace UIAutomation.Core.Abstration
{
    public interface IGlobalProperties
    {
        void Configuration();
        string datasetlocation { get; set; }
        string downloadedlocation { get; set; }
        string browsertype { get; }
        bool stepscreenshot { get; set; }
        string gridhuburl { get; set; }
        string extentreportportalurl { get; set; }
        string loglevel { get; set; }
        bool extentreporttoportal { get; set; }


    }
}
