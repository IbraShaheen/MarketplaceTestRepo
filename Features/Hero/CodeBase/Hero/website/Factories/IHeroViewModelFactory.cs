using Marketplace.Feature.Hero.Models;
using Marketplace.Feature.Hero.ViewModels;

namespace Marketplace.Feature.Hero.Factories
{
    public interface IHeroViewModelFactory
    {
        HeroViewModel CreateHeroViewModel(IHeroContentType heroItemDataSource, bool isExperienceEditor);
    }
}
