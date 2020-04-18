using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;

namespace Prism.Test.Extensions
{
    public static class ObservableExtensions
    {
        public static IObservable<T> ThrottleFirst<T>(this IObservable<T> source, TimeSpan delay, IScheduler scheduler)
        {
            return source.Publish(o => o.Take(1)
                .Concat(o.IgnoreElements().TakeUntil(Observable.Return(default(T)).Delay(delay, scheduler)))
                .Repeat()
                .TakeUntil(o.IgnoreElements().Concat(Observable.Return(default(T)))));
        }

        public static IDisposable SubscribeAsync<T>(this IObservable<T> source, Func<T, Task> onNext, Action<Exception> onError = null, Action onCompleted = null)
        {
            if (onError == null)
            {
                onError = ex => { };
            }

            if (onCompleted == null)
            {
                onCompleted = () => { };
            }

            return source.Select(e => Observable.Defer(() => onNext(e).ToObservable())).Concat()
                .Subscribe(
                    e => { }, // empty
                    onError,
                    onCompleted);
        }

        public static void DisposeWith(this IDisposable disposable, IList<IDisposable> disposables)
        {
            disposables.Add(disposable);
        }

        /// <summary>
        /// Dispose all objects in the list and clears it
        /// </summary>
        /// <param name="disposables"></param>
        public static void DisposeAll(this IList<IDisposable> disposables)
        {
            foreach (var disposable in disposables)
            {
                disposable.Dispose();
            }
            disposables.Clear();
        }
    }
}
