using Marketplace.Feature.Hero.Models;
using Marketplace.Foundation.Search.Models;

namespace Marketplace.Feature.Hero.Services
{
    public interface IHeroService
    {
        IHeroContentType GetHeroItems();
        BaseSearchResultItem GetHeroImagesSearch();
        bool IsExperienceEditor { get; }
    }
}
