using System.Collections.Concurrent;

namespace MyBasketStats.API.Services.DictionaryServices
{
    public class DictionaryService : IDictionaryService
    {
        public ConcurrentDictionary<int, CancellationTokenSource> _gameClocks { get; } = new();
    }
}
