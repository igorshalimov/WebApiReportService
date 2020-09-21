using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiReportService.ViewModels
{
    /*Результативная модель для отображения отчета*/
    public class ReportViewModel
    {
        public int guideidbystring { get; set; } //идентификатор справочника по строкам
        public int guideidbycolumn { get; set; }// идентификатор справочника по столбцам
        public List<bool> ListEnabledAtributesByString { get; set; }//список переключателей, определяющих включенные/выключенные атрибуты справочника по строкам
        public List<bool> ListEnabledAtributByColumn { get; set; } //список переключателей, определяющих включенные/выключенные атрибуты справочника по столбцам
        public List<ConstructionObjects> Constructions { get; set; }//Перечень всех указанных объектов для отчета
        public List<DataVersions> Versions { get; set; }// перечень всех указанных версий для отчета
        public List<Intersection> Intersections { get; set; }//перечень всех значений на основе указанных объектов и версий

    }
}
