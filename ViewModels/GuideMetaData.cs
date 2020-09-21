using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuideService.Data.Models;

namespace WebApiGuideService.ViewModels
{
    /*модель взятая из сервиса справочников для получения метаданных конкретного справочника*/
    public class GuideMetaData
    {
        public GuideStructure guide { get; set; }//структура справочника
        public List<Atributes> guideAtr { get; set; }//его атрибуты
    }
}
