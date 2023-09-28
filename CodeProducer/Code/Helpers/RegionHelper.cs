using Utte.Code.Code.SupportClasses;

namespace Utte.Code.Code.Helpers
{
    public static class RegionHelper
    {

        public static void ProduceRegionStart(this CodeWriter codeWriter, string text)
        {
            if (Settings.Default.UseRegions)
            {
                codeWriter.WriteLine("#region " + text, true);
                codeWriter.WriteLine("");
            }
        }

        public static void ProduceRegionEnd(this CodeWriter codeWriter)
        {
            if (Settings.Default.UseRegions)
            {
                codeWriter.WriteLine("#endregion", true);
                codeWriter.WriteLine("");
            }
        }
    }
}
