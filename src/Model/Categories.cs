using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Money_App.Model
{
    public class Categories : IEnumerable<string>
    {
        private readonly List<string> list = new List<string>();

        public void Add(string category)
            => list.Add(category);

        public void Remove(string category)
            => list.Remove(category);

        public int Count()
            => list.Count();

        public string this[int index]
            => list[index];

        public IEnumerator<string> GetEnumerator()
            => list.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
    }
}
