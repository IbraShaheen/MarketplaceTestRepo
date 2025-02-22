using System.Linq;
using Marketplace.Feature.Hero.Models;
using Marketplace.Foundation.Content.Repositories;
using Marketplace.Foundation.Logging.Repositories;
using Marketplace.Foundation.Search.Models;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.Data.Items;

namespace Marketplace.Feature.Hero.Services
{
    public class HeroService : IHeroService
    {
        private readonly IContextRepository _contextRepository;
        private readonly ILogRepository _logRepository;
        private readonly IRenderingRepository _renderingRepository;

        public HeroService(IContextRepository contextRepository,
            ILogRepository logRepository, IRenderingRepository renderingRepository)
        {
            _contextRepository = contextRepository;
            _logRepository = logRepository;
            _renderingRepository = renderingRepository;
        }

        /// <summary>
        ///     Get an item using the rendering repository
        /// </summary>
        /// <returns>The Hero datasource item from the Content API</returns>
        public IHeroContentType GetHeroItems()
        {
            var dataSource = _renderingRepository.GetDataSourceItem<IHeroContentType>();

            // Basic example of using the wrapped logger
            if (dataSource == null)
                _logRepository.Warn(Logging.Error.DataSourceError);

            return dataSource;
        }

        /// <summary>
        ///     **** This method is not required/in use. It is here as an example of how to use the computed search field ****
        ///     Get an item from the index
        /// </summary>
        /// <returns>The first item based on the Hero template</returns>
        public BaseSearchResultItem GetHeroImagesSearch()
        {
            // First setup your predicate
            var predicate = PredicateBuilder.True<BaseSearchResultItem>();
            predicate = predicate.And(item => item.Templates.Contains(Constants.Hero.TemplateId));
            predicate = predicate.And(item => !item.Name.Equals("__Standard Values"));

            // We could set the index manually using the line below (do not use magic strings, sample only)
            // var index = ContentSearchManager.GetIndex($"Marketplace_{_contextRepository.GetDatabaseContext()}_index");
            // OR we could automate retrieval of the context index:
            var contextIndex = _contextRepository.GetSearchIndexContext(_contextRepository.GetCurrentItem<Item>());

            using (var context = contextIndex.CreateSearchContext())
            {
                var result = context.GetQueryable<BaseSearchResultItem>().Where(predicate).First();

                return result;

                // OR we could have populated a Glass model using:
                // injectedSitecoreService.Populate(result);
            }
        }

        public bool IsExperienceEditor => _contextRepository.IsExperienceEditor;
    }
}
