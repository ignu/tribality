using System;
using System.Web.Mvc;
using Tribality.Models;
using Tribality.Repository;
using Tribality.Services;

namespace Tribality.Controllers
{
    public interface IPairRequestController
    {
        ViewResult List(int? pageNumber);
    }

    public class PairRequestController : ControllerBase, IPairRequestController
    {
        private IPairRequestRepository pairRequestRepository;
        private ILanguageRepository languageRepository;
        public const int PAGE_SIZE = 20;

        public PairRequestController(IPairRequestRepository pairRequestRepository1, ILanguageRepository languageRepository)
        {
            this.pairRequestRepository = pairRequestRepository1;
            this.languageRepository = languageRepository;
        }

        public PairRequestController(ILanguageRepository languageRepository)
        {
            this.pairRequestRepository = Container.Resolve<IPairRequestRepository>();
            this.languageRepository = languageRepository;
        }

        public ViewResult List(int? pageNumber)
        {
            int firstPage = pageNumber ?? 1;
            return View(pairRequestRepository.GetPage(firstPage, PAGE_SIZE));
        }

        public string Save(PairRequest pairRequest)
        {
            pairRequestRepository.Save(pairRequest);
            return "Pair Request Saved.";
        }

        public ViewResult Edit()
        {
            var languages = languageRepository.GetAll();
            return View(languages);
        }
    }
}