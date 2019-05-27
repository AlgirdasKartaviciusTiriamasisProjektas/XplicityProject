namespace TFSApi.BranchStates
{
    public class BranchStateFactory
    {
        public IBranchState Create(string name)
        {
            switch (name)
            {
                case "master":
                    return new MasterBranch();

                case "stable":
                    return new StableBranch();

                default:
                    return new FeatureBranch(name);
            }
        }
    }
}