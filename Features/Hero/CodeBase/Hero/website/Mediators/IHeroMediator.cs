using Marketplace.Feature.Hero.ViewModels;
using Marketplace.Foundation.Core.Models;

namespace Marketplace.Feature.Hero.Mediators
{
    public interface IHeroMediator
    {
        MediatorResponse<HeroViewModel> RequestHeroViewModel();
    }
}
