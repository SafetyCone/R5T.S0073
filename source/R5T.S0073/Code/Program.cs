using System;
using System.Threading.Tasks;


namespace R5T.S0073
{
    class Program
    {
        static async Task Main()
        {
            //await RepositoryScripts.Instance.Create_Repository();
            //await RepositoryScripts.Instance.Delete_Repository();
            //await RepositoryScripts.Instance.In_New_SampleRepositoryContext();
            await RepositoryScripts.Instance.In_New_RepositoryContext();
        }
    }
}