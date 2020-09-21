using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiGuideService.Data.Models
{
    /*Собрал из всех сервисов модели для дальнейшей работы и реализации отчета, действовал по тому же методу*/
    public class Atributes //Атрибуты справочника
    {
        /*Идентификатор атрибута*/
        public int id { get; set; }
        /*Наименование атрибута*/
        public string Name { get; set; }
        /*Тип данных*/
        public string DataType { get; set; }
        /*Идентификатор справочника*/
        public int guideStructureId { get; set; } // Если guideStructureId=0, то данный атрибут универсален и присутсвует в каждом справочнике

    }
}
