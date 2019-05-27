using Contracts.Models;
using Microsoft.TeamFoundation.Build.WebApi;

namespace Contracts
{
    public interface IBuildsClient
    {
        BuildDefinition CreateBuildDefinition(string project, NewBuild newBuild);
    }
}