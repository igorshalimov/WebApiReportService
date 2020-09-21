using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiReportService.Data.Models
{
    /*модель входных данных для отчета*/
    public class InputAtributData
    {
        /*идентификатор справочника по строкам*/
        public int GuideByStringId { get; set; }
        /*идентификатор справочника по столбцам*/
        public int GuideByColumnId { get; set; }
        /*Список указанных атрибутов справочника по строкам для отображения в отчете*/
        public List<Atributes> ListAttributesGuideString { get; set; }
        /*Указанный атрибут справочника по столбцам*/
        public Atributes AttributGuideColumn { get; set; }
        /*перечень указанных объектов строительства*/
        public List<ConstructionObjects> ListConstructions { get; set; }
        /*перечень указанных версий данных*/
        public List<DataVersions> ListVersions { get; set; }
    }
}
