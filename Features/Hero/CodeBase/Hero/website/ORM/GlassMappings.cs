using Glass.Mapper.Sc.Maps;
using Marketplace.Feature.Hero.Models;

namespace Marketplace.Feature.Hero.ORM
{
    public class GlassMappings : SitecoreGlassMap<IHero>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
                config.TemplateId(Constants.Hero.TemplateId);
                config.Field(f => f.HeroTitle).FieldName("Hero Title");
                config.Field(f => f.HeroImages).FieldName("Hero Images");
            });
        }
    }

    public class ContentTypeGlassMappings : SitecoreGlassMap<IHeroContentType>
    {
        public override void Configure()
        {
            Map(config =>
            {
                ImportMap<IHero>();
                config.AutoMap();
                config.TemplateId(Constants.HeroContentType.TemplateId);
            });
        }
    }


    public class GlassBaseMappings : SitecoreGlassMap<IHeroGlassBase>
    {
        public override void Configure()
        {
            Map(config =>
            {
                config.AutoMap();
            });
        }
    }
}
