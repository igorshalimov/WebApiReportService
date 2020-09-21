using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiReportService.ViewModels
{
    /*модель для получения интересующих нас пересечений*/
    public class Intersection
    {
        public ConstructionObjects Construction { get; set; } //объект
        public DataVersions Version { get; set; }//версия
        public int DataIntersection { get; set; }//значение
    }
}
