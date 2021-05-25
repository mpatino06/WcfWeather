using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Wcf.DTOs;

namespace Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IWCFWeatherCity" in both code and config file together.
    [ServiceContract]
    public interface IWCFWeatherCity
    {
        [OperationContract]
        List<CityWeatherDTO> Get();

        [OperationContract]
        CityWeatherDTO GetWeatherCityById(int Id);

        [OperationContract]
        List<CityWeatherDTO> GetWeatherCityByIdCity(int Id);

        [OperationContract]
        bool InsertWeatherCity(CityWeatherDTO city);

        [OperationContract]
        bool UpdateWeatherCity(CityWeatherDTO city);

        [OperationContract]
        bool DeleteWeatherCity(int Id);
    }
}
