using System;


namespace R5T.S0073
{
    public class RepositoryScripts : IRepositoryScripts
    {
        #region Infrastructure

        public static IRepositoryScripts Instance { get; } = new RepositoryScripts();


        private RepositoryScripts()
        {
        }

        #endregion
    }
}
