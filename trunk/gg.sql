

CREATE  TABLE [Perfil_usuario] (
  [idPerfil_usuario] INT NOT NULL ,
  [nombre] VARCHAR(45) NOT NULL ,
  [descripcion] VARCHAR(45) NULL ,
  [token] CHAR(30) NOT NULL ,
  PRIMARY KEY ([idPerfil_usuario]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Departamento[
-- -----------------------------------------------------
CREATE  TABLE [Departamento] (
  [idDepartamento] INT NOT NULL ,
  [nombre] VARCHAR(40) NOT NULL ,
  PRIMARY KEY ([idDepartamento]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Provincia[
-- -----------------------------------------------------
CREATE  TABLE [Provincia] (
  [idProvincia] INT NOT NULL ,
  [nombre] VARCHAR(40) NOT NULL ,
  [idDepartamento] INT NOT NULL ,
  PRIMARY KEY ([idProvincia], [idDepartamento]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Distrito[
-- -----------------------------------------------------
CREATE  TABLE [Distrito] (
  [idDistrito] INT NOT NULL ,
  [idProvincia] INT NOT NULL ,
  [idDepartamento] INT NOT NULL ,
  [nombre] VARCHAR(40) NOT NULL ,
  PRIMARY KEY ([idDistrito], [idProvincia], [idDepartamento]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Usuario[
-- -----------------------------------------------------
CREATE  TABLE [Usuario] (
  [idUsuario] INT NOT NULL AUTO_INCREMENT ,
  [idPerfil_usuario] INT NOT NULL ,
  [idDistrito] INT NOT NULL ,
  [idProvincia] INT NOT NULL ,
  [idDepartamento] INT NOT NULL ,
  [nombre] VARCHAR(45) NOT NULL ,
  [apellido_paterno] VARCHAR(45) NOT NULL ,
  [apellido_materno] VARCHAR(45) NULL ,
  [estado] VARCHAR(10) NOT NULL ,
  [email] VARCHAR(45) NOT NULL ,
  [celular] VARCHAR(10) NOT NULL ,
  [tipo_documento] VARCHAR(45) NULL ,
  [numero_documento] VARCHAR(45) NOT NULL ,
  [direccion] VARCHAR(45) NOT NULL ,
  PRIMARY KEY ([idUsuario]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Permiso[
-- -----------------------------------------------------
CREATE  TABLE [Permiso] (
  [idPermiso] INT NOT NULL ,
  [idPerfil_usuario] INT NOT NULL ,
  PRIMARY KEY ([idPermiso]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Cafeteria[
-- -----------------------------------------------------
CREATE  TABLE [Cafeteria] (
  [idCafeteria] INT NOT NULL ,
  [nombre] VARCHAR(45) NOT NULL ,
  [razonsocial] VARCHAR(45) NOT NULL ,
  [ruc] VARCHAR(45) NOT NULL ,
  [direccion] VARCHAR(45) NOT NULL ,
  [telefono1] VARCHAR(45) NOT NULL ,
  [telefono2] VARCHAR(45) NULL ,
  [estado] VARCHAR(45) NOT NULL ,
  [idDistrito] INT NOT NULL ,
  [idProvincia[ INT NOT NULL ,
  [idDepartamento] INT NOT NULL ,
  PRIMARY KEY ([idCafeteria]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Empleado[
-- -----------------------------------------------------
CREATE  TABLE [Empleado] (
  [idempleado] INT NOT NULL ,
  [fecha_ingreso] DATE NOT NULL ,
  [fecha_salida] DATE NOT NULL ,
  [estado] VARCHAR(10) NOT NULL ,
  PRIMARY KEY ([idempleado]) )
  PRIMARY KEY ([idempleado]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Cliente[
-- -----------------------------------------------------
CREATE  TABLE [Cliente] (
  [idcliente] INT NOT NULL ,
  [idCafeteria] INT NOT NULL ,
  [estado] VARCHAR(10) NOT NULL ,
  [fecha_registro] DATE NOT NULL ,
  PRIMARY KEY ([idcliente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Horario[
-- -----------------------------------------------------
CREATE  TABLE [Horario] (
  [idHorario] INT NOT NULL ,
  [fechaini] DATE NOT NULL ,
  [fechafin] DATE NULL ,
  [idempleado] INT NOT NULL ,
  PRIMARY KEY ([idHorario]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[HorarioDetalle[
-- -----------------------------------------------------
CREATE  TABLE [HorarioDetalle] (
  [idHorarioDetalle] INT NOT NULL ,
  [idHorario] INT NOT NULL ,
  [diasemana] VARCHAR(45) NOT NULL ,
  [horaentrada] VARCHAR(6) NOT NULL ,
  [horasalida] VARCHAR(6) NOT NULL ,
  PRIMARY KEY ([idHorarioDetalle]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Asistencia[
-- -----------------------------------------------------
CREATE  TABLE [Asistencia] (
  [idAsistencia] INT NOT NULL ,
  [horamarcada] VARCHAR(6) NOT NULL ,
  [estado] VARCHAR(45) NOT NULL ,
  [idHorarioDetalle] INT NOT NULL ,
  PRIMARY KEY ([idAsistencia]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Proveedor[
-- -----------------------------------------------------
CREATE  TABLE [Proveedor] (
  [idProveedor] INT NOT NULL ,
  [razonSocial] VARCHAR(45) NOT NULL ,
  [estado] VARCHAR(45) NOT NULL ,
  [contaco] VARCHAR(45) NOT NULL ,
  [email_contacto] VARCHAR(45) NOT NULL ,
  [direccion] VARCHAR(45) NOT NULL ,
  [ruc] VARCHAR(45) NOT NULL ,
  [telefono1] VARCHAR(12) NOT NULL ,
  [descripcion] VARCHAR(45) NULL ,
  [telefono_contacto] VARCHAR(45) NULL ,
  [web] VARCHAR(40) NULL ,
  [observacion] VARCHAR(45) NULL ,
  [telefono2] VARCHAR(45) NULL ,
  PRIMARY KEY ([idProveedor]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Almacen[
-- -----------------------------------------------------
CREATE  TABLE [Almacen] (
  [idAlmacen] INT NOT NULL ,
  [idCafeteria] INT NOT NULL ,
  PRIMARY KEY ([idAlmacen], [idCafeteria]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Ingrediente[
-- -----------------------------------------------------
CREATE  TABLE [Ingrediente] (
  [idIngrediente] INT NOT NULL ,
  [descripcion] VARCHAR(45) NULL ,
  PRIMARY KEY ([idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Ordencompra[
-- -----------------------------------------------------
CREATE  TABLE [Ordencompra] (
  [idOrdencompra] INT NOT NULL ,
  [idProveedor] INT NOT NULL ,
  [estado] VARCHAR(10) NOT NULL ,
  [fechaemitida] DATE NOT NULL ,
  PRIMARY KEY ([idOrdencompra]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Almacen_x_Producto[
-- -----------------------------------------------------
CREATE  TABLE [Almacen_x_Producto] (
  [idAlmacen] INT NOT NULL ,
  [idIngrediente] INT NOT NULL ,
  [stockactual] INT NOT NULL ,
  [stockminimo] INT NOT NULL ,
  [stockmaximo] INT NOT NULL ,
  PRIMARY KEY ([idAlmacen], [idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Proveedor_x_Producto[
-- -----------------------------------------------------
CREATE  TABLE [Proveedor_x_Producto] (
  [idProveedor] INT NOT NULL ,
  [idIngrediente] INT NOT NULL ,
  [precio] DECIMAL(15,2) NOT NULL ,
  PRIMARY KEY ([idProveedor], [idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Notaentrada[
-- -----------------------------------------------------
CREATE  TABLE [Notaentrada] (
  [idNotaentrada] INT NOT NULL ,
  [idOrdencompra] INT NOT NULL ,
  [fechaEntrega] DATE NOT NULL ,
  PRIMARY KEY ([idNotaentrada]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[OrdenCompraDetalle[
-- -----------------------------------------------------
CREATE  TABLE [OrdenCompraDetalle] (
  [idOrdencompra] INT NOT NULL ,
  [idIngrediente] INT NOT NULL ,
  [cantidad] INT NOT NULL ,
  [precio] DECIMAL(15,2) NOT NULL ,
  PRIMARY KEY ([idOrdencompra], [idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[notaEntradaDetalle[
-- -----------------------------------------------------
CREATE  TABLE [notaEntradaDetalle] (
  [idNotaentrada] INT NOT NULL ,
  [idIngrediente] INT NOT NULL ,
  [cantidadentrante] INT NOT NULL ,
  PRIMARY KEY ([idNotaentrada], [idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Producto[
-- -----------------------------------------------------
CREATE  TABLE [Producto] (
  [idProducto] INT NOT NULL ,
  [nombre] VARCHAR(45) NOT NULL ,
  [descripcion] VARCHAR(45) NULL ,
  [tipo] VARCHAR(45) NOT NULL ,
  PRIMARY KEY ([idProducto]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Producto_x_Ingrediente[
-- -----------------------------------------------------
CREATE  TABLE [Producto_x_Ingrediente] (
  [idProducto] INT NOT NULL ,
  [idIngrediente] INT NOT NULL ,
  [cantidad] INT NOT NULL ,
  [unidaddemedida] VARCHAR(45) NOT NULL ,
  PRIMARY KEY ([idProducto], [idIngrediente]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Cafeteria_x_Producto[
-- -----------------------------------------------------
CREATE  TABLE [Cafeteria_x_Producto] (
  [idCafeteria] INT NOT NULL ,
  [idProducto] INT NOT NULL ,
  [precio] DECIMAL(15,2) NOT NULL ,
  [estado] VARCHAR(10) NULL ,
  PRIMARY KEY ([idCafeteria], [idProducto]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[Venta[
-- -----------------------------------------------------
CREATE  TABLE [Venta] (
  [idVenta] INT NOT NULL ,
  [idCafeteria] INT NOT NULL ,
  [fechaventa] VARCHAR(45) NOT NULL ,
  [estado] VARCHAR(10) NOT NULL ,
  [montototal] DECIMAL(15,2) NOT NULL ,
  PRIMARY KEY ([idVenta]) )
 


-- -----------------------------------------------------
-- Table [Basedatos1[.[VentaDetalle[
-- -----------------------------------------------------
CREATE  TABLE [VentaDetalle] (
  [idVenta] INT NOT NULL ,
  [idProducto] INT NOT NULL ,
  [cantidad] INT NOT NULL ,
  [subtotal] DECIMAL(15,2) NOT NULL ,
  PRIMARY KEY ([idVenta], [idProducto]) )
 



SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
