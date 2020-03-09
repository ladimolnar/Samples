using System;
using System.Threading.Tasks;

namespace NewInCSharp6.AwaitInCatchAndFinally
{
    public class AwaitInCatchAndFinallyDemo
    {
        public async Task Demo()
        {
            try
            {
                await DoWork();
            }
            catch (Exception)
            {
                await Recover();
                throw;
            }
            finally
            {
                await Close();
            }
        }

        private async Task Close()
        {
            throw new NotImplementedException();
        }

        private async Task Recover()
        {
            throw new NotImplementedException();
        }

        private async Task DoWork()
        {
            throw new NotImplementedException();
        }
    }
}
