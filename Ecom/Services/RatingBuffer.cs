using DB.IRepos;
using DB.Models;
using DB.UOW;

namespace Ecom.Services
{
    public interface IRatingBuffer
    {
        public void AddRating(Rating rating,IProductRepo productRepo);
    }
    public class RatingBuffer : IRatingBuffer
    {
        /**
         * ProductId -> (Count,RatingSum
         */
        private readonly IDictionary<long,(long,long)> _buffer;
        public RatingBuffer()
        {
            _buffer = new Dictionary<long, (long, long)>();
        }
        public void AddRating(Rating rating,IProductRepo productRepo)
        {
            if (_buffer.Count > 10000)
            {
                foreach (var entry in _buffer)
                {
                    var (c, s) = entry.Value;
                    productRepo.UpdateRating(entry.Key, c, s, message);
                }
                _buffer.Clear();
            }
            else
            {
                if (_buffer.ContainsKey(rating.ProductId))
                {
                    var (count,rSum) = _buffer[rating.ProductId];
                    _buffer[rating.ProductId] = (count+1,rSum + rating.Rate);
                }
                else
                {
                    _buffer.Add(rating.ProductId, (1, rating.Rate));
                }
            }
        }
    }
}
