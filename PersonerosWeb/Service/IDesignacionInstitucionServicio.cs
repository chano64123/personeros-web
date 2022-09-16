using PersonerosWeb.Models;
using RestSharp;
using Retrofit.Net.Attributes.Methods;
using Retrofit.Net.Attributes.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonerosWeb.Service {
    public interface IDesignacionInstitucionServicio {
        [Get("api/DesignacionInstitucion")]
        RestResponse<Response<List<DesignacionInstitucion>>> obtenerDesignacionesInstitucions();

        [Get("api/DesignacionInstitucion/{id}")]
        RestResponse<Response<DesignacionInstitucion>> obtenerDesignacionInstitucion([Path("id")] int id);

        [Post("api/DesignacionInstitucion")]
        RestResponse<Response<List<DesignacionInstitucion>>> crearDesignacionInstitucion([Body] List<DesignacionInstitucion> designacionesInstitucions);

        [Put("api/DesignacionInstitucion")]
        RestResponse<Response<List<DesignacionInstitucion>>> modificarDesignacionInstitucion([Body] List<DesignacionInstitucion> DesignacionInstitucion);

        [Delete("api/DesignacionInstitucion/{id}")]
        RestResponse<Response<DesignacionInstitucion>> eliminarDesignacionInstitucion([Path("id")] int id);

    }
}
