using System;
using System.Collections.Generic;

namespace NewInCSharp7.LocalFunctions
{
    // Separating LocalFunctionsDemo in parameter validation and a separate iterator method has some advantages.
    // In this version the caller will observe an exception when LocalFunctionsDemo is called.
    // Without separation in two methods, the caller will only observe an exception later,
    // when the iterator is iterated.
    // A similar advantage is observer on asynchronous methods where separating parameter validation from
    // the asynchronous part has a similar effect.
    public class LocalFunctions
    {
        public IEnumerable<int> LocalFunctionsDemo(IEnumerable<int> first, IEnumerable<int> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));

            if (second == null) throw new ArgumentNullException(nameof(second));

            return SumCollectionsImpl();

            IEnumerable<int> SumCollectionsImpl()
            {
                IEnumerator<int> e1 = first.GetEnumerator();
                IEnumerator<int> e2 = second.GetEnumerator();

                while (e1.MoveNext() && e2.MoveNext())
                {
                    yield return e1.Current + e2.Current;
                }
            }
        }

        public IEnumerable<int> LocalFunctionsDemo2(IEnumerable<int> first, IEnumerable<int> second)
        {
            if (first == null) throw new ArgumentNullException(nameof(first));

            if (second == null) throw new ArgumentNullException(nameof(second));

            IEnumerator<int> e1 = first.GetEnumerator();
            IEnumerator<int> e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current + e2.Current;
            }
        }

        public IEnumerable<int> SumCollections(IEnumerable<int> first, IEnumerable<int> second)
        {
            if (first == null)
                throw new ArgumentNullException(nameof(first));
            if (second == null)
                throw new ArgumentNullException(nameof(second));

            return SumCollectionsImpl(first, second);
        }

        public IEnumerable<int> SumCollectionsImpl(IEnumerable<int> first, IEnumerable<int> second)
        {
            IEnumerator<int> e1 = first.GetEnumerator();
            IEnumerator<int> e2 = second.GetEnumerator();

            while (e1.MoveNext() && e2.MoveNext())
            {
                yield return e1.Current + e2.Current;
            }
        }
    }
}
