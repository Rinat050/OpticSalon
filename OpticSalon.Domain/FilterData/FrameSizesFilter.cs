using OpticSalon.Domain.Consts;

namespace OpticSalon.Domain.FilterData
{
    public static class FrameSizesFilter
    {
        public static List<int> GetLensWidthRange()
        {
            return GetRange(FrameSizesConsts.MinLensWidth, FrameSizesConsts.MaxLensWidth);
        }

        public static List<int> GetDistanceBetweenLensRange()
        {
            return GetRange(FrameSizesConsts.MinDistanceBetweenLens, FrameSizesConsts.MaxDistanceBetweenLens);
        }

        public static List<int> GetTempleLenghtRange()
        {
            return GetRange(FrameSizesConsts.MinTempleLenght, FrameSizesConsts.MaxTempleLenght);
        }

        private static List<int> GetRange(int start, int end)
        {
            return Enumerable.Range(start, end - start + 1)
                            .ToList();
        }
    }
}
