using Glass.Mapper.Sc.Pipelines.AddMaps;
using Marketplace.Foundation.ORM.Extensions;

namespace Marketplace.Feature.Hero.ORM
{
    public class RegisterMappings : AddMapsPipeline  {
        public void Process(AddMapsPipelineArgs args)
        {
            args.MapsConfigFactory.AddFluentMaps("Marketplace.Feature.Hero");
        }
    }
}
