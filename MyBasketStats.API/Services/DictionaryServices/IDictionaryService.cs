using System.Collections.Concurrent;

namespace MyBasketStats.API.Services.DictionaryServices
{
    public interface IDictionaryService
    {
        ConcurrentDictionary<int, CancellationTokenSource> _gameClocks { get; }
        List<int> _startClockIds { get; set; }
        List<int> _stopClockIds { get; set; }
    }
}
