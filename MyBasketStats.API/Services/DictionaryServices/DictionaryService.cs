using System.Collections.Concurrent;

namespace MyBasketStats.API.Services.DictionaryServices
{
    public class DictionaryService : IDictionaryService
    {
        public ConcurrentDictionary<int, CancellationTokenSource> _gameClocks { get; } = new();
        public List<int> _startClockIds { get; set; } = new List<int>();
        public List<int> _stopClockIds { get; set; } = new List<int>();
    }
}
