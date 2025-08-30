# ConsumoAgua

Sistema de gestión para el consumo de agua potable. Aplicación desarrollada en C# con Windows Forms para la administración de contratos, facturación, cobranza y reportes relacionados con el servicio de agua.

## Características

- **Gestión de Contratos**: Administración completa de contratos de servicio de agua
- **Facturación**: Sistema de facturación con soporte para CFDI 3.3
- **Cobranza**: Control de pagos, convenios y descuentos
- **Lecturas**: Captura y procesamiento de lecturas de medidores
- **Reportes**: Generación de reportes diversos (arqueo, corte de caja, etc.)
- **Usuarios**: Sistema de usuarios con permisos por módulo
- **Notificaciones**: Gestión de notificaciones y requerimientos

## Tecnologías

- **Lenguaje**: C# (.NET Framework)
- **Interfaz**: Windows Forms
- **Base de Datos**: SQL Server
- **Reportes**: Crystal Reports
- **Facturación**: Integración con servicios CFDI

## Estructura del Proyecto

```
ConsumoAgua/
├── Clases/           # Clases de negocio y entidades
├── DataSets/         # Conjuntos de datos para reportes
├── FrmPrincipal.cs  # Formulario principal de la aplicación
├── LogIn.cs         # Formulario de autenticación
├── Program.cs       # Punto de entrada de la aplicación
├── Properties/      # Configuraciones del proyecto
├── Reportes/        # Reportes de Crystal Reports
├── Resources/       # Recursos gráficos e iconos
└── Vistas/          # Formularios y controles de usuario
```

## Requisitos del Sistema

- Windows 7 o superior
- .NET Framework 4.0 o superior
- SQL Server 2008 o superior
- Crystal Reports Runtime

## Instalación

1. Clonar el repositorio
2. Abrir la solución en Visual Studio
3. Restaurar los paquetes NuGet
4. Configurar la cadena de conexión a la base de datos
5. Compilar y ejecutar

## Uso

La aplicación se inicia desde `Program.cs` y requiere autenticación de usuario. Una vez autenticado, se accede al formulario principal que contiene todos los módulos del sistema.

## Contribución

Para contribuir al proyecto:

1. Fork el repositorio
2. Crear una rama para tu feature (`git checkout -b feature/AmazingFeature`)
3. Commit tus cambios (`git commit -m 'Add some AmazingFeature'`)
4. Push a la rama (`git push origin feature/AmazingFeature`)
5. Abrir un Pull Request

## Licencia

Este proyecto es propiedad de la organización y está destinado para uso interno.

## Contacto

Para más información sobre el proyecto, contactar al equipo de desarrollo.
