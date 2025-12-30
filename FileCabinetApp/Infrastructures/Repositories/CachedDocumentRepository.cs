using FileCabinetApp.Core.Entities;
using FileCabinetApp.Core.Interfaces;

namespace FileCabinetApp.Infrastructures.Repositories
{
    public class CachedDocumentRepository : IDocumentRepository
    {

        private readonly IDocumentRepository _realRepository;
        private readonly Dictionary<string, CacheEntity> _cache = new Dictionary<string, CacheEntity>();

        private readonly Dictionary<Type, TimeSpan?> _cacheSettings;

        public CachedDocumentRepository(IDocumentRepository realRepository)
        {

            _realRepository = realRepository;

            _cacheSettings = new Dictionary<Type, TimeSpan?>
            {

                { typeof(Book), null },
                { typeof(Patent), TimeSpan.FromMinutes(30) },
                { typeof(Magazine), TimeSpan.Zero },

            };

        }

        public IEnumerable<DocumentCard> FindByNumber(string number)
        {

            if (_cache.ContainsKey(number))
            {

                var entity = _cache[number];
                if(!entity.IsExpired)
                {

                    Console.WriteLine($"[Cache Hit] Returning data for #{number} from memory.");
                    return entity.Data;

                }
                else
                {

                    Console.WriteLine($"[Cache Expired] entry for #{number} is too old.");
                    _cache.Remove(number);

                }

            }

            Console.WriteLine("[Cache Miss] Reading from File System...");
            var results = _realRepository.FindByNumber(number).ToList();

            if (results.Any())
            {
                TimeSpan? duration = GetCachedDurationForResults(results);

                if (duration != TimeSpan.Zero)
                {

                    _cache[number] = new CacheEntity(results, duration);

                }
            }

            return results;

        }

        private TimeSpan? GetCachedDurationForResults(List<DocumentCard> docs)
        {

            TimeSpan? minDuration = null;

            foreach (var doc in docs)
            {

                Type t = doc.GetType();

                TimeSpan? typeDuration = _cacheSettings.ContainsKey(t) ? _cacheSettings[t] : TimeSpan.FromMinutes(5);

                if (typeDuration == TimeSpan.Zero)
                {

                    return TimeSpan.Zero;

                }

                if (typeDuration.HasValue)
                {

                    if (minDuration == null || typeDuration < minDuration)
                    {

                        minDuration = typeDuration;

                    }

                }

            }

            return minDuration;

        }

        private class CacheEntity
        {

            public IEnumerable<DocumentCard> Data { get; }
            public DateTime? ExpirationTime { get; }

            public CacheEntity(IEnumerable<DocumentCard> data, TimeSpan? duration)
            {
                Data = data;
                ExpirationTime = duration.HasValue ? DateTime.Now.Add(duration.Value) : null;
            }

            public bool IsExpired => ExpirationTime.HasValue && DateTime.Now > ExpirationTime;
        }

    }
}
