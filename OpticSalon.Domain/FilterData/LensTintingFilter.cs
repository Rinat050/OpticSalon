
using OpticSalon.Domain.Consts;

namespace OpticSalon.Domain.FilterData
{
    public static class LensTintingFilter
    {
        public static List<int> GetLensTintingRange()
        {
            return Range(LensTintingConsts.MinTintingPercent, LensTintingConsts.MaxTintingPercent, 10);
        }

        public static List<int> Range(int start, int stop, int step = 1)
        {
            if (step == 0)
                return new List<int>();

            return RangeIterator(start, stop, step);
        }

        private static List<int> RangeIterator(int start, int stop, int step)
        {
            int x = start;
            var result = new List<int>();

            while (x <= stop)
            {
                result.Add(x);
                x += step;
            }

            return result;
        }
    }
}
