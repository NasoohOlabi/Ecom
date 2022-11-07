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
        private DateTime _nextFlush;
        public RatingBuffer()
        {
            _nextFlush = DateTime.UtcNow.Add(new TimeSpan(1,0,0));
            _buffer = new Dictionary<long, (long, long)>();
        }
        private bool FlushTime { get { 
            return DateTime.UtcNow.CompareTo(_nextFlush) > 0; 
            }  }
        private DateTime HourFromNow { get {
                return DateTime.UtcNow.AddHours(1);
            } }
        public void AddRating(Rating rating,IProductRepo productRepo)
        {
            if (_buffer.Count > 10000|| FlushTime)
            {
                foreach (var entry in _buffer)
                {
                    var (c, s) = entry.Value;
                    productRepo.UpdateRating(entry.Key, c, s);
                }
                _buffer.Clear();
                _nextFlush = HourFromNow;
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
