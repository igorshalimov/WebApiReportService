using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Models;
using WebApiGuideService.Data.Models;
using WebApiGuideService.ViewModels;

namespace WebApiDataService.Data.Interfaces
{
    /*интерфейс для получения данных из других сервисов, реализован также как в сервисе данных*/
    public interface IDataRequest
    {
        public Task<List<ConstructionObjects>> getConstructions(); // получаем все объекты строительства из сервиса справочников
        public Task<List<DataVersions>> getVersions(); //получаем все версии данных из сервиса справочников

        public Task<List<DataIntersection>> getIntersections(string key, int value); ////получаем все значения из сервиса данных по данным справочников

        public Task<GuideMetaData> getGuideMetaData(int id); //получаем метаданные конкретного справочника из сервиса справочников

    }
}
