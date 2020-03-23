using System.Threading.Tasks;
using NewInCSharp7.Deconstructing;

namespace NewInCSharp7.Discards
{
    public class Discards
    {
        public void DiscardsAndSwitch(object item)
        {
            switch (item)
            {
                case int _:
                    // We do something when item is int but don't care about the actual value
                    break;

                case Person _:
                    // We do something when item is a Person but don't care about the actual value
                    break;
            }
        }

        public void DiscardsAndIs(object item)
        {
            if (item is int _)
            {
                // We do something when item is int but don't care about the actual value
            }
            else if (item is Person _)
            {
                // We do something when item is a Person but don't care about the actual value
            }
        }

        public void DiscardAndOutParameters(string text)
        {
            if (int.TryParse(text, out int _))
            {
                // We only care that "text" contains a valid integer, we don't care about its value.
            }

            // We can use multiple discards in the same scope.
            if (TryGetInfo(out var _, out var _))
            {
                // We only care that we were able to get the info and not what the info was.
            }
        }

        public async Task DiscardAsStandalone()
        {
            // Trigger a task and do not await it. 
            _ = DoSomethingAsync();

            // Await the task but ignore its return.
            _ = await DoSomethingAsync();
        }

        private async Task<int> DoSomethingAsync()
        {
            await Task.Delay(1000);
            return 10;
        }

        private bool  TryGetInfo(out string name, out int age)
        {
            name = "Tom";
            age = 48;
            return true;
        }
    }
}
