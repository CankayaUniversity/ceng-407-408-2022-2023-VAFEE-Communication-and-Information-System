namespace Api.Application.Extensions;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> SelectRandom<T>(this IEnumerable<T> source, int count) where T : class
    {
        var random = new Random();
        var result = new List<T>();
        var selectedIndexes = new int[source.Count()];

        
        for (int i = 0; i < count;)
        {
            // Choose random elements from source, dont choose the same element twice
            var index = random.Next(0, source.Count());
            if (!selectedIndexes.Contains(index))
            {
                result.Add(source.ElementAt(index));
                selectedIndexes[i++] = index;
            }
                
            
        }

        return result;
    }
}