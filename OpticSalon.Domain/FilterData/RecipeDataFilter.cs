using OpticSalon.Domain.Consts;

namespace OpticSalon.Domain.FilterData
{
    public static class RecipeDataFilter
    {
        public static List<double> GetSphRange()
        {
            return Range(RecipeDataConsts.MinSph, RecipeDataConsts.MaxSph, 0.25).ToList();
        }

        public static List<double> GetCylRange()
        {
            return Range(RecipeDataConsts.MinCyl, RecipeDataConsts.MaxCyl, 0.25).ToList();
        }

        public static List<int> GetAxisRange()
        {
            return Range(RecipeDataConsts.MinAxis, RecipeDataConsts.MaxAxis)
                    .Select(x => Convert.ToInt32(x)).ToList();
        }

        public static List<int> GetDpRange()
        {
            return Range(RecipeDataConsts.MinDp, RecipeDataConsts.MaxDp)
                    .Select(x => Convert.ToInt32(x)).ToList();
        }

        public static List<double> Range(double start, double stop, double step = 1)
        {
            if (step == 0)
                return new List<double>();

            return RangeIterator(start, stop, step);
        }

        private static List<double> RangeIterator(double start, double stop, double step)
        {
            double x = start;
            var result = new List<double>();

            while (x <= stop)
            {
                result.Add(x);
                x += step;
            }

            return result;
        }
    }
}
