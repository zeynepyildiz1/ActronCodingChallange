
using ActronCodingChallange.Business.Interfaces;

namespace ActronCodingChallange.Business.Services
{
    public class FindMaxNumber : IFindMaxNumber
    {
     string IFindMaxNumber.FindMaxNumber(List<int> list)
        {
            list.Sort((x, y) =>
            {
                string xy = x.ToString() + y.ToString();
                string yx = y.ToString() + x.ToString();
                return yx.CompareTo(xy);
            });

            return string.Join("", list);
        }
    }
}