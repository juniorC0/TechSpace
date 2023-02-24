using AutoMapper;

public interface IAsyncValueResolver<in TSource, TDestination, TResult>
{
    Task<TResult> ResolveAsync(TSource source, TDestination destination, ResolutionContext context);
}
