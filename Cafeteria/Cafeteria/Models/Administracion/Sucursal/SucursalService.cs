using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cafeteria.Models.Administracion.Sucursal
{
    public class SucursalService
    {
        SucursalDao sucursalDAo = new SucursalDao();

        public void registrar(SucursalBean sucu)
        {
            sucursalDAo.registrar(sucu);
        }

        public List<SucursalBean> listarsucursal()
        {
            List<SucursalBean> suc = new List<SucursalBean>();
            suc = sucursalDAo.Listarsucursal();
            return suc;
        }

        public SucursalBean buscarSucursal(string Id)
        {
            SucursalBean suc = new SucursalBean();
            suc=sucursalDAo.buscarSucursal(Id);
            return suc;
        }

        public void EliminarSucursal(string Id)
        {
            sucursalDAo.EliminarSucursal(Id);
        }

        public void ActualizarSucursal(SucursalBean suc)
        {
            sucursalDAo.ActualizarSucursal(suc);
        }

    }
}