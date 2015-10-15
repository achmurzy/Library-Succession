using Wisc.Flel.GeospatialModeling.RasterIO;

namespace Landis.Library.InitialCommunities
{
    public class Pixel
        : SingleBandPixel<ushort>
    {
        public Pixel()
            : base()
        {
        }

        //---------------------------------------------------------------------

        public Pixel(ushort band0)
            : base(band0)
        {
        }
    }
}
