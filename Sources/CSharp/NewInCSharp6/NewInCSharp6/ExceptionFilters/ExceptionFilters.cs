using System;
using System.Web;

namespace NewInCSharp6.ExceptionFilters
{
    public class ExceptionFiltersDemo
    {
        public void Demo()
        {
            try
            {
                DoSomething();
            }
            catch (HttpException hex) when (hex.GetHttpCode() == 303)
            {
                throw;
            }
            catch (Exception ex) when (ex is InvalidOperationException || ex is InvalidCastException)
            {
                throw;
            }
            catch (Exception ex)
            {
                Foo();
                throw;
            }
        }

        private void Foo()
        {
            throw new NotImplementedException();
        }

        private void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
