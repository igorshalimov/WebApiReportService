using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDataService.Data.Interfaces;
using WebApiReportService.Data.Interfaces;
using WebApiReportService.Data.Models;
using WebApiReportService.ViewModels;

namespace WebApiReportService.Data.Implementation
{
    /*класс реализации интерфейса по созданию отчета*/
    public class Report : IReport
    {
        private readonly IDataRequest _dataRequest; // экземпляр интерфейса получения данных из других сервисов
        public Report(IDataRequest dataRequest)
        {
            _dataRequest = dataRequest; // получаем все данные
        }

        /*Реализация не скрою получилась довольно сложной, все на основе старой проблемы в сервисе справочников,
         * при создании миграции и работе с метаданными, знаю что можно было сделать проще и компактнее
         причем сделать боле гибкую систему как оно собственно и полагается,
         но повторюсь я был нацелен на результат, и к тому же пытался уложиться в конкретнык сроки
        ниже описано что и для чего
         */
        public ReportViewModel GetReport(InputAtributData InputData)
        {
            List<bool> EnabledAtributsString=new List<bool>(), EnabledAtributsColumn = new List<bool>(); // Списки определения: включены ли атрибуты справочника или нет? 
                                                                                                        //для отображения в отчете, по строкам и столбцам соответственно 
            var contentData = new ReportViewModel(); //экземпляер модели для отображения данных всего отчета
            var intersections = new List<Intersection>(); // здесь храним все пересечения которые нас будут интересовать
            
            /*получаем все данные из всех сервисов*/
            var constructions = _dataRequest.getConstructions().Result; //объекты строительства 
            var versions = _dataRequest.getVersions().Result;//версии данных
            var consrtuctionObj_metadata = _dataRequest.getGuideMetaData(1).Result;//метаданные справочника объекты строительства
            var versionData_metadata = _dataRequest.getGuideMetaData(2).Result;// метаданные справочника версии данных

            /*определяем какой справочник указан в качества справочника по строкам*/
            if (InputData.GuideByStringId == 1) //если это объекты строительства, то
            {
                /*проверяем все ли атрибуты соответствуют своим справочникам, вынужденная мера(так как атрибуты у нас самостоятельные (1 - объекты строительства, 2 -версии данных, 0-универсальный))*/
                if (InputData.ListAttributesGuideString.FindAll(a => a.guideStructureId == 2).Count > 0 || InputData.AttributGuideColumn.id == 1) //если имеются несоответсвия,то возвращаем пустой отчет,
                                                                                                                                                     //а в дальнейшем указываем, что неправильные входные данные
                {
                    return null;
                }

                foreach (var a in consrtuctionObj_metadata.guideAtr) //проверяем наличие, указанных метаданных справочника объекты строительства, так как уже знаем что, он указан справочником по строкам
                {
                    if (InputData.ListAttributesGuideString.Contains(a)) EnabledAtributsString.Add(true); else EnabledAtributsString.Add(false); // определяем какие атрибуты доступны исходя из входных данных, далее мы будем определять данные атрибуты справочника по id
                                                                                                                                                    //в шаблоне при выводе информации
                }

                foreach (var v in versionData_metadata.guideAtr) //проверяем наличие, указанных метаданных справочника версии данных, так уже знаем что, он указан справочником по столбцам
                {
                    if (InputData.AttributGuideColumn.Equals(v)) EnabledAtributsColumn.Add(true); else EnabledAtributsColumn.Add(false); // определяем какой атрибут доступен исходя входных данных по столбцу, далее мы будем определять его по id
                }


                //заполнение нужной нам модели пересечений
                foreach (var cns in InputData.ListConstructions)
                {
                    foreach (var vrs in InputData.ListVersions)
                    {
                        intersections.Add
                            (
                                new Intersection
                                {
                                    Construction = cns,
                                    Version = vrs,
                                    DataIntersection = _dataRequest.getIntersections("object",cns.id).Result.Find(i=>i.Objectindex == cns.id && i.Versionindex == vrs.id).Intersection
                                }
                            );
                    }
                }
            }

            if (InputData.GuideByStringId == 2) //если это версии данных,то
            {
                if (InputData.ListAttributesGuideString.FindAll(a => a.guideStructureId == 1).Count > 0 || InputData.AttributGuideColumn.id == 2) //проверка на соответствие атрибутов справочнику, вынужденная мера
                {
                    return null;
                }


                foreach (var v in versionData_metadata.guideAtr) //проверяем наличие, указанных метаданных справочника версии данных, так уже знаем что, он указан справочником по строкам
                {
                    if (InputData.ListAttributesGuideString.Contains(v)) EnabledAtributsString.Add(true); else EnabledAtributsString.Add(false); // определяем какие атрибуты доступны исходя входных данных, далее мы будем определять данные атрибуты справочника по id
                }

                foreach (var a in consrtuctionObj_metadata.guideAtr) //проверяем наличие, указанных метаданных справочника объекты строительства, так уже знаем что, он указан справочником по столбцам
                {
                    if (InputData.AttributGuideColumn.Equals(a)) EnabledAtributsColumn.Add(true); else EnabledAtributsColumn.Add(false); //определяем какой атрибут доступен исходя входных данных по столбцу, далее мы будем определять его по id
                }

                //заполнение нужной нам модели пересечений
                foreach (var vrs in InputData.ListVersions)
                {
                    foreach (var cns in InputData.ListConstructions)
                    {
                        intersections.Add
                            (
                                new Intersection
                                {
                                    Construction = cns,
                                    Version = vrs,
                                    DataIntersection = _dataRequest.getIntersections("version", cns.id).Result.Find(i => i.Objectindex == cns.id && i.Versionindex == vrs.id).Intersection
                                }
                            );
                    }
                }
            }
            /*получаем объект для отображения  отчета и возвращаем его*/
            contentData = new ReportViewModel
            {
                guideidbystring = InputData.GuideByStringId,
                guideidbycolumn = InputData.GuideByColumnId,
                ListEnabledAtributesByString = EnabledAtributsString,
                ListEnabledAtributByColumn = EnabledAtributsColumn,
                Constructions = InputData.ListConstructions,
                Versions = InputData.ListVersions,
                Intersections = intersections
            };
            return contentData;
        }
    }
}
